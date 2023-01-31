using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MvM_Upgrade_Vscript_Converter
{
    public partial class Main : Form
    {
	public Main()
	{
	    InitializeComponent();
	}

	private string gamePath;
	private string bspzipPath;
	private string vscriptPath;
	private string upgradesPath;

	private string mapSuffix;
	private bool mirror;
	private List<string> dataStations = new List<string>();
	private List<string> dataSigns = new List<string>();

	private BspReader reader;
	private BspLumpDataWriter writer;

	private string formatStation = "{0, -22}{1}";
	private string formatSign = "{0, -22}{1, -10}{2}";
	private string formatPosition = "{0, -7}{1, -7}{2}";

	private string urlVscript = "https://raw.githubusercontent.com/Lazyneer/MvM-Upgrades-Vscript/master/scripts/vscripts/mapspawn.nut";
	private string urlUpgrades = "https://raw.githubusercontent.com/Lazyneer/MvM-Upgrades-Vscript/master/scripts/items/mvm_upgrades.txt";

	private void Main_Load(object sender, EventArgs e)
	{
	    ListStations.Items.Add(string.Format(formatStation, "Position", "Angle"));
	    ListSigns.Items.Add(string.Format(formatSign, "Position", "Angle", "Height"));

	    string filePath = Directory.GetCurrentDirectory() + "\\game.txt";
	    if(File.Exists(filePath))
	    {
		gamePath = File.ReadAllText(filePath);
		InputGame.Text = gamePath;

		bspzipPath = gamePath + "\\bin\\bspzip.exe";
		FileDialogMap.InitialDirectory = gamePath + "\\tf\\maps";
	    }
	}

	private void BtnMap_Click(object sender, EventArgs e)
	{
	    if(FileDialogMap.ShowDialog() == DialogResult.OK)
	    {
		ClearUpgradeStations();
		if(FileDialogMap.FileNames.Length == 1)
		{
		    InputMap.Text = FileDialogMap.FileName;
		    WriteToLog("Map selected: " + GetMapName(FileDialogMap.FileName));
		    LoadMapUpgradeStations(GetMapName(FileDialogMap.FileName), false);
		    ToggleConfiguration(true);
		}
		else
		{
		    string log = "";
		    string maps = "";
		    List<string> noConfig = new List<string>();
		    for(int i = 0; i < FileDialogMap.FileNames.Length; i++)
		    {
			string map = GetMapName(FileDialogMap.FileNames[i]);
			log += map;
			if(i > 0)
			    maps += map + ".bsp";
			if(i < FileDialogMap.FileNames.Length - 1)
			{
			    log += ", ";
			    maps += ", ";
			}

			if(GetConfigFile(map) is null)
			    noConfig.Add(map);
		    }

		    InputMap.Text = FileDialogMap.FileName + maps;
		    WriteToLog("Maps selected: " + log);
		    ToggleConfiguration(false);

		    if(noConfig.Count > 0)
		    {
			string map = "";
			for(int i = 0; i < noConfig.Count; i++)
			{
			    map += noConfig[i];
			    if(i < noConfig.Count - 2)
				map += ", ";
			    else if(i < noConfig.Count - 1)
				map += " and ";
			}

			WriteToLog("Multiple maps have been selected, but " + map + " do not have any upgrade stations set up.");
			WriteToLog("Converting multiple maps at the same time is intended for maps that have already been configured and converted.");
			WriteToLog("Please select and convert the map individually to configure the upgrade stations.");
		    }
		}
	    }
	}

	private void BtnGame_Click(object sender, EventArgs e)
	{
	    if(FolderDialogGame.ShowDialog() == DialogResult.OK)
	    {
		gamePath = FolderDialogGame.SelectedPath;
		InputGame.Text = gamePath;

		string bspzip = gamePath + "\\bin\\bspzip.exe";
		if(File.Exists(bspzip))
		{
		    bspzipPath = bspzip;
		    FileDialogMap.InitialDirectory = gamePath + "\\tf\\maps";

		    string filePath = Directory.GetCurrentDirectory() + "\\game.txt";
		    if(File.Exists(filePath))
			File.Delete(filePath);

		    File.WriteAllText(filePath, gamePath);
		}
		else
		    WriteToLog("bspzip.exe not found in " + bspzip);
	    }
	}

	private void BtnVscript_Click(object sender, EventArgs e)
	{
	    if(FileDialogVscript.ShowDialog() == DialogResult.OK)
	    {
		vscriptPath = FileDialogVscript.FileName;
		InputVscriptPath.Text = vscriptPath;
		InputVscriptPull.Checked = false;
	    }
	}

	private void BtnUpgrades_Click(object sender, EventArgs e)
	{
	    if(FileDialogUpgrades.ShowDialog() == DialogResult.OK)
	    {
		upgradesPath = FileDialogUpgrades.FileName;
		InputUpgradesPath.Text = upgradesPath;
		InputUpgradesPull.Checked = false;
	    }
	}

	private void BtnConvert_Click(object sender, EventArgs e)
	{
	    string mapPath = InputMap.Text;
	    vscriptPath = InputVscriptPath.Text;
	    upgradesPath = InputUpgradesPath.Text;
	    mapSuffix = InputSuffix.Text.Replace(' ', '_');

	    if(string.IsNullOrWhiteSpace(mapPath))
	    {
		WriteToLog("No map selected");
		return;
	    }
	    if(string.IsNullOrWhiteSpace(mapSuffix))
	    {
		WriteToLog("Map suffix is empty");
		return;
	    }
	    if(string.IsNullOrWhiteSpace(vscriptPath))
	    {
		if(!InputVscriptPull.Checked)
		{
		    WriteToLog("No vscript selected");
		    return;
		}
	    }
	    if(InputCompress.Checked)
	    {
		if(string.IsNullOrWhiteSpace(bspzipPath))
		{
		    WriteToLog("Output map will be compressed, but the game path is not set");
		    return;
		}
	    }

	    string[] maps = mapPath.Split(", ");
	    string[] split = Regex.Split(maps[0], @"(?<=[\\])");

	    string path = "";
	    for(int i = 0; i < split.Length - 1; i++)
		path += split[i];

	    maps[0] = split[split.Length - 1];
	    List<string> mapPaths = new List<string>();
	    foreach(string map in maps)
		mapPaths.Add(path + map);

	    ToggleControls(false);
	    Thread thread = new Thread(() => ConvertMap(mapPaths));
	    thread.Start();
	}

	private string GetMapName(string file)
	{
	    if(string.IsNullOrEmpty(file))
		return "";

	    string[] split = file.Split('\\');
	    return split[split.Length - 1].Replace(".bsp", "");
	}

	private void WriteToLog(string message)
	{
	    if(!LogBox.InvokeRequired)
	    {
		if(string.IsNullOrWhiteSpace(message))
		    return;

		if(!string.IsNullOrWhiteSpace(LogBox.Text))
		    LogBox.AppendText(Environment.NewLine);

		LogBox.AppendText(message);
	    }
	    else
		Invoke(new Action<string>(WriteToLog), message);
	}

	private void ConvertMap(List<string> mapPaths)
	{
	    List<string> erroredMaps = new List<string>();
	    for(int i = 0; i < mapPaths.Count; i++)
	    {
		string mapPath = mapPaths[i];
		if(mapPaths.Count > 1)
		    WriteToLog("Converting " + GetMapName(mapPath));

		try
		{
		    string map = GetMapName(mapPath);
		    string newMap = map + "_" + mapSuffix;
		    string tempMap = Path.GetTempPath() + map + ".bsp";
		    File.Copy(mapPath, tempMap, true);

		    reader = new BspReader(mapPath);
		    BspInfo info = reader.ReadInfo();
		    if(info.Compressed)
		    {
			reader.Dispose();
			if(string.IsNullOrWhiteSpace(bspzipPath))
			{
			    WriteToLog("Map is compressed, please set the game path");
			    return;
			}

			WriteToLog("Map is compressed, decompressing");
			DecompressMap(tempMap);
		    }

		    if(mapPaths.Count == 1)
		    {
			dataStations.Clear();
			dataSigns.Clear();

			mirror = InputMirror.Checked;
			if(ListStations.Items.Count > 1)
			    for(int j = 1; j < ListStations.Items.Count; j++)
				dataStations.Add((string)ListStations.Items[j]);

			if(ListSigns.Items.Count > 1)
			    for(int j = 1; j < ListSigns.Items.Count; j++)
				dataSigns.Add((string)ListSigns.Items[j]);

			SaveMapUpgradeStations(map);
		    }
		    else
			LoadConfigFile(map);

		    WriteToLog("Extracting content");
		    reader = new BspReader(tempMap);

		    string path = Path.GetTempPath() + newMap;
		    if(Directory.Exists(path))
			Directory.Delete(path, true);

		    byte[] bytes = reader.ReadLumpData(BspLumpType.LUMP_PAKFILE);
		    reader.Dispose();

		    File.WriteAllBytes(path + ".zip", bytes);
		    //Throws System.ArgumentOutOfRangeException because the time is missing from the files
		    //Only slows down program during debugging
		    ZipFile.ExtractToDirectory(path + ".zip", path);

		    RenameContent(path, map, newMap);
		    AppendScripts(path);
		    EditScript(path);

		    WriteToLog("Compressing content");
		    if(File.Exists(path + ".zip"))
			File.Delete(path + ".zip");

		    ZipFile.CreateFromDirectory(path, path + ".zip", CompressionLevel.NoCompression, false);
		    bytes = File.ReadAllBytes(path + ".zip");

		    WriteToLog("Writing BSP");
		    writer = new BspLumpDataWriter(tempMap, path + ".bsp");
		    writer.WriteLumpData(BspLumpType.LUMP_PAKFILE, bytes);
		    writer.Dispose();

		    WriteToLog("Finished writing BSP");

		    if(InputCompress.Checked)
		    {
			WriteToLog("Compressing map");
			CompressMap(path + ".bsp");
		    }

		    CleanUpTempFiles(mapPath, map, newMap);

		    WriteToLog(Environment.NewLine + "All Done!");
		}
		catch(Exception exception)
		{
		    reader?.Dispose();
		    writer?.Dispose();
		    erroredMaps.Add(GetMapName(mapPath));
		    WriteToLog("Error: " + exception.Message);
		    MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	    }

	    for(int i = 0; i < erroredMaps.Count; i++)
		WriteToLog("Failed to convert " + erroredMaps[i]);

	    ToggleControls(true);
	}

	private void DecompressMap(string map)
	{
	    var process = new Process();
	    var startInfo = new ProcessStartInfo();

	    WriteToLog(bspzipPath);

	    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
	    startInfo.FileName = bspzipPath;
	    startInfo.Arguments = "-repack " + map;
	    startInfo.RedirectStandardOutput = true;

	    process.StartInfo = startInfo;
	    process.Start();

	    WriteToLog(process.StandardOutput.ReadToEnd());
	}

	private void CompressMap(string map)
	{
	    var process = new Process();
	    var startInfo = new ProcessStartInfo();

	    WriteToLog(bspzipPath);

	    startInfo.WindowStyle = ProcessWindowStyle.Hidden;
	    startInfo.FileName = bspzipPath;
	    startInfo.Arguments = "-repack -compress " + map;
	    startInfo.RedirectStandardOutput = true;

	    process.StartInfo = startInfo;
	    process.Start();

	    WriteToLog(process.StandardOutput.ReadToEnd());
	}

	private void RenameContent(string path, string oldMap, string newMap)
	{
	    RenameFiles(path, oldMap, newMap, Directory.GetFiles(path, "*" + oldMap + "*", SearchOption.AllDirectories));
	    FixCubemaps(path, oldMap, newMap);
	}

	private void RenameFiles(string path, string oldMap, string newMap, string[] files)
	{
	    foreach(string file in files)
	    {
		string newFile = RenameItem(path, oldMap, newMap, file);
		File.Move(file, newFile, true);
	    }
	}

	private string RenameItem(string path, string oldMap, string newMap, string item)
	{
	    string[] split = Regex.Split(item, @"(?<=[\\])");
	    split[split.Length - 1] = split[split.Length - 1].Replace(oldMap, newMap);
	    string newFile = "";
	    foreach(string s in split)
		newFile += s;

	    WriteToLog(string.Format("Renaming {0} to {1}", item.Replace(path + "\\", ""), newFile.Replace(path + "\\", "")));
	    return newFile;
	}

	private void FixCubemaps(string path, string oldMap, string newMap)
	{
	    path += "\\materials\\maps\\";
	    Directory.CreateDirectory(path + newMap);
	    string[] files = Directory.GetFiles(path + oldMap, "c*.vtf");
	    foreach(string file in files)
	    {
		string[] split = Regex.Split(file, @"(?<=[\\])");
		split[split.Length - 2] = split[split.Length - 2].Replace(oldMap, newMap);
		string newFile = "";
		foreach(string s in split)
		    newFile += s;

		WriteToLog(string.Format("Moving {0} to {1}", file.Replace(path + "\\", ""), file.Replace(path + "\\", "")));
		File.Move(file, newFile, true);
	    }
	}

	private void AppendScripts(string path)
	{
	    WriteToLog("Creating scripts");

	    path += "\\scripts\\";
	    Directory.CreateDirectory(path + "vscripts");
	    Directory.CreateDirectory(path + "items");
	    if(string.IsNullOrWhiteSpace(vscriptPath))
		GetGitHubFile(urlVscript, path + "vscripts\\mapspawn.nut");
	    else
		File.Copy(vscriptPath, path + "vscripts\\mapspawn.nut");

	    if(string.IsNullOrWhiteSpace(upgradesPath))
		if(InputUpgradesPull.Checked)
		    GetGitHubFile(urlUpgrades, path + "items\\mvm_upgrades.txt");
	    else
		File.Copy(upgradesPath, path + "items\\mvm_upgrades.txt");
	}

	private void EditScript(string path)
	{
	    path += "\\scripts\\vscripts\\mapspawn.nut";
	    bool found = false;
	    var lines = File.ReadLines(path);
	    var listLines = new List<string>();
	    foreach(string line in lines)
	    {
		if(line.Contains("//Use this function to spawn an upgrade station"))
		{
		    found = true;
		    listLines.Add(line);
		    for(int i = 0; i < dataStations.Count; i++)
		    {
			string station = dataStations[i];
			string[] split = station.Split(' ', StringSplitOptions.RemoveEmptyEntries);

			int posX = int.Parse(split[0]);
			int posY = int.Parse(split[1]);
			int posZ = int.Parse(split[2]);
			int ang = int.Parse(split[3]);

			listLines.Add(string.Format("    SpawnUpgradeStation({0}, {1}, {2}, {3})", posX, posY, posZ, ang));

			if(mirror)
			{
			    posX *= -1;
			    posY *= -1;
			    ang += 180;
			    if(ang >= 360)
				ang -= 360;

			    listLines.Add(string.Format("    SpawnUpgradeStation({0}, {1}, {2}, {3})", posX, posY, posZ, ang));
			}
		    }

		    for(int i = 0; i < dataSigns.Count; i++)
		    {
			string station = dataSigns[i];
			string[] split = station.Split(' ', StringSplitOptions.RemoveEmptyEntries);

			int posX = int.Parse(split[0]);
			int posY = int.Parse(split[1]);
			int posZ = int.Parse(split[2]);
			int ang = int.Parse(split[3]);
			int height = int.Parse(split[4]);

			listLines.Add(string.Format("    SpawnUpgradeSign({0}, {1}, {2}, {3}, {4})", posX, posY, posZ, ang, height));

			if(mirror)
			{
			    posX *= -1;
			    posY *= -1;
			    ang += 180;
			    if(ang >= 360)
				ang -= 360;

			    listLines.Add(string.Format("    SpawnUpgradeSign({0}, {1}, {2}, {3}, {4})", posX, posY, posZ, ang, height));
			}
		    }

		    continue;
		}
		else if((line.Contains("SpawnUpgradeStation") || line.Contains("SpawnUpgradeSign")) && !line.Contains("function"))
		    continue;

		listLines.Add(line);
	    }

	    if(!found)
		WriteToLog("Line to place functions at not found, no upgrade stations have been added");

	    File.WriteAllLines(path, listLines.ToArray());
	}

	private void CleanUpTempFiles(string mapPath, string oldMap, string newMap)
	{
	    WriteToLog("Cleaning up temporary files");

	    string path = Path.GetTempPath();
	    Directory.Delete(path + newMap, true);
	    File.Delete(path + oldMap + ".bsp");
	    File.Delete(path + newMap + ".zip");


	    string[] split = Regex.Split(mapPath, @"(?<=[\\])");
	    split[split.Length - 1] = split[split.Length - 1].Replace(oldMap, newMap);
	    string newFile = "";
	    foreach(string s in split)
		newFile += s;

	    WriteToLog("Moving map to " + newFile);
	    File.Move(path + newMap + ".bsp", newFile, true);
	}

	private void ClearUpgradeStations()
	{
	    InputMirror.Checked = false;

	    while(ListStations.Items.Count > 1)
		ListStations.Items.RemoveAt(1);

	    while(ListSigns.Items.Count > 1)
		ListSigns.Items.RemoveAt(1);
	}

	private void BtnAddStation_Click(object sender, EventArgs e)
	{
	    var form = new AddStation();
	    if(form.ShowDialog() == DialogResult.OK)
		AddStationEntry(form.PosX, form.PosY, form.PosZ, form.Ang);
	}

	private void BtnAddSign_Click(object sender, EventArgs e)
	{
	    var form = new AddSign();
	    if(form.ShowDialog() == DialogResult.OK)
		AddSignEntry(form.PosX, form.PosY, form.PosZ, form.Ang, form.Height);
	}

	private void AddStationEntry(int x, int y, int z, int ang, int index = 0)
	{
	    if(ang < 0)
		ang += 360;

	    if(ang % 90 > 0)
	    {
		int mul = (int)Math.Round((decimal)(ang / 90.0));
		ang = Math.Clamp(ang, mul * 90, mul * 90);
		WriteToLog("Angle for upgrade station is not a right angle, clamped to " + ang);
	    }

	    if(index > 0)
		ListStations.Items[index] = string.Format(formatStation, string.Format(formatPosition, x, y, z), ang);
	    else
		ListStations.Items.Add(string.Format(formatStation, string.Format(formatPosition, x, y, z), ang));
	}

	private void AddSignEntry(int x, int y, int z, int ang, int height, int index = 0)
	{
	    if(ang < 0)
		ang += 360;

	    if(index > 0)
		ListSigns.Items[index] = string.Format(formatSign, string.Format(formatPosition, x, y, z), ang, height);
	    else
		ListSigns.Items.Add(string.Format(formatSign, string.Format(formatPosition, x, y, z), ang, height));
	}

	private void BtnEditStation_Click(object sender, EventArgs e)
	{
	    if(ListStations.SelectedIndex <= 0)
		return;

	    string station = (string)ListStations.Items[ListStations.SelectedIndex];
	    string[] split = station.Split(' ', StringSplitOptions.RemoveEmptyEntries);

	    int posX = int.Parse(split[0]);
	    int posY = int.Parse(split[1]);
	    int posZ = int.Parse(split[2]);
	    int ang = int.Parse(split[3]);

	    var form = new AddStation(posX, posY, posZ, ang);
	    if(form.ShowDialog() == DialogResult.OK)
		AddStationEntry(form.PosX, form.PosY, form.PosZ, form.Ang, ListStations.SelectedIndex);
	}

	private void BtnEditSign_Click(object sender, EventArgs e)
	{
	    if(ListSigns.SelectedIndex <= 0)
		return;

	    string station = (string)ListSigns.Items[ListSigns.SelectedIndex];
	    string[] split = station.Split(' ', StringSplitOptions.RemoveEmptyEntries);

	    int posX = int.Parse(split[0]);
	    int posY = int.Parse(split[1]);
	    int posZ = int.Parse(split[2]);
	    int ang = int.Parse(split[3]);
	    int height = int.Parse(split[4]);

	    var form = new AddSign(posX, posY, posZ, ang, height);
	    if(form.ShowDialog() == DialogResult.OK)
		AddSignEntry(form.PosX, form.PosY, form.PosZ, form.Ang, form.Height);
	}

	private void BtnRemoveStation_Click(object sender, EventArgs e)
	{
	    if(ListStations.SelectedIndex <= 0)
		return;

	    ListStations.Items.RemoveAt(ListStations.SelectedIndex);
	}

	private void BtnRemoveSign_Click(object sender, EventArgs e)
	{
	    if(ListSigns.SelectedIndex <= 0)
		return;

	    ListSigns.Items.RemoveAt(ListSigns.SelectedIndex);
	}

	private void GetGitHubFile(string url, string outputFilename)
	{
	    using WebClient client = new WebClient();

	    using Stream data = client.OpenRead(url);
	    using StreamReader reader = new StreamReader(data);
	    File.WriteAllText(outputFilename, reader.ReadToEnd());
	}

	private void SaveMapUpgradeStations(string map)
	{
	    if(!InputSave.Checked)
		return;

	    WriteToLog("Saving upgrade stations for future use");

	    var lines = new List<string>();
	    if(InputMirror.Checked)
		lines.Add("mirrored");

	    if(ListStations.Items.Count > 1)
		for(int i = 1; i < ListStations.Items.Count; i++)
		    lines.Add((string)ListStations.Items[i]);

	    if(ListSigns.Items.Count > 1)
		for(int i = 1; i < ListSigns.Items.Count; i++)
		    lines.Add((string)ListSigns.Items[i]);

	    if(lines.Count == 0)
		return;

	    Directory.CreateDirectory(Directory.GetCurrentDirectory() + "\\maps");

	    string path = string.Format("{0}\\maps\\{1}.txt", Directory.GetCurrentDirectory(), map);
	    if(File.Exists(path))
		File.Delete(path);

	    File.WriteAllLines(path, lines.ToArray());
	}

	private void LoadMapUpgradeStations(string map, bool printLog = true)
	{
	    string path = GetConfigFile(map);
	    if(path is null)
		return;

	    if(printLog)
		WriteToLog("Found upgrade stations for " + map);

	    foreach(string line in File.ReadLines(path))
	    {
		if(line.Contains("mirrored"))
		    InputMirror.Checked = true;
		else
		{
		    int[] data = new int[5];
		    string[] split = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
		    if(split.Length == 4)
		    {
			for(int i = 0; i < 4; i++)
			    int.TryParse(split[i], out data[i]);
			AddStationEntry(data[0], data[1], data[2], data[3]);
		    }
		    else if(split.Length > 4)
		    {
			for(int i = 0; i < 4; i++)
			    int.TryParse(split[i], out data[i]);
			AddSignEntry(data[0], data[1], data[2], data[3], data[4]);
		    }
		}
	    }
	}

	private void LoadConfigFile(string map)
	{
	    mirror = false;
	    dataStations.Clear();
	    dataSigns.Clear();

	    string path = GetConfigFile(map);
	    if(path is null)
		return;

	    foreach(string line in File.ReadLines(path))
	    {
		if(line.Contains("mirrored"))
		    mirror = true;
		else
		{
		    string[] split = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
		    if(split.Length == 4)
			dataStations.Add(line);
		    else if(split.Length > 4)
			dataSigns.Add(line);
		}
	    }
	}

	private string GetConfigFile(string map)
	{
	    string path = string.Format("{0}\\maps\\{1}.txt", Directory.GetCurrentDirectory(), map);
	    if(File.Exists(path))
		return path;
	    else
		return null;
	}

	private void ToggleControls(bool enabled)
	{
	    if(!InputGame.InvokeRequired)
	    {
		InputGame.Enabled = enabled;
		InputMap.Enabled = enabled;
		InputSuffix.Enabled = enabled;
		InputVscriptPull.Enabled = enabled;
		InputVscriptPath.Enabled = enabled;
		InputUpgradesPull.Enabled = enabled;
		InputUpgradesPath.Enabled = enabled;
		InputMirror.Enabled = enabled;
		InputSave.Enabled = enabled;
		InputCompress.Enabled = enabled;

		BtnGame.Enabled = enabled;
		BtnMap.Enabled = enabled;
		BtnVscript.Enabled = enabled;
		BtnUpgrades.Enabled = enabled;
		BtnAddStation.Enabled = enabled;
		BtnEditStation.Enabled = enabled;
		BtnRemoveStation.Enabled = enabled;
		BtnAddSign.Enabled = enabled;
		BtnEditSign.Enabled = enabled;
		BtnRemoveSign.Enabled = enabled;
		BtnConvert.Enabled = enabled;
	    }
	    else
		Invoke(new Action<bool>(ToggleControls), enabled);
	}

	private void ToggleConfiguration(bool enabled)
	{
	    if(!InputMirror.InvokeRequired)
	    {
		InputMirror.Enabled = enabled;
		InputSave.Enabled = enabled;

		BtnAddStation.Enabled = enabled;
		BtnEditStation.Enabled = enabled;
		BtnRemoveStation.Enabled = enabled;
		BtnAddSign.Enabled = enabled;
		BtnEditSign.Enabled = enabled;
		BtnRemoveSign.Enabled = enabled;
	    }
	    else
		Invoke(new Action<bool>(ToggleConfiguration), enabled);
	}
    }
}

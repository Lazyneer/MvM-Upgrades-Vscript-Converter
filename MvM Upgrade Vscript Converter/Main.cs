using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
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
	private string mapPath;
	private string bspzipPath;
	private string vscriptPath;
	private string upgradesPath;

	private string mapSuffix;
	private bool mirror;

	private BspReader reader;
	private BspLumpDataWriter writer;

	private string formatStation = "{0, -22}{1}";
	private string formatSign = "{0, -22}{1, -10}{2}";
	private string formatPosition = "{0, -7}{1, -7}{2}";

	private string urlVscript = "https://raw.githubusercontent.com/Lazyneer/MvM-Upgrades-Vscript/master/scripts/vscripts/mapspawn.nut";
	private string urlUpgrades = "https://raw.githubusercontent.com/Lazyneer/MvM-Upgrades-Vscript/master/scripts/items/mvm_upgrades.txt";

	private void Form1_Load(object sender, EventArgs e)
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
		mapPath = FileDialogMap.FileName;
		InputMap.Text = mapPath;

		string map = GetMapName();
		WriteToLog("Map selected: " + map);

		ClearUpgradeStations();
		LoadMapUpgradeStations(map);
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
	    mapPath = InputMap.Text;
	    vscriptPath = InputVscriptPath.Text;
	    upgradesPath = InputUpgradesPath.Text;
	    mapSuffix = InputSuffix.Text.Replace(' ', '_');
	    mirror = InputMirror.Checked;

	    if(string.IsNullOrWhiteSpace(mapPath))
	    {
		WriteToLog("No map selected");
		return;
	    }
	    else if(string.IsNullOrWhiteSpace(mapSuffix))
	    {
		WriteToLog("Map suffix is empty");
		return;
	    }
	    else if(string.IsNullOrWhiteSpace(vscriptPath))
	    {
		if(!InputVscriptPull.Checked)
		{
		    WriteToLog("No vscript selected");
		    return;
		}
	    }
	    else if(string.IsNullOrWhiteSpace(upgradesPath))
	    {
		if(!InputUpgradesPull.Checked)
		{
		    WriteToLog("No upgrade file selected");
		    return;
		}
	    }

	    Thread thread = new Thread(ConvertMap);
	    thread.Start();
	}

	private string GetMapName()
	{
	    if(string.IsNullOrEmpty(mapPath))
		return "";

	    string[] split = mapPath.Split('\\');
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

	private void ConvertMap()
	{
	    try
	    {
		ToggleControls(false);

		string map = GetMapName();
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

		SaveMapUpgradeStations(map);

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

		CleanUpTempFiles(Path.GetTempPath(), map, newMap);

		WriteToLog(Environment.NewLine + "All Done!");
		ToggleControls(true);
	    }
	    catch(Exception exception)
	    {
		MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

		reader?.Dispose();
		writer?.Dispose();
		ToggleControls(true);
	    }
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
		    if(ListStations.Items.Count > 1)
		    {
			for(int i = 1; i < ListStations.Items.Count; i++)
			{
			    string station = (string)ListStations.Items[i];
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
		    }

		    if(ListSigns.Items.Count > 1)
		    {
			for(int i = 1; i < ListSigns.Items.Count; i++)
			{
			    string station = (string)ListSigns.Items[i];
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

	private void CleanUpTempFiles(string path, string oldMap, string newMap)
	{
	    WriteToLog("Cleaning up temporary files");
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

	private void BtnAddStation_Click(object sender, EventArgs e)
	{
	    var form = new AddStation();
	    if(form.ShowDialog() == DialogResult.OK)
	    {
		int ang = form.Ang;
		if(ang % 90 > 0)
		{
		    int mul = (int)Math.Round((decimal)(ang / 90.0));
		    ang = Math.Clamp(ang, mul * 90, mul * 90);
		    WriteToLog("Angle for upgrade station is not a right angle, clamped to " + ang);
		}

		AddStationEntry(form.PosX, form.PosY, form.PosZ, form.Ang);
	    }
	}

	private void BtnAddSign_Click(object sender, EventArgs e)
	{
	    var form = new AddSign();
	    if(form.ShowDialog() == DialogResult.OK)
		AddSignEntry(form.PosX, form.PosY, form.PosZ, form.Ang, form.Height);
	}

	private void AddStationEntry(int x, int y, int z, int ang)
	{
	    ListStations.Items.Add(string.Format(formatStation, string.Format(formatPosition, x, y, z), ang));
	}

	private void AddSignEntry(int x, int y, int z, int ang, int height)
	{
	    ListSigns.Items.Add(string.Format(formatSign, string.Format(formatPosition, x, y, z), ang, height));
	}

	private void ClearUpgradeStations()
	{
	    while(ListStations.Items.Count > 1)
		ListStations.Items.RemoveAt(1);

	    while(ListSigns.Items.Count > 1)
		ListSigns.Items.RemoveAt(1);
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

	private void LoadMapUpgradeStations(string map)
	{
	    string path = string.Format("{0}\\maps\\{1}.txt", Directory.GetCurrentDirectory(), map);
	    if(File.Exists(path))
	    {
		WriteToLog("Found upgrade stations for " + map);
		foreach(string line in File.ReadLines(path))
		{
		    if(line.Contains("mirrored"))
			InputMirror.Checked = true;
		    else
		    {
			string[] split = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
			if(split.Length == 4)
			    AddStationEntry(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]), int.Parse(split[3]));
			else if(split.Length == 5)
			    AddSignEntry(int.Parse(split[0]), int.Parse(split[1]), int.Parse(split[2]), int.Parse(split[3]), int.Parse(split[4]));
		    }
		}
	    }
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

		BtnGame.Enabled = enabled;
		BtnMap.Enabled = enabled;
		BtnVscript.Enabled = enabled;
		BtnUpgrades.Enabled = enabled;
		BtnAddStation.Enabled = enabled;
		BtnRemoveStation.Enabled = enabled;
		BtnAddSign.Enabled = enabled;
		BtnRemoveSign.Enabled = enabled;
		BtnConvert.Enabled = enabled;
	    }
	    else
		Invoke(new Action<bool>(ToggleControls), enabled);
	}
    }
}


namespace MvM_Upgrade_Vscript_Converter
{
	partial class Main
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
	    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
	    this.FileDialogMap = new System.Windows.Forms.OpenFileDialog();
	    this.MainTable = new System.Windows.Forms.TableLayoutPanel();
	    this.GroupSettings = new System.Windows.Forms.GroupBox();
	    this.InputTable = new System.Windows.Forms.TableLayoutPanel();
	    this.InputCompress = new System.Windows.Forms.CheckBox();
	    this.BtnEditStation = new System.Windows.Forms.Button();
	    this.BtnEditSign = new System.Windows.Forms.Button();
	    this.InputSave = new System.Windows.Forms.CheckBox();
	    this.InputMirror = new System.Windows.Forms.CheckBox();
	    this.BtnRemoveStation = new System.Windows.Forms.Button();
	    this.BtnRemoveSign = new System.Windows.Forms.Button();
	    this.ListSigns = new System.Windows.Forms.ListBox();
	    this.BtnAddSign = new System.Windows.Forms.Button();
	    this.BtnAddStation = new System.Windows.Forms.Button();
	    this.LabelSign = new System.Windows.Forms.Label();
	    this.LabelStation = new System.Windows.Forms.Label();
	    this.BtnUpgrades = new System.Windows.Forms.Button();
	    this.BtnVscript = new System.Windows.Forms.Button();
	    this.InputUpgradesPath = new System.Windows.Forms.TextBox();
	    this.InputVscriptPath = new System.Windows.Forms.TextBox();
	    this.LabelUpgrades = new System.Windows.Forms.Label();
	    this.LabelVscript = new System.Windows.Forms.Label();
	    this.InputUpgradesPull = new System.Windows.Forms.CheckBox();
	    this.LabelMap = new System.Windows.Forms.Label();
	    this.LabelGame = new System.Windows.Forms.Label();
	    this.InputMap = new System.Windows.Forms.TextBox();
	    this.InputGame = new System.Windows.Forms.TextBox();
	    this.LabelSuffix = new System.Windows.Forms.Label();
	    this.BtnConvert = new System.Windows.Forms.Button();
	    this.BtnGame = new System.Windows.Forms.Button();
	    this.BtnMap = new System.Windows.Forms.Button();
	    this.InputSuffix = new System.Windows.Forms.TextBox();
	    this.InputVscriptPull = new System.Windows.Forms.CheckBox();
	    this.ListStations = new System.Windows.Forms.ListBox();
	    this.GroupLog = new System.Windows.Forms.GroupBox();
	    this.LogBox = new System.Windows.Forms.TextBox();
	    this.FileDialogVscript = new System.Windows.Forms.OpenFileDialog();
	    this.FileDialogUpgrades = new System.Windows.Forms.OpenFileDialog();
	    this.FolderDialogGame = new System.Windows.Forms.FolderBrowserDialog();
	    this.MainTable.SuspendLayout();
	    this.GroupSettings.SuspendLayout();
	    this.InputTable.SuspendLayout();
	    this.GroupLog.SuspendLayout();
	    this.SuspendLayout();
	    // 
	    // FileDialogMap
	    // 
	    this.FileDialogMap.DefaultExt = "bsp";
	    this.FileDialogMap.Filter = "Source engine map|*.bsp";
	    this.FileDialogMap.Multiselect = true;
	    // 
	    // MainTable
	    // 
	    this.MainTable.ColumnCount = 1;
	    this.MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
	    this.MainTable.Controls.Add(this.GroupSettings, 0, 0);
	    this.MainTable.Controls.Add(this.GroupLog, 0, 1);
	    this.MainTable.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.MainTable.Location = new System.Drawing.Point(0, 0);
	    this.MainTable.Name = "MainTable";
	    this.MainTable.RowCount = 2;
	    this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
	    this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
	    this.MainTable.Size = new System.Drawing.Size(600, 650);
	    this.MainTable.TabIndex = 0;
	    // 
	    // GroupSettings
	    // 
	    this.GroupSettings.Controls.Add(this.InputTable);
	    this.GroupSettings.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.GroupSettings.Location = new System.Drawing.Point(3, 3);
	    this.GroupSettings.Name = "GroupSettings";
	    this.GroupSettings.Size = new System.Drawing.Size(594, 481);
	    this.GroupSettings.TabIndex = 2;
	    this.GroupSettings.TabStop = false;
	    this.GroupSettings.Text = "Settings";
	    // 
	    // InputTable
	    // 
	    this.InputTable.ColumnCount = 8;
	    this.InputTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 83F));
	    this.InputTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
	    this.InputTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
	    this.InputTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
	    this.InputTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
	    this.InputTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
	    this.InputTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
	    this.InputTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
	    this.InputTable.Controls.Add(this.InputCompress, 4, 11);
	    this.InputTable.Controls.Add(this.BtnEditStation, 2, 9);
	    this.InputTable.Controls.Add(this.BtnEditSign, 6, 9);
	    this.InputTable.Controls.Add(this.InputSave, 4, 10);
	    this.InputTable.Controls.Add(this.InputMirror, 0, 10);
	    this.InputTable.Controls.Add(this.BtnRemoveStation, 3, 9);
	    this.InputTable.Controls.Add(this.BtnRemoveSign, 7, 9);
	    this.InputTable.Controls.Add(this.ListSigns, 4, 8);
	    this.InputTable.Controls.Add(this.BtnAddSign, 5, 9);
	    this.InputTable.Controls.Add(this.BtnAddStation, 0, 9);
	    this.InputTable.Controls.Add(this.LabelSign, 4, 7);
	    this.InputTable.Controls.Add(this.LabelStation, 0, 7);
	    this.InputTable.Controls.Add(this.BtnUpgrades, 7, 6);
	    this.InputTable.Controls.Add(this.BtnVscript, 7, 4);
	    this.InputTable.Controls.Add(this.InputUpgradesPath, 1, 6);
	    this.InputTable.Controls.Add(this.InputVscriptPath, 1, 4);
	    this.InputTable.Controls.Add(this.LabelUpgrades, 0, 5);
	    this.InputTable.Controls.Add(this.LabelVscript, 0, 3);
	    this.InputTable.Controls.Add(this.InputUpgradesPull, 1, 5);
	    this.InputTable.Controls.Add(this.LabelMap, 0, 1);
	    this.InputTable.Controls.Add(this.LabelGame, 0, 0);
	    this.InputTable.Controls.Add(this.InputMap, 1, 1);
	    this.InputTable.Controls.Add(this.InputGame, 1, 0);
	    this.InputTable.Controls.Add(this.LabelSuffix, 0, 2);
	    this.InputTable.Controls.Add(this.BtnConvert, 7, 11);
	    this.InputTable.Controls.Add(this.BtnGame, 7, 0);
	    this.InputTable.Controls.Add(this.BtnMap, 7, 1);
	    this.InputTable.Controls.Add(this.InputSuffix, 1, 2);
	    this.InputTable.Controls.Add(this.InputVscriptPull, 1, 3);
	    this.InputTable.Controls.Add(this.ListStations, 0, 8);
	    this.InputTable.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.InputTable.Location = new System.Drawing.Point(3, 19);
	    this.InputTable.Margin = new System.Windows.Forms.Padding(0);
	    this.InputTable.Name = "InputTable";
	    this.InputTable.RowCount = 12;
	    this.InputTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
	    this.InputTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
	    this.InputTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
	    this.InputTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
	    this.InputTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
	    this.InputTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
	    this.InputTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
	    this.InputTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
	    this.InputTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
	    this.InputTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
	    this.InputTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
	    this.InputTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
	    this.InputTable.Size = new System.Drawing.Size(588, 459);
	    this.InputTable.TabIndex = 0;
	    // 
	    // InputCompress
	    // 
	    this.InputCompress.AutoSize = true;
	    this.InputTable.SetColumnSpan(this.InputCompress, 3);
	    this.InputCompress.Dock = System.Windows.Forms.DockStyle.Left;
	    this.InputCompress.Location = new System.Drawing.Point(296, 431);
	    this.InputCompress.Name = "InputCompress";
	    this.InputCompress.Size = new System.Drawing.Size(145, 25);
	    this.InputCompress.TabIndex = 21;
	    this.InputCompress.Text = "Compress output map";
	    this.InputCompress.UseVisualStyleBackColor = true;
	    // 
	    // BtnEditStation
	    // 
	    this.BtnEditStation.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.BtnEditStation.Enabled = false;
	    this.BtnEditStation.Location = new System.Drawing.Point(126, 369);
	    this.BtnEditStation.Name = "BtnEditStation";
	    this.BtnEditStation.Size = new System.Drawing.Size(79, 25);
	    this.BtnEditStation.TabIndex = 13;
	    this.BtnEditStation.Text = "Edit";
	    this.BtnEditStation.UseVisualStyleBackColor = true;
	    this.BtnEditStation.Click += new System.EventHandler(this.BtnEditStation_Click);
	    // 
	    // BtnEditSign
	    // 
	    this.BtnEditSign.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.BtnEditSign.Enabled = false;
	    this.BtnEditSign.Location = new System.Drawing.Point(421, 369);
	    this.BtnEditSign.Name = "BtnEditSign";
	    this.BtnEditSign.Size = new System.Drawing.Size(79, 25);
	    this.BtnEditSign.TabIndex = 16;
	    this.BtnEditSign.Text = "Edit";
	    this.BtnEditSign.UseVisualStyleBackColor = true;
	    this.BtnEditSign.Click += new System.EventHandler(this.BtnEditSign_Click);
	    // 
	    // InputSave
	    // 
	    this.InputSave.AutoSize = true;
	    this.InputSave.Checked = true;
	    this.InputSave.CheckState = System.Windows.Forms.CheckState.Checked;
	    this.InputTable.SetColumnSpan(this.InputSave, 3);
	    this.InputSave.Dock = System.Windows.Forms.DockStyle.Left;
	    this.InputSave.Enabled = false;
	    this.InputSave.Location = new System.Drawing.Point(296, 400);
	    this.InputSave.Name = "InputSave";
	    this.InputSave.Size = new System.Drawing.Size(174, 25);
	    this.InputSave.TabIndex = 19;
	    this.InputSave.Text = "Save upgrade stations to file";
	    this.InputSave.UseVisualStyleBackColor = true;
	    // 
	    // InputMirror
	    // 
	    this.InputMirror.AutoSize = true;
	    this.InputTable.SetColumnSpan(this.InputMirror, 4);
	    this.InputMirror.Dock = System.Windows.Forms.DockStyle.Left;
	    this.InputMirror.Enabled = false;
	    this.InputMirror.Location = new System.Drawing.Point(3, 400);
	    this.InputMirror.Name = "InputMirror";
	    this.InputMirror.Size = new System.Drawing.Size(218, 25);
	    this.InputMirror.TabIndex = 18;
	    this.InputMirror.Text = "Mirror all upgrade stations and signs";
	    this.InputMirror.UseVisualStyleBackColor = true;
	    // 
	    // BtnRemoveStation
	    // 
	    this.BtnRemoveStation.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.BtnRemoveStation.Enabled = false;
	    this.BtnRemoveStation.Location = new System.Drawing.Point(211, 369);
	    this.BtnRemoveStation.Name = "BtnRemoveStation";
	    this.BtnRemoveStation.Size = new System.Drawing.Size(79, 25);
	    this.BtnRemoveStation.TabIndex = 14;
	    this.BtnRemoveStation.Text = "Remove";
	    this.BtnRemoveStation.UseVisualStyleBackColor = true;
	    this.BtnRemoveStation.Click += new System.EventHandler(this.BtnRemoveStation_Click);
	    // 
	    // BtnRemoveSign
	    // 
	    this.BtnRemoveSign.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.BtnRemoveSign.Enabled = false;
	    this.BtnRemoveSign.Location = new System.Drawing.Point(506, 369);
	    this.BtnRemoveSign.Name = "BtnRemoveSign";
	    this.BtnRemoveSign.Size = new System.Drawing.Size(79, 25);
	    this.BtnRemoveSign.TabIndex = 17;
	    this.BtnRemoveSign.Text = "Remove";
	    this.BtnRemoveSign.UseVisualStyleBackColor = true;
	    this.BtnRemoveSign.Click += new System.EventHandler(this.BtnRemoveSign_Click);
	    // 
	    // ListSigns
	    // 
	    this.InputTable.SetColumnSpan(this.ListSigns, 4);
	    this.ListSigns.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.ListSigns.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
	    this.ListSigns.FormattingEnabled = true;
	    this.ListSigns.ItemHeight = 15;
	    this.ListSigns.Location = new System.Drawing.Point(296, 251);
	    this.ListSigns.Name = "ListSigns";
	    this.ListSigns.Size = new System.Drawing.Size(289, 112);
	    this.ListSigns.TabIndex = 0;
	    // 
	    // BtnAddSign
	    // 
	    this.BtnAddSign.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.BtnAddSign.Enabled = false;
	    this.BtnAddSign.Location = new System.Drawing.Point(336, 369);
	    this.BtnAddSign.Name = "BtnAddSign";
	    this.BtnAddSign.Size = new System.Drawing.Size(79, 25);
	    this.BtnAddSign.TabIndex = 15;
	    this.BtnAddSign.Text = "Add";
	    this.BtnAddSign.UseVisualStyleBackColor = true;
	    this.BtnAddSign.Click += new System.EventHandler(this.BtnAddSign_Click);
	    // 
	    // BtnAddStation
	    // 
	    this.InputTable.SetColumnSpan(this.BtnAddStation, 2);
	    this.BtnAddStation.Dock = System.Windows.Forms.DockStyle.Right;
	    this.BtnAddStation.Enabled = false;
	    this.BtnAddStation.Location = new System.Drawing.Point(43, 369);
	    this.BtnAddStation.Name = "BtnAddStation";
	    this.BtnAddStation.Size = new System.Drawing.Size(77, 25);
	    this.BtnAddStation.TabIndex = 12;
	    this.BtnAddStation.Text = "Add";
	    this.BtnAddStation.UseVisualStyleBackColor = true;
	    this.BtnAddStation.Click += new System.EventHandler(this.BtnAddStation_Click);
	    // 
	    // LabelSign
	    // 
	    this.LabelSign.AutoSize = true;
	    this.InputTable.SetColumnSpan(this.LabelSign, 4);
	    this.LabelSign.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.LabelSign.Location = new System.Drawing.Point(296, 217);
	    this.LabelSign.Name = "LabelSign";
	    this.LabelSign.Size = new System.Drawing.Size(289, 31);
	    this.LabelSign.TabIndex = 0;
	    this.LabelSign.Text = "Upgrade signs";
	    this.LabelSign.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	    // 
	    // LabelStation
	    // 
	    this.LabelStation.AutoSize = true;
	    this.InputTable.SetColumnSpan(this.LabelStation, 4);
	    this.LabelStation.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.LabelStation.Location = new System.Drawing.Point(3, 217);
	    this.LabelStation.Name = "LabelStation";
	    this.LabelStation.Size = new System.Drawing.Size(287, 31);
	    this.LabelStation.TabIndex = 0;
	    this.LabelStation.Text = "Upgrade stations";
	    this.LabelStation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	    // 
	    // BtnUpgrades
	    // 
	    this.BtnUpgrades.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.BtnUpgrades.Location = new System.Drawing.Point(506, 189);
	    this.BtnUpgrades.Name = "BtnUpgrades";
	    this.BtnUpgrades.Size = new System.Drawing.Size(79, 25);
	    this.BtnUpgrades.TabIndex = 4;
	    this.BtnUpgrades.Text = "Browse...";
	    this.BtnUpgrades.UseVisualStyleBackColor = true;
	    this.BtnUpgrades.Click += new System.EventHandler(this.BtnUpgrades_Click);
	    // 
	    // BtnVscript
	    // 
	    this.BtnVscript.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.BtnVscript.Location = new System.Drawing.Point(506, 127);
	    this.BtnVscript.Name = "BtnVscript";
	    this.BtnVscript.Size = new System.Drawing.Size(79, 25);
	    this.BtnVscript.TabIndex = 3;
	    this.BtnVscript.Text = "Browse...";
	    this.BtnVscript.UseVisualStyleBackColor = true;
	    this.BtnVscript.Click += new System.EventHandler(this.BtnVscript_Click);
	    // 
	    // InputUpgradesPath
	    // 
	    this.InputTable.SetColumnSpan(this.InputUpgradesPath, 6);
	    this.InputUpgradesPath.Dock = System.Windows.Forms.DockStyle.Bottom;
	    this.InputUpgradesPath.Location = new System.Drawing.Point(86, 191);
	    this.InputUpgradesPath.Name = "InputUpgradesPath";
	    this.InputUpgradesPath.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
	    this.InputUpgradesPath.Size = new System.Drawing.Size(414, 23);
	    this.InputUpgradesPath.TabIndex = 11;
	    this.InputUpgradesPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
	    // 
	    // InputVscriptPath
	    // 
	    this.InputTable.SetColumnSpan(this.InputVscriptPath, 6);
	    this.InputVscriptPath.Dock = System.Windows.Forms.DockStyle.Bottom;
	    this.InputVscriptPath.Location = new System.Drawing.Point(86, 129);
	    this.InputVscriptPath.Name = "InputVscriptPath";
	    this.InputVscriptPath.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
	    this.InputVscriptPath.Size = new System.Drawing.Size(414, 23);
	    this.InputVscriptPath.TabIndex = 9;
	    this.InputVscriptPath.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
	    // 
	    // LabelUpgrades
	    // 
	    this.LabelUpgrades.AutoSize = true;
	    this.LabelUpgrades.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.LabelUpgrades.Location = new System.Drawing.Point(3, 155);
	    this.LabelUpgrades.Name = "LabelUpgrades";
	    this.LabelUpgrades.Size = new System.Drawing.Size(77, 31);
	    this.LabelUpgrades.TabIndex = 0;
	    this.LabelUpgrades.Text = "Upgrades";
	    this.LabelUpgrades.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	    // 
	    // LabelVscript
	    // 
	    this.LabelVscript.AutoSize = true;
	    this.LabelVscript.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.LabelVscript.Location = new System.Drawing.Point(3, 93);
	    this.LabelVscript.Name = "LabelVscript";
	    this.LabelVscript.Size = new System.Drawing.Size(77, 31);
	    this.LabelVscript.TabIndex = 0;
	    this.LabelVscript.Text = "Vscript";
	    this.LabelVscript.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	    // 
	    // InputUpgradesPull
	    // 
	    this.InputUpgradesPull.AutoSize = true;
	    this.InputUpgradesPull.Checked = true;
	    this.InputUpgradesPull.CheckState = System.Windows.Forms.CheckState.Checked;
	    this.InputTable.SetColumnSpan(this.InputUpgradesPull, 3);
	    this.InputUpgradesPull.Dock = System.Windows.Forms.DockStyle.Left;
	    this.InputUpgradesPull.Location = new System.Drawing.Point(86, 158);
	    this.InputUpgradesPull.Name = "InputUpgradesPull";
	    this.InputUpgradesPull.Size = new System.Drawing.Size(168, 25);
	    this.InputUpgradesPull.TabIndex = 10;
	    this.InputUpgradesPull.Text = "Pull upgrades from GitHub";
	    this.InputUpgradesPull.UseVisualStyleBackColor = true;
	    // 
	    // LabelMap
	    // 
	    this.LabelMap.AutoSize = true;
	    this.LabelMap.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.LabelMap.Location = new System.Drawing.Point(3, 31);
	    this.LabelMap.Name = "LabelMap";
	    this.LabelMap.Size = new System.Drawing.Size(77, 31);
	    this.LabelMap.TabIndex = 0;
	    this.LabelMap.Text = "Map path";
	    this.LabelMap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	    // 
	    // LabelGame
	    // 
	    this.LabelGame.AutoSize = true;
	    this.LabelGame.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.LabelGame.Location = new System.Drawing.Point(3, 0);
	    this.LabelGame.Name = "LabelGame";
	    this.LabelGame.Size = new System.Drawing.Size(77, 31);
	    this.LabelGame.TabIndex = 0;
	    this.LabelGame.Text = "Game path";
	    this.LabelGame.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	    // 
	    // InputMap
	    // 
	    this.InputTable.SetColumnSpan(this.InputMap, 6);
	    this.InputMap.Dock = System.Windows.Forms.DockStyle.Bottom;
	    this.InputMap.Location = new System.Drawing.Point(86, 36);
	    this.InputMap.Name = "InputMap";
	    this.InputMap.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
	    this.InputMap.Size = new System.Drawing.Size(414, 23);
	    this.InputMap.TabIndex = 6;
	    this.InputMap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
	    // 
	    // InputGame
	    // 
	    this.InputTable.SetColumnSpan(this.InputGame, 6);
	    this.InputGame.Dock = System.Windows.Forms.DockStyle.Bottom;
	    this.InputGame.Location = new System.Drawing.Point(86, 5);
	    this.InputGame.Name = "InputGame";
	    this.InputGame.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
	    this.InputGame.Size = new System.Drawing.Size(414, 23);
	    this.InputGame.TabIndex = 5;
	    this.InputGame.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
	    // 
	    // LabelSuffix
	    // 
	    this.LabelSuffix.AutoSize = true;
	    this.LabelSuffix.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.LabelSuffix.Location = new System.Drawing.Point(3, 62);
	    this.LabelSuffix.Name = "LabelSuffix";
	    this.LabelSuffix.Size = new System.Drawing.Size(77, 31);
	    this.LabelSuffix.TabIndex = 0;
	    this.LabelSuffix.Text = "Map suffix";
	    this.LabelSuffix.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	    // 
	    // BtnConvert
	    // 
	    this.BtnConvert.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.BtnConvert.Location = new System.Drawing.Point(506, 431);
	    this.BtnConvert.Name = "BtnConvert";
	    this.BtnConvert.Size = new System.Drawing.Size(79, 25);
	    this.BtnConvert.TabIndex = 22;
	    this.BtnConvert.Text = "Convert";
	    this.BtnConvert.UseVisualStyleBackColor = true;
	    this.BtnConvert.Click += new System.EventHandler(this.BtnConvert_Click);
	    // 
	    // BtnGame
	    // 
	    this.BtnGame.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.BtnGame.Location = new System.Drawing.Point(506, 3);
	    this.BtnGame.Name = "BtnGame";
	    this.BtnGame.Size = new System.Drawing.Size(79, 25);
	    this.BtnGame.TabIndex = 1;
	    this.BtnGame.Text = "Browse...";
	    this.BtnGame.UseVisualStyleBackColor = true;
	    this.BtnGame.Click += new System.EventHandler(this.BtnGame_Click);
	    // 
	    // BtnMap
	    // 
	    this.BtnMap.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.BtnMap.Location = new System.Drawing.Point(506, 34);
	    this.BtnMap.Name = "BtnMap";
	    this.BtnMap.Size = new System.Drawing.Size(79, 25);
	    this.BtnMap.TabIndex = 2;
	    this.BtnMap.Text = "Browse...";
	    this.BtnMap.UseVisualStyleBackColor = false;
	    this.BtnMap.Click += new System.EventHandler(this.BtnMap_Click);
	    // 
	    // InputSuffix
	    // 
	    this.InputTable.SetColumnSpan(this.InputSuffix, 6);
	    this.InputSuffix.Dock = System.Windows.Forms.DockStyle.Bottom;
	    this.InputSuffix.Location = new System.Drawing.Point(86, 67);
	    this.InputSuffix.Name = "InputSuffix";
	    this.InputSuffix.Size = new System.Drawing.Size(414, 23);
	    this.InputSuffix.TabIndex = 7;
	    this.InputSuffix.Text = "mvm";
	    // 
	    // InputVscriptPull
	    // 
	    this.InputVscriptPull.AutoSize = true;
	    this.InputVscriptPull.Checked = true;
	    this.InputVscriptPull.CheckState = System.Windows.Forms.CheckState.Checked;
	    this.InputTable.SetColumnSpan(this.InputVscriptPull, 3);
	    this.InputVscriptPull.Dock = System.Windows.Forms.DockStyle.Left;
	    this.InputVscriptPull.Location = new System.Drawing.Point(86, 96);
	    this.InputVscriptPull.Name = "InputVscriptPull";
	    this.InputVscriptPull.Size = new System.Drawing.Size(155, 25);
	    this.InputVscriptPull.TabIndex = 8;
	    this.InputVscriptPull.Text = "Pull Vscript from GitHub";
	    this.InputVscriptPull.UseVisualStyleBackColor = true;
	    // 
	    // ListStations
	    // 
	    this.InputTable.SetColumnSpan(this.ListStations, 4);
	    this.ListStations.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.ListStations.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
	    this.ListStations.FormattingEnabled = true;
	    this.ListStations.ItemHeight = 15;
	    this.ListStations.Location = new System.Drawing.Point(3, 251);
	    this.ListStations.Name = "ListStations";
	    this.ListStations.Size = new System.Drawing.Size(287, 112);
	    this.ListStations.TabIndex = 0;
	    this.ListStations.TabStop = false;
	    // 
	    // GroupLog
	    // 
	    this.GroupLog.Controls.Add(this.LogBox);
	    this.GroupLog.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.GroupLog.Location = new System.Drawing.Point(3, 490);
	    this.GroupLog.Name = "GroupLog";
	    this.GroupLog.Size = new System.Drawing.Size(594, 157);
	    this.GroupLog.TabIndex = 1;
	    this.GroupLog.TabStop = false;
	    this.GroupLog.Text = "Log";
	    // 
	    // LogBox
	    // 
	    this.LogBox.Cursor = System.Windows.Forms.Cursors.Default;
	    this.LogBox.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.LogBox.Location = new System.Drawing.Point(3, 19);
	    this.LogBox.Multiline = true;
	    this.LogBox.Name = "LogBox";
	    this.LogBox.ReadOnly = true;
	    this.LogBox.Size = new System.Drawing.Size(588, 135);
	    this.LogBox.TabIndex = 0;
	    this.LogBox.TabStop = false;
	    // 
	    // FileDialogVscript
	    // 
	    this.FileDialogVscript.DefaultExt = "bsp";
	    this.FileDialogVscript.Filter = "Squirrel script|*.nut";
	    // 
	    // FileDialogUpgrades
	    // 
	    this.FileDialogUpgrades.DefaultExt = "exe";
	    this.FileDialogUpgrades.Filter = "Text file|*.txt";
	    // 
	    // FolderDialogGame
	    // 
	    this.FolderDialogGame.RootFolder = System.Environment.SpecialFolder.MyComputer;
	    // 
	    // Main
	    // 
	    this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
	    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	    this.ClientSize = new System.Drawing.Size(600, 650);
	    this.Controls.Add(this.MainTable);
	    this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
	    this.Name = "Main";
	    this.Text = "MvM Upgrades Vscript Converter";
	    this.Load += new System.EventHandler(this.Main_Load);
	    this.MainTable.ResumeLayout(false);
	    this.GroupSettings.ResumeLayout(false);
	    this.InputTable.ResumeLayout(false);
	    this.InputTable.PerformLayout();
	    this.GroupLog.ResumeLayout(false);
	    this.GroupLog.PerformLayout();
	    this.ResumeLayout(false);

		}

	#endregion

	private System.Windows.Forms.OpenFileDialog FileDialogMap;
	private System.Windows.Forms.TableLayoutPanel MainTable;
	private System.Windows.Forms.TableLayoutPanel InputTable;
	private System.Windows.Forms.Button BtnMap;
	private System.Windows.Forms.GroupBox GroupLog;
	private System.Windows.Forms.GroupBox GroupSettings;
	private System.Windows.Forms.TextBox LogBox;
	private System.Windows.Forms.Button BtnGame;
	private System.Windows.Forms.Label LabelSuffix;
	private System.Windows.Forms.TextBox InputSuffix;
	private System.Windows.Forms.TextBox InputMap;
	private System.Windows.Forms.TextBox InputGame;
	private System.Windows.Forms.Label LabelMap;
	private System.Windows.Forms.Label LabelGame;
	private System.Windows.Forms.CheckBox InputUpgradesPull;
	private System.Windows.Forms.CheckBox InputVscriptPull;
	private System.Windows.Forms.OpenFileDialog FileDialogVscript;
	private System.Windows.Forms.OpenFileDialog FileDialogUpgrades;
	private System.Windows.Forms.Button BtnUpgrades;
	private System.Windows.Forms.Button BtnVscript;
	private System.Windows.Forms.TextBox InputUpgradesPath;
	private System.Windows.Forms.TextBox InputVscriptPath;
	private System.Windows.Forms.Label LabelUpgrades;
	private System.Windows.Forms.Label LabelVscript;
	private System.Windows.Forms.Button BtnAddSign;
	private System.Windows.Forms.Button BtnAddStation;
	private System.Windows.Forms.Label LabelSign;
	private System.Windows.Forms.Label LabelStation;
	private System.Windows.Forms.Button BtnConvert;
	private System.Windows.Forms.ListBox ListStations;
	private System.Windows.Forms.ListBox ListSigns;
	private System.Windows.Forms.Button BtnRemoveStation;
	private System.Windows.Forms.Button BtnRemoveSign;
	private System.Windows.Forms.CheckBox InputMirror;
	private System.Windows.Forms.CheckBox InputSave;
	private System.Windows.Forms.FolderBrowserDialog FolderDialogGame;
	private System.Windows.Forms.Button BtnEditStation;
	private System.Windows.Forms.Button BtnEditSign;
	private System.Windows.Forms.CheckBox InputCompress;
    }
}


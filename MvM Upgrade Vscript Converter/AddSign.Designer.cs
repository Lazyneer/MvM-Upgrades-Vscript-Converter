
namespace MvM_Upgrade_Vscript_Converter
{
    partial class AddSign
    {
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	/// Clean up any resources being used.
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
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
	    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddSign));
	    this.MainTable = new System.Windows.Forms.TableLayoutPanel();
	    this.InputHeight = new MvM_Upgrade_Vscript_Converter.NumericUpDownNoArrows();
	    this.LabelHeight = new System.Windows.Forms.Label();
	    this.BtnAdd = new System.Windows.Forms.Button();
	    this.BtnCancel = new System.Windows.Forms.Button();
	    this.InputAng = new MvM_Upgrade_Vscript_Converter.NumericUpDownNoArrows();
	    this.InputPosZ = new MvM_Upgrade_Vscript_Converter.NumericUpDownNoArrows();
	    this.InputPosY = new MvM_Upgrade_Vscript_Converter.NumericUpDownNoArrows();
	    this.LabelAng = new System.Windows.Forms.Label();
	    this.LabelPosZ = new System.Windows.Forms.Label();
	    this.LabelPosY = new System.Windows.Forms.Label();
	    this.LabelPosX = new System.Windows.Forms.Label();
	    this.InputPosX = new MvM_Upgrade_Vscript_Converter.NumericUpDownNoArrows();
	    this.MainTable.SuspendLayout();
	    ((System.ComponentModel.ISupportInitialize)(this.InputHeight)).BeginInit();
	    ((System.ComponentModel.ISupportInitialize)(this.InputAng)).BeginInit();
	    ((System.ComponentModel.ISupportInitialize)(this.InputPosZ)).BeginInit();
	    ((System.ComponentModel.ISupportInitialize)(this.InputPosY)).BeginInit();
	    ((System.ComponentModel.ISupportInitialize)(this.InputPosX)).BeginInit();
	    this.SuspendLayout();
	    // 
	    // MainTable
	    // 
	    this.MainTable.ColumnCount = 3;
	    this.MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
	    this.MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
	    this.MainTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
	    this.MainTable.Controls.Add(this.InputHeight, 1, 4);
	    this.MainTable.Controls.Add(this.LabelHeight, 0, 4);
	    this.MainTable.Controls.Add(this.BtnAdd, 0, 6);
	    this.MainTable.Controls.Add(this.BtnCancel, 2, 6);
	    this.MainTable.Controls.Add(this.InputAng, 1, 3);
	    this.MainTable.Controls.Add(this.InputPosZ, 1, 2);
	    this.MainTable.Controls.Add(this.InputPosY, 1, 1);
	    this.MainTable.Controls.Add(this.LabelAng, 0, 3);
	    this.MainTable.Controls.Add(this.LabelPosZ, 0, 2);
	    this.MainTable.Controls.Add(this.LabelPosY, 0, 1);
	    this.MainTable.Controls.Add(this.LabelPosX, 0, 0);
	    this.MainTable.Controls.Add(this.InputPosX, 1, 0);
	    this.MainTable.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.MainTable.Location = new System.Drawing.Point(0, 0);
	    this.MainTable.Margin = new System.Windows.Forms.Padding(0);
	    this.MainTable.Name = "MainTable";
	    this.MainTable.RowCount = 7;
	    this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
	    this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
	    this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
	    this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
	    this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
	    this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
	    this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
	    this.MainTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
	    this.MainTable.Size = new System.Drawing.Size(220, 200);
	    this.MainTable.TabIndex = 1;
	    // 
	    // InputHeight
	    // 
	    this.MainTable.SetColumnSpan(this.InputHeight, 2);
	    this.InputHeight.Dock = System.Windows.Forms.DockStyle.Bottom;
	    this.InputHeight.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
	    this.InputHeight.Location = new System.Drawing.Point(88, 129);
	    this.InputHeight.Maximum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
	    this.InputHeight.Minimum = new decimal(new int[] {
            64,
            0,
            0,
            0});
	    this.InputHeight.Name = "InputHeight";
	    this.InputHeight.Size = new System.Drawing.Size(129, 23);
	    this.InputHeight.TabIndex = 5;
	    this.InputHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
	    this.InputHeight.Value = new decimal(new int[] {
            128,
            0,
            0,
            0});
	    // 
	    // LabelHeight
	    // 
	    this.LabelHeight.AutoSize = true;
	    this.LabelHeight.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.LabelHeight.Location = new System.Drawing.Point(3, 124);
	    this.LabelHeight.Name = "LabelHeight";
	    this.LabelHeight.Size = new System.Drawing.Size(79, 31);
	    this.LabelHeight.TabIndex = 0;
	    this.LabelHeight.Text = "Height";
	    this.LabelHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	    // 
	    // BtnAdd
	    // 
	    this.MainTable.SetColumnSpan(this.BtnAdd, 2);
	    this.BtnAdd.Dock = System.Windows.Forms.DockStyle.Right;
	    this.BtnAdd.Location = new System.Drawing.Point(53, 172);
	    this.BtnAdd.Name = "BtnAdd";
	    this.BtnAdd.Size = new System.Drawing.Size(79, 25);
	    this.BtnAdd.TabIndex = 6;
	    this.BtnAdd.Text = "Add";
	    this.BtnAdd.UseVisualStyleBackColor = true;
	    this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
	    // 
	    // BtnCancel
	    // 
	    this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
	    this.BtnCancel.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.BtnCancel.Location = new System.Drawing.Point(138, 172);
	    this.BtnCancel.Name = "BtnCancel";
	    this.BtnCancel.Size = new System.Drawing.Size(79, 25);
	    this.BtnCancel.TabIndex = 7;
	    this.BtnCancel.Text = "Cancel";
	    this.BtnCancel.UseVisualStyleBackColor = true;
	    // 
	    // InputAng
	    // 
	    this.MainTable.SetColumnSpan(this.InputAng, 2);
	    this.InputAng.Dock = System.Windows.Forms.DockStyle.Bottom;
	    this.InputAng.Increment = new decimal(new int[] {
            90,
            0,
            0,
            0});
	    this.InputAng.Location = new System.Drawing.Point(88, 98);
	    this.InputAng.Maximum = new decimal(new int[] {
            359,
            0,
            0,
            0});
	    this.InputAng.Name = "InputAng";
	    this.InputAng.Size = new System.Drawing.Size(129, 23);
	    this.InputAng.TabIndex = 4;
	    this.InputAng.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
	    // 
	    // InputPosZ
	    // 
	    this.MainTable.SetColumnSpan(this.InputPosZ, 2);
	    this.InputPosZ.Dock = System.Windows.Forms.DockStyle.Bottom;
	    this.InputPosZ.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
	    this.InputPosZ.Location = new System.Drawing.Point(88, 67);
	    this.InputPosZ.Maximum = new decimal(new int[] {
            16384,
            0,
            0,
            0});
	    this.InputPosZ.Minimum = new decimal(new int[] {
            16384,
            0,
            0,
            -2147483648});
	    this.InputPosZ.Name = "InputPosZ";
	    this.InputPosZ.Size = new System.Drawing.Size(129, 23);
	    this.InputPosZ.TabIndex = 3;
	    this.InputPosZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
	    // 
	    // InputPosY
	    // 
	    this.MainTable.SetColumnSpan(this.InputPosY, 2);
	    this.InputPosY.Dock = System.Windows.Forms.DockStyle.Bottom;
	    this.InputPosY.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
	    this.InputPosY.Location = new System.Drawing.Point(88, 36);
	    this.InputPosY.Maximum = new decimal(new int[] {
            16384,
            0,
            0,
            0});
	    this.InputPosY.Minimum = new decimal(new int[] {
            16384,
            0,
            0,
            -2147483648});
	    this.InputPosY.Name = "InputPosY";
	    this.InputPosY.Size = new System.Drawing.Size(129, 23);
	    this.InputPosY.TabIndex = 2;
	    this.InputPosY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
	    // 
	    // LabelAng
	    // 
	    this.LabelAng.AutoSize = true;
	    this.LabelAng.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.LabelAng.Location = new System.Drawing.Point(3, 93);
	    this.LabelAng.Name = "LabelAng";
	    this.LabelAng.Size = new System.Drawing.Size(79, 31);
	    this.LabelAng.TabIndex = 0;
	    this.LabelAng.Text = "Angle";
	    this.LabelAng.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	    // 
	    // LabelPosZ
	    // 
	    this.LabelPosZ.AutoSize = true;
	    this.LabelPosZ.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.LabelPosZ.Location = new System.Drawing.Point(3, 62);
	    this.LabelPosZ.Name = "LabelPosZ";
	    this.LabelPosZ.Size = new System.Drawing.Size(79, 31);
	    this.LabelPosZ.TabIndex = 0;
	    this.LabelPosZ.Text = "Position Z";
	    this.LabelPosZ.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	    // 
	    // LabelPosY
	    // 
	    this.LabelPosY.AutoSize = true;
	    this.LabelPosY.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.LabelPosY.Location = new System.Drawing.Point(3, 31);
	    this.LabelPosY.Name = "LabelPosY";
	    this.LabelPosY.Size = new System.Drawing.Size(79, 31);
	    this.LabelPosY.TabIndex = 0;
	    this.LabelPosY.Text = "Position Y";
	    this.LabelPosY.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	    // 
	    // LabelPosX
	    // 
	    this.LabelPosX.AutoSize = true;
	    this.LabelPosX.Dock = System.Windows.Forms.DockStyle.Fill;
	    this.LabelPosX.Location = new System.Drawing.Point(3, 0);
	    this.LabelPosX.Name = "LabelPosX";
	    this.LabelPosX.Size = new System.Drawing.Size(79, 31);
	    this.LabelPosX.TabIndex = 0;
	    this.LabelPosX.Text = "Position X";
	    this.LabelPosX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
	    // 
	    // InputPosX
	    // 
	    this.MainTable.SetColumnSpan(this.InputPosX, 2);
	    this.InputPosX.Dock = System.Windows.Forms.DockStyle.Bottom;
	    this.InputPosX.Increment = new decimal(new int[] {
            16,
            0,
            0,
            0});
	    this.InputPosX.Location = new System.Drawing.Point(88, 5);
	    this.InputPosX.Maximum = new decimal(new int[] {
            16384,
            0,
            0,
            0});
	    this.InputPosX.Minimum = new decimal(new int[] {
            16384,
            0,
            0,
            -2147483648});
	    this.InputPosX.Name = "InputPosX";
	    this.InputPosX.Size = new System.Drawing.Size(129, 23);
	    this.InputPosX.TabIndex = 1;
	    this.InputPosX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
	    // 
	    // AddSign
	    // 
	    this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
	    this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
	    this.ClientSize = new System.Drawing.Size(220, 200);
	    this.ControlBox = false;
	    this.Controls.Add(this.MainTable);
	    this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
	    this.Name = "AddSign";
	    this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
	    this.Text = "Add upgrade sign";
	    this.MainTable.ResumeLayout(false);
	    this.MainTable.PerformLayout();
	    ((System.ComponentModel.ISupportInitialize)(this.InputHeight)).EndInit();
	    ((System.ComponentModel.ISupportInitialize)(this.InputAng)).EndInit();
	    ((System.ComponentModel.ISupportInitialize)(this.InputPosZ)).EndInit();
	    ((System.ComponentModel.ISupportInitialize)(this.InputPosY)).EndInit();
	    ((System.ComponentModel.ISupportInitialize)(this.InputPosX)).EndInit();
	    this.ResumeLayout(false);

	}

	#endregion

	private System.Windows.Forms.TableLayoutPanel MainTable;
	private NumericUpDownNoArrows InputHeight;
	private System.Windows.Forms.Label LabelHeight;
	private System.Windows.Forms.Button BtnAdd;
	private System.Windows.Forms.Button BtnCancel;
	private NumericUpDownNoArrows InputAng;
	private NumericUpDownNoArrows InputPosZ;
	private NumericUpDownNoArrows InputPosY;
	private System.Windows.Forms.Label LabelAng;
	private System.Windows.Forms.Label LabelPosZ;
	private System.Windows.Forms.Label LabelPosY;
	private System.Windows.Forms.Label LabelPosX;
	private NumericUpDownNoArrows InputPosX;
    }
}
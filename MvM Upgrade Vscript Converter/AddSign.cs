﻿using System;
using System.Windows.Forms;

namespace MvM_Upgrade_Vscript_Converter
{
    public partial class AddSign : Form
    {
	public AddSign()
	{
	    InitializeComponent();
	}

	public int PosX = 0;
	public int PosY = 0;
	public int PosZ = 0;
	public int Ang = 0;
	public new int Height = 0;

	private void BtnAdd_Click(object sender, EventArgs e)
	{
	    PosX = (int)InputPosX.Value;
	    PosY = (int)InputPosY.Value;
	    PosZ = (int)InputPosZ.Value;
	    Ang = (int)InputAng.Value;
	    Height = (int)InputHeight.Value;

	    DialogResult = DialogResult.OK;
	}
    }
}

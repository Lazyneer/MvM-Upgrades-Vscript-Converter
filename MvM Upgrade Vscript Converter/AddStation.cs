using System;
using System.Windows.Forms;

namespace MvM_Upgrade_Vscript_Converter
{
    public partial class AddStation : Form
    {
	public AddStation()
	{
	    InitializeComponent();
	}

	public AddStation(int x, int y, int z, int ang)
	{
	    InitializeComponent();

	    InputPosX.Value = x;
	    InputPosY.Value = y;
	    InputPosZ.Value = z;
	    InputAng.Value = ang;

	    BtnAdd.Text = "Edit";
	    Text = Text.Replace("Add", "Edit");
	}

	public int PosX = 0;
	public int PosY = 0;
	public int PosZ = 0;
	public int Ang = 0;

	private void BtnAdd_Click(object sender, EventArgs e)
	{
	    PosX = (int)InputPosX.Value;
	    PosY = (int)InputPosY.Value;
	    PosZ = (int)InputPosZ.Value;
	    Ang = (int)InputAng.Value;

	    DialogResult = DialogResult.OK;
	}
    }
}

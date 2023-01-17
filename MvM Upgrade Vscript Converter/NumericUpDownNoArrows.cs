using System;
using System.Windows.Forms;

namespace MvM_Upgrade_Vscript_Converter
{
    public class NumericUpDownNoArrows : NumericUpDown
    {
	public NumericUpDownNoArrows()
	{
	    Controls[0].Hide();
	}

	protected override void OnTextBoxResize(object source, EventArgs e)
	{
	    Controls[1].Width = Width - 4;
	}

	protected override void OnMouseWheel(MouseEventArgs e)
	{
	    HandledMouseEventArgs hme = e as HandledMouseEventArgs;
	    if(hme != null)
		hme.Handled = true;

	    decimal newValue = Value;

	    if(e.Delta > 0)
		newValue += Increment;
	    else if(e.Delta < 0)
		newValue -= Increment;

	    Value = Math.Clamp(newValue, Minimum, Maximum);
	}
    }
}

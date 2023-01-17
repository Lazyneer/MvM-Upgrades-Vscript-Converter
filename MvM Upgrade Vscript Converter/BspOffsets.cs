namespace MvM_Upgrade_Vscript_Converter
{
    internal class BspOffsets
    {
	public static int CalculateLumpOffset(int lumpId)
	{
	    return 8 + 16 * lumpId;
	}

	public static int CalculateLumpOffset(BspLumpType lump)
	{
	    return CalculateLumpOffset((int)lump);
	}
    }
}

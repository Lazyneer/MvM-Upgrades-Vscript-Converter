namespace MvM_Upgrade_Vscript_Converter
{
    public class BspInfo
    {
	public int Identifier { get; set; }
	public int Version { get; set; }
	public BspLumpInfo[] Lumps { get; set; }
	public int MapRevision { get; set; }
	public bool Compressed { get; set; }

	internal BspInfo Clone()
	{
	    var clonedInfo = new BspInfo()
	    {
		Identifier = Identifier,
		Version = Version,
		Lumps = new BspLumpInfo[64],
		MapRevision = MapRevision
	    };

	    for(int i = 0; i < 64; i++)
	    {
		var oldLump = Lumps[i];
		clonedInfo.Lumps[i] = new BspLumpInfo()
		{
		    FileLength = oldLump.FileLength,
		    FileOffset = oldLump.FileOffset,
		    fourCC = oldLump.fourCC,
		    Version = oldLump.Version
		};
	    }

	    return clonedInfo;
	}
    }
}

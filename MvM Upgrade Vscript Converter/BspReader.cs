using System;
using System.IO;

namespace MvM_Upgrade_Vscript_Converter
{
    public class BspReader : IDisposable
    {
	private BinaryReader reader;
	private BspInfo cachedInfo;
	private bool disposed = false;

	public BspReader(BinaryReader reader)
	{
	    this.reader = reader;
	}

	public BspReader(Stream input)
	{
	    reader = new BinaryReader(input);
	}

	public BspReader(string filename)
	{
	    reader = new BinaryReader(new FileStream(filename, FileMode.Open));
	}

	public void Dispose()
	{
	    reader.Dispose();
	    disposed = true;
	}

	public BspInfo ReadInfo()
	{
	    ThrowExceptionIfDisposed();

	    if(cachedInfo == null)
		cachedInfo = RefreshInfo();

	    return cachedInfo;
	}

	private BspInfo RefreshInfo()
	{
	    BspInfo info = new BspInfo();

	    if(reader.BaseStream.Length < 1036)
		throw new FileFormatException();

	    reader.BaseStream.Position = 0;

	    info.Identifier = reader.ReadInt32();

	    if(info.Identifier != 0x50534256)
		throw new FileFormatException();

	    info.Version = reader.ReadInt32();

	    info.Lumps = new BspLumpInfo[64];
	    for(int i = 0; i < 64; i++)
		info.Lumps[i] = ReadLump();

	    info.MapRevision = reader.ReadInt32();

	    info.Compressed = false;
	    byte[] bytes = ReadLumpData(BspLumpType.LUMP_ENTITIES);
	    if(bytes.Length > 0 && bytes[0] == 0x4C && bytes[1] == 0x5A && bytes[2] == 0x4D && bytes[3] == 0x41)
		info.Compressed = true;

	    return info;
	}

	private BspLumpInfo ReadLump()
	{
	    BspLumpInfo lump = new BspLumpInfo();

	    lump.FileOffset = reader.ReadInt32();
	    lump.FileLength = reader.ReadInt32();
	    lump.Version = reader.ReadInt32();
	    lump.fourCC = reader.ReadInt32();

	    return lump;
	}

	public BspLumpInfo ReadLumpInfo(BspLumpType lumpType)
	{
	    return ReadLumpInfo((int)lumpType);
	}

	public BspLumpInfo ReadLumpInfo(int lumpId)
	{
	    ThrowExceptionIfDisposed();

	    if(cachedInfo != null)
		return cachedInfo.Lumps[lumpId];
	    else
	    {
		reader.BaseStream.Position = BspOffsets.CalculateLumpOffset(lumpId);
		return ReadLump();
	    }
	}

	public byte[] ReadLumpData(int lumpId)
	{
	    ThrowExceptionIfDisposed();

	    var lump = ReadLumpInfo(lumpId);

	    reader.BaseStream.Position = lump.FileOffset;
	    return reader.ReadBytes(lump.FileLength);
	}

	public byte[] ReadLumpData(BspLumpType lumpType)
	{
	    return ReadLumpData((int)lumpType);
	}

	private void ThrowExceptionIfDisposed()
	{
	    if(disposed)
		throw new ObjectDisposedException(nameof(BspReader));
	}
    }
}

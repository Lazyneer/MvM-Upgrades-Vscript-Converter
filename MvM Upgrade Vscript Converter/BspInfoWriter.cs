using System;
using System.IO;

namespace MvM_Upgrade_Vscript_Converter
{
    public class BspInfoWriter : IDisposable
    {
	private readonly BinaryWriter writer;
	private bool disposed = false;

	public BspInfoWriter(BinaryWriter writer)
	{
	    this.writer = writer;
	}

	public BspInfoWriter(Stream outputStream)
	{
	    writer = new BinaryWriter(outputStream);
	}

	public BspInfoWriter(string filename)
	{
	    writer = new BinaryWriter(new FileStream(filename, FileMode.Open));
	}

	public void Dispose()
	{
	    writer.Dispose();
	    disposed = true;
	}

	public void WriteInfo(BspInfo i)
	{
	    ThrowExceptionIfDisposed();

	    writer.BaseStream.Position = 0;

	    writer.Write(i.Identifier);
	    writer.Write(i.Version);

	    foreach(BspLumpInfo l in i.Lumps)
		WriteBspLumpInfo(l);

	    writer.Write(i.MapRevision);
	}

	private void WriteBspLumpInfo(BspLumpInfo info)
	{
	    ThrowExceptionIfDisposed();

	    writer.Write(info.FileOffset);
	    writer.Write(info.FileLength);
	    writer.Write(info.Version);
	    writer.Write(info.fourCC);
	}

	public void WriteBspLumpInfo(int lumpId, BspLumpInfo info)
	{
	    ThrowExceptionIfDisposed();

	    writer.BaseStream.Position = BspOffsets.CalculateLumpOffset(lumpId);
	    WriteBspLumpInfo(info);
	}

	public void WriteBspLumpInfo(BspLumpType lumpId, BspLumpInfo info)
	{
	    WriteBspLumpInfo((int)lumpId, info);
	}

	private void ThrowExceptionIfDisposed()
	{
	    if(disposed)
		throw new ObjectDisposedException(nameof(BspInfoWriter));
	}
    }
}

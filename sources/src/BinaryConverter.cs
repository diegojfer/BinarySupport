using System;

namespace FoolishTech.Support.Binary
{
    public static class BinaryConverter
    {
        public enum Endianess 
        {
            SystemEndian,
            LittleEndian,
            BigEndian
        }

		public static SByte ReadInt8(byte[] buffer) => ReadInt8(new ReadOnlyMemory<byte>(buffer));
		public static SByte ReadInt8(ReadOnlyMemory<byte> buffer) => ReadInt8(buffer.Span);
		public static SByte ReadInt8(ReadOnlySpan<byte> buffer)	
		{
			if (buffer.Length != 1) throw new ArgumentException(nameof(buffer), "Invalid buffer length. The length must be the same of target integer.");
	
			return (SByte)buffer.ToArray()[0];
		}
		public static byte[] WriteInt8(SByte integer) => new byte[] { (byte)integer };

		public static Byte ReadUInt8(byte[] buffer) => ReadUInt8(new ReadOnlyMemory<byte>(buffer));
		public static Byte ReadUInt8(ReadOnlyMemory<byte> buffer) => ReadUInt8(buffer.Span);
		public static Byte ReadUInt8(ReadOnlySpan<byte> buffer)
		{
			if (buffer.Length != 1) throw new ArgumentException(nameof(buffer), "Invalid buffer length. The length must be the same of target integer.");
	
			return (Byte)buffer.ToArray()[0];
		}
		public static byte[] WriteUInt8(Byte integer) => new byte[] { integer };

    }   
}

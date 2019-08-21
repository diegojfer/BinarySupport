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

		public static Int16 ReadInt16(byte[] buffer, Endianess endianess = Endianess.SystemEndian) => ReadInt16(new ReadOnlyMemory<byte>(buffer), endianess);
		public static Int16 ReadInt16(ReadOnlyMemory<byte> buffer, Endianess endianess = Endianess.SystemEndian) => ReadInt16(buffer.Span, endianess);
		public static Int16 ReadInt16(ReadOnlySpan<byte> buffer, Endianess endianess = Endianess.SystemEndian)
		{
			if (buffer.Length != 2) throw new ArgumentException(nameof(buffer), "Invalid buffer length. The length must be the same of target integer.");
			
			if (ShouldReverseBytes(endianess)) {
				var span = new Span<byte>(new byte[2]);
				buffer.CopyTo(span);
				span.Reverse();
				return BitConverter.ToInt16(span);
			} else {
				return BitConverter.ToInt16(buffer);
			}
		}
		public static byte[] WriteInt16(Int16 integer, Endianess endianess = Endianess.SystemEndian) 
		{
			byte[] buffer = BitConverter.GetBytes(integer);

			if (ShouldReverseBytes(endianess)) {
				var span = new Span<byte>(buffer); 
				span.Reverse();
				buffer = span.ToArray();
			}
			
			return buffer;
		}

		public static UInt16 ReadUInt16(byte[] buffer, Endianess endianess = Endianess.SystemEndian) => ReadUInt16(new ReadOnlyMemory<byte>(buffer), endianess);
		public static UInt16 ReadUInt16(ReadOnlyMemory<byte> buffer, Endianess endianess = Endianess.SystemEndian) => ReadUInt16(buffer.Span, endianess);
		public static UInt16 ReadUInt16(ReadOnlySpan<byte> buffer, Endianess endianess = Endianess.SystemEndian)
		{
			if (buffer.Length != 2) throw new ArgumentException(nameof(buffer), "Invalid buffer length. The length must be the same of target integer.");
			
			if (ShouldReverseBytes(endianess)) {
				var span = new Span<byte>(new byte[2]);
				buffer.CopyTo(span);
				span.Reverse();
				return BitConverter.ToUInt16(span);
			} else {
				return BitConverter.ToUInt16(buffer);
			}
		}
		public static byte[] WriteUInt16(UInt16 integer, Endianess endianess = Endianess.SystemEndian) 
		{
			byte[] buffer = BitConverter.GetBytes(integer);

			if (ShouldReverseBytes(endianess)) {
				var span = new Span<byte>(buffer); 
				span.Reverse();
				buffer = span.ToArray();
			}
			
			return buffer;
		}

        private static bool ShouldReverseBytes(Endianess endianess) 
        {
            if (endianess == Endianess.SystemEndian) return false;
            if (endianess == Endianess.LittleEndian && BitConverter.IsLittleEndian == false) return true;
            if (endianess == Endianess.LittleEndian && BitConverter.IsLittleEndian == true) return false;
            if (endianess == Endianess.BigEndian && BitConverter.IsLittleEndian == false) return false;
            if (endianess == Endianess.BigEndian && BitConverter.IsLittleEndian == true) return true;
             
            throw new ArgumentException(nameof(endianess), $"Endianness should be [{nameof(Endianess.SystemEndian)}, {nameof(Endianess.LittleEndian)} or {nameof(Endianess.BigEndian)}].");
        }
    }   
}

using System;
using NUnit.Framework;

namespace FoolishTech.Support.Binary.BinarySupport
{
    public class Size16Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Signed_CheckBufferLengthInvalid()
        {
            var buffer = new byte[0];

            Assert.Throws<ArgumentException>(() => BinaryConverter.ReadInt16(buffer));
            Assert.Throws<ArgumentException>(() => BinaryConverter.ReadInt16(new ReadOnlyMemory<byte>(buffer)));
            Assert.Throws<ArgumentException>(() => BinaryConverter.ReadInt16(new ReadOnlySpan<byte>(buffer)));
        }

        [Test]
        public void Signed_CheckBufferLengthValid()
        {
            var buffer = new byte[2];

            Assert.DoesNotThrow(() => BinaryConverter.ReadInt16(buffer));
            Assert.DoesNotThrow(() => BinaryConverter.ReadInt16(new ReadOnlyMemory<byte>(buffer)));
            Assert.DoesNotThrow(() => BinaryConverter.ReadInt16(new ReadOnlySpan<byte>(buffer)));
        }

        [Test]
        public void Signed_CheckReadBEValueValid()
        {
            var buffer = new byte[] { 0xFF, 0x00 };

            Assert.AreEqual(BinaryConverter.ReadInt16(buffer, BinaryConverter.Endianess.BigEndian), -256);
            Assert.AreEqual(BinaryConverter.ReadInt16(new ReadOnlyMemory<byte>(buffer), BinaryConverter.Endianess.BigEndian), -256);
            Assert.AreEqual(BinaryConverter.ReadInt16(new ReadOnlySpan<byte>(buffer), BinaryConverter.Endianess.BigEndian), -256);
        }

        [Test]
        public void Signed_CheckReadLEValueValid()
        {
            var buffer = new byte[] { 0xFF, 0x00 };

            Assert.AreEqual(BinaryConverter.ReadInt16(buffer, BinaryConverter.Endianess.LittleEndian), 255);
            Assert.AreEqual(BinaryConverter.ReadInt16(new ReadOnlyMemory<byte>(buffer), BinaryConverter.Endianess.LittleEndian), 255);
            Assert.AreEqual(BinaryConverter.ReadInt16(new ReadOnlySpan<byte>(buffer), BinaryConverter.Endianess.LittleEndian), 255);
        }

        [Test]
        public void Signed_CheckWriteBEValueValid()
        {
            Int16 value = -256;

            Assert.AreEqual(BinaryConverter.WriteInt16(value, BinaryConverter.Endianess.BigEndian), new byte[] { 0xFF, 0x00 });
        }

        [Test]
        public void Signed_CheckWriteLEValueValid()
        {
            Int16 value = 255;

            Assert.AreEqual(BinaryConverter.WriteInt16(value, BinaryConverter.Endianess.LittleEndian), new byte[] { 0xFF, 0x00 });
        }
        
        [Test]
        public void Unsigned_CheckBufferLengthInvalid()
        {
            var buffer = new byte[0];

            Assert.Throws<ArgumentException>(() => BinaryConverter.ReadUInt16(buffer));
            Assert.Throws<ArgumentException>(() => BinaryConverter.ReadUInt16(new ReadOnlyMemory<byte>(buffer)));
            Assert.Throws<ArgumentException>(() => BinaryConverter.ReadUInt16(new ReadOnlySpan<byte>(buffer)));
        }

        [Test]
        public void Unsigned_CheckBufferLengthValid()
        {
            var buffer = new byte[2];

            Assert.DoesNotThrow(() => BinaryConverter.ReadUInt16(buffer));
            Assert.DoesNotThrow(() => BinaryConverter.ReadUInt16(new ReadOnlyMemory<byte>(buffer)));
            Assert.DoesNotThrow(() => BinaryConverter.ReadUInt16(new ReadOnlySpan<byte>(buffer)));
        }

        [Test]
        public void Unsigned_CheckReadBEValueValid()
        {
            var buffer = new byte[] { 0xFF, 0x00 };

            Assert.AreEqual(BinaryConverter.ReadUInt16(buffer, BinaryConverter.Endianess.BigEndian), 65280);
            Assert.AreEqual(BinaryConverter.ReadUInt16(new ReadOnlyMemory<byte>(buffer), BinaryConverter.Endianess.BigEndian), 65280);
            Assert.AreEqual(BinaryConverter.ReadUInt16(new ReadOnlySpan<byte>(buffer), BinaryConverter.Endianess.BigEndian), 65280);
        }

        [Test]
        public void Unsigned_CheckReadLEValueValid()
        {
            var buffer = new byte[] { 0xFF, 0x00 };

            Assert.AreEqual(BinaryConverter.ReadUInt16(buffer, BinaryConverter.Endianess.LittleEndian), 255);
            Assert.AreEqual(BinaryConverter.ReadUInt16(new ReadOnlyMemory<byte>(buffer), BinaryConverter.Endianess.LittleEndian), 255);
            Assert.AreEqual(BinaryConverter.ReadUInt16(new ReadOnlySpan<byte>(buffer), BinaryConverter.Endianess.LittleEndian), 255);
        }

        [Test]
        public void Unsigned_CheckWriteBEValueValid()
        {
            UInt16 value = 65280;

            Assert.AreEqual(BinaryConverter.WriteUInt16(value, BinaryConverter.Endianess.BigEndian), new byte[] { 0xFF, 0x00 });
        }

        [Test]
        public void Unsigned_CheckWriteLEValueValid()
        {
            UInt16 value = 255;

            Assert.AreEqual(BinaryConverter.WriteUInt16(value, BinaryConverter.Endianess.LittleEndian), new byte[] { 0xFF, 0x00 });
        }
    }
}
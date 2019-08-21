using System;
using NUnit.Framework;

using FoolishTech.Support.Binary;

namespace FoolishTech.Support.Binary.BinarySupport
{
    public class Size32Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Signed_CheckBufferLengthInvalid()
        {
            var buffer = new byte[0];

            Assert.Throws<ArgumentException>(() => BinaryConverter.ReadInt32(buffer));
            Assert.Throws<ArgumentException>(() => BinaryConverter.ReadInt32(new ReadOnlyMemory<byte>(buffer)));
            Assert.Throws<ArgumentException>(() => BinaryConverter.ReadInt32(new ReadOnlySpan<byte>(buffer)));
        }

        [Test]
        public void Signed_CheckBufferLengthValid()
        {
            var buffer = new byte[4];

            Assert.DoesNotThrow(() => BinaryConverter.ReadInt32(buffer));
            Assert.DoesNotThrow(() => BinaryConverter.ReadInt32(new ReadOnlyMemory<byte>(buffer)));
            Assert.DoesNotThrow(() => BinaryConverter.ReadInt32(new ReadOnlySpan<byte>(buffer)));
        }

        [Test]
        public void Signed_CheckReadBEValueValid()
        {
            var buffer = new byte[] { 0xFF, 0x00, 0x00, 0x00 };

            Assert.AreEqual(BinaryConverter.ReadInt32(buffer, BinaryConverter.Endianess.BigEndian), -16777216);
            Assert.AreEqual(BinaryConverter.ReadInt32(new ReadOnlyMemory<byte>(buffer), BinaryConverter.Endianess.BigEndian), -16777216);
            Assert.AreEqual(BinaryConverter.ReadInt32(new ReadOnlySpan<byte>(buffer), BinaryConverter.Endianess.BigEndian), -16777216);
        }

        [Test]
        public void Signed_CheckReadLEValueValid()
        {
            var buffer = new byte[] { 0xFF, 0x00, 0x00, 0x00 };

            Assert.AreEqual(BinaryConverter.ReadInt32(buffer, BinaryConverter.Endianess.LittleEndian), 255);
            Assert.AreEqual(BinaryConverter.ReadInt32(new ReadOnlyMemory<byte>(buffer), BinaryConverter.Endianess.LittleEndian), 255);
            Assert.AreEqual(BinaryConverter.ReadInt32(new ReadOnlySpan<byte>(buffer), BinaryConverter.Endianess.LittleEndian), 255);
        }

        [Test]
        public void Signed_CheckWriteBEValueValid()
        {
            Int32 value = -16777216;

            Assert.AreEqual(BinaryConverter.WriteInt32(value, BinaryConverter.Endianess.BigEndian), new byte[] { 0xFF, 0x00, 0x00, 0x00 });
        }

        [Test]
        public void Signed_CheckWriteLEValueValid()
        {
            Int32 value = 255;

            Assert.AreEqual(BinaryConverter.WriteInt32(value, BinaryConverter.Endianess.LittleEndian), new byte[] { 0xFF, 0x00, 0x00, 0x00 });
        }

        [Test]
        public void Unsigned_CheckBufferLengthInvalid()
        {
            var buffer = new byte[0];

            Assert.Throws<ArgumentException>(() => BinaryConverter.ReadUInt32(buffer));
            Assert.Throws<ArgumentException>(() => BinaryConverter.ReadUInt32(new ReadOnlyMemory<byte>(buffer)));
            Assert.Throws<ArgumentException>(() => BinaryConverter.ReadUInt32(new ReadOnlySpan<byte>(buffer)));
        }

        [Test]
        public void Unsigned_CheckBufferLengthValid()
        {
            var buffer = new byte[4];

            Assert.DoesNotThrow(() => BinaryConverter.ReadUInt32(buffer));
            Assert.DoesNotThrow(() => BinaryConverter.ReadUInt32(new ReadOnlyMemory<byte>(buffer)));
            Assert.DoesNotThrow(() => BinaryConverter.ReadUInt32(new ReadOnlySpan<byte>(buffer)));
        }

        [Test]
        public void Unsigned_CheckReadBEValueValid()
        {
            var buffer = new byte[] { 0xFF, 0x00, 0x00, 0x00 };

            Assert.AreEqual(BinaryConverter.ReadUInt32(buffer, BinaryConverter.Endianess.BigEndian), 4278190080);
            Assert.AreEqual(BinaryConverter.ReadUInt32(new ReadOnlyMemory<byte>(buffer), BinaryConverter.Endianess.BigEndian), 4278190080);
            Assert.AreEqual(BinaryConverter.ReadUInt32(new ReadOnlySpan<byte>(buffer), BinaryConverter.Endianess.BigEndian), 4278190080);
        }

        [Test]
        public void Unsigned_CheckReadLEValueValid()
        {
            var buffer = new byte[] { 0xFF, 0x00, 0x00, 0x00 };

            Assert.AreEqual(BinaryConverter.ReadUInt32(buffer, BinaryConverter.Endianess.LittleEndian), 255);
            Assert.AreEqual(BinaryConverter.ReadUInt32(new ReadOnlyMemory<byte>(buffer), BinaryConverter.Endianess.LittleEndian), 255);
            Assert.AreEqual(BinaryConverter.ReadUInt32(new ReadOnlySpan<byte>(buffer), BinaryConverter.Endianess.LittleEndian), 255);
        }

        [Test]
        public void Unsigned_CheckWriteBEValueValid()
        {
            UInt32 value = 4278190080;

            Assert.AreEqual(BinaryConverter.WriteUInt32(value, BinaryConverter.Endianess.BigEndian), new byte[] { 0xFF, 0x00, 0x00, 0x00 });
        }

        [Test]
        public void Unsigned_CheckWriteLEValueValid()
        {
            UInt32 value = 255;

            Assert.AreEqual(BinaryConverter.WriteUInt32(value, BinaryConverter.Endianess.LittleEndian), new byte[] { 0xFF, 0x00, 0x00, 0x00 });
        }
    }
}
using System;
using NUnit.Framework;

using FoolishTech.Support.Binary;

namespace FoolishTech.Support.Binary.BinarySupport
{
    public class Size64Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Signed_CheckBufferLengthInvalid()
        {
            var buffer = new byte[0];

            Assert.Throws<ArgumentException>(() => BinaryConverter.ReadInt64(buffer));
            Assert.Throws<ArgumentException>(() => BinaryConverter.ReadInt64(new ReadOnlyMemory<byte>(buffer)));
            Assert.Throws<ArgumentException>(() => BinaryConverter.ReadInt64(new ReadOnlySpan<byte>(buffer)));
        }

        [Test]
        public void Signed_CheckBufferLengthValid()
        {
            var buffer = new byte[8];

            Assert.DoesNotThrow(() => BinaryConverter.ReadInt64(buffer));
            Assert.DoesNotThrow(() => BinaryConverter.ReadInt64(new ReadOnlyMemory<byte>(buffer)));
            Assert.DoesNotThrow(() => BinaryConverter.ReadInt64(new ReadOnlySpan<byte>(buffer)));
        }

        [Test]
        public void Signed_CheckReadBEValueValid()
        {
            var buffer = new byte[] { 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            Assert.AreEqual(BinaryConverter.ReadInt64(buffer, BinaryConverter.Endianess.BigEndian), -72057594037927936);
            Assert.AreEqual(BinaryConverter.ReadInt64(new ReadOnlyMemory<byte>(buffer), BinaryConverter.Endianess.BigEndian), -72057594037927936);
            Assert.AreEqual(BinaryConverter.ReadInt64(new ReadOnlySpan<byte>(buffer), BinaryConverter.Endianess.BigEndian), -72057594037927936);
        }

        [Test]
        public void Signed_CheckReadLEValueValid()
        {
            var buffer = new byte[] { 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            Assert.AreEqual(BinaryConverter.ReadInt64(buffer, BinaryConverter.Endianess.LittleEndian), 255);
            Assert.AreEqual(BinaryConverter.ReadInt64(new ReadOnlyMemory<byte>(buffer), BinaryConverter.Endianess.LittleEndian), 255);
            Assert.AreEqual(BinaryConverter.ReadInt64(new ReadOnlySpan<byte>(buffer), BinaryConverter.Endianess.LittleEndian), 255);
        }

        [Test]
        public void Signed_CheckWriteBEValueValid()
        {
            Int64 value = -72057594037927936;

            Assert.AreEqual(BinaryConverter.WriteInt64(value, BinaryConverter.Endianess.BigEndian), new byte[] { 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
        }

        [Test]
        public void Signed_CheckWriteLEValueValid()
        {
            Int64 value = 255;

            Assert.AreEqual(BinaryConverter.WriteInt64(value, BinaryConverter.Endianess.LittleEndian), new byte[] { 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
        }

        [Test]
        public void Unsigned_CheckBufferLengthInvalid()
        {
            var buffer = new byte[0];

            Assert.Throws<ArgumentException>(() => BinaryConverter.ReadUInt64(buffer));
            Assert.Throws<ArgumentException>(() => BinaryConverter.ReadUInt64(new ReadOnlyMemory<byte>(buffer)));
            Assert.Throws<ArgumentException>(() => BinaryConverter.ReadUInt64(new ReadOnlySpan<byte>(buffer)));
        }

        [Test]
        public void Unsigned_CheckBufferLengthValid()
        {
            var buffer = new byte[8];

            Assert.DoesNotThrow(() => BinaryConverter.ReadUInt64(buffer));
            Assert.DoesNotThrow(() => BinaryConverter.ReadUInt64(new ReadOnlyMemory<byte>(buffer)));
            Assert.DoesNotThrow(() => BinaryConverter.ReadUInt64(new ReadOnlySpan<byte>(buffer)));
        }

        [Test]
        public void Unsigned_CheckReadBEValueValid()
        {
            var buffer = new byte[] { 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            Assert.AreEqual(BinaryConverter.ReadUInt64(buffer, BinaryConverter.Endianess.BigEndian), 18374686479671623680);
            Assert.AreEqual(BinaryConverter.ReadUInt64(new ReadOnlyMemory<byte>(buffer), BinaryConverter.Endianess.BigEndian), 18374686479671623680);
            Assert.AreEqual(BinaryConverter.ReadUInt64(new ReadOnlySpan<byte>(buffer), BinaryConverter.Endianess.BigEndian), 18374686479671623680);
        }

        [Test]
        public void Unsigned_CheckReadLEValueValid()
        {
            var buffer = new byte[] { 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };

            Assert.AreEqual(BinaryConverter.ReadUInt64(buffer, BinaryConverter.Endianess.LittleEndian), 255);
            Assert.AreEqual(BinaryConverter.ReadUInt64(new ReadOnlyMemory<byte>(buffer), BinaryConverter.Endianess.LittleEndian), 255);
            Assert.AreEqual(BinaryConverter.ReadUInt64(new ReadOnlySpan<byte>(buffer), BinaryConverter.Endianess.LittleEndian), 255);
        }

        [Test]
        public void Unsigned_CheckWriteBEValueValid()
        {
            UInt64 value = 18374686479671623680;

            Assert.AreEqual(BinaryConverter.WriteUInt64(value, BinaryConverter.Endianess.BigEndian), new byte[] { 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
        }

        [Test]
        public void Unsigned_CheckWriteLEValueValid()
        {
            UInt64 value = 255;

            Assert.AreEqual(BinaryConverter.WriteUInt64(value, BinaryConverter.Endianess.LittleEndian), new byte[] { 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 });
        }
    }
}
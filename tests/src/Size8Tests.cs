using System;
using NUnit.Framework;

using FoolishTech.Support.Binary;

namespace FoolishTech.Support.Binary.BinarySupport
{
    public class Size8Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Signed_CheckBufferLengthInvalid()
        {
            var buffer = new byte[0];

            Assert.Throws<ArgumentException>(() => BinaryConverter.ReadInt8(buffer));
            Assert.Throws<ArgumentException>(() => BinaryConverter.ReadInt8(new ReadOnlyMemory<byte>(buffer)));
            Assert.Throws<ArgumentException>(() => BinaryConverter.ReadInt8(new ReadOnlySpan<byte>(buffer)));
        }

        [Test]
        public void Signed_CheckBufferLengthValid()
        {
            var buffer = new byte[1];

            Assert.DoesNotThrow(() => BinaryConverter.ReadInt8(buffer));
            Assert.DoesNotThrow(() => BinaryConverter.ReadInt8(new ReadOnlyMemory<byte>(buffer)));
            Assert.DoesNotThrow(() => BinaryConverter.ReadInt8(new ReadOnlySpan<byte>(buffer)));
        }

        [Test]
        public void Signed_CheckReadValueValid()
        {
            var buffer = new byte[] { 0xFF };

            Assert.AreEqual(BinaryConverter.ReadInt8(buffer), -1);
            Assert.AreEqual(BinaryConverter.ReadInt8(new ReadOnlyMemory<byte>(buffer)), -1);
            Assert.AreEqual(BinaryConverter.ReadInt8(new ReadOnlySpan<byte>(buffer)), -1);
        }

        [Test]
        public void Signed_CheckWriteValueValid()
        {
            SByte value = -1;

            Assert.AreEqual(BinaryConverter.WriteInt8(value), new byte[] { 0xFF });
        }

        [Test]
        public void Unsigned_CheckBufferLengthInvalid()
        {
            var buffer = new byte[0];

            Assert.Throws<ArgumentException>(() => BinaryConverter.ReadUInt8(buffer));
            Assert.Throws<ArgumentException>(() => BinaryConverter.ReadUInt8(new ReadOnlyMemory<byte>(buffer)));
            Assert.Throws<ArgumentException>(() => BinaryConverter.ReadUInt8(new ReadOnlySpan<byte>(buffer)));
        }

        [Test]
        public void Unsigned_CheckBufferLengthValid()
        {
            var buffer = new byte[1];

            Assert.DoesNotThrow(() => BinaryConverter.ReadUInt8(buffer));
            Assert.DoesNotThrow(() => BinaryConverter.ReadUInt8(new ReadOnlyMemory<byte>(buffer)));
            Assert.DoesNotThrow(() => BinaryConverter.ReadUInt8(new ReadOnlySpan<byte>(buffer)));
        }

        [Test]
        public void Unsigned_CheckReadValueValid()
        {
            var buffer = new byte[] { 0xFF };

            Assert.AreEqual(BinaryConverter.ReadUInt8(buffer), 255);
            Assert.AreEqual(BinaryConverter.ReadUInt8(new ReadOnlyMemory<byte>(buffer)), 255);
            Assert.AreEqual(BinaryConverter.ReadUInt8(new ReadOnlySpan<byte>(buffer)), 255);
        }

        [Test]
        public void Unsigned_CheckWriteValueValid()
        {
            Byte value = 255;

            Assert.AreEqual(BinaryConverter.WriteUInt8(value), new byte[] { 0xFF });
        }
    }
}
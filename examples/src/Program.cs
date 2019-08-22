using System;

using FoolishTech.Support.Binary;

namespace BinarySupportExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Hello World! We are parsing 0xFF00 to 255 on LE: {BinaryConverter.ReadInt16(new byte[] { 0xFF, 0x00 }, BinaryConverter.Endianess.LittleEndian)}");
        }
    }
}

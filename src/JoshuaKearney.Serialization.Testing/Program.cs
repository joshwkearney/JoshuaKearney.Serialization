﻿using System;
using System.Text;

namespace JoshuaKearney.Serialization.Testing {
    class Program {
        static void Main(string[] args) {
            var writer = new ArraySerializer();

            writer.WriteSectors(
                wr => {
                    wr.Write(45);
                    wr.Write("some");
                    wr.Write(89);
                },
                wr => {
                    wr.Write("last");
                    wr.Write(int.MaxValue);
                }
            );

            var reader = new ArrayDeserializer(writer.Close());
            var sectors = reader.ReadSectors();

            Console.WriteLine(sectors[0].ReadInt32());
            Console.WriteLine(sectors[0].ReadString());
            Console.WriteLine(sectors[0].ReadInt32());

            Console.WriteLine(sectors[1].ReadString());
            Console.WriteLine(sectors[1].ReadInt32());

            Console.Read();
        }
    }
}
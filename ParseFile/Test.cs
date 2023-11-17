using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ParseFile
{
    [MemoryDiagnoser]
    [RankColumn]
    public class Test
    {
        string inputPath = "D:\\Learning\\Projects\\ParseFile\\ParseFile\\Files\\257.csv";
        string outputPath = "D:\\Learning\\Projects\\ParseFile\\ParseFile\\Files\\result.txt";
        string link = "https://drive.google.com/uc?export=download&id=1ZQBgouAZ5pfHkleQLNRKquTxrQqDDiN7";
        string filePath = @"D:\\Learning\\Projects\\ParseFile\\ParseFile\\Files\\257.csv";

        [Benchmark]
        public void testReadOnlySpan()
        {
            using StreamReader reader = new StreamReader(inputPath);
            using StreamWriter writer = new StreamWriter(outputPath, false);
            writer.WriteLine("Name".PadLeft(5) + "CellId".PadLeft(10) + "lon".PadLeft(17) + "lan".PadLeft(17));
            ReadOnlySpan<char> str;
            ReadOnlySpan<char> extracted;
            int count = 0;
            int startIndex = 0;
            while ((str = reader.ReadLine()) != null)
            {
                count = 0;
                startIndex = 0;

                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == ',')
                    {
                        count++;
                        if (count == 1 || count == 5 || count == 7 || count == 8)
                        {
                            extracted = str.Slice(startIndex, i - startIndex);
                            writer.Write(extracted);
                            writer.Write("\t\t");
                        }
                        startIndex = i + 1;
                    }
                }
                writer.WriteLine("");
            }
        }
        [Benchmark]
        public void testBuffer()
        {
            using FileStream reader = new FileStream(inputPath, FileMode.Open, FileAccess.Read);
            //using FileStream writer = new FileStream(outputPath, FileMode.OpenOrCreate, FileAccess.Write);
            using StreamWriter writer = new StreamWriter(outputPath, false);
            byte[] buffer = new byte[reader.Length];
            reader.Read(buffer, 0, buffer.Length);
            int index = 0;
            int startIndex = 0;
            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer[i] == 10)
                {
                    index = 0;
                    for (int j = startIndex; j < i; j++)
                    {
                        if (buffer[j] == 44)
                        {
                            index++;
                            if (index == 1 || index == 5 || index == 7 || index == 8)
                            {
                                ArraySegment<byte> segment = new ArraySegment<byte>(buffer, startIndex, j - startIndex);
                                foreach(var a in segment)
                                {
                                    writer.Write((char)a);
                                }
                                writer.Write("\t\t");
                            }
                            startIndex = j + 1;
                        }
                    }
                    startIndex = i + 1;
                    writer.WriteLine("");
                }
            }
        }
        [Benchmark]
        public void parseOptimization()
        {
            using FileStream reader = new FileStream("D:\\Learning\\Projects\\ParseFile\\ParseFile\\Files\\257.csv", FileMode.Open, FileAccess.Read);
            using StreamWriter writer = new StreamWriter("D:\\Learning\\Projects\\ParseFile\\ParseFile\\Files\\result.txt", false);
            byte[] buffer = new byte[reader.Length];
            reader.Read(buffer, 0, buffer.Length);
            ReadOnlySpan<char> content = Encoding.UTF8.GetString(buffer);
            int index = 0;
            int startIndex = 0;
            ReadOnlySpan<char> extracted;
            for (int i = 0; i < content.Length; i++)
            {
                if (content[i] == '\n')
                {
                    index = 0;
                    for (int j = startIndex; j < i; j++)
                    {
                        if (content[j] == ',')
                        {
                            index++;
                            if (index == 1 || index == 5 || index == 7 || index == 8)
                            {
                                extracted = content.Slice(startIndex, j - startIndex);
                                writer.Write(extracted);
                                writer.Write("\t\t");
                            }
                            startIndex = j + 1;
                        }
                    }
                    startIndex = i + 1;
                    writer.WriteLine("");
                }
            }
        }
        [Benchmark]
        public void parse()
        {
            using StreamReader reader = new StreamReader("D:\\Learning\\Projects\\ParseFile\\ParseFile\\Files\\257.csv");
            using StreamWriter writer = new StreamWriter("D:\\Learning\\Projects\\ParseFile\\ParseFile\\Files\\result.txt", false);
            StringBuilder builder = new StringBuilder("");
            writer.WriteLine("Name".PadLeft(5) + "CellId".PadLeft(10) + "lon".PadLeft(17) + "lan".PadLeft(17));
            ReadOnlySpan<char> str;
            ReadOnlySpan<char> extracted;
            int count = 0;
            int startIndex = 0;
            while ((str = reader.ReadLine()) != null)
            {
                count = 0;
                startIndex = 0;

                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == ',')
                    {
                        count++;
                        if (count == 1 || count == 5 || count == 7 || count == 8)
                        {
                            extracted = str.Slice(startIndex, i - startIndex);
                            builder.Append(extracted);
                            builder.Append("\t\t");
                        }
                        startIndex = i + 1;
                    }
                }
                builder.AppendLine("");
            }
            writer.WriteLine(builder);
        }
        [Benchmark]
        public void parseOptimization2()
        {
            using FileStream reader = new FileStream("D:\\Learning\\Projects\\ParseFile\\ParseFile\\Files\\257.csv", FileMode.Open, FileAccess.Read);
            using FileStream writer = new FileStream("D:\\Learning\\Projects\\ParseFile\\ParseFile\\Files\\result.txt", FileMode.OpenOrCreate, FileAccess.Write);
            byte[] buffer = new byte[reader.Length];
            reader.Read(buffer, 0, buffer.Length);
            int index = 0;
            int startIndex = 0;
            byte[] newLine = Encoding.Default.GetBytes("\n");
            byte[] tabulation = Encoding.Default.GetBytes("\t\t");
            for (int i = 0; i < buffer.Length; i++)
            {
                if (buffer[i] == 10)
                {
                    index = 0;
                    for (int j = startIndex; j < i; j++)
                    {
                        if (buffer[j] == 44)
                        {
                            index++;
                            if (index == 1 || index == 5 || index == 7 || index == 8)
                            {
                                ArraySegment<byte> segment = new ArraySegment<byte>(buffer, startIndex, j - startIndex);
                                writer.Write(segment);
                                writer.Write(tabulation);
                            }
                            startIndex = j + 1;
                        }
                    }
                    startIndex = i + 1;
                    writer.Write(newLine);
                }
            }
        }
    }
}

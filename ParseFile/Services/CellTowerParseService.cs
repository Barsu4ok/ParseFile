using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParseFile.Services.Interfaces;
using BenchmarkDotNet;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace ParseFile.Services
{
    [MemoryDiagnoser]
    [RankColumn]
    public class CellTowerParseService : IParseService
    {
        [Benchmark]
        public void parse(string inputPath, string outputPath)
        {
            using StreamReader reader = new StreamReader(inputPath);
            using StreamWriter writer = new StreamWriter(outputPath, false);
            StringBuilder builder = new StringBuilder("");
            writer.WriteLine("Name".PadLeft(5) + "CellId".PadLeft(10) + "lon".PadLeft(17) + "lan".PadLeft(17));
            string? str;
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
                            string extracted = str.Substring(startIndex, i - startIndex);
                            builder.Append(extracted + "\t\t");
                        }
                        startIndex = i + 1;
                    }
                }
                builder.AppendLine("");
            }
            writer.WriteLine(builder);
        }
    }
}

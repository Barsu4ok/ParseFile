using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ParseFile.Services.Interfaces;

namespace ParseFile.Services
{
    internal class CellTowerParseService : IParseService
    {
        public async void parse(string inputFilePath, string outputFilePath)
        {
            using StreamReader reader = new StreamReader(inputFilePath);
            using StreamWriter writer = new StreamWriter(outputFilePath, false);

            writer.WriteLine("Name".PadLeft(5) + "CellId".PadLeft(10) + "lon".PadLeft(17) + "lan".PadLeft(17) + "\n");
            string? str;
            while ((str = reader.ReadLine()) != null)
            {
                string[] arr = str.Split(',');
                if (arr[0] == "GSM" || arr[0] == "UMTS")
                {
                     writer.WriteLine(arr[0].PadLeft(5) + arr[4].PadLeft(10) + arr[6].PadLeft(17) + arr[7].PadLeft(17));
                }
            }
        }
    }
}

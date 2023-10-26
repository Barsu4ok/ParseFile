using ParseFile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseFile
{
    internal class Parser 
    {
        IParseService? cellTowerParseService;

        public Parser(IParseService? parseService)
        {
            this.cellTowerParseService = parseService;
        }

        public void parseFile(string inputFilePath, string outputFilePath)
        {
            cellTowerParseService?.parse(inputFilePath, outputFilePath);
        }
    }
}

using ParseFile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseFile
{
    class Parser 
    {
        IParseService? cellTowerParseService;

        public Parser(IParseService? parseService)
        {
            this.cellTowerParseService = parseService;
        }

        public void parseFile(string inputPath, string outputPath)
        {
            cellTowerParseService?.parse(inputPath, outputPath);
        }
    }
}

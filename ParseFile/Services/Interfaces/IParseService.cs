using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseFile.Services.Interfaces
{
    internal interface IParseService
    {
        public void parse(string inputFilePath, string outputFilePath);
    }
}

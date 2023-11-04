using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseFile.Services.Interfaces
{
    interface IParseService
    {
        public void parse(string inputPath, string outputPath);
    }
}

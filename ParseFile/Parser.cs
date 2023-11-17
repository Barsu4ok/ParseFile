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
        private IParseService cellTowerParseService;
        private IDownloadService downloadService;


        public Parser(IParseService parseService, IDownloadService downloadService)
        {
            this.cellTowerParseService = parseService;
            this.downloadService = downloadService;
        }

        public void parseFile(string uri, string outputPath)
        {
            cellTowerParseService.parse(downloadService.download(uri),outputPath);
        }
    }
}

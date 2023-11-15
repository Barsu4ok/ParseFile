using ParseFile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseFile
{
    class Loader
    {
        private IDownloadService? downloadService;

        public Loader(IDownloadService downloadService)
        {
            this.downloadService = downloadService;
        }
        
        public void downloadFile(string uri, string filePath)
        {
            downloadService?.download(uri, filePath);
        }
    }
}

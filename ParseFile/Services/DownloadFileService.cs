using ParseFile.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParseFile.Services
{
    class DownloadFileService : IDownloadService
    {
        public void download(string uri,string filePath)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(new Uri(uri), filePath);
            }
        }
    }
}

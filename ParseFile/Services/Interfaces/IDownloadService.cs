using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseFile.Services.Interfaces
{
    interface IDownloadService
    {
        public void download(string uri,string filePath);
    }
}

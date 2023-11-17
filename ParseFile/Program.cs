using System.Reflection.PortableExecutable;
using Microsoft.Extensions.DependencyInjection;
using ParseFile.Services.Interfaces;
using ParseFile.Services;
using ParseFile;
using BenchmarkDotNet;
using BenchmarkDotNet.Running;
using System.Net;

//BenchmarkRunner.Run<Test>();
string outputPath = "D:\\Learning\\Projects\\ParseFile\\ParseFile\\Files\\result.txt";
string uri = "https://drive.google.com/uc?export=download&id=1ZQBgouAZ5pfHkleQLNRKquTxrQqDDiN7";


var services = new ServiceCollection()
    .AddTransient<IParseService, CellTowerParseService>()
    .AddTransient<IDownloadService,DownloadFileService>()
    .AddTransient<Parser>();


using var serviceProvider = services.BuildServiceProvider();

var parser = serviceProvider.GetService<Parser>();

parser.parseFile(uri, outputPath);












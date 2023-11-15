using System.Reflection.PortableExecutable;
using Microsoft.Extensions.DependencyInjection;
using ParseFile.Services.Interfaces;
using ParseFile.Services;
using ParseFile;
using BenchmarkDotNet;
using BenchmarkDotNet.Running;
using System.Net;

//BenchmarkRunner.Run<Test>();
string inputPath = "D:\\Learning\\Projects\\ParseFile\\ParseFile\\Files\\257.csv";
string outputPath = "D:\\Learning\\Projects\\ParseFile\\ParseFile\\Files\\result.txt";
string link = "https://drive.google.com/uc?export=download&id=1ZQBgouAZ5pfHkleQLNRKquTxrQqDDiN7";
string filePath = @"D:\\Learning\\Projects\\ParseFile\\ParseFile\\Files\\257.csv";


var services = new ServiceCollection()
    .AddTransient<IParseService, CellTowerParseService>()
    .AddTransient<Parser>()
    .AddTransient<IDownloadService, DownloadFileService>()
    .AddTransient<Loader>();


using var serviceProvider = services.BuildServiceProvider();

var loader = serviceProvider.GetService<Loader>();
var parser = serviceProvider.GetService<Parser>();

loader.downloadFile(link, filePath);
parser.parseFile(inputPath, outputPath);










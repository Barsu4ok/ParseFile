using System.Reflection.PortableExecutable;
using Microsoft.Extensions.DependencyInjection;
using ParseFile.Services.Interfaces;
using ParseFile.Services;
using ParseFile;

var services = new ServiceCollection()
    .AddTransient<IParseService, CellTowerParseService>()
    .AddTransient<Parser>();

string inputPath = "D:\\Learning\\Projects\\ParseFile\\ParseFile\\257.csv";
string outputPath = "D:\\Learning\\Projects\\ParseFile\\ParseFile\\result.txt";

using var serviceProvider = services.BuildServiceProvider();
var parser = serviceProvider.GetService<Parser>();
parser.parseFile(inputPath,outputPath);
 





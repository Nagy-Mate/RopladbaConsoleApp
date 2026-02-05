
using RoplabdaConsoleApp;

var fileService = new FileService();
var volleyService = new VolleyballService();

var data = fileService.GetData();
foreach (var e in data)
{
    Console.WriteLine(e);
}

volleyService.GetUtok(data);
volleyService.GetTeamMates(data);
volleyService.OrderByHeight(data);
volleyService.GetByNationality(data);
volleyService.GetAboveAvgHeight(data);
volleyService.GetPostHeights(data);
volleyService.GetBelovAvgHeight(data); 
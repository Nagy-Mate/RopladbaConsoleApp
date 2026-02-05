
namespace RoplabdaConsoleApp;

public class VolleyballService
{
    private FileService fileService = new FileService();
    public void GetUtok(List<Volleyball> data)
    {
        var utok = new List<Volleyball>();

        foreach (var i in data)
        {
            if (i.Post.Equals("ütő"))
            {
                utok.Add(i);
            }
        }
        fileService.WriteFileUtok(utok);
    }

    public void GetTeamMates(List<Volleyball> data)
    {
        var teams = new Dictionary<string, string>();

        foreach (var i in data)
        {
            if (!teams.ContainsKey(i.Team))
            {
                teams[i.Team] = $"{i.Name},";
            }
            else
            {
                teams[i.Team] += $"{i.Name},";

            }
        }
        fileService.WriteFileTeams(teams);
    }

    public void OrderByHeight(List<Volleyball> data)
    {
        var ordered = data.OrderBy(p => p.Height).ToList();
        fileService.WriteFileOrderedByHeight(ordered);

    }

    public void GetByNationality(List<Volleyball> data)
    {
        var byNationality =  data.GroupBy(p => p.Nationality).ToList();
        fileService.WriteFileByNationality(byNationality);
    }
    public void GetAboveAvgHeight(List<Volleyball> data)
    {
        var aboveAvg = new Dictionary<string, int>();
        foreach (var e in data)
        {
            if(e.Height > data.Average(p => p.Height))
            {
                aboveAvg[e.Name] = e.Height;
            }
        }
        fileService.WriteFileAboveAvgHeight(aboveAvg);
    }

    public void GetPostHeights(List<Volleyball> data)
    {
        var postHeights = data.GroupBy(p => p.Post).OrderBy(e => e.Sum(i => i.Height));
        fileService.WriteFilePostHeights(postHeights);
    }

    public void GetBelovAvgHeight(List<Volleyball> data)
    {
        var belowAvg = new Dictionary<string, string>();
        var avg = data.Average(p => p.Height);
        foreach (var e in data)
        {
            if (e.Height < avg)
            {
                belowAvg[e.Name] = $"{e.Height},  {Math.Floor((avg - e.Height) * 100) / 100 }";
            }
        }
        fileService.WriteFileBelowAvgHeight(belowAvg);
    }
}

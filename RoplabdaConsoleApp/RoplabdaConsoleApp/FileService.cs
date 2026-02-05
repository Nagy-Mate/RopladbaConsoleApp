using System.Text;

namespace RoplabdaConsoleApp;   

public class FileService
{
    private string _filePath = "adatok.txt";
    public List<Volleyball> GetData()
    {
        var volleyball = new List<Volleyball>();

        var text = File.ReadAllLines(this._filePath, Encoding.UTF8);
        

        foreach (var row in text)
        {
            var splitted = row.ToString().Split('\t');
            volleyball.Add(new Volleyball 
            { 
                Name = splitted[0],
                Height = int.Parse(splitted[1]),
                Post = splitted[2],
                Nationality = splitted[3],
                Team = splitted[4],
                Country = splitted[5]
            });
        }
        return volleyball;
    }
    public void WriteFileUtok(List<Volleyball> data)
    {

        using (StreamWriter sw = new StreamWriter("utok.txt"))
        {
            foreach (var e in data)
            {
                sw.WriteLine($"{e.Name}\t{e.Height}\t{e.Post}\t{e.Nationality}\t{e.Team}\t{e.Country}");
            }
        }
    }

    public void WriteFileTeams(Dictionary<string, string> data)
    {

        using (StreamWriter sw = new StreamWriter("csapattagok.txt"))
        {
            foreach (var e in data)
            {
                sw.WriteLine($"{e.Key}: {e.Value}");
            }
        }
    }

    public void WriteFileOrderedByHeight(List<Volleyball> data)
    {

        using (StreamWriter sw = new StreamWriter("magaslatok.txt"))
        {
            foreach (var e in data)
            {
                sw.WriteLine($"{e.Name}\t{e.Height}\t{e.Post}\t{e.Nationality}\t{e.Team}\t{e.Country}");
            }
        }
    }

    public void WriteFileByNationality(List<IGrouping<string, Volleyball>> data)
    {

        using (StreamWriter sw = new StreamWriter("nemzetisegek.txt"))
        {
            foreach (var e in data)
            {
                sw.WriteLine($"{e.Key}:  {string.Join(", ",e.Select(v => v.Name))}; {e.Count()}");
            }
        }
    }

    public void WriteFileAboveAvgHeight(Dictionary<string, int> data)
    {

        using (StreamWriter sw = new StreamWriter("atlagnalmagasabbak.txt"))
        {
            foreach (var e in data)
            {
                sw.WriteLine($"{e.Key}: {e.Value}");
            }
        }
    }
    public void WriteFilePostHeights(IOrderedEnumerable<IGrouping<string, Volleyball>> data)
    {

        using (StreamWriter sw = new StreamWriter("posztooszmagassag.txt"))
        {
            foreach (var e in data)
            {
                sw.WriteLine($"{e.Key}: {e.Sum(p => p.Height)}");
            }
        }
    }
    public void WriteFileBelowAvgHeight(Dictionary<string, string> data)
    {

        using (StreamWriter sw = new StreamWriter("atlagnalalacsonyabbak.txt"))
        {
            foreach (var e in data)
            {
                sw.WriteLine($"{e.Key}: {e.Value}");
            }
        }
    }
}

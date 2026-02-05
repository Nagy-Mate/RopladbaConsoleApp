

namespace RoplabdaConsoleApp;

public class Volleyball
{
    public string Name { get; set; }
    public int Height { get; set; }
    public string Post { get; set; }
    public string Nationality { get; set; }
    public string Team { get; set; }
    public string Country { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Height: {Height}, Post: {Post}, Nationality: {Nationality}, Team: {Team}, Country: {Country} \n";
    }
}

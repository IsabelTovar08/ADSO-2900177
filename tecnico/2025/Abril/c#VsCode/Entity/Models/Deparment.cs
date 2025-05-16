namespace Entity.Models;

public class Deparment
{
    public int Id { get; set; }
    public string name { get; set; }
    public List<City> cities { get; set; } = new List<City>();
}

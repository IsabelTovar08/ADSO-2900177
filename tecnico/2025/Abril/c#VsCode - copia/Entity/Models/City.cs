namespace Entity.Models;

public class City
{
    public int Id { get; set; }
    public string name { get; set; }
    public int deparmentId { get; set; }
    public Deparment deparment { get; set; }
    public List<Person> People { get; set; } = new List<Person>();
}

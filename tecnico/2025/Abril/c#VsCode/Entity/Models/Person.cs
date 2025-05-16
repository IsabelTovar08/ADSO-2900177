namespace Entity.Models;

public class Person
{
    public int Id { get; set; }
    public string fistName { get; set; }
    public string LastName { get; set; }
    public int cityId { get; set; }
    public City city { get; set; }
}

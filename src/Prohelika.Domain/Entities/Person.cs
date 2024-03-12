namespace Prohelika.Domain.Entities;

public class Person: Entity<int>
{
    public string Name { get; set; }
    public int Age { get; set; }
}
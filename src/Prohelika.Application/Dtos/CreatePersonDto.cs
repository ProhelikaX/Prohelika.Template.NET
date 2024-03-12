using Prohelika.Domain.Entities;

namespace Prohelika.Application.Dtos;

public record CreatePersonDto
{
    public string Name { get; set; }
    public int Age { get; set; }
    
   public Person ToEntity() => new Person { Name = Name, Age = Age };
}
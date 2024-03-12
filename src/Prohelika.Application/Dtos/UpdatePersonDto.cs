using Prohelika.Domain.Entities;

namespace Prohelika.Application.Dtos;

public record UpdatePersonDto(int Id) : CreatePersonDto
{
    public new Person ToEntity() => new Person { Id = Id,Name = Name, Age = Age };
}
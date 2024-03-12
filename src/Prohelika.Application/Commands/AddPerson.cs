using MediatR;
using Prohelika.Application.Dtos;
using Prohelika.Domain.Entities;
using Prohelika.Domain.Repositories;

namespace Prohelika.Application.Commands;

public record AddPerson(CreatePersonDto Dto) : IRequest<Person>;

public class AddPersonHandler(ICrudRepository<Person, int> repository) : IRequestHandler<AddPerson, Person>
{
    public async Task<Person> Handle(AddPerson request, CancellationToken cancellationToken)
    {
        var result = await repository.CreateAsync(request.Dto.ToEntity());

        await repository.SaveChangesAsync();

        return result;
    }
}
using MediatR;
using Prohelika.Application.Dtos;
using Prohelika.Domain.Entities;
using Prohelika.Domain.Errors.Exceptions;
using Prohelika.Domain.Repositories;

namespace Prohelika.Application.Commands;

public record UpdatePerson(int Id, UpdatePersonDto Dto) : IRequest<Person>;

public class UpdatePersonHandler(ICrudRepository<Person, int> repository) : IRequestHandler<UpdatePerson, Person>
{
    public async Task<Person> Handle(UpdatePerson request, CancellationToken cancellationToken)
    {
        if (request.Id != request.Dto.Id)
        {
            throw new ForbiddenException();
        }

        var existing = await repository.GetAsync(request.Id);

        if (existing == null)
        {
            throw new NotFoundException();
        }

        existing.Name = request.Dto.Name;
        existing.Age = request.Dto.Age;


        await repository.SaveChangesAsync();

        return existing;
    }
}
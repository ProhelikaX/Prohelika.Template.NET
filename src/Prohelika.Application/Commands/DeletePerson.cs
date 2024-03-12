using MediatR;
using Prohelika.Domain.Entities;
using Prohelika.Domain.Errors.Exceptions;
using Prohelika.Domain.Repositories;

namespace Prohelika.Application.Commands;

public record DeletePerson(int Id) : IRequest;

public class DeletePersonHandler(ICrudRepository<Person, int> repository) : IRequestHandler<DeletePerson>
{
    public async Task Handle(DeletePerson request, CancellationToken cancellationToken)
    {
        var existing = await repository.GetAsync(request.Id);

        if (existing == null)
        {
            throw new NotFoundException();
        }

        repository.Delete(existing);

        await repository.SaveChangesAsync();
    }
}
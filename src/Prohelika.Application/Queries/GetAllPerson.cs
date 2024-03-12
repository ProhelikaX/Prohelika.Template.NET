using MediatR;
using Prohelika.Domain.Entities;
using Prohelika.Domain.Repositories;

namespace Prohelika.Application.Queries;

public record GetAllPerson : IRequest<IEnumerable<Person>>;


public class GetAllPersonHandler(ICrudRepository<Person, int> repository)
    : IRequestHandler<GetAllPerson, IEnumerable<Person>>
{
    public async Task<IEnumerable<Person>> Handle(GetAllPerson request, CancellationToken cancellationToken)
    {
        return await repository.GetAllAsync();
    }
}
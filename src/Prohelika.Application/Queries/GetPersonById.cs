using MediatR;
using Prohelika.Domain.Entities;
using Prohelika.Domain.Errors.Exceptions;
using Prohelika.Domain.Repositories;

namespace Prohelika.Application.Queries;

public record GetPersonById(int PersonId) : IRequest<Person>;

public class GetPersonByIdHandler(ICrudRepository<Person, int> repository) : IRequestHandler<GetPersonById, Person>
{
    public async Task<Person> Handle(GetPersonById request, CancellationToken cancellationToken)
    {
       var result = await repository.GetAsync(request.PersonId);

       if (result == null)
       {
           throw new NotFoundException();
       }

       return result;
    }
}
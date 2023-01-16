using Domain;
using MediatR;

namespace Application.Queries
{
    public class GetAllDataQuery : IRequest<IEnumerable<Data>>
    {
    }
}

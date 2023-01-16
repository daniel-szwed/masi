using Application.Queries;
using Domain;
using Domain.Repository;
using MediatR;

namespace Application.Handlers
{
    public class GetAllDataQueryHandler : IRequestHandler<GetAllDataQuery, IEnumerable<Data>>
    {
        private readonly IUnitOfWork unitOfWork;

        public GetAllDataQueryHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public Task<IEnumerable<Data>> Handle(GetAllDataQuery request, CancellationToken cancellationToken)
        {
            return unitOfWork.Repository<Data>().GetAllAsync();
        }
    }
}

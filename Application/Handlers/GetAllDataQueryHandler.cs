using Application.Queries;
using Domain;
using Domain.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handlers
{
    public class GetAllDataQueryHandler : IRequestHandler<GetAllDataQuery, IEnumerable<Data>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<GetAllDataQueryHandler> logger;

        public GetAllDataQueryHandler(IUnitOfWork unitOfWork, ILogger<GetAllDataQueryHandler> logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        public Task<IEnumerable<Data>> Handle(GetAllDataQuery request, CancellationToken cancellationToken)
        {
            return unitOfWork.Repository<Data>().GetAllAsync();
        }
    }
}

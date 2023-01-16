using Application.Commands;
using Domain;
using Domain.Repository;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Handlers
{
    public class SaveDataCommandHandler : IRequestHandler<SaveDataCommand, Data>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ILogger<SaveDataCommandHandler> logger;

        public SaveDataCommandHandler(IUnitOfWork unitOfWork, ILogger<SaveDataCommandHandler> logger)
        {
            this.unitOfWork = unitOfWork;
            this.logger = logger;
        }

        public async Task<Data> Handle(SaveDataCommand request, CancellationToken cancellationToken)
        {
            var data = request.Data;
            data.SaveAt = DateTime.Now;
            unitOfWork.Repository<Data>().Add(data);
            await unitOfWork.SaveChangesAsync();

            return data;
        }
    }
}

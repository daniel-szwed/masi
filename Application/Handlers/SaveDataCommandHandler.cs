using Application.Commands;
using Domain;
using Domain.Repository;
using MediatR;

namespace Application.Handlers
{
    public class SaveDataCommandHandler : IRequestHandler<SaveDataCommand, Data>
    {
        private readonly IUnitOfWork unitOfWork;

        public SaveDataCommandHandler(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
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

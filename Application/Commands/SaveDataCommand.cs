using Domain;
using MediatR;

namespace Application.Commands
{
    public class SaveDataCommand : IRequest<Data>
    {
        public SaveDataCommand(Data data)
        {
            Data = data;
        }

        public Data Data { get; }
    }
}

using InventoryManagement.Adstractions.UseCasesPorts.commons;
using InventoryManagement.Dtos.Abstractions;

namespace InventoryManagement.Presenters.Responses
{
    internal class CommonResponsePresenter : IResponseOutputPort<IResponseResult>
    {
        public IResponseResult Content { get; private set; }

        public Task Handle(IResponseResult input)
        {
            Content = input;
            return Task.CompletedTask;
        }
    }
}

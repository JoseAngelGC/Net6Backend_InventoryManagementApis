using InventoryManagement.Dtos.Abstractions;

namespace InventoryManagement.Adstractions.UseCasesPorts.commons
{
    public interface IResponseOutputPort<T>
    {
        public T Content { get; }
        Task Handle(IResponseResult input);
    }
}

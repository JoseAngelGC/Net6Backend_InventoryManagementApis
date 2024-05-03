using InventoryManagement.Dtos.Results;

namespace InventoryManagement.Adstractions.Helpers
{
    public interface IResponseResultHelpers
    {
        void ByPassingValuesAsync<T>(ref ResponseResult<T> response, bool success, T result, int? foundItemsNumber);
        void ByPassingValuesAsync<T>(ref ResponseResult<T> response, bool success, T result, string message);
        void CatalogCommandOperationAsync(ref ResponseResult<int> response, int operationState, string message);
    }
}

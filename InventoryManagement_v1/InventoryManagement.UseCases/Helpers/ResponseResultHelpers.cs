using InventoryManagement.Adstractions.Helpers;
using InventoryManagement.Dtos.Results;
using InventoryManagement.Shared.Utilities.Constants;

namespace InventoryManagement.UseCases.Helpers
{
    public class ResponseResultHelpers : IResponseResultHelpers
    {
        public void ByPassingValuesAsync<T>(ref ResponseResult<T> response, bool success, T result, int? foundItemsNumber)
        {
            response.Success = success;
            response.Result = result;
            if (foundItemsNumber is null)
            {
                response.Message = ReplyMessages.MESSAGE_QUERY_EMPTY;
            }
            else
            {
                response.Message = foundItemsNumber > 0 ? ReplyMessages.MESSAGE_QUERY_SUCCESSFULL : ReplyMessages.MESSAGE_QUERY_EMPTY;
            }
            
        }

        public void ByPassingValuesAsync<T>(ref ResponseResult<T> response, bool success, T result, string message)
        {
            response.Success = success;
            response.Result = result;
            response.Message = message;
        }

        public void CatalogCommandOperationAsync(ref ResponseResult<int> response, int operationState, string message)
        {
            if (operationState == 0)
            {
                response.Success = false;
                response.Message = message;
                response.Result = operationState;
            }
            else
            {
                response.Success = true;
                response.Message = message;
                response.Result = operationState;
            }
        }
    }
}

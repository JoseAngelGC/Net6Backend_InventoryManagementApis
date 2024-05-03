using InventoryManagement.Dtos.Results;
using InventoryManagement.Shared.Utilities.Constants;
using InventoryManagement.Shared.Utilities.ErrorDtos;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace InventoryManagement.Shared.Milddlewares
{
    public class ErrorHadlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ErrorHadlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context) 
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";
                var responseModel = new ResponseResult<string>()
                {
                    Success = false,
                };

                switch (error)
                {
                    case CustomBadRequestException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Message = e.Message;
                        break;
                    case ValidationException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        responseModel.Message = e.Message;
                        responseModel.Errors = e.Errors;
                        break;
                    case KeyNotFoundException e:
                        response.StatusCode= (int)HttpStatusCode.NotFound;
                        responseModel.Message = e.Message;
                        break;
                    default:
                        ServerErrorResponse(ref response, ref responseModel, error.HResult);
                        break;
                }

                var result = JsonSerializer.Serialize(responseModel);
                await context.Response.WriteAsync(result);
            }
        }

        
        private static void ServerErrorResponse(ref HttpResponse response, ref ResponseResult<string> responseModel, int hResultException)
        {
            switch (hResultException.ToString())
            {
                case "-2146232060":
                    response.StatusCode = (int)HttpStatusCode.ServiceUnavailable;
                    responseModel.Message = ReplyMessages.MESSAGE_UNAVAILABLESERVICE;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    responseModel.Message = ReplyMessages.MESSAGE_FAILED;
                    break;
            }
            
        }

    }
}

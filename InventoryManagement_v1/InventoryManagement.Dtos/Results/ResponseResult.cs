using InventoryManagement.Dtos.Abstractions;

namespace InventoryManagement.Dtos.Results
{
    public class ResponseResult<T> : IResponseResult
    {
        public bool Success { get; set; } = true;
        public string? Message { get; set; }
        public T? Result { get; set; } = default;
        public List<string>? Errors { get; set; } = default;
    }
}

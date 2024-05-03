using FluentValidation.Results;
using InventoryManagement.Shared.Utilities.Constants;

namespace InventoryManagement.Shared.Utilities.ErrorDtos
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get; set; }
        public ValidationException() : base(ReplyMessages.MESSAGE_VALIDATE)
        {
            Errors = new List<string>();
        }
        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }
    }
}

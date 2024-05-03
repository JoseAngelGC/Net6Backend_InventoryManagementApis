using System.Globalization;

namespace InventoryManagement.Shared.Utilities.ErrorDtos
{
    public class CustomBadRequestException : Exception
    {
        public CustomBadRequestException() : base() { }
        public CustomBadRequestException(string message) : base(message) { }
        public CustomBadRequestException(string message, params object[] args) :
            base(string.Format(CultureInfo.CurrentCulture, message, args)){ }
    }
}

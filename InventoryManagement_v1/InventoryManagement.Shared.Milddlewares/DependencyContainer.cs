using Microsoft.AspNetCore.Builder;

namespace InventoryManagement.Shared.Milddlewares
{
    public static class DependencyContainer
    {
        public static void UseCustomExceptionMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHadlerMiddleware>();
        }
    }
}

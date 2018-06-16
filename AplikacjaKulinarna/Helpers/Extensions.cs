using Microsoft.AspNetCore.Builder;

namespace AplikacjaKulinarna.API.Helpers
{
    public static class Extensions
    {
        public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder builder) =>
            builder.UseMiddleware(typeof(ErrorHandler));
    }
}
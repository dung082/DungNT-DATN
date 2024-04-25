using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace BackEndApi.ExceptionHandler
{
    public static class ExceptionMiddlewareHandler
    {
        public static void ConfigureExceptionHandler(this WebApplication app)
        {
            app.UseExceptionHandler(
                appError =>
                {
                    appError.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        context.Response.ContentType = "application/json";

                        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                        if(contextFeature != null) {
                            //logger.LogError($"Lỗi:  {contextFeature.Error}");
                            await context.Response.WriteAsync(new ErrorDetail
                            {
                                StatusCode = context.Response.StatusCode,
                                Message = contextFeature.Error.Message,
                            }.ToString());
                        }
                    });
                });
        }
    }
}

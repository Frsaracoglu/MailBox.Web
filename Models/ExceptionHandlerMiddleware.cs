using log4net;
using MailBox.Web.Providers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MailBox.Web.Models
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate next;
        private readonly ILoggerManager _logger;

        public ExceptionHandlerMiddleware(RequestDelegate Next, ILoggerManager logger)
        {
            next = Next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await next.Invoke(httpContext);
                HttpTransferDto dto = new();
                dto.HttpInfo = httpContext;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
                _logger.LogInfoFormat(
                   "Method: {0}" +
                   "Url: {1}" +
                   "statusCode: {2}",
                   httpContext.Request?.Method,
                   httpContext.Request?.Path,
                   httpContext.Response?.StatusCode);
            }
        }
    }
}

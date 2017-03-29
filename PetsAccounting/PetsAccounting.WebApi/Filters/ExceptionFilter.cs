using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;

using PetsAccounting.BLL.Exceptions;

namespace PetsAccounting.WebApi.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public bool AllowMultiple => true;

        public async Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext, CancellationToken cancellationToken)
        {
            var exception = actionExecutedContext.Exception;

            if (exception == null)
            {
                await Task.Run(() => actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.OK), cancellationToken);
            }
            else if (exception is ServiceNotFoundException)
            {
                await Task.Run(
                    () =>
                        actionExecutedContext.Response =
                            actionExecutedContext.Request.CreateErrorResponse(
                                HttpStatusCode.NotFound,
                                exception.Message),
                    cancellationToken);
            }
            else
            {
                await Task.Run(() => actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError), cancellationToken);
            }
        }
    }
}
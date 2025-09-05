using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using RollbarSharp;

namespace exp.web.Code
{
    public class RollbarExceptionFilterAttribute : IExceptionFilter
    {
        public Task ExecuteExceptionFilterAsync(HttpActionExecutedContext actionExecutedContext,
            CancellationToken cancellationToken)
        {
            //if (cancellationToken.IsCancellationRequested) { 

            //}
            return Task.Factory.StartNew(() => { new RollbarClient().SendException(actionExecutedContext.Exception); },
                cancellationToken);
        }

        public bool AllowMultiple => true;
    }
}
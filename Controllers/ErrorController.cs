using System.Diagnostics;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace SampleWebApi
{
    /// <summary>
    /// ErrorController
    /// </summary>
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ApiControllerBase
    {
        private readonly bool _isDev;

        /// <summary>
        /// Init Error Controller
        /// </summary>
        /// <param name="hostEnvironment"></param>
        /// <param name="logger"></param>
        public ErrorController(ILogger<ErrorController> logger, IHostEnvironment hostEnvironment) : base(logger)
        {
            _isDev = hostEnvironment.IsDevelopment();
        }

        /// <summary>
        /// 例外錯誤處理
        /// </summary>
        /// <returns></returns>
        [Route("/Error")]
        public ActionResult Error()
        {
            const int statusCode = (int)HttpStatusCode.InternalServerError;
            var feature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var ex = feature?.Error;
            var traceId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

            var problemDetails = new RequestProblemDetails
            {
                Status = statusCode,
                Instance = feature?.Path,
                Title = _isDev ? $"{ex?.GetType().FullName}: {ex?.Message}" : "An error occurred",
                Detail = _isDev ? ex?.StackTrace : null,
                TraceId = traceId,
                Error = ex,
            };

            return StatusCode(statusCode, problemDetails);
        }

        /// <summary>
        /// 
        /// </summary>
        public class RequestProblemDetails : ProblemDetails
        {
            /// <summary>
            /// Trace Id
            /// </summary>
            /// <value></value>
            public string? TraceId { get; set; }

            /// <summary>
            /// Exception Object
            /// </summary>
            /// <value></value>
            public dynamic? Error { get; set; }
        }
    }
}
using System;
using Microsoft.AspNetCore.Mvc;

namespace SampleWebApi
{
    /// <summary>
    /// ApiControllerBase
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ApiControllerBase : ControllerBase, IDisposable
    {
        private readonly IDisposable _loggerScope;

        /// <summary>
        /// ApiControllerBase
        /// </summary>
        /// <param name="logger"></param>
        protected ApiControllerBase(ILogger logger)
        {
            _loggerScope = logger.BeginScope(new[] { new KeyValuePair<string, object>("ScopeId", $"{Guid.NewGuid():N}"[..4]) });
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            _loggerScope?.Dispose();
        }
    }
}
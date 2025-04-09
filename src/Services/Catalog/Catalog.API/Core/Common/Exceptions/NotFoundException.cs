using System.Net;

namespace Catalog.API.Core.Common.Exceptions
{
    /// <summary>
    /// Represents an exception when a requested resource is not found (HTTP 404).
    /// </summary>
    public class NotFoundException : Exception
    {
        /// <summary>
        /// HTTP status code associated with the exception (default: 404).
        /// </summary>
        public int StatusCode { get; } = (int)HttpStatusCode.NotFound;

        public NotFoundException()
            : base("The requested resource was not found.")
        {
        }

        public NotFoundException(string message)
            : base(message)
        {
        }

        public NotFoundException(string message, int statusCode)
            : base(message)
        {
            StatusCode = statusCode;
        }

        // Optional: Constructor with inner exception for stack trace support
        public NotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
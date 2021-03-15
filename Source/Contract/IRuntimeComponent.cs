using Routindo.Contract.Services;

namespace Routindo.Contract
{
    public interface IRuntimeComponent
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        string Id { get; set; }

        /// <summary>
        /// Gets or sets the logging service.
        /// </summary>
        /// <value>
        /// The logging service.
        /// </value>
        ILoggingService LoggingService { get; set; }
    }
}
namespace Spoon.NuGet.Core.Application.Mediator.PipelineBehaviors.Permission
{
    /// <summary>
    ///  Class PermissionFailed.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PermissionFailed<T>
    {
        /// <summary>
        ///  Gets or sets the command.
        /// </summary>
        public string? Command { get; set; }
        /// <summary>
        ///  Gets or sets the command values.
        /// </summary>
        public T? CommandValues { get; set; }
        /// <summary>
        ///  Gets or sets the origin.
        /// </summary>
        public string? Origin { get; set; }
        /// <summary>
        ///  Gets or sets the HTTP status code.
        /// </summary>
        public int? HttpStatusCode { get; set; }
        /// <summary>
        ///  Gets or sets the message.
        /// </summary>
        public string? Message { get; set; }
    }
}
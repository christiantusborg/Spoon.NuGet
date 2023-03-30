namespace Spoon.NuGet.Core
{
    /// <summary>
    /// Interface for mocking the current UTC date and time.
    /// </summary>
    public class MockbleDateTimeDefault : IMockbleDateTime
    {
        /// <summary>
        /// Gets the current UTC date and time.
        /// </summary>
        /// <value>The current UTC date and time.</value>
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
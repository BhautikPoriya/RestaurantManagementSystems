namespace Restaurant_Management_Systems.Factories
{
    /// <summary>
    /// Represents the interface of the common models factory
    /// </summary>
    public interface ICommonModelFactory
    {
        /// Prepare the logo model
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the logo model
        /// </returns>
        Task<string> PrepareLogoModelAsync();
    }
}

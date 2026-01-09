
namespace Restaurant_Management_Systems.Factories
{
    public class CommonModelFactory : ICommonModelFactory
    {
        #region Fields

        protected readonly IHttpContextAccessor _httpContextAccessor;

        #endregion

        #region Ctor

        public CommonModelFactory( IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        #endregion

        #region Methods 

        /// <summary>
        /// Prepare the logo model
        /// </summary>
        /// <returns>
        /// A task that represents the asynchronous operation
        /// The task result contains the logo model
        /// </returns>
        public async Task<string> PrepareLogoModelAsync()
        {
            var pathBase = _httpContextAccessor.HttpContext.Request.PathBase.Value ?? string.Empty;
            var logoUrl = pathBase + "/images/Logo.png";
            return await Task.FromResult(logoUrl);
        }

        #endregion
    }
}

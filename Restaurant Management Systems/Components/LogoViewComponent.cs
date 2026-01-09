using Microsoft.AspNetCore.Mvc;
using Restaurant_Management_Systems.Factories;

namespace Restaurant_Management_Systems.Components
{
    public partial class LogoViewComponent : ViewComponent
    {
        #region Fields

        protected readonly ICommonModelFactory _commonModelFactory;

        #endregion

        #region Ctor 

        public LogoViewComponent(ICommonModelFactory commonModelFactory)
        {
            _commonModelFactory = commonModelFactory;
        }

        #endregion

        #region Methods

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var model = await _commonModelFactory.PrepareLogoModelAsync();
            return View("Default", model);
        }

        #endregion
    }
}

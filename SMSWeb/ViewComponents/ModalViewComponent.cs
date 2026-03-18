using Microsoft.AspNetCore.Mvc;
namespace SMSWeb.ViewComponents
{
    public class ModalViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("Default"); //Here the default path is /Components/Modal/
        }
    }
}

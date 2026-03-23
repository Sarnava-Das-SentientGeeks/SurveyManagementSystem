using Microsoft.AspNetCore.Mvc;
namespace SMSWeb.ViewComponents
{
    public class CheckboxesViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("CheckBoxes");
        }
    }
}

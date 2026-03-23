using Microsoft.AspNetCore.Mvc;
namespace SMSWeb.ViewComponents
{
    public class QuestioncardViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View("QuestionCard");
        }
    }
}

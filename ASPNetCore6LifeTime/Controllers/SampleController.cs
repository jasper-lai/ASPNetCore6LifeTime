namespace ASPNetCore6LifeTime.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class SampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

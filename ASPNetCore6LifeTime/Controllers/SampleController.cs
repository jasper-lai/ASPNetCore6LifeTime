namespace ASPNetCore6LifeTime.Controllers
{
    using ASPNetCore6LifeTime.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    public class SampleController : Controller
    {
        private readonly ILogger<SampleController> _logger;
        private readonly ITransientService _tranService1;
        private readonly ITransientService _tranService2;
        private readonly IScopedService _scopedService1;
        private readonly IScopedService _scopedService2;
        private readonly ISingletonService _singletonService1;
        private readonly ISingletonService _singletonService2;

        public SampleController(ILogger<SampleController> logger,
            ITransientService tranService1,
            ITransientService tranService2,
            IScopedService scopedService1,
            IScopedService scopedService2,
            ISingletonService singletonService1,
            ISingletonService singletonService2)
        {
            _logger = logger;
            _tranService1 = tranService1;
            _tranService2 = tranService2;
            _scopedService1 = scopedService1;
            _scopedService2 = scopedService2;
            _singletonService1 = singletonService1;
            _singletonService2 = singletonService2;
        }

        public IActionResult Index()
        {
            ViewBag.transient1 = _tranService1.GetCurrentGUID().ToString();
            ViewBag.transient2 = _tranService2.GetCurrentGUID().ToString();
            ViewBag.scoped1 = _scopedService1.GetCurrentGUID().ToString();
            ViewBag.scoped2 = _scopedService2.GetCurrentGUID().ToString();
            ViewBag.singleton1 = _singletonService1.GetCurrentGUID().ToString();
            ViewBag.singleton2 = _singletonService2.GetCurrentGUID().ToString();
            return View();
        }
    }
}

using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using ServiceLifeTime.Models;
using ServiceLifeTime.Services;

namespace ServiceLifeTime.Controllers
{
    public class HomeController(
        ILogger<HomeController> logger,
        ISingletonService singletonService01,
        ISingletonService singletonService02,
        IScopedService scopedService01,
        IScopedService scopedService02,
        ITransientService transientService01,
        ITransientService transientService02
        ) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly ISingletonService singletonService01 = singletonService01;
        private readonly ISingletonService singletonService02 = singletonService02;
        private readonly IScopedService scopedService01 = scopedService01;
        private readonly IScopedService scopedService02 = scopedService02;
        private readonly ITransientService transientService01 = transientService01;
        private readonly ITransientService transientService02 = transientService02;

        public string Index()
        {
            StringBuilder stringBuilder = new StringBuilder();
            //                                                                                   first request          second request
            stringBuilder.AppendLine($"Singleton Service 01: {singletonService01.GetGuid()}"); //    X                        X
            stringBuilder.AppendLine($"Singleton Service 02: {singletonService02.GetGuid()}"); //    X                        X

            stringBuilder.AppendLine($"Scoped Service 01: {scopedService01.GetGuid()}");       //    Y                        Z
            stringBuilder.AppendLine($"Scoped Service 02: {scopedService02.GetGuid()}");       //    Y                        Z

            stringBuilder.AppendLine($"Transient Service 01: {transientService01.GetGuid()}"); //    A                        C
            stringBuilder.AppendLine($"Transient Service 02: {transientService02.GetGuid()}"); //    B                        D
            return stringBuilder.ToString();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

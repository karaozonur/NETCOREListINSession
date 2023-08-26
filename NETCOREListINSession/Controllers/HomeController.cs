using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NETCOREListINSession.Models;
using Newtonsoft.Json;
using System.Diagnostics;

namespace NETCOREListINSession.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _contextAccessor;
        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _contextAccessor = contextAccessor;
        }

        public IActionResult Index()
        {
            //Listemizi Oluşturduk
            List<Categories> list = new List<Categories>();
            list.Add(new Categories { CategoriesId = 1, CategoryName = "CSharp", IsActive = true });
            list.Add(new Categories { CategoriesId = 2, CategoryName = "Abone Ol", IsActive = true });
            list.Add(new Categories { CategoriesId = 2, CategoryName = "Videoyu beğen", IsActive = true });

            string str = JsonConvert.SerializeObject(list);
            _contextAccessor.HttpContext.Session.SetString("CategoriList", str);


            //Objemizi Oluşturuk
            Users users = new Users();
            users.UserID = 1;
            users.UserName = "Abone Ol";
            users.lastName = "Videoyu beğen";
            users.email = "asdafaf@gmail.com";
            users.IsActive = true;

            string ustr = JsonConvert.SerializeObject(users);
            _contextAccessor.HttpContext.Session.SetString("userObject", ustr);


            return View();
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
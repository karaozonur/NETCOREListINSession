using Microsoft.AspNetCore.Mvc;
using NETCOREListINSession.Models;
using Newtonsoft.Json;

namespace NETCOREListINSession.Controllers
{
    public class DemoController : Controller
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public DemoController(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor=contextAccessor;
        }
        public IActionResult Demo()
        {
            List<Categories> list = new List<Categories>();
            string st = _contextAccessor.HttpContext.Session.GetString("CategoriList");
            list = JsonConvert.DeserializeObject<List<Categories>>(st);

            Users users = new Users();  
            string st2 = _contextAccessor.HttpContext.Session.GetString("userObject");
            users = JsonConvert.DeserializeObject<Users>(st2);


             ViewModel _model=new ViewModel();
            _model.Categories = list;
            _model.Users = users;

            return View(_model);
        }
    }
}

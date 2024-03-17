using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using pos.BLL.Interface;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserBLL _userBLL;
        private readonly IRoleBLL _roleBLL;

        public HomeController(ILogger<HomeController> logger, IUserBLL userBLL, IRoleBLL roleBLL)
        {
            _logger = logger;
            _userBLL = userBLL;
            _roleBLL = roleBLL;
        }

        public IActionResult Index()
        {
            var view = _userBLL.GetAllWithRoles();
            return View(view);
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

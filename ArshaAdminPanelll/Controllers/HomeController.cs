using ArshaAdminPanelll.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ArshaAdminPanelll.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
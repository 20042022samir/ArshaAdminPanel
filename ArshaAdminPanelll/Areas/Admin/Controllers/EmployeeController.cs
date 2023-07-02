using ArshaAdminPanel.Core.Entites;
using ArshaAdminPanelll.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace ArshaAdminPanelll.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmployeeController : Controller
    {
        private readonly ArshaDbContext _context;
        private IWebHostEnvironment _enviromet;

        public EmployeeController(ArshaDbContext context, IWebHostEnvironment enviromet)
        {
            _context = context;
            _enviromet = enviromet;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employees employee)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }
            await _context.employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Employees? employee = await _context.employees.Where(a => !a.IsDeleted && a.Id == id).FirstOrDefaultAsync();
            if(employee == null)
            {
                return View();
            }

            employee.IsDeleted = true;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Update(Employees employees)
        {
            if (employees == null)
            {
                return NotFound();
            }
            return View(employees);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int Id,Employees employee)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            Employees? employeToUpdate=await _context.employees.Where(a=>!a.IsDeleted).FirstOrDefaultAsync();
            if(employeToUpdate == null)
            {
                return NotFound();
            }
            string root = _enviromet.WebRootPath;
            string path = "assets/img/";
            string FullName = Guid.NewGuid().ToString() + employee.formFile.FileName;
            string FullPath = Path.Combine(root, path, FullName);
            using(FileStream fileStream=new FileStream(FullPath,FileMode.Create))
            {
                employee.formFile.CopyTo(fileStream); 
            };
            employee.Image = FullName;
            await _context.employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}

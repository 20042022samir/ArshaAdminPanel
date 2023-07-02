using ArshaAdminPanel.Core.Entites;
using ArshaAdminPanelll.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArshaAdminPanelll.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PositionController : Controller
    {
        private readonly ArshaDbContext _context;
        public PositionController(ArshaDbContext context)
        {
            _context= context;
        }
        public async Task<IActionResult> Index()
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
        public async Task<IActionResult> Create(Positionn positionn)
        {
            if (!ModelState.IsValid)
                return View();
          await  _context.jobsposition.AddRangeAsync(positionn);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Positionn? positionn=await _context.jobsposition.Where(a=>!a.IsDeleted && a.Id==id).FirstOrDefaultAsync();
            if (positionn == null)
                return NotFound();
            positionn.IsDeleted=true;
           await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(Positionn positionn) 
        { 
            if(positionn==null) return NotFound();
           return View(positionn);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int Id,Positionn position)
        {
            Positionn? positionToUpdate=await _context.jobsposition
                .Where(a=>!a.IsDeleted && a.Id== Id).FirstOrDefaultAsync();
            if(positionToUpdate==null) return NotFound();
            positionToUpdate.Name = position.Name;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}

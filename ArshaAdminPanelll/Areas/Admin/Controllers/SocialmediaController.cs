using ArshaAdminPanel.Core.Entites;
using ArshaAdminPanelll.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArshaAdminPanelll.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SocialmediaController : Controller
    {
        private readonly ArshaDbContext _context;
        public SocialmediaController(ArshaDbContext context)
        {
            _context = context;
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
        public async Task<IActionResult> Create(SocialMedia socialMedia)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _context.socialMedias.AddAsync(socialMedia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            SocialMedia? socialMedia=await _context.socialMedias
                .Where(a=>!a.IsDeleted && a.Id== id)
                   .FirstOrDefaultAsync();
            if (socialMedia == null)
                return NotFound();
            socialMedia.IsDeleted= true;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            SocialMedia? media=await _context.socialMedias.Where(a=>a.Id==id).FirstOrDefaultAsync();
            if(media == null) return NotFound();
            return View(media);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int Id,SocialMedia media)
        {
            if(!ModelState.IsValid) return View();
            SocialMedia? mediaToUpdate=await _context.socialMedias
                .Where(a=>!a.IsDeleted && a.Id== Id)
                .FirstOrDefaultAsync();
            if (mediaToUpdate == null) return NotFound();
            mediaToUpdate.Name= media.Name;
            _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}

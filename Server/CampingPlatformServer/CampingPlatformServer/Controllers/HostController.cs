using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CampingPlatformServer.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace CampingPlatformServer.Controllers
{
    public class HostController : Controller
    {
        private readonly CampingPlatformContext _context;

        public HostController(CampingPlatformContext context)
        {
            _context = context;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var hosts = await _context.Hosts.ToListAsync();
            return View(hosts);
        }

        [Authorize]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var host = await _context.Hosts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (host == null)
            {
                return NotFound();
            }

            return View(host);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Username,Password,FirstName,LastName,DateOfBirth,TelephoneNumber,Email,ProfilePictureLocation")] Host host)
        {
            if (ModelState.IsValid)
            {
                _context.Add(host);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(host);
        }

        [Authorize]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var host = await _context.Hosts.FindAsync(id);
            if (host == null)
            {
                return NotFound();
            }
            return View(host);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Username,Password,FirstName,LastName,DateOfBirth,TelephoneNumber,Email,ProfilePictureLocation")] Host host)
        {
            if (id != host.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(host);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HostExists(host.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(host);
        }

        [Authorize]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var host = await _context.Hosts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (host == null)
            {
                return NotFound();
            }

            return View(host);
        }

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var host = await _context.Hosts.FindAsync(id);
            _context.Hosts.Remove(host);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HostExists(Guid id)
        {
            return _context.Hosts.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YMSweb.Data;
using YMSweb.Data.Entities;

namespace YMSweb.Controllers
{
    public class MDChofersController : Controller
    {
        private readonly DataContext _context;

        public MDChofersController(DataContext context)
        {
            _context = context;
        }

        // GET: MDChofers
        public async Task<IActionResult> Index()
        {
            return View(await _context.Choferes.ToListAsync());
        }

 
        // GET: MDChofers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MDChofers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_chofer,chof_nomb,chof_apell,chof_dni,chof_brevette,chof_act")] MDChofer mDChofer)
        {

            if (ModelState.IsValid)
            {
                _context.Add(mDChofer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mDChofer);
        }

        // GET: MDChofers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDChofer = await _context.Choferes.FindAsync(id);
            if (mDChofer == null)
            {
                return NotFound();
            }
            return View(mDChofer);
        }

        // POST: MDChofers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_chofer,chof_nomb,chof_apell,chof_dni,chof_brevette,chof_act")] MDChofer mDChofer)
        {
            if (id != mDChofer.id_chofer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mDChofer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MDChoferExists(mDChofer.id_chofer))
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
            return View(mDChofer);
        }

        // GET: MDChofers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDChofer = await _context.Choferes
                .FirstOrDefaultAsync(m => m.id_chofer == id);
            if (mDChofer == null)
            {
                return NotFound();
            }

            return View(mDChofer);
        }

        // POST: MDChofers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mDChofer = await _context.Choferes.FindAsync(id);
            _context.Choferes.Remove(mDChofer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MDChoferExists(int id)
        {
            return _context.Choferes.Any(e => e.id_chofer == id);
        }
    }
}

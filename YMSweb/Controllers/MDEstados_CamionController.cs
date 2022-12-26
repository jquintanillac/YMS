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
    public class MDEstados_CamionController : Controller
    {
        private readonly DataContext _context;

        public MDEstados_CamionController(DataContext context)
        {
            _context = context;
        }

        // GET: MDEstados_Camion
        public async Task<IActionResult> Index()
        {
            return View(await _context.Estados_Camiones.ToListAsync());
        }

        // GET: MDEstados_Camion/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDEstados_Camion = await _context.Estados_Camiones
                .FirstOrDefaultAsync(m => m.id_estcam == id);
            if (mDEstados_Camion == null)
            {
                return NotFound();
            }

            return View(mDEstados_Camion);
        }

        // GET: MDEstados_Camion/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MDEstados_Camion/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_estcam,estcam_desc,estcam_act,estcam_busq")] MDEstados_Camion mDEstados_Camion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mDEstados_Camion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mDEstados_Camion);
        }

        // GET: MDEstados_Camion/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDEstados_Camion = await _context.Estados_Camiones.FindAsync(id);
            if (mDEstados_Camion == null)
            {
                return NotFound();
            }
            return View(mDEstados_Camion);
        }

        // POST: MDEstados_Camion/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_estcam,estcam_desc,estcam_act,estcam_busq")] MDEstados_Camion mDEstados_Camion)
        {
            if (id != mDEstados_Camion.id_estcam)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mDEstados_Camion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MDEstados_CamionExists(mDEstados_Camion.id_estcam))
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
            return View(mDEstados_Camion);
        }

        // GET: MDEstados_Camion/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDEstados_Camion = await _context.Estados_Camiones
                .FirstOrDefaultAsync(m => m.id_estcam == id);
            if (mDEstados_Camion == null)
            {
                return NotFound();
            }

            return View(mDEstados_Camion);
        }

        // POST: MDEstados_Camion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mDEstados_Camion = await _context.Estados_Camiones.FindAsync(id);
            _context.Estados_Camiones.Remove(mDEstados_Camion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MDEstados_CamionExists(int id)
        {
            return _context.Estados_Camiones.Any(e => e.id_estcam == id);
        }
    }
}

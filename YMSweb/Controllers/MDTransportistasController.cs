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
    public class MDTransportistasController : Controller
    {
        private readonly DataContext _context;

        public MDTransportistasController(DataContext context)
        {
            _context = context;
        }

        // GET: MDTransportistas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Transportistas.ToListAsync());
        }

        // GET: MDTransportistas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDTransportista = await _context.Transportistas
                .FirstOrDefaultAsync(m => m.id_transp == id);
            if (mDTransportista == null)
            {
                return NotFound();
            }

            return View(mDTransportista);
        }

        // GET: MDTransportistas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MDTransportistas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_transp,transp_desc,transp_ruc,transp_act,transp_libre")] MDTransportista mDTransportista)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mDTransportista);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mDTransportista);
        }

        // GET: MDTransportistas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDTransportista = await _context.Transportistas.FindAsync(id);
            if (mDTransportista == null)
            {
                return NotFound();
            }
            return View(mDTransportista);
        }

        // POST: MDTransportistas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_transp,transp_desc,transp_ruc,transp_act,transp_libre")] MDTransportista mDTransportista)
        {
            if (id != mDTransportista.id_transp)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mDTransportista);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MDTransportistaExists(mDTransportista.id_transp))
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
            return View(mDTransportista);
        }

        // GET: MDTransportistas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDTransportista = await _context.Transportistas
                .FirstOrDefaultAsync(m => m.id_transp == id);
            if (mDTransportista == null)
            {
                return NotFound();
            }

            return View(mDTransportista);
        }

        // POST: MDTransportistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mDTransportista = await _context.Transportistas.FindAsync(id);
            _context.Transportistas.Remove(mDTransportista);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MDTransportistaExists(int id)
        {
            return _context.Transportistas.Any(e => e.id_transp == id);
        }
    }
}

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
    public class MDTipo_TransporteController : Controller
    {
        private readonly DataContext _context;

        public MDTipo_TransporteController(DataContext context)
        {
            _context = context;
        }

        // GET: MDTipo_Transporte
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tipo_Transportes.ToListAsync());
        }

        // GET: MDTipo_Transporte/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDTipo_Transporte = await _context.Tipo_Transportes
                .FirstOrDefaultAsync(m => m.id_tiptran == id);
            if (mDTipo_Transporte == null)
            {
                return NotFound();
            }

            return View(mDTipo_Transporte);
        }

        // GET: MDTipo_Transporte/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MDTipo_Transporte/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_tiptran,tiptran_desc,tiptran_act")] MDTipo_Transporte mDTipo_Transporte)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mDTipo_Transporte);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mDTipo_Transporte);
        }

        // GET: MDTipo_Transporte/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDTipo_Transporte = await _context.Tipo_Transportes.FindAsync(id);
            if (mDTipo_Transporte == null)
            {
                return NotFound();
            }
            return View(mDTipo_Transporte);
        }

        // POST: MDTipo_Transporte/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_tiptran,tiptran_desc,tiptran_act")] MDTipo_Transporte mDTipo_Transporte)
        {
            if (id != mDTipo_Transporte.id_tiptran)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mDTipo_Transporte);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MDTipo_TransporteExists(mDTipo_Transporte.id_tiptran))
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
            return View(mDTipo_Transporte);
        }

        // GET: MDTipo_Transporte/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDTipo_Transporte = await _context.Tipo_Transportes
                .FirstOrDefaultAsync(m => m.id_tiptran == id);
            if (mDTipo_Transporte == null)
            {
                return NotFound();
            }

            return View(mDTipo_Transporte);
        }

        // POST: MDTipo_Transporte/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mDTipo_Transporte = await _context.Tipo_Transportes.FindAsync(id);
            _context.Tipo_Transportes.Remove(mDTipo_Transporte);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MDTipo_TransporteExists(int id)
        {
            return _context.Tipo_Transportes.Any(e => e.id_tiptran == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YMSweb.Data;
using YMSweb.Data.Entities;

namespace YMSweb.Controllers
{
    public class MDEstacionamientosController : Controller
    {
        private readonly DataContext _context;

        public MDEstacionamientosController(DataContext context)
        {
            _context = context;
        }

        // GET: MDEstacionamientos
        public async Task<IActionResult> Index()
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var id_user = _context.Usuarios.Where(x => x.Usua_user == currentUserID).Select(x => x.IdUsuario).SingleOrDefault();
            var id_sede = _context.Accesos.Where(x => x.IdUsuario == id_user).Select(x => x.id_sede).SingleOrDefault();
            return View(await _context.Estacionamientos.Where(x => x.id_sede == id_sede).ToListAsync());
        }

        // GET: MDEstacionamientos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDEstacionamiento = await _context.Estacionamientos
                .FirstOrDefaultAsync(m => m.id_estacionamiento == id);
            if (mDEstacionamiento == null)
            {
                return NotFound();
            }

            return View(mDEstacionamiento);
        }

        // GET: MDEstacionamientos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MDEstacionamientos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_estacionamiento,idplaca,esta_desc,esta_act,esta_libre,esta_cod")] MDEstacionamiento mDEstacionamiento)
        {
            int id_sede = 0;
            var sede = HttpContext.Session.GetString("Sede");
            if (sede == "AQP")
            {
                id_sede = 1;
            }
            else
            {
                id_sede = 2;
            }
            if (ModelState.IsValid)
            {
                mDEstacionamiento.id_sede = id_sede;
                _context.Add(mDEstacionamiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mDEstacionamiento);
        }

        // GET: MDEstacionamientos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDEstacionamiento = await _context.Estacionamientos.FindAsync(id);
            if (mDEstacionamiento == null)
            {
                return NotFound();
            }
            return View(mDEstacionamiento);
        }

        // POST: MDEstacionamientos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_estacionamiento,idplaca,esta_desc,esta_act,esta_libre")] MDEstacionamiento mDEstacionamiento)
        {
            if (id != mDEstacionamiento.id_estacionamiento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mDEstacionamiento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MDEstacionamientoExists(mDEstacionamiento.id_estacionamiento))
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
            return View(mDEstacionamiento);
        }

        // GET: MDEstacionamientos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDEstacionamiento = await _context.Estacionamientos
                .FirstOrDefaultAsync(m => m.id_estacionamiento == id);
            if (mDEstacionamiento == null)
            {
                return NotFound();
            }

            return View(mDEstacionamiento);
        }

        // POST: MDEstacionamientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mDEstacionamiento = await _context.Estacionamientos.FindAsync(id);
            _context.Estacionamientos.Remove(mDEstacionamiento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MDEstacionamientoExists(int id)
        {
            return _context.Estacionamientos.Any(e => e.id_estacionamiento == id);
        }
    }
}

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
    public class MDCuadrillasController : Controller
    {
        private readonly DataContext _context;

        public MDCuadrillasController(DataContext context)
        {
            _context = context;
        }

        // GET: MDCuadrillas
        public async Task<IActionResult> Index()
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var id_user = _context.Usuarios.Where(x => x.Usua_user == currentUserID).Select(x => x.IdUsuario).SingleOrDefault();
            var id_sede = _context.Accesos.Where(x => x.IdUsuario == id_user).Select(x => x.id_sede).SingleOrDefault();

            //int id_sede = 0;
            //var sede = HttpContext.Session.GetString("Sede");
            //if (sede == "AQP")
            //{
            //    id_sede = 1;
            //}
            //else
            //{
            //    id_sede = 2;
            //}
            return View(await _context.Cuadrillas.Where(x => x.id_sede == id_sede).ToListAsync());
        }

        // GET: MDCuadrillas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDCuadrilla = await _context.Cuadrillas
                .FirstOrDefaultAsync(m => m.id_cuadrilla == id);
            if (mDCuadrilla == null)
            {
                return NotFound();
            }

            return View(mDCuadrilla);
        }

        // GET: MDCuadrillas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MDCuadrillas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_cuadrilla,cua_desc,cua_act,cua_libre, cua_cod")] MDCuadrilla mDCuadrilla)
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var id_user = _context.Usuarios.Where(x => x.Usua_user == currentUserID).Select(x => x.IdUsuario).SingleOrDefault();
            var id_sede = _context.Accesos.Where(x => x.IdUsuario == id_user).Select(x => x.id_sede).SingleOrDefault();

            //int id_sede = 0;
            //var sede = HttpContext.Session.GetString("Sede");
            //if (sede == "AQP")
            //{
            //    id_sede = 1;
            //}
            //else
            //{
            //    id_sede = 2;
            //}

            if (ModelState.IsValid)
            {
                mDCuadrilla.id_sede = id_sede;
                _context.Add(mDCuadrilla);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mDCuadrilla);
        }

        // GET: MDCuadrillas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDCuadrilla = await _context.Cuadrillas.FindAsync(id);
            if (mDCuadrilla == null)
            {
                return NotFound();
            }
            return View(mDCuadrilla);
        }

        // POST: MDCuadrillas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_cuadrilla,cua_desc,cua_act,cua_libre,cua_cod")] MDCuadrilla mDCuadrilla)
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var id_user = _context.Usuarios.Where(x => x.Usua_user == currentUserID).Select(x => x.IdUsuario).SingleOrDefault();
            var id_sede = _context.Accesos.Where(x => x.IdUsuario == id_user).Select(x => x.id_sede).SingleOrDefault();
            //int id_sede = 0;
            //var sede = HttpContext.Session.GetString("Sede");
            //if (sede == "AQP")
            //{
            //    id_sede = 1;
            //}
            //else
            //{
            //    id_sede = 2;
            //}
            if (id != mDCuadrilla.id_cuadrilla)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    mDCuadrilla.id_sede = id_sede;
                    _context.Update(mDCuadrilla);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MDCuadrillaExists(mDCuadrilla.id_cuadrilla))
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
            return View(mDCuadrilla);
        }

        // GET: MDCuadrillas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDCuadrilla = await _context.Cuadrillas
                .FirstOrDefaultAsync(m => m.id_cuadrilla == id);
            if (mDCuadrilla == null)
            {
                return NotFound();
            }

            return View(mDCuadrilla);
        }

        // POST: MDCuadrillas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mDCuadrilla = await _context.Cuadrillas.FindAsync(id);
            _context.Cuadrillas.Remove(mDCuadrilla);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MDCuadrillaExists(int id)
        {
            return _context.Cuadrillas.Any(e => e.id_cuadrilla == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YMSweb.Data;
using YMSweb.Data.Entities;

namespace YMSweb.Controllers
{
    public class MDTipo_UnidadController : Controller
    {
        private readonly DataContext _context;
        public MDTipo_UnidadController(DataContext context)
        {
            _context = context;
        }
        // GET: MDTipo_UnidadController
        public async Task<ActionResult> Index()
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
            return View(await _context.Tipo_Unidades.Where(x => x.id_sede == id_sede).ToListAsync());
        }

        // GET: MDTipo_UnidadController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MDTipo_UnidadController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MDTipo_UnidadController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("id_tipuni, tipuni_cod, tipuni_desc")] MDTipo_unidad mDTipo_Unidad)
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
                mDTipo_Unidad.id_sede = id_sede;
                _context.Add(mDTipo_Unidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mDTipo_Unidad);
        }

        // GET: MDTipo_UnidadController/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDTipo_Unidad = await _context.Tipo_Unidades.FindAsync(id);
            if (mDTipo_Unidad == null)
            {
                return NotFound();
            }
            return View(mDTipo_Unidad);
        }

        // POST: MDTipo_UnidadController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("id_tipuni, tipuni_cod, tipuni_desc")] MDTipo_unidad mDTipo_Unidad)
        {
            if (id != mDTipo_Unidad.id_tipuni)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mDTipo_Unidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!mDTipo_UnidadExists(mDTipo_Unidad.id_tipuni))
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
            return View(mDTipo_Unidad);
        }

        // GET: MDTipo_UnidadController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MDTipo_UnidadController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDTipo_Unidad = await _context.Tipo_Unidades
                .FirstOrDefaultAsync(m => m.id_tipuni == id);
            if (mDTipo_Unidad == null)
            {
                return NotFound();
            }

            return View(mDTipo_Unidad);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mDTipo_Unidad = await _context.Tipo_Unidades.FindAsync(id);
            _context.Tipo_Unidades.Remove(mDTipo_Unidad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool mDTipo_UnidadExists(int id)
        {
            return _context.Anexos.Any(e => e.id_anexo == id);
        }
    }
}

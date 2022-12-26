using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using YMSweb.Data;
using YMSweb.Data.Entities;

namespace YMSweb.Controllers
{
    public class AnexosController : Controller
    {
        private readonly DataContext _context;        
        public AnexosController(DataContext context)
        {
            _context = context;
          
        }
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
            return View(await _context.Anexos.Where(x => x.id_sede == id_sede).ToListAsync());
        }

        // GET: MDEstacionamientos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDanexos = await _context.Anexos
                .FirstOrDefaultAsync(m => m.id_anexo == id);
            if (mDanexos == null)
            {
                return NotFound();
            }

            return View(mDanexos);
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
        public async Task<IActionResult> Create([Bind("id_anexo, anex_desc, anex_act, anex_cod")] MDAnexos mDanexos)
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
                mDanexos.id_sede = id_sede;
                _context.Add(mDanexos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mDanexos);
        }

        // GET: MDEstacionamientos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDanexos = await _context.Anexos.FindAsync(id);
            if (mDanexos == null)
            {
                return NotFound();
            }
            return View(mDanexos);
        }

        // POST: MDEstacionamientos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_anexo, anex_desc, anex_act, anex_cod")] MDAnexos mDanexos)
        {
            if (id != mDanexos.id_anexo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mDanexos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MDAnexosExists(mDanexos.id_anexo))
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
            return View(mDanexos);
        }

        // GET: MDEstacionamientos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDanexos = await _context.Anexos
                .FirstOrDefaultAsync(m => m.id_anexo == id);
            if (mDanexos == null)
            {
                return NotFound();
            }

            return View(mDanexos);
        }

        // POST: MDEstacionamientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mDanexos = await _context.Anexos.FindAsync(id);
            _context.Anexos.Remove(mDanexos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MDAnexosExists(int id)
        {
            return _context.Anexos.Any(e => e.id_anexo == id);
        }
    }
}

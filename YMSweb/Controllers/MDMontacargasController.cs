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
    public class MDMontacargasController : Controller
    {
        private readonly DataContext _context;

        public MDMontacargasController(DataContext context)
        {
            _context = context;
        }

        // GET: MDCanals
        public async Task<IActionResult> Index()
        {
            try
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
                return View(await _context.Montacargas.Where(x => x.id_sede == id_sede).ToListAsync());
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }

        // GET: MDCanals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDCanal = await _context.Montacargas
                .FirstOrDefaultAsync(m => m.id_monta == id);
            if (mDCanal == null)
            {
                return NotFound();
            }

            return View(mDCanal);
        }

        // GET: MDCanals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MDCanals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_monta,monta_desc,monta_act, monta_cod")] MDMontacargas mDMontacargas)
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
                mDMontacargas.id_sede = id_sede;
                _context.Add(mDMontacargas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mDMontacargas);
        }

        // GET: MDCanals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDmontacarga = await _context.Montacargas.FindAsync(id);
            if (mDmontacarga == null)
            {
                return NotFound();
            }
            return View(mDmontacarga);
        }

        // POST: MDCanals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_monta,monta_desc,monta_act, monta_cod")] MDMontacargas mDMontacargas)
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
            if (id != mDMontacargas.id_monta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    mDMontacargas.id_sede = id_sede;
                    _context.Update(mDMontacargas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MDCanalExists(mDMontacargas.id_monta))
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
            return View(mDMontacargas);
        }

        // GET: MDCanals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDmontacargas = await _context.Montacargas
                .FirstOrDefaultAsync(m => m.id_monta == id);
            if (mDmontacargas == null)
            {
                return NotFound();
            }

            return View(mDmontacargas);
        }

        // POST: MDCanals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mDmontacargas = await _context.Montacargas.FindAsync(id);
            _context.Montacargas.Remove(mDmontacargas);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MDCanalExists(int id)
        {
            return _context.Canales.Any(e => e.id_canal == id);
        }
    }
}

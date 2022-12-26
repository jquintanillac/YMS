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
   
    public class MDCanalsController : Controller
    {
        private readonly DataContext _context;

        public MDCanalsController(DataContext context)
        {
            _context = context;
        }

        // GET: MDCanals
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
            return View(await _context.Canales.Where(x => x.id_sede == id_sede).OrderBy(x => x.id_canal).ToListAsync());
        }

        // GET: MDCanals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDCanal = await _context.Canales
                .FirstOrDefaultAsync(m => m.id_canal == id);
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
        public async Task<IActionResult> Create([Bind("id_canal,can_desc,can_act, can_cod")] MDCanal mDCanal)
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var id_user = _context.Usuarios.Where(x => x.Usua_user == currentUserID).Select(x => x.IdUsuario).SingleOrDefault();
            var id_sede = _context.Accesos.Where(x => x.IdUsuario == id_user).Select(x => x.id_sede).SingleOrDefault();


            if (ModelState.IsValid)
            {
                mDCanal.id_sede = id_sede;
                _context.Add(mDCanal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mDCanal);
        }

        // GET: MDCanals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDCanal = await _context.Canales.FindAsync(id);
            if (mDCanal == null)
            {
                return NotFound();
            }
            return View(mDCanal);
        }

        // POST: MDCanals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_canal,can_desc,can_act, can_cod")] MDCanal mDCanal)
        {
            if (id != mDCanal.id_canal)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mDCanal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MDCanalExists(mDCanal.id_canal))
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
            return View(mDCanal);
        }

        // GET: MDCanals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDCanal = await _context.Canales
                .FirstOrDefaultAsync(m => m.id_canal == id);
            if (mDCanal == null)
            {
                return NotFound();
            }

            return View(mDCanal);
        }

        // POST: MDCanals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mDCanal = await _context.Canales.FindAsync(id);
            _context.Canales.Remove(mDCanal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MDCanalExists(int id)
        {
            return _context.Canales.Any(e => e.id_canal == id);
        }
    }
}

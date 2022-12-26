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
    public class MDMuellesController : Controller
    {
        private readonly DataContext _context;

        public MDMuellesController(DataContext context)
        {
            _context = context;
        }

        // GET: MDMuelles
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
            return View(await _context.Muelles.Where(x => x.id_sede == id_sede).ToListAsync());
        }

        // GET: MDMuelles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDMuelle = await _context.Muelles
                .FirstOrDefaultAsync(m => m.id_muelle == id);
            if (mDMuelle == null)
            {
                return NotFound();
            }

            return View(mDMuelle);
        }

        // GET: MDMuelles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MDMuelles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_muelle,mue_desc,mue_act,mue_libre,mue_cod")] MDMuelle mDMuelle)
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
                mDMuelle.id_sede = id_sede;
                _context.Add(mDMuelle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mDMuelle);
        }

        // GET: MDMuelles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDMuelle = await _context.Muelles.FindAsync(id);
            if (mDMuelle == null)
            {
                return NotFound();
            }
            return View(mDMuelle);
        }

        // POST: MDMuelles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_muelle,mue_desc,mue_act,mue_libre")] MDMuelle mDMuelle)
        {
            if (id != mDMuelle.id_muelle)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mDMuelle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MDMuelleExists(mDMuelle.id_muelle))
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
            return View(mDMuelle);
        }

        // GET: MDMuelles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDMuelle = await _context.Muelles
                .FirstOrDefaultAsync(m => m.id_muelle == id);
            if (mDMuelle == null)
            {
                return NotFound();
            }

            return View(mDMuelle);
        }

        // POST: MDMuelles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mDMuelle = await _context.Muelles.FindAsync(id);
            _context.Muelles.Remove(mDMuelle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MDMuelleExists(int id)
        {
            return _context.Muelles.Any(e => e.id_muelle == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using YMSweb.Data;
using YMSweb.Data.DataSql;
using YMSweb.Data.Entities;
using YMSweb.Models.ViewModels;

namespace YMSweb.Controllers
{
    public class MDRol_UsuarioController : Controller
    {
        private readonly DataContext _context;
        SP_Administracion _administracion;
        public MDRol_UsuarioController(DataContext context)
        {
            _context = context;
            _administracion = new SP_Administracion();
        }

        // GET: MDRol_Usuario
        public async Task<IActionResult> Index()
        {
            //return View(await _context.Rol_Usuarios.ToListAsync());        
            ViewBag.Roluser = await _administracion.mRol_Usuarios();
            ViewBag.Usuario = await _context.Usuarios.ToListAsync();
            ViewBag.rol = await _context.Roles.ToListAsync();
            return View();

        }

        // GET: MDRol_Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDRol_Usuario = await _context.Rol_Usuarios
                .FirstOrDefaultAsync(m => m.Idrol_usua == id);
            if (mDRol_Usuario == null)
            {
                return NotFound();
            }

            return View(mDRol_Usuario);
        }

        // GET: MDRol_Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MDRol_Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int iduser, int idrol)
        {
            //if (ModelState.IsValid)
            //{
            MDRol_Usuario mDRol_Usuario = new MDRol_Usuario
            {
                Idrol = idrol,
                IdUsuario = iduser

            };
                _context.Add(mDRol_Usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            //}
            //return View(mDRol_Usuario);
        }

        // GET: MDRol_Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDRol_Usuario = await _context.Rol_Usuarios.FindAsync(id);
            if (mDRol_Usuario == null)
            {
                return NotFound();
            }
            return View(mDRol_Usuario);
        }

        // POST: MDRol_Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idrol_usua,Idrol,IdUsuario")] MDRol_Usuario mDRol_Usuario)
        {
            if (id != mDRol_Usuario.Idrol_usua)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mDRol_Usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MDRol_UsuarioExists(mDRol_Usuario.Idrol_usua))
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
            return View(mDRol_Usuario);
        }

        // GET: MDRol_Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDRol_Usuario = await _context.Rol_Usuarios
                .FirstOrDefaultAsync(m => m.Idrol_usua == id);
            if (mDRol_Usuario == null)
            {
                return NotFound();
            }

            return View(mDRol_Usuario);
        }

        // POST: MDRol_Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mDRol_Usuario = await _context.Rol_Usuarios.FindAsync(id);
            _context.Rol_Usuarios.Remove(mDRol_Usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MDRol_UsuarioExists(int id)
        {
            return _context.Rol_Usuarios.Any(e => e.Idrol_usua == id);
        }

        [BindProperty]
        public MDUsuario dUsuario { get; set; }
        [HttpPost]
        public async Task<IActionResult> BUsuario()
        {
             ViewBag.Usuario = await _context.Rol_Usuarios.ToListAsync();                        
            return PartialView("_BuscarUsuario");
        }


    }
}

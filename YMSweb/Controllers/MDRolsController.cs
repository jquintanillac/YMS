using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YMSweb.Data;
using YMSweb.Data.DataSql;
using YMSweb.Data.Entities;

namespace YMSweb.Controllers
{
    public class MDRolsController : Controller
    {
        private readonly DataContext _context;
        SP_Administracion _Administracion;

        public MDRolsController(DataContext context)
        {
            _context = context;
            _Administracion = new SP_Administracion();
        }

        // GET: MDRols
        public async Task<IActionResult> Index()
        {
            return View(await _context.Roles.ToListAsync());
        }

        // GET: MDRols/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MDRols/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idrol,rol_desc")] MDRol mDRol)
        {
            try
            {
                ClaimsPrincipal currentUser = this.User;
                var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
                var id_user = _context.Usuarios.Where(x => x.Usua_user == currentUserID).Select(x => x.IdUsuario).SingleOrDefault();
                var id_sede = _context.Accesos.Where(x => x.IdUsuario == id_user).Select(x => x.id_sede).SingleOrDefault();

                if (ModelState.IsValid)
                {
                    MDRol mDrol2 = new MDRol()
                    {
                        rol_desc = mDRol.rol_desc,
                        id_sede = id_sede
                    };
                    _context.Add(mDrol2);
                    await _context.SaveChangesAsync();
                    await _Administracion.mInsrolpermiso(mDrol2.Idrol);
                    return RedirectToAction(nameof(Index));
                }
                return View(mDRol);
            }
            catch (Exception ex)
            {
                TempData["success"] = "No se pudieron grabar los datos.";
                return View();
            }
           
        }

        // GET: MDRols/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var mDRol = await _context.Roles.FindAsync(id);
                if (mDRol == null)
                {
                    return NotFound();
                }
                return View(mDRol);
            }
            catch (Exception ex)
            {
                TempData["success"] = "No se pudieron grabar los datos.";
                return View();
            }
      
        }

        // POST: MDRols/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idrol,rol_desc")] MDRol mDRol)
        {
            try
            {
                if (id != mDRol.Idrol)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(mDRol);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!MDRolExists(mDRol.Idrol))
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
                return View(mDRol);
            }
            catch (Exception ex)
            {
                TempData["success"] = "No se pudieron grabar los datos.";
                return View();
            }
         
        }

        // GET: MDRols/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var mDRol = await _context.Roles
                    .FirstOrDefaultAsync(m => m.Idrol == id);
                if (mDRol == null)
                {
                    return NotFound();
                }

                return View(mDRol);
            }
            catch (Exception ex)
            {
                TempData["success"] = "No se pudieron grabar los datos.";
                return View();
            }
 
        }

        // POST: MDRols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var mDRol = await _context.Roles.FindAsync(id);
                _context.Roles.Remove(mDRol);
                await _Administracion.mDelrolpermiso(mDRol.Idrol);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["success"] = "No se pudieron grabar los datos.";
                return View();
            }
    
        }

        private bool MDRolExists(int id)
        {
            return _context.Roles.Any(e => e.Idrol == id);
        }
    }
}

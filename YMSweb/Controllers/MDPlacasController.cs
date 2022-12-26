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
using Microsoft.Extensions.Configuration;
using YMSweb.Data;
using YMSweb.Data.DataSql;
using YMSweb.Data.Entities;

namespace YMSweb.Controllers
{
    public class MDPlacasController : Controller
    {
        private readonly DataContext _context;
        SP_Operaciones _operaciones;
        public MDPlacasController(DataContext context)
        {
            _context = context;
            _operaciones = new SP_Operaciones();
        }

        // GET: MDPlacas
        public async Task<IActionResult> Index()
        {
            try
            {
                //string conn = _config["ConnectionStrings:DefaultConnection"];
                ViewBag.placas = await _operaciones.mPlacas();
                ViewBag.chofer = await _context.Choferes.ToListAsync();
                ViewBag.transportista = await _context.Transportistas.ToListAsync();
                ViewBag.tipounidad = await _context.Tipo_Unidades.ToListAsync();
                return View();
            }
            catch (Exception ex)
            {
                TempData["success"] = "Error por favor vuelva a ingresar.";
                return View();
            }

            //return View(await _context.Placas.ToListAsync());
        }


        // GET: MDPlacas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MDPlacas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int id_chofer, int id_transp, string Placa, int id_tipo, bool activa, bool libre)
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
                if (id_transp == 0)
                {
                    TempData["success"] = "El campo transportista es obligatorio.";
                    return RedirectToAction(nameof(Index));
                }

                MDPlaca mDPlaca = new MDPlaca()
                {
                    id_chofer = id_chofer,
                    id_transp = id_transp,
                    plac_desc = Placa,
                    id_tipo = id_tipo,
                    plac_act = activa,
                    plac_libre = libre,
                    id_sede = id_sede
                };
                _context.Add(mDPlaca);
                await _context.SaveChangesAsync();
                TempData["success"] = "El registro se grabo satisfactoriamente.";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["success"] = "Error por favor vuelva a ingresar.";
                return RedirectToAction(nameof(Index));
            }

        }

        // GET: MDPlacas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                //string conn = _config["ConnectionStrings:DefaultConnection"];
                ViewBag.placas = await _operaciones.mPlacas();
                ViewBag.chofer = await _context.Choferes.ToListAsync();
                ViewBag.transportista = await _context.Transportistas.ToListAsync();
                ViewData["id"] = id;
                var mDPlaca = await _context.Placas.FindAsync(id);
                if (mDPlaca == null)
                {
                    return NotFound();
                }

                return View();
            }
            catch (Exception ex)
            {
                TempData["success"] = "Error por favor vuelva a ingresar.";
                return View();
            }

        }

        // POST: MDPlacas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int id_chofer, int id_transp, string Tipo, bool activa, bool libre)
        {
            try
            { 
               var mDPlaca = await _context.Placas.FindAsync(id);
                mDPlaca.id_chofer = id_chofer;
                mDPlaca.id_transp = id_transp;
                mDPlaca.plac_tipo = Tipo;
                mDPlaca.plac_act = activa;
                mDPlaca.plac_libre = libre;        
                _context.Update(mDPlaca);
                await _context.SaveChangesAsync();
                return RedirectToAction("Edit", "MDPlacas");
            }
            catch (Exception ex)
            {
                TempData["success"] = "Error por favor vuelva a ingresar.";
                return RedirectToAction("Edit", "MDPlacas");
            }

        }

        // GET: MDPlacas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var mDPlaca = await _context.Placas
                    .FirstOrDefaultAsync(m => m.id_placa == id);
                if (mDPlaca == null)
                {
                    return NotFound();
                }

                return View(mDPlaca);
            }
            catch (Exception ex)
            {
                TempData["success"] = "Error por favor vuelva a ingresar.";
                return View();
            }

        }

        // POST: MDPlacas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var mDPlaca = await _context.Placas.FindAsync(id);
                _context.Placas.Remove(mDPlaca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["success"] = "Error por favor vuelva a ingresar.";
                return View();
            }

        }

        private bool MDPlacaExists(int id)
        {
            return _context.Placas.Any(e => e.id_placa == id);
        }
    }
}

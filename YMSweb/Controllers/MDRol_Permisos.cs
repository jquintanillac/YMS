using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YMSweb.Data;
using YMSweb.Data.DataSql;

namespace YMSweb.Controllers
{
    public class MDRol_Permisos : Controller
    {
        private readonly DataContext _context;
        SP_Administracion _administracion;

        public MDRol_Permisos(DataContext context)
        {
            _context = context;
            _administracion = new SP_Administracion();
        }

        // GET: MDRol_Permisos
        public async Task<ActionResult> Index(int idrol)
        {
            ViewBag.role = await _context.Roles.Where(x => x.id_sede == 1).ToListAsync();
            if (idrol == 0)
            {
                idrol = 1;
            }
            ViewBag.admin = await _administracion.mRolpermadmin(idrol);
            ViewBag.oper = await _administracion.mRolpermoper(idrol);
            ViewBag.prog = await _administracion.mRolpermprog(idrol);
            ViewBag.segu = await _administracion.mRolpermsegu(idrol);
            ViewBag.repor = await _administracion.mRolpermrepor(idrol);

            return View();
        }

        // GET: MDRol_Permisos/Details/5
        public async Task<ActionResult> updatepermisos(int id_rolperm)
        {
            await _administracion.mUpdatemenu(id_rolperm);
            return RedirectToAction("Index", "MDRol_Permisos");
        }

        // GET: MDRol_Permisos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MDRol_Permisos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MDRol_Permisos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MDRol_Permisos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MDRol_Permisos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MDRol_Permisos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

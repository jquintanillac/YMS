using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using YMSweb.Data;
using YMSweb.Data.DataSql;
using YMSweb.Data.Entities;
using YMSweb.Helpers;
using YMSweb.Models.ViewModels;

namespace YMSweb.Controllers
{
    public class MDUsuariosController : Controller
    {
        private readonly DataContext _context;
        SP_Administracion _administracion;
        //private readonly IHostingEnvironment hostingEnvironment;

        public MDUsuariosController(DataContext context)
        {
            _context = context;           
            _administracion = new SP_Administracion();

        }

        // GET: MDUsuarios
        public async Task<IActionResult> Index()
        {
            try
            {
                ViewBag.usuario = await _context.Usuarios.ToListAsync();
                return View();
            }
            catch (Exception ex)
            {
                TempData["success"] = "No se pudieron grabar los datos.";
                return View();
            }
           
        }

        // POST: MDUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,Usua_user,Usua_nombres,Usua_apellidos,Usua_email,Usua_pass,Usua_act, Usua_ruta")] VMUsuario mDUsuario, [FromServices] IHostingEnvironment hostingEnviroment)
        {
            try
            {
                string uniquefilename = null;
                string filename = null;
                string filename2 = null;
                if (mDUsuario.Usua_ruta != null)
                {
                    //string updaload = Path.Combine(hostingEnvironment.WebRootPath, "Fotos");                   
                    uniquefilename = Guid.NewGuid().ToString() + "_" + mDUsuario.Usua_ruta.FileName;
                    //string Filepath = Path.Combine(updaload, uniquefilename);
                    //mDUsuario.Usua_ruta.CopyTo(new FileStream(Filepath, FileMode.Create)); 
                    filename = $"{hostingEnviroment.WebRootPath}\\Fotos\\{uniquefilename}";
                    filename2 = $"~/Fotos/{uniquefilename}";
                    using (FileStream fileStream = System.IO.File.Create(filename))
                    {
                        mDUsuario.Usua_ruta.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                }
                var result = await _context.Usuarios.Where(x => x.Usua_user == mDUsuario.Usua_user).SingleOrDefaultAsync();
                if (result != null)
                {
                    TempData["success"] = "El usuario ya existe.";
                    return RedirectToAction("Index");
                }
                else
                {
                    var hash = HashHelper.Hash(mDUsuario.Usua_pass);
                    mDUsuario.Usua_pass = hash.Password;
                    mDUsuario.Usua_Hash = hash.Salt;

                    MDUsuario dUsuario = new MDUsuario
                    {
                        Usua_user = mDUsuario.Usua_user,
                        Usua_nombres = mDUsuario.Usua_nombres,
                        Usua_apellidos = mDUsuario.Usua_apellidos,
                        Usua_email = mDUsuario.Usua_email,
                        Usua_pass = mDUsuario.Usua_pass,
                        Usua_Hash = mDUsuario.Usua_Hash,
                        Usua_act = mDUsuario.Usua_act,
                        Usua_imagen = filename2,
                        id_sede = 1
                        
                    };


                    _context.Usuarios.Add(dUsuario);
                    await _context.SaveChangesAsync();
                    mDUsuario.Usua_pass = "";
                    mDUsuario.Usua_Hash = "";
                    TempData["success"] = "El usuario se creo correctamente.";
                    return RedirectToAction("Index");

                }
            }
            catch (Exception ex)
            {
                TempData["success"] = "No se pudieron grabar los datos.";
                return RedirectToAction("Index");
            }
        

            //}
            //return View(mDUsuario);
           // return RedirectToAction("Index");
        }

        // GET: MDUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var mDUsuario = await _context.Usuarios.FindAsync(id);
                if (mDUsuario == null)
                {
                    return NotFound();
                }
                return View(mDUsuario);
            }
            catch (Exception ex)
            {
                TempData["success"] = "No se pudieron grabar los datos.";
                return View();
            }
           
        }

        // POST: MDUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editconfirmar(int IdUsuario, string Usua_user, string Usua_nombres, string Usua_apellidos, string Usua_email, string Usua_pass, bool Usua_act)
        {
            try
            {
                var hash = HashHelper.Hash(Usua_pass);
                var Usua_pass1 = hash.Password;
                var Usua_Hash1 = hash.Salt;
                await _administracion.mUpdateUsuario(IdUsuario, Usua_user, Usua_nombres, Usua_apellidos, Usua_email, Usua_pass1, Usua_Hash1, Usua_act);                
                   
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["success"] = "No se pudieron grabar los datos.";
                return RedirectToAction("Index");
            }
          
        }

        // GET: MDUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var mDUsuario = await _context.Usuarios
                    .FirstOrDefaultAsync(m => m.IdUsuario == id);
                if (mDUsuario == null)
                {
                    return NotFound();
                }

                return View(mDUsuario);
            }
            catch (Exception ex)
            {
                TempData["success"] = "No se pudieron grabar los datos.";
                return View();
            }
         
        }

        // POST: MDUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var mDUsuario = await _context.Usuarios.FindAsync(id);
                _context.Usuarios.Remove(mDUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["success"] = "No se pudieron grabar los datos.";
                return View();
            }
       
        }

        private bool MDUsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.IdUsuario == id);
        }

    }
}

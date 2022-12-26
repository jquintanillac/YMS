using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ExcelDataReader;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
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
    public class MDCamiones_PlanificadosController : Controller
    {
        private readonly DataContext _context;
        SP_Operaciones _operaciones;        
        public MDCamiones_PlanificadosController(DataContext context)
        {
            _context = context;
            _operaciones = new SP_Operaciones();
        }
      
        public async Task<IActionResult> Carga(int placa)
        {
            try
            {
                ClaimsPrincipal currentUser = this.User;
                var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
                var id_user = _context.Usuarios.Where(x => x.Usua_user == currentUserID).Select(x => x.IdUsuario).SingleOrDefault();
                var id_sede = _context.Accesos.Where(x => x.IdUsuario == id_user).Select(x => x.id_sede).SingleOrDefault();

                string cardesc = "C";
                ViewData["carga"] = cardesc;
                if (placa == 0)
                {
                    placa = 0;
                }            
                ViewBag.camplani = await _operaciones.mCamiones_Planificados_Carga(placa, id_sede);
                ViewBag.placas = await _context.Placas.Where(x => x.id_sede == 1).ToListAsync();
                ViewBag.tipotrans = await _context.Tipo_Transportes.Where(x => x.id_sede == 1).ToListAsync();
                ViewBag.Nroviaj = await _context.Camiones_Planificados_Cabecera.Where(x => x.id_sede == id_sede).OrderByDescending(x => x.id_camplacab).ToListAsync();
                ViewData["placa"] = placa;
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }

        }

        public async Task<IActionResult> Descarga(int placa)
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var id_user = _context.Usuarios.Where(x => x.Usua_user == currentUserID).Select(x => x.IdUsuario).SingleOrDefault();
            var id_sede = _context.Accesos.Where(x => x.IdUsuario == id_user).Select(x => x.id_sede).SingleOrDefault();


            string cardesc = "D";
            ViewData["carga"] = cardesc;
            if (placa == 0)
            {
                placa = 0;
            }
            
            ViewBag.camplani = await _operaciones.mCamiones_Planificados_Descarga(placa, id_sede);
            ViewBag.placas = await _context.Placas.Where(x => x.id_sede == 1).ToListAsync();
            ViewBag.tipotrans = await _context.Tipo_Transportes.Where(x => x.id_sede == 1).ToListAsync();
            ViewBag.Nroviaj = await _context.Camiones_Planificados_Cabecera.Where(x => x.id_sede == id_sede).OrderByDescending(x => x.id_camplacab).ToListAsync();
            ViewData["placa"] = placa;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Importarcarga(IFormFile file, [FromServices] IHostingEnvironment hostingEnviroment)
        {
            DateTime fecha = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");
            try
            {
                ClaimsPrincipal currentUser = this.User;
                var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
                var id_user = _context.Usuarios.Where(x => x.Usua_user == currentUserID).Select(x => x.IdUsuario).SingleOrDefault();
                var id_sede = _context.Accesos.Where(x => x.IdUsuario == id_user).Select(x => x.id_sede).SingleOrDefault();
           
                string filename = $"{hostingEnviroment.WebRootPath}\\Files\\{file.FileName}";
                using (FileStream fileStream = System.IO.File.Create(filename))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }
                int nro_viaje_fin;
                int ind_viaj = 1;
                var mCarga = this.mCargas(file.FileName);
                
                foreach (var item in mCarga)
                {
                    int id_plac = await _operaciones.mBuscaplac(item.placa);
                    if (id_plac != 0)
                    {
                        if (ind_viaj == Convert.ToInt32(item.ind_viaj))
                        {
                            int ind_cam = await _operaciones.mBuscaViaje(id_plac, fecha);
                            if (ind_cam != 0)
                            {
                                nro_viaje_fin = ind_cam;
                                MDCamiones_Planificados mDCamiones_Planificadosc = new MDCamiones_Planificados()
                                {
                                    id_camplacab = nro_viaje_fin,
                                    id_placa = id_plac,
                                    id_tiptran = Convert.ToInt32(item.tipo_trans),
                                    campla_nrotrans = item.Nro_transp,
                                    campla_peso = item.peso,
                                    campla_volumen = item.volumen,
                                    campla_fecha = fecha,
                                    campla_obse = item.observacion,
                                    campla_cardesc = "C",
                                    id_sede = id_sede,
                                    campla_fase = "0"
                                };
                                _context.Add(mDCamiones_Planificadosc);
                                await _context.SaveChangesAsync();
                                await _operaciones.mGenerarViaje(item.Nro_transp, fecha, id_sede);
                            }
                            else
                            {
                                MDCamiones_Planificados_Cabecera mDCamiones_Planificados_Cabecera = new MDCamiones_Planificados_Cabecera()
                                {
                                    camplacab_fecha = fecha,
                                    camplacab_act = true,
                                    camplacab_obs = item.observacion,
                                    camplacab_fin = "N",
                                    id_sede = id_sede
                                };
                                _context.Add(mDCamiones_Planificados_Cabecera);
                                await _context.SaveChangesAsync();
                                var nro_viaje = _context.Camiones_Planificados_Cabecera.Max(p => p.id_camplacab);
                                nro_viaje_fin = Convert.ToInt32(nro_viaje);
                                MDCamiones_Planificados mDCamiones_Planificadosc = new MDCamiones_Planificados()
                                {
                                    id_camplacab = nro_viaje_fin,
                                    id_placa = id_plac,
                                    id_tiptran = Convert.ToInt32(item.tipo_trans),
                                    campla_nrotrans = item.Nro_transp,
                                    campla_peso = item.peso,
                                    campla_volumen = item.volumen,
                                    campla_fecha = fecha,
                                    campla_obse = item.observacion,
                                    campla_cardesc = "C",
                                    id_sede = id_sede,
                                    campla_fase = "0"
                                };
                                _context.Add(mDCamiones_Planificadosc);
                                await _context.SaveChangesAsync();
                                await _operaciones.mGenerarViaje(item.Nro_transp, fecha, id_sede);
                            }
                        }
                        else
                        {
                            MDCamiones_Planificados_Cabecera mDCamiones_Planificados_Cabecera = new MDCamiones_Planificados_Cabecera()
                            {
                                camplacab_fecha = fecha,
                                camplacab_act = true,
                                camplacab_obs = item.observacion,
                                camplacab_fin = "N",
                                id_sede = id_sede
                            };
                            _context.Add(mDCamiones_Planificados_Cabecera);
                            await _context.SaveChangesAsync();
                            var nro_viaje = _context.Camiones_Planificados_Cabecera.Max(p => p.id_camplacab);
                            nro_viaje_fin = Convert.ToInt32(nro_viaje);
                            MDCamiones_Planificados mDCamiones_Planificadosc = new MDCamiones_Planificados()
                            {
                                id_camplacab = nro_viaje_fin,
                                id_placa = id_plac,
                                id_tiptran = Convert.ToInt32(item.tipo_trans),
                                campla_nrotrans = item.Nro_transp,
                                campla_peso = item.peso,
                                campla_volumen = item.volumen,
                                campla_fecha = fecha,
                                campla_obse = item.observacion,
                                campla_cardesc = "C",
                                id_sede = id_sede,
                                campla_fase = "0"
                            };
                            _context.Add(mDCamiones_Planificadosc);
                            await _context.SaveChangesAsync();
                            await _operaciones.mGenerarViaje(item.Nro_transp, fecha, id_sede);
                            ind_viaj = ind_viaj + 1;
                        }                       
                    }
                }
                TempData["success"] = "Los registros se importaron correctamente.";
                return RedirectToAction("Carga", "MDCamiones_Planificados");
            }
            catch (Exception ex)
            {
                TempData["error"] = "Fallo la importacion de excel, revisar el archivo.";
                return RedirectToAction("Carga", "MDCamiones_Planificados");
            }
        }

        private List<VMCarga> mCargas(string fName)
        {
            List<VMCarga> mCargas = new List<VMCarga>();
            var fileName = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\Files"}" + "\\" + fName;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using (var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while (reader.Read())
                    {
                        mCargas.Add(new VMCarga()
                        {
                            placa = reader.GetValue(0).ToString(),                                                        
                            Nro_transp = reader.GetValue(1).ToString(),
                            peso = reader.GetValue(2).ToString(),
                            volumen = reader.GetValue(3).ToString(),
                            tipo_trans = reader.GetValue(4).ToString(),
                            ind_viaj = reader.GetValue(5).ToString(),
                            observacion = reader.GetValue(6).ToString()
                        });
                    }
                }
            }
            return mCargas;
        }

        [HttpPost]
        public async Task<IActionResult> ImportarDescarga(IFormFile file, [FromServices] IHostingEnvironment hostingEnviroment)
        {
            DateTime fecha = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");
            try
            {
                ClaimsPrincipal currentUser = this.User;
                var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
                var id_user = _context.Usuarios.Where(x => x.Usua_user == currentUserID).Select(x => x.IdUsuario).SingleOrDefault();
                var id_sede = _context.Accesos.Where(x => x.IdUsuario == id_user).Select(x => x.id_sede).SingleOrDefault();
               
                string filename = $"{hostingEnviroment.WebRootPath}\\Files\\{file.FileName}";
            using (FileStream fileStream = System.IO.File.Create(filename))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            int nro_viaje_fin;
            var mDescarga = this.mDescargas(file.FileName);

            foreach (var item in mDescarga)
            {                               
                int id_plac = await _operaciones.mBuscaplac(item.placa);
                if(id_plac != 0)
                {
                    MDCamiones_Planificados_Cabecera mDCamiones_Planificados_Cabecera = new MDCamiones_Planificados_Cabecera()
                    {
                        camplacab_fecha = Convert.ToDateTime(item.feclleg),
                        camplacab_act = false,
                        camplacab_obs = item.observacion,
                        camplacab_fin = "N",
                        id_sede = id_sede
                    };
                    _context.Add(mDCamiones_Planificados_Cabecera);
                    await _context.SaveChangesAsync();
                    var nro_viaje = _context.Camiones_Planificados_Cabecera.Max(p => p.id_camplacab);
                    nro_viaje_fin = Convert.ToInt32(nro_viaje);

                    MDCamiones_Planificados mDCamiones_Planificados = new MDCamiones_Planificados()
                    {
                        id_camplacab = nro_viaje_fin,
                        id_placa = id_plac,
                        id_tiptran = 1,
                        campla_nrotrans = item.nro_transp,
                        campla_peso = item.peso,
                        campla_volumen = item.volumen,
                        campla_fecha = fecha,
                        campla_obse = item.observacion,
                        campla_cardesc = "D",
                        id_sede = id_sede,
                        campla_fase = "0"
                    };
                    _context.Add(mDCamiones_Planificados);
                    await _context.SaveChangesAsync();
                    await _operaciones.mGenerarViaje(item.nro_transp, fecha, id_sede);
                }
              
            }
                TempData["success"] = "Los registros se importaron correctamente.";
                return RedirectToAction("Descarga", "MDCamiones_Planificados");
            }
            catch (Exception ex)
            {
                TempData["error"] = "Fallo la importacion de excel, revisar el archivo.";
                return RedirectToAction("Descarga", "MDCamiones_Planificados");
            }
        }

        private List<VMDescarga> mDescargas(string fName)
        {
            List<VMDescarga> mDescargas = new List<VMDescarga>();
            var fileName = $"{Directory.GetCurrentDirectory()}{@"\wwwroot\Files"}" + "\\" + fName;
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            using(var stream = System.IO.File.Open(fileName, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    while(reader.Read())
                    {
                        mDescargas.Add(new VMDescarga()
                        {
                            feclleg = reader.GetValue(0).ToString(),
                            nro_transp = reader.GetValue(1).ToString(),
                            peso = reader.GetValue(2).ToString(),
                            volumen = reader.GetValue(3).ToString(),
                            placa = reader.GetValue(4).ToString(),
                            tipo_uni = reader.GetValue(5).ToString(),
                            observacion = reader.GetValue(6).ToString()
                        });
                    }
                }
            }
            return mDescargas;
        }

        // GET: MDCamiones_Planificados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDCamiones_Planificados = await _context.Camiones_Planificados
                .FirstOrDefaultAsync(m => m.id_campla == id);
            if (mDCamiones_Planificados == null)
            {
                return NotFound();
            }

            return View(mDCamiones_Planificados);
        }

        // GET: MDCamiones_Planificados/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MDCamiones_Planificados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Create(int placa, int tiptran, string dcampla_nrotrans, string dcampla_peso, string dcampla_volumen, string dcampla_obse, int Nroviaj, string campla_cardesc)
        {
            DateTime fecha = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");
            try
            {
                ClaimsPrincipal currentUser = this.User;
                var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
                var id_user = _context.Usuarios.Where(x => x.Usua_user == currentUserID).Select(x => x.IdUsuario).SingleOrDefault();
                var id_sede = _context.Accesos.Where(x => x.IdUsuario == id_user).Select(x => x.id_sede).SingleOrDefault();
                if (placa == 0)
                {
                    TempData["error"] = "Debe seleccionar una placa";
                    if (campla_cardesc == "C")
                    {
                        return RedirectToAction("Carga", "MDCamiones_Planificados", new { placa = placa });
                    }
                    else
                    {
                        return RedirectToAction("Descarga", "MDCamiones_Planificados", new { placa = placa });
                    }
                }
                if(campla_cardesc == "C")
                {
                    if (tiptran == 0)
                    {
                        TempData["error"] = "Debe seleccionar un tipo de transporte";
                        if (campla_cardesc == "C")
                        {
                            return RedirectToAction("Carga", "MDCamiones_Planificados", new { placa = placa });
                        }
                        else
                        {
                            return RedirectToAction("Descarga", "MDCamiones_Planificados", new { placa = placa });
                        }
                    }
                }
                else
                {
                    tiptran = 1;
                }
             
                if (dcampla_nrotrans == null)
                {
                    TempData["error"] = "Debe escribir un numero de transporte";
                    if (campla_cardesc == "C")
                    {
                        return RedirectToAction("Carga", "MDCamiones_Planificados", new { placa = placa });
                    }
                    else
                    {
                        return RedirectToAction("Descarga", "MDCamiones_Planificados", new { placa = placa });
                    }
                }
                int Inrotrans = dcampla_nrotrans.Length;
                if (Inrotrans != 10)
                {
                    TempData["error"] = "El nro. de transporte debe contener 10 digitos";
                    if (campla_cardesc == "C")
                    {
                        return RedirectToAction("Carga", "MDCamiones_Planificados", new { placa = placa });
                    }
                    else
                    {
                        return RedirectToAction("Descarga", "MDCamiones_Planificados", new { placa = placa });
                    }
                }
                if (campla_cardesc == "C")
                {
                    if (dcampla_peso == null)
                    {
                        TempData["error"] = "Debe ingresar un peso";
                        if (campla_cardesc == "C")
                        {
                            return RedirectToAction("Carga", "MDCamiones_Planificados", new { placa = placa });
                        }
                        else
                        {
                            return RedirectToAction("Descarga", "MDCamiones_Planificados", new { placa = placa });
                        }
                    }
                }
                else
                {
                    dcampla_peso = "0";
                }

                if (campla_cardesc == "C")
                {
                    if (dcampla_volumen == null)
                    {
                        TempData["error"] = "Debe ingresar un volumen";
                        if (campla_cardesc == "C")
                        {
                            return RedirectToAction("Carga", "MDCamiones_Planificados", new { placa = placa });
                        }
                        else
                        {
                            return RedirectToAction("Descarga", "MDCamiones_Planificados", new { placa = placa });
                        }
                    }
                }
                else
                {
                    dcampla_volumen = "0";
                }

                int nro_viaje_fin;                    
                    if (Nroviaj != 0)
                    {                    
                        nro_viaje_fin = Nroviaj;
                        MDCamiones_Planificados mDCamiones_Planificados = new MDCamiones_Planificados()
                        {
                            id_camplacab = nro_viaje_fin,
                            id_placa = placa,
                            id_tiptran = tiptran,
                            campla_nrotrans = dcampla_nrotrans,
                            campla_peso = dcampla_peso,
                            campla_volumen = dcampla_volumen,
                            campla_obse = dcampla_obse,
                            campla_fecha = fecha,
                            campla_cardesc = campla_cardesc,
                            id_sede = id_sede,
                            campla_fase = "0"
                        };
                        _context.Add(mDCamiones_Planificados);
                        await _context.SaveChangesAsync();
                        await _operaciones.mGenerarViaje(dcampla_nrotrans, fecha, id_sede);
                    }
                        
                    //string conn = _config["ConnectionStrings:DefaultConnection"];
                    int ind_cam = await _operaciones.mBuscab(placa, fecha);
                    if (ind_cam != 0)
                    {
                        nro_viaje_fin = ind_cam;
                        MDCamiones_Planificados mDCamiones_Planificados = new MDCamiones_Planificados()
                        {
                            id_camplacab = nro_viaje_fin,
                            id_placa = placa,
                            id_tiptran = tiptran,
                            campla_nrotrans = dcampla_nrotrans,
                            campla_peso = dcampla_peso,
                            campla_volumen = dcampla_volumen,
                            campla_obse = dcampla_obse,
                            campla_fecha = fecha,
                            campla_cardesc = campla_cardesc,
                            id_sede = id_sede,
                            campla_fase = "0"
                        };
                        _context.Add(mDCamiones_Planificados);
                        await _context.SaveChangesAsync();
                        await _operaciones.mGenerarViaje(dcampla_nrotrans, fecha, id_sede);
                    }
                    else
                    {
                        MDCamiones_Planificados_Cabecera mDCamiones_Planificados_Cabecera = new MDCamiones_Planificados_Cabecera()
                        {
                            camplacab_fecha = DateTime.Now,
                            camplacab_act = false,
                            camplacab_obs = dcampla_obse,
                            camplacab_fin = "N",
                            id_sede = id_sede
                        };
                        _context.Add(mDCamiones_Planificados_Cabecera);
                        await _context.SaveChangesAsync();
                        var nro_viaje = _context.Camiones_Planificados_Cabecera.Max(p => p.id_camplacab);
                        nro_viaje_fin = Convert.ToInt32(nro_viaje);
                        MDCamiones_Planificados mDCamiones_Planificados = new MDCamiones_Planificados()
                        {
                            id_camplacab = nro_viaje_fin,
                            id_placa = placa,
                            id_tiptran = tiptran,
                            campla_nrotrans = dcampla_nrotrans,
                            campla_peso = dcampla_peso,
                            campla_volumen = dcampla_volumen,
                            campla_obse = dcampla_obse,
                            campla_fecha = fecha,
                            campla_cardesc = campla_cardesc,
                            id_sede = id_sede,
                            campla_fase = "0"
                        };
                        _context.Add(mDCamiones_Planificados);
                        await _context.SaveChangesAsync();
                        await _operaciones.mGenerarViaje(dcampla_nrotrans, fecha, id_sede);

                    }
                    TempData["success"] = "Los registros se grabaron exitosamente";

                    switch (campla_cardesc)
                    {
                        case "C":
                            return RedirectToAction("Carga", "MDCamiones_Planificados", new { placa = placa });
                            
                        default:
                            return RedirectToAction("Descarga", "MDCamiones_Planificados", new { placa = placa });                            
                    }   

                   //return RedirectToAction("Index", "MDCamiones_Planificados", new { placa = placa });
            }
            catch (Exception ex)
            {
                placa = 0;
                TempData["error"] = "Los registro no se grabaron, Nro. de transporte duplicado.";
                if (campla_cardesc == "C")
                {
                    return RedirectToAction("Carga", "MDCamiones_Planificados", new { placa = placa });
                }
                else
                {
                    return RedirectToAction("Descarga", "MDCamiones_Planificados", new { placa = placa });
                }
               // return RedirectToAction("Index", "MDCamiones_Planificados", new { placa = placa });
            }
        }

        [HttpPost]
        public async Task<IActionResult> GenerarViaje(int placa2)
        {
            DateTime fecha = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");           
            int ind_cam = await _operaciones.mBuscab(placa2, fecha);
            if(ind_cam != 0)
            {
                await _operaciones.mUpdateViaje(ind_cam);
            }

            return RedirectToAction("Index", "MDCamiones_Planificados", new { placa = placa2 });
        }

        public async Task<IActionResult> GenerarViajecarga(int placa2, int Nroviaj)
        {
            DateTime fecha = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");           
            if (Nroviaj != 0)
            {
                TempData["success"] = "El registro se realizo correctamente.";
                await _operaciones.mUpdateViaje(Nroviaj);
            }
            else
            {
                int ind_cam = await _operaciones.mBuscab(placa2, fecha);
                if (ind_cam != 0)
                {
                    TempData["success"] = "El registro se realizo correctamente.";
                    await _operaciones.mUpdateViaje(ind_cam);
                }

            }

            return RedirectToAction("Carga", "MDCamiones_Planificados", new { placa = placa2 });
        }

        public async Task<IActionResult> GenerarViajedescarga(int placa2, int id_campla)
        {
            DateTime fecha = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");            
            await _operaciones.mUpdateViajedesc(id_campla, fecha);
            TempData["success"] = "El registro se realizo correctamente.";
            return RedirectToAction("Descarga", "MDCamiones_Planificados", new { placa = placa2 });
        }

        // GET: MDCamiones_Planificados/Edit/5
        public async Task<IActionResult> Edit(int? id, string campla_cardesc)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewData["carga"] = campla_cardesc;            
            ViewBag.placas = await _context.Placas.ToListAsync();
            var mDCamiones_Planificados = await _context.Camiones_Planificados.FindAsync(id);
            if (mDCamiones_Planificados == null)
            {
                return NotFound();
            }
            return View(mDCamiones_Planificados);
        }

        // POST: MDCamiones_Planificados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editconfirmar(int id, int placa, string campla_nrotrans, string campla_peso, string campla_volumen, string campla_obse, string campla_cardesc)
        {  
            try
            {                             
                if (placa != 0)
                {
                    await _operaciones.mUpdatePlanificacion(id, placa, campla_nrotrans, campla_peso, campla_volumen, campla_obse);
                    if (campla_cardesc == "C")
                    {
                        TempData["success"] = "El registro se actualizo correctamente";
                        return RedirectToAction("Carga", "MDCamiones_Planificados");
                    }
                    else
                    {
                        TempData["success"] = "El registro se actualizo correctamente";
                        return RedirectToAction("Descarga", "MDCamiones_Planificados");
                    }

                    int ind = await _operaciones.mIndtrans(campla_nrotrans);
                    if (ind == 0)
                    {
                        await _operaciones.mUpdatePlanificacion(id, placa, campla_nrotrans, campla_peso, campla_volumen, campla_obse);
                        if (campla_cardesc == "C")
                        {
                            TempData["success"] = "El registro se actualizo correctamente";
                            return RedirectToAction("Carga", "MDCamiones_Planificados");
                        }
                        else
                        {
                            TempData["success"] = "El registro se actualizo correctamente";
                            return RedirectToAction("Descarga", "MDCamiones_Planificados");
                        }
                    }
                    else
                    {
                        TempData["success"] = "El Nro. de transporte ya existe.";
                        if (campla_cardesc == "C")
                        {
                            return RedirectToAction("Carga", "MDCamiones_Planificados");
                        }
                        else
                        {
                            return RedirectToAction("Descarga", "MDCamiones_Planificados");
                        }
                    }
                }
                else 
                {
                    TempData["error"] = "Debe ingresar una placa.";
                    if (campla_cardesc == "C")
                    {
                        return RedirectToAction("Carga", "MDCamiones_Planificados");
                    }
                    else
                    {
                        return RedirectToAction("Descarga", "MDCamiones_Planificados");
                    }
                }
                          
            }
            catch (DbUpdateConcurrencyException)
            {
                return RedirectToAction("Edit", "MDCamiones_Planificados", new { id = id });
            }
                //return RedirectToAction(nameof(Index));          
        }

        // GET: MDCamiones_Planificados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mDCamiones_Planificados = await _context.Camiones_Planificados
                .FirstOrDefaultAsync(m => m.id_campla == id);
            if (mDCamiones_Planificados == null)
            {
                return NotFound();
            }

            return View(mDCamiones_Planificados);
        }

        // POST: MDCamiones_Planificados/Delete/5
        [HttpPost]
        public async Task<IActionResult> Deletecarga(int mid_idpla)
        {
            try
            {
                var mDCamiones_Planificados = await _context.Camiones_Planificados.FindAsync(mid_idpla);
                _context.Camiones_Planificados.Remove(mDCamiones_Planificados);
                await _context.SaveChangesAsync();
                TempData["success"] = "Se elimino el registro.";
                return RedirectToAction("Carga", "MDCamiones_Planificados");
            }
            catch (Exception ex)
            {

                throw ex;
                return RedirectToAction("Carga", "MDCamiones_Planificados");
            }
   
        }
        [HttpPost]
        public async Task<IActionResult> Deletedescarga(int mid_idpla)
        {
            try
            {
                var mDCamiones_Planificados = await _context.Camiones_Planificados.FindAsync(mid_idpla);
                _context.Camiones_Planificados.Remove(mDCamiones_Planificados);
                await _context.SaveChangesAsync();
                TempData["success"] = "Se elimino el registro.";
                return RedirectToAction("Descarga", "MDCamiones_Planificados");
            }
            catch (Exception)
            {
                return RedirectToAction("Descarga", "MDCamiones_Planificados");
                throw;
            }
  
        }

        private bool MDCamiones_PlanificadosExists(int id)
        {
            return _context.Camiones_Planificados.Any(e => e.id_campla == id);
        }
    }
}

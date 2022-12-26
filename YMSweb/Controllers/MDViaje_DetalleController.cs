using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using YMSweb.Data;
using YMSweb.Data.DataSql;
using YMSweb.Data.Entities;

namespace YMSweb.Controllers
{
    public class MDViaje_DetalleController : Controller
    {
        private readonly DataContext _context;
        IdentityError _identityError;
        SP_Operaciones _operaciones;
        public MDViaje_DetalleController(DataContext context)
        {
            _context = context;            
            _operaciones = new SP_Operaciones();
            _identityError = new IdentityError();
        }

        // GET: MDViaje_Detalle
        public async Task<IActionResult> Index(string placa)
        {
            try
            {
                //ViewBag.viajedetalle = await _operaciones.mViajes_detalles(conn, placa);
                ViewData["placa"] = placa;
                return View();
            }
            catch (Exception ex)
            {
                TempData["success"] = "Ocurrio un problema por favor consulte con su area de sistemas";
                return View();
            }

        }
        [HttpPost]
        public async Task<IActionResult> Regresar(string tipcar,int id_vijcab)
        {
            try
            {
                
                var tipoper = await _operaciones.mIndtip(id_vijcab);

                if (tipoper == 1)
                {
                    return RedirectToAction("viajecarga", "MDViaje_Cabecera");
                }
                else
                {
                    return RedirectToAction("viajedescarga", "MDViaje_Cabecera");
                }
            }
            catch (Exception ex)
            {
                TempData["success"] = "Ocurrio un problema por favor consulte con su area de sistemas";
                return View();
            }      

        }

        // POST: MDViaje_Detalle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mDViaje_Detalle = await _context.Viaje_Detalles.FindAsync(id);
            _context.Viaje_Detalles.Remove(mDViaje_Detalle);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Validar(int id, string cardesg)
        {
            try
            {
                int id_validar = id;               
                ViewBag.nrotrans = await _operaciones.mTransportes(id);
                ViewBag.general = await _operaciones.mDatosGenerales(id);
                ViewData["tipcar"] = cardesg;
                ViewData["id_cab"] = id_validar;
                return View();

            }
            catch (Exception ex)
            {     
                TempData["success"] = "Ocurrio un problema por favor consulte con su area de sistemas";
                return View();
               
            }
        }

        public async Task<IActionResult> UpdateViaje(int mid_vijdet, int mid_vijcab, int mid_estcam,int mid_tiptran, int id_cab)
        {
            try
            {
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
                int id = mid_vijcab;
                if (id == 0)
                {
                    id = id_cab;
                    mid_vijcab = id;
                }
                DateTime fecha = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");

                switch (mid_estcam)
                {
                    case 2:                                                                                                                                                                   
                        await _operaciones.mEstadoViaje(mid_vijdet, mid_vijcab, mid_estcam, fecha);
                        TempData["success"] = "registro ingresado";
                        break;
                        
                    case 3:
                        var canal = await _operaciones.mvalcanal(mid_vijcab);
                        var fase = await _operaciones.mvalfase(mid_vijcab);
                        if (canal == 0)
                        {
                            TempData["error"] = "Tiene que ingresar el Canal";
                            break;
                        }
                        else if (fase == 0)
                        {
                            TempData["error"] = "Tiene que ingresar el nro. de fase.";
                            break;
                        }
                        else
                        {
                            await _operaciones.mEstadoViaje(mid_vijdet, mid_vijcab, mid_estcam, fecha);
                            TempData["success"] = "registro ingresado";
                            break;
                        }
                    case 4:
                        var indest4 = await _operaciones.mIndestado(mid_vijcab, mid_estcam);
                        if (indest4 == 0)
                        {
                            TempData["error"] = "Tiene que finalizar Proc. Preparacion";
                            break;
                        }
                        else
                        {
                            await _operaciones.mEstadoViaje(mid_vijdet, mid_vijcab, mid_estcam, fecha);
                            TempData["success"] = "registro ingresado";
                            break;
                        }
                    //case 5:
                    //    var indest5 = await _operaciones.mIndestado(mid_vijcab, mid_estcam);
                    //    if (indest5 == 0)
                    //    {
                    //        TempData["error"] = "Tiene que finalizar Prep. Completa";
                    //        break;
                    //    }
                    //    else
                    //    {
                    //        await _operaciones.mEstadoViaje(mid_vijdet, mid_vijcab, mid_estcam, fecha);
                    //        TempData["success"] = "registro ingresado";
                    //        break;
                    //    }
                    case 6:

                        if(mid_tiptran == 1)
                        {
                            // var indpick = await _operaciones.mvalingpick(conn, mid_vijcab);
                            var inguni = await _operaciones.mvalinguni(mid_vijcab);
                            var recpic = await _operaciones.mvalingpick(mid_vijcab);
                            var cuadrilla = await _operaciones.mvalcuad(mid_vijcab);
                            var montacarga = await _operaciones.mvalmonta(mid_vijcab);
                            var muelle = await _operaciones.mvalmuelle(mid_vijcab);
                            //var inspec = await _operaciones.mvalinspsani(conn, mid_vijcab);
                            //var indest6 = await _operaciones.mIndestado(mid_vijcab, mid_estcam);
                            //if (indest6 == 0)
                            //{
                            //    TempData["error"] = "Tiene que finalizar Transp. Cerrado";
                            //    break;
                            //}
                            if (inguni == 0)
                            {
                                TempData["error"] = "Tiene que ingresar unidad";
                                break;
                            }
                            else if (recpic == 0)
                            {
                                TempData["error"] = "Tiene que ingresar recojo picking";
                                break;
                            }                            
                            else if (muelle == 0)
                            {
                                TempData["error"] = "Tiene que ingresar Muelle";
                                break;
                            }
                            else if (cuadrilla == 0 && montacarga == 0)
                            {
                                TempData["error"] = "Tiene que ingresar una cuadrilla o montacarga";
                                break;
                            }
                            else
                            {
                                await _operaciones.mEstadoViaje(mid_vijdet, mid_vijcab, mid_estcam, fecha);
                                TempData["success"] = "registro ingresado";
                                break;
                            }
                        } 
                        else
                        {
                            var anexo = await _operaciones.mvalanexo(mid_vijcab);
                            var recpic = await _operaciones.mvalingpick(mid_vijcab);
                            var cuadrilla = await _operaciones.mvalcuad(mid_vijcab);
                            var montacarga = await _operaciones.mvalmonta(mid_vijcab);
                            //var canal2 = await _operaciones.mvalcanal(conn, mid_vijcab);
                            //var inspec = await _operaciones.mvalinspsani(conn, mid_vijcab);
                            //var indest6 = await _operaciones.mIndestado(mid_vijcab, mid_estcam);
                            //if (indest6 == 0)
                            //{
                            //    TempData["error"] = "Tiene que finalizar Transp. Cerrado";
                            //    break;
                            //}
                            if (anexo == 0)
                            {
                                TempData["error"] = "Tiene que ingresar Molino";
                                break;
                            }
                            else if (recpic == 0)
                            {
                                TempData["error"] = "Tiene que ingresar recojo picking";
                                break;
                            }
                            else if (cuadrilla == 0 && montacarga == 0) 
                            {
                                TempData["error"] = "Tiene que ingresar cuadrilla o montacarga";
                                break;
                            }
                            else
                            {
                                await _operaciones.mEstadoViaje(mid_vijdet, mid_vijcab, mid_estcam, fecha);
                                TempData["success"] = "registro ingresado";
                                break;
                            }
                        }

                    case 7:
                        var indest7 = await _operaciones.mIndestado(mid_vijcab, mid_estcam);
                        if (indest7 == 0)
                        {
                            TempData["error"] = "Tiene que finalizar Transp. Cerrado";
                            break;
                        }
                        else
                        {                            
                            await _operaciones.mLiberarCanal(mid_vijcab, mid_vijdet, fecha);
                            await _operaciones.mLiberarCuadrilla(mid_vijcab, mid_vijdet, fecha);
                            await _operaciones.mLiberarmonta(mid_vijcab, mid_vijdet, fecha);
                            await _operaciones.mEstadoViaje(mid_vijdet, mid_vijcab, mid_estcam, fecha);
                            var indcarga = await _operaciones.mIndcarga(mid_vijcab);
                            if (indcarga == 0)
                            {
                                await _operaciones.mLiberarTotal(mid_vijcab, mid_vijdet, fecha);
                            }                         
                            TempData["success"] = "registro ingresado";
                            break;
                        }
                    case 8:
                            await _operaciones.mEstadoViaje(mid_vijdet, mid_vijcab, mid_estcam, fecha);
                            TempData["success"] = "registro ingresado";
                            break;                        
                    case 9:
                            await _operaciones.mEstadoViaje(mid_vijdet, mid_vijcab, mid_estcam, fecha);
                            TempData["success"] = "registro ingresado";
                            break;                   
                    case 13:

                        var indest13 = await _operaciones.mIndestado(mid_vijcab, mid_estcam);
                        if (indest13 == 0)
                        {
                            TempData["success"] = "Tiene que finalizar Registro de llegada";
                            break;
                        }
                        else
                        {
                            await _operaciones.mEstadoViaje(mid_vijdet, mid_vijcab, mid_estcam, fecha);
                            TempData["success"] = "registro ingresado";
                            break;
                        }
                    case 14:
                        var muelled = await _operaciones.mvalmuelle(mid_vijcab);
                        var indest14 = await _operaciones.mIndestado(mid_vijcab, mid_estcam);
                        if (indest14 == 0)
                        {
                            TempData["success"] = "Tiene que finalizar Ingreso";
                            break;
                        }
                        else if (muelled == 0)
                        {
                            TempData["success"] = "Tiene que ingresar Muelle";
                            break;
                        }
                        else
                        {
                            await _operaciones.mEstadoViaje(mid_vijdet, mid_vijcab, mid_estcam, fecha);
                            TempData["success"] = "registro ingresado";
                            break;
                        }
                    case 15:
                        var cuadrillad = await _operaciones.mvalcuad(mid_vijcab);
                        var canald = await _operaciones.mvalcanal(mid_vijcab);               
                        var indest15 = await _operaciones.mIndestado(mid_vijcab, mid_estcam);
                        if (indest15 == 0)
                        {
                            TempData["success"] = "Tiene que finalizar Muelle";
                            break;
                        }
                        else if (canald == 0)
                        {
                            TempData["success"] = "Tiene que ingresar canal";
                            break;
                        }
                        else if (cuadrillad == 0)
                        {
                            TempData["success"] = "Tiene que ingresar cuadrilla";
                            break;
                        }
                        else
                        {
                            await _operaciones.mEstadoViaje(mid_vijdet, mid_vijcab, mid_estcam, fecha);
                            TempData["success"] = "registro ingresado";
                            break;
                        }
                    case 16:                       
                        var indest16 = await _operaciones.mIndestado(mid_vijcab, mid_estcam);
                        if (indest16 == 0)
                        {
                            TempData["success"] = "Tiene que finalizar Inicio descarga";
                            break;
                        }
                        else
                        {
                            await _operaciones.mLiberarCuadrilla(mid_vijcab, mid_vijdet, fecha);
                            await _operaciones.mEstadoViaje(mid_vijdet, mid_vijcab, mid_estcam, fecha);
                            await _operaciones.mLiberarTotald(mid_vijcab, mid_vijdet, fecha);
                            TempData["success"] = "registro ingresado";
                            break;
                        }
                    case 19:
                            await _operaciones.mEstadoViaje(mid_vijdet, mid_vijcab, mid_estcam, fecha);
                            TempData["success"] = "registro ingresado";
                            break;         
                    default:
                        await _operaciones.mEstadoViaje(mid_vijdet, mid_vijcab, mid_estcam, fecha);
                        TempData["success"] = "registro ingresado";
                        break;
                }

                return RedirectToAction("Validar", "MDViaje_Detalle", new { id = id });
            }
            catch (Exception ex)
            {
                TempData["success"] = "Ocurrio un problema por favor consulte con su area de sistemas";
                return View();
            }
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="plac_desc"></param>
        /// <param name="id_vijcab"></param>
        /// <param name="nro_trans"></param>
        /// <returns></returns>
        public async Task<IActionResult> listacanal(string plac_desc, int id_vijcab, string nro_trans)
        {
            try
            {
                ClaimsPrincipal currentUser = this.User;
                var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
                var id_user = _context.Usuarios.Where(x => x.Usua_user == currentUserID).Select(x => x.IdUsuario).SingleOrDefault();
                var id_sede = _context.Accesos.Where(x => x.IdUsuario == id_user).Select(x => x.id_sede).SingleOrDefault();
                ViewData["mplac_desc"] = plac_desc;
                ViewData["id_vijcab"] = id_vijcab;
                ViewData["nro_trans"] = nro_trans;
                ViewBag.Canales = await _operaciones.mCheckCanales(id_sede);
                return View();
            }
            catch (Exception ex)
            {
                TempData["success"] = "Ocurrio un problema por favor consulte con su area de sistemas";
                return View();
            }
       
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id_canal"></param>
        /// <param name="mplac_desc"></param>
        /// <param name="id_vijcab"></param>
        /// <param name="nro_trans"></param>
        /// <returns></returns>
        public async Task<IActionResult> Updatecanal(int id_canal, string mplac_desc, int id_vijcab, string nro_trans)
        {
            DateTime fecha = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");
            try
            {
                await _operaciones.mUpdatecanal(id_canal, mplac_desc, nro_trans, fecha);
                return RedirectToAction("listacanal", "MDViaje_Detalle", new { plac_desc = mplac_desc, id_vijcab = id_vijcab, nro_trans = nro_trans });                
            }
            catch (Exception ex)
            {
                TempData["success"] = "Ocurrio un problema por favor consulte con su area de sistemas";
                return RedirectToAction("listacanal", "MDViaje_Detalle", new { plac_desc = mplac_desc, id_vijcab = id_vijcab, nro_trans = nro_trans });
            }
     
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plac_desc"></param>
        /// <param name="id_vijcab"></param>
        /// <param name="nro_trans"></param>
        /// <returns></returns>
        public async Task<IActionResult> listamontacarga(string plac_desc, int id_vijcab, string nro_trans)
        {
            try
            {
                ClaimsPrincipal currentUser = this.User;
                var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
                var id_user = _context.Usuarios.Where(x => x.Usua_user == currentUserID).Select(x => x.IdUsuario).SingleOrDefault();
                var id_sede = _context.Accesos.Where(x => x.IdUsuario == id_user).Select(x => x.id_sede).SingleOrDefault();
                ViewData["mplac_desc"] = plac_desc;
                ViewData["id_vijcab"] = id_vijcab;
                ViewData["nro_trans"] = nro_trans;
                ViewBag.Montacarga = await _operaciones.mCheckMontacarga(id_sede);
                return View();
            }
            catch (Exception ex)
            {
                TempData["success"] = "Ocurrio un problema por favor consulte con su area de sistemas";
                return View();
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id_canal"></param>
        /// <param name="mplac_desc"></param>
        /// <param name="id_vijcab"></param>
        /// <param name="nro_trans"></param>
        /// <returns></returns>
        public async Task<IActionResult> Updatemontacarga(int id_monta, string mplac_desc, int id_vijcab, string nro_trans)
        {
            DateTime fecha = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");
            try
            {
                await _operaciones.mUpdatemontacarga(id_monta, mplac_desc, nro_trans, fecha);
                //return View();
                return RedirectToAction("listamontacarga", "MDViaje_Detalle", new { plac_desc = mplac_desc, id_vijcab = id_vijcab, nro_trans = nro_trans });
            }
            catch (Exception ex)
            {
                TempData["success"] = "Ocurrio un problema por favor consulte con su area de sistemas";
                return View();
            }

        }

        public async Task<IActionResult> UpdatesinMontacarga(string mplac_desc, int id_vijcab, string nro_trans, bool check_cua)
        {
            DateTime fecha = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");
            try
            {
                if (check_cua == true)
                {
                    await _operaciones.mUpdatesinmontacarga(mplac_desc, nro_trans, fecha);
                    return RedirectToAction("listamontacarga", "MDViaje_Detalle", new { plac_desc = mplac_desc, id_vijcab = id_vijcab, nro_trans = nro_trans });
                }
                else
                {
                    return RedirectToAction("listamontacarga", "MDViaje_Detalle", new { plac_desc = mplac_desc, id_vijcab = id_vijcab, nro_trans = nro_trans });
                }
            }
            catch (Exception ex)
            {
                TempData["success"] = "Ocurrio un problema por favor consulte con su area de sistemas";
                return View();
            }

        }

        public async Task<IActionResult> listaestacion(string plac_desc, int id_vijcab, string nro_trans)
        {
            try
            {
                ClaimsPrincipal currentUser = this.User;
                var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
                var id_user = _context.Usuarios.Where(x => x.Usua_user == currentUserID).Select(x => x.IdUsuario).SingleOrDefault();
                var id_sede = _context.Accesos.Where(x => x.IdUsuario == id_user).Select(x => x.id_sede).SingleOrDefault();
                ViewData["mplac_desc"] = plac_desc;
                ViewData["id_vijcab"] = id_vijcab;
                ViewData["nro_trans"] = nro_trans;
                ViewBag.estacion = await _operaciones.mCheckEstacionamiento(id_sede);
                return View();
            }
            catch (Exception ex)
            {
                TempData["success"] = "Ocurrio un problema por favor consulte con su area de sistemas";
                return View();
            }

        }

        public async Task<IActionResult> UpdateEstacionamiento(int id_estacionamiento, string mplac_desc, int id_vijcab, string nro_trans)
        {
            DateTime fecha = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");
            try
            {
                await _operaciones.mUpdateEstacionamiento(id_estacionamiento, mplac_desc, nro_trans, fecha);
                return RedirectToAction("listaestacion", "MDViaje_Detalle", new { plac_desc = mplac_desc, id_vijcab = id_vijcab, nro_trans = nro_trans });
            }
            catch (Exception ex)
            {
                TempData["success"] = "Ocurrio un problema por favor consulte con su area de sistemas";
                return View();
            }
          
        }

        public async Task<IActionResult> listanexos(string plac_desc, int id_vijcab, string nro_trans)
        {
            try
            {
                ClaimsPrincipal currentUser = this.User;
                var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
                var id_user = _context.Usuarios.Where(x => x.Usua_user == currentUserID).Select(x => x.IdUsuario).SingleOrDefault();
                var id_sede = _context.Accesos.Where(x => x.IdUsuario == id_user).Select(x => x.id_sede).SingleOrDefault();
                ViewData["mplac_desc"] = plac_desc;
                ViewData["id_vijcab"] = id_vijcab;
                ViewData["nro_trans"] = nro_trans;
                ViewBag.anexos = await _operaciones.mCheckAnexos(id_sede);
                return View();
            }
            catch (Exception ex)
            {
                TempData["success"] = "Ocurrio un problema por favor consulte con su area de sistemas";
                return View();
            }

        }

        public async Task<IActionResult> Updateanexos(int id_anexo, string mplac_desc, int id_vijcab, string nro_trans)
        {
            DateTime fecha = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");
            try
            {
                await _operaciones.mUpdateAnexoSeguridad(id_anexo, id_vijcab, mplac_desc, nro_trans, fecha);
                return RedirectToAction("listanexos", "MDViaje_Detalle", new { plac_desc = mplac_desc, id_vijcab = id_vijcab, nro_trans = nro_trans });
            }
            catch (Exception ex)
            {
                TempData["success"] = "Ocurrio un problema por favor consulte con su area de sistemas";
                return View();
            }

        }


        public async Task<IActionResult> listacuadrilla(string plac_desc, int id_vijcab, string nro_trans)
        {
            try
            {
                ClaimsPrincipal currentUser = this.User;
                var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
                var id_user = _context.Usuarios.Where(x => x.Usua_user == currentUserID).Select(x => x.IdUsuario).SingleOrDefault();
                var id_sede = _context.Accesos.Where(x => x.IdUsuario == id_user).Select(x => x.id_sede).SingleOrDefault();

                ViewData["mplac_desc"] = plac_desc;
                ViewData["id_vijcab"] = id_vijcab;
                ViewData["nro_trans"] = nro_trans;
                ViewBag.Cuadrilla = await _operaciones.mCheckCuadrilla(id_sede);
                return View();
            }
            catch (Exception ex)
            {
                TempData["success"] = "Ocurrio un problema por favor consulte con su area de sistemas";
                return View();
            }

        }

        public async Task<IActionResult> UpdateCuadrilla(int id_cuadrilla, string mplac_desc, int id_vijcab, string nro_trans)
        {
            DateTime fecha = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");
            try
            {
                await _operaciones.mUpdatecuadrilla(id_cuadrilla, mplac_desc, nro_trans, fecha);                   
                return RedirectToAction("listacuadrilla", "MDViaje_Detalle", new { plac_desc = mplac_desc, id_vijcab = id_vijcab, nro_trans = nro_trans });
            }
            catch (Exception ex)
            {
                TempData["success"] = "Ocurrio un problema por favor consulte con su area de sistemas";
                return View();
            }
    
        }
        public async Task<IActionResult> UpdatesinCuadrilla(string mplac_desc, int id_vijcab, string nro_trans, bool check_cua)
        {
            DateTime fecha = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");
            try
            {
                if(check_cua == true)
                { 
                await _operaciones.mUpdatesincuadrilla(mplac_desc, nro_trans, fecha);
                return RedirectToAction("listacuadrilla", "MDViaje_Detalle", new { plac_desc = mplac_desc, id_vijcab = id_vijcab, nro_trans = nro_trans });
                }
                else
                {
                    return RedirectToAction("listacuadrilla", "MDViaje_Detalle", new { plac_desc = mplac_desc, id_vijcab = id_vijcab, nro_trans = nro_trans });
                }
            }
            catch (Exception ex)
            {
                TempData["success"] = "Ocurrio un problema por favor consulte con su area de sistemas";
                return View();
            }

        }

        public async Task<IActionResult> listamuelle(string plac_desc, int id_vijcab, string nro_trans)
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
                ViewData["mplac_desc"] = plac_desc;
                ViewData["id_vijcab"] = id_vijcab;
                ViewData["nro_trans"] = nro_trans;
                ViewBag.Muelles = await _operaciones.mCheckMuelle(id_sede);
                return View();
            }
            catch (Exception ex)
            {
                TempData["success"] = "Ocurrio un problema por favor consulte con su area de sistemas";
                return View();
            }

        }

        public async Task<IActionResult> UpdateMuelle(int id_muelle, string mplac_desc, int id_vijcab, string nro_trans)
        {
            DateTime fecha = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");
            try
            {
                await _operaciones.mUpdateMuelle(id_muelle, mplac_desc, nro_trans, fecha);
                return RedirectToAction("listamuelle", "MDViaje_Detalle", new { plac_desc = mplac_desc, id_vijcab = id_vijcab, nro_trans = nro_trans });
            }
            catch (Exception ex)
            {
                TempData["success"] = "Ocurrio un problema por favor consulte con su area de sistemas";
                return View();
            }
         
        }

        public async Task<IActionResult> listainspeccion(string plac_desc, int id_vijcab, string nro_trans)
        {
            try
            {
                ViewData["mplac_desc"] = plac_desc;
                ViewData["id_vijcab"] = id_vijcab;
                ViewData["nro_trans"] = nro_trans;
                ViewBag.Muelles2 = await _operaciones.mCheckinspec(plac_desc);
                return View();
            }
            catch (Exception ex)
            {
                TempData["success"] = "Ocurrio un problema por favor consulte con su area de sistemas";
                return View();
            }

        }

        public async Task<IActionResult> Updateinspeccion(int id_muelle, string mplac_desc, int id_vijcab, string nro_trans)
        {
            DateTime fecha = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");
            try
            {
                await _operaciones.mUpdateInspec(id_muelle, id_vijcab, fecha);
                return RedirectToAction("listainspeccion", "MDViaje_Detalle", new { plac_desc = mplac_desc, id_vijcab = id_vijcab, nro_trans = nro_trans });
            }
            catch (Exception ex)
            {
                TempData["success"] = "Ocurrio un problema por favor consulte con su area de sistemas";
                return View();
            }

        }

        public async Task<IActionResult> UpdatePicking(int pid_vijcab, int id_cab)
        {
            DateTime fecha = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");
            try
            {
                if (pid_vijcab == 0)
                {
                    pid_vijcab = id_cab;
                }
                await _operaciones.mUpdatePicking(pid_vijcab, fecha);
                TempData["success"] = "Registro ingresado";
                return RedirectToAction("Validar", "MDViaje_Detalle", new { id = pid_vijcab });
            }
            catch (Exception ex)
            {
                TempData["success"] = "Ocurrio un problema por favor consulte con su area de sistemas";
                return View();
            }
        

        }

        public async Task<IActionResult> Updatefase(int fid_vijcab, int id_cab, string id_fase)
        {
            DateTime fecha = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");
            try
            {
                if (fid_vijcab == 0)
                {
                    fid_vijcab = id_cab;
                }
                await _operaciones.mUpdatefase(fid_vijcab, id_fase);
                TempData["success"] = "Registro ingresado";
                return RedirectToAction("Validar", "MDViaje_Detalle", new { id = fid_vijcab });
            }
            catch (Exception ex)
            {
                TempData["success"] = "Ocurrio un problema por favor consulte con su area de sistemas";
                return View();
            }
        }


        public async Task<IActionResult> Updateingunidad(int nid_vijcab, int id_cab)
        {
            DateTime fecha = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");
            try
            {
                if (nid_vijcab == 0)
                {
                    nid_vijcab = id_cab;
                }
                await _operaciones.mUpdateingunidad(nid_vijcab, fecha);
                TempData["success"] = "Registro ingresado";
                return RedirectToAction("Validar", "MDViaje_Detalle", new { id = nid_vijcab });
            }
            catch (Exception ex)
            {
                TempData["success"] = "Ocurrio un problema por favor consulte con su area de sistemas";
                return View();
            }


        }

        public IActionResult ingresarfecha(int id_vijcab, int id_cab)
        {
            try
            {
                if (id_vijcab == 0)
                {
                    id_vijcab = id_cab;
                }
                ViewData["id_vijcab"] = id_vijcab;                 
                return View();
            }
            catch (Exception ex)
            {
                TempData["success"] = "Ocurrio un problema por favor consulte con su area de sistemas";
                return View();
            }

        }

        public async Task<IActionResult> Updatefecalmacen(int id_cab, DateTime fecalma)
        {           
            try
            {
                int nid_vijcab = 0;
                if (nid_vijcab == 0)
                {
                    nid_vijcab = id_cab;
                }
                await _operaciones.mUpdatefecalma(nid_vijcab, fecalma);
                TempData["success"] = "Registro ingresado";
                return RedirectToAction("Validar", "MDViaje_Detalle", new { id = nid_vijcab });
            }
            catch (Exception ex)
            {
                TempData["success"] = "Ocurrio un problema por favor consulte con su area de sistemas";
                return View();
            }


        }

        private bool MDViaje_DetalleExists(int id)
        {
            return _context.Viaje_Detalles.Any(e => e.id_vijdet == id);
        }
    }
}

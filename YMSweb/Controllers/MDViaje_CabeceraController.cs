using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using YMSweb.Data;
using YMSweb.Data.DataSql;

namespace YMSweb.Controllers
{
	public class MDViaje_CabeceraController : Controller
	{
		private readonly DataContext _context;
		SP_Operaciones _operaciones;
		public MDViaje_CabeceraController(DataContext context)
		{
			_context = context;
			_operaciones = new SP_Operaciones();
		}		

		public async Task<IActionResult> viajecarga(string placa, int id_camplacab)
		{
			try
			{
				ClaimsPrincipal currentUser = this.User;
				var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
				var id_user = _context.Usuarios.Where(x => x.Usua_user == currentUserID).Select(x => x.IdUsuario).SingleOrDefault();
				var id_sede = _context.Accesos.Where(x => x.IdUsuario == id_user).Select(x => x.id_sede).SingleOrDefault();

				if (placa == null)
				{
					placa = "";
				}
				if (id_camplacab == 0)
				{
					id_camplacab = 0;
				}
				string tipcarg = "C";
				ViewBag.viajes = await _operaciones.mViajescarga(id_sede);
				ViewBag.viajedetalle = await _operaciones.mViajes_detalles(placa, id_camplacab, tipcarg, id_sede);
				ViewBag.viajedetalle_ewm = await _operaciones.mViajes_detalles_ewm(placa, id_camplacab, tipcarg, id_sede);
				ViewBag.viajedetalle_sap = await _operaciones.mViajes_detalles_sap(placa, id_camplacab, tipcarg, id_sede);
				ViewBag.Canales = await _operaciones.mCheckCanales(id_sede);
				ViewBag.cuadro = await _operaciones.mCuadro(id_sede);
				ViewData["placa"] = placa;
				ViewData["cardesg"] = "C";
				return View();
			}
			catch (Exception ex)
			{
				TempData["error"] = "Error por favor vuelva a ingresar.";
				return View();
			}

		}

		public async Task<IActionResult> Cuadro(int id_estcam)
        {
			ViewBag.cuaddetalle = await _operaciones.mCuadroDetalle(id_estcam);
			return View();
        }

		public async Task<IActionResult> viajedescarga(string placa, int id_camplacab)
		{
			try
			{
				ClaimsPrincipal currentUser = this.User;
				var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
				var id_user = _context.Usuarios.Where(x => x.Usua_user == currentUserID).Select(x => x.IdUsuario).SingleOrDefault();
				var id_sede = _context.Accesos.Where(x => x.IdUsuario == id_user).Select(x => x.id_sede).SingleOrDefault();

				if (placa == null)
				{
					placa = "";
				}
				if (id_camplacab == 0)
				{
					id_camplacab = 0;
				}
				string tipcarg = "D";
				ViewBag.viajes = await _operaciones.mViajesdescarga(id_sede);
				ViewBag.viajedetalle = await _operaciones.mViajes_detalles_descarga(placa, id_camplacab, tipcarg, id_sede);
				ViewData["placa"] = placa;
				ViewData["cardesg"] = "D";
				return View();
			}
			catch (Exception ex)
			{
				TempData["error"] = "Error por favor vuelva a ingresar.";
				return View();
			}

		}

		// GET: MDViaje_Cabecera/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			try
			{
				if (id == null)
				{
					return NotFound();
				}

				var mDViaje_Cabecera = await _context.Viaje_Cabeceras
					.FirstOrDefaultAsync(m => m.id_vijcab == id);
				if (mDViaje_Cabecera == null)
				{
					return NotFound();
				}

				return View(mDViaje_Cabecera);
			}
			catch (Exception ex)
			{
				TempData["error"] = "Error por favor vuelva a ingresar.";
				return View();
			}

		}

		// POST: MDViaje_Cabecera/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			try
			{
				var mDViaje_Cabecera = await _context.Viaje_Cabeceras.FindAsync(id);
				_context.Viaje_Cabeceras.Remove(mDViaje_Cabecera);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			catch (Exception ex)
			{
				TempData["error"] = "Error por favor vuelva a ingresar.";
				return View();
			}

		}

		public async Task<IActionResult> Layout()
		{
			try
			{
				ClaimsPrincipal currentUser = this.User;
				var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
				var id_user = _context.Usuarios.Where(x => x.Usua_user == currentUserID).Select(x => x.IdUsuario).SingleOrDefault();
				var id_sede = _context.Accesos.Where(x => x.IdUsuario == id_user).Select(x => x.id_sede).SingleOrDefault();

				ViewBag.canales = await _operaciones.mCanales(id_sede);
				ViewBag.muelles = await _operaciones.mMuelles(id_sede);
				ViewBag.cuadrilla = await _operaciones.mCuadrillas(id_sede);
				ViewBag.estacionamiento = await _operaciones.mEstacionamientos(id_sede);
				ViewBag.anexos = await _operaciones.mAnexos(id_sede);

				return View();
			}
			catch (Exception ex)
			{
				TempData["success"] = "Error por favor vuelva a ingresar.";
				return View();
			}

		}

		public async Task<IActionResult> Bloqueos()
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
				ViewBag.canales = await _operaciones.mBloqCanal(id_sede);
				ViewBag.muelles = await _operaciones.mBloqmuelles(id_sede);
				ViewBag.estacionamiento = await _operaciones.mBloqestacionamientos(id_sede);
				ViewBag.cuadrilla = await _operaciones.mBloqcuadrillas(id_sede);
				return View();
			}
			catch (Exception ex)
			{
				TempData["success"] = "Error por favor vuelva a ingresar.";
				return View();
			}

		}

		[HttpPost]
		public async Task<IActionResult> UpdateBloqueos(int id_esta, int id_cua, int id_can, int id_mue, string tipest, string obser)
		{
			DateTime fecha = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");
			try
			{
				int id = 0;
				if (id_esta != 0)
				{
					id = id_esta;
				}
				if (id_cua != 0)
				{
					id = id_cua;
				}
				if (id_can != 0)
				{
					id = id_can;
				}
				if (id_mue != 0)
				{
					id = id_mue;
				}
				await _operaciones.mUpdateBloqueos(id, tipest, obser, fecha);
				TempData["success"] = "Regitro ingresado";
				return RedirectToAction("Bloqueos", "MDViaje_Cabecera");
			}
			catch (Exception ex)
			{
				TempData["success"] = "Error por favor vuelva a ingresar.";
				return View();
			}

		}

		public async Task<IActionResult> Seguridad()
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
				ViewBag.seguridad = await _operaciones.mSeguridad(id_sede);
				return View();
			}
			catch (Exception ex)
			{
				TempData["success"] = "Error por favor vuelva a ingresar.";
				return View();
			}

		}

		public async Task<IActionResult> Seguridadsalida()
		{
			try
			{
				ClaimsPrincipal currentUser = this.User;
				var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
				var id_user = _context.Usuarios.Where(x => x.Usua_user == currentUserID).Select(x => x.IdUsuario).SingleOrDefault();
				var id_sede = _context.Accesos.Where(x => x.IdUsuario == id_user).Select(x => x.id_sede).SingleOrDefault();
				ViewBag.salida = await _operaciones.mSeguridadsalida(id_sede);
				return View();
			}
			catch (Exception ex)
			{
				TempData["Error"] = "Error por favor vuelva a ingresar.";
				return View();
			}

		}

		[HttpPost]
		public async Task<IActionResult> ingresounidad(int id_vijcab)
		{
			DateTime fecha = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");
			try
			{
				await _operaciones.mUpdateseg(id_vijcab, fecha);
				TempData["success"] = "Registro ingresado correctamente";
				return RedirectToAction("Seguridad", "MDViaje_Cabecera");
			}
			catch (Exception ex)
			{
				TempData["success"] = "Error por favor vuelva a ingresar.";
				return View();
			}

		}


		[HttpPost]
		public async Task<IActionResult> Salidavehiculo(int id_vijcab)
		{
			DateTime fecha = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");
			try
			{
				ClaimsPrincipal currentUser = this.User;
				var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
				var id_user = _context.Usuarios.Where(x => x.Usua_user == currentUserID).Select(x => x.IdUsuario).SingleOrDefault();
				var id_sede = _context.Accesos.Where(x => x.IdUsuario == id_user).Select(x => x.id_sede).SingleOrDefault();
				var indcarga = await _operaciones.mIndcarga(id_vijcab);
				if (indcarga == 0)
				{
					await _operaciones.mUpdatesalida(id_vijcab, fecha, id_sede);
					TempData["success"] = "Registro ingresado correctamente";
					return RedirectToAction("Seguridadsalida", "MDViaje_Cabecera");
				}
				else
				{
					TempData["error"] = "Vehiculo no termina con todos sus procesos";
					return RedirectToAction("Seguridadsalida", "MDViaje_Cabecera");
				}

			}
			catch (Exception ex)
			{
				TempData["error"] = "Error por favor vuelva a ingresar.";
				return View();
			}

		}

		[HttpPost]
		public async Task<IActionResult> ingresollegada(int id_vijcab)
		{
			DateTime fecha = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");
			try
			{
				await _operaciones.mUpdatellegada(id_vijcab, fecha);
				TempData["success"] = "Registro ingresado correctamente";
				return RedirectToAction("Seguridad", "MDViaje_Cabecera");
			}
			catch (Exception ex)
			{
				TempData["success"] = "Error por favor vuelva a ingresar.";
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
				TempData["success"] = "Error por favor vuelva a ingresar.";
				return View();
			}

		}

		public async Task<IActionResult> UpdateEstacionamiento(int id_estacionamiento, string mplac_desc, int id_vijcab, string nro_trans)
		{
			DateTime fecha = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");
			try
			{
				nro_trans = "";
				await _operaciones.mUpdateEstacionseguridad(id_estacionamiento, id_vijcab, mplac_desc, nro_trans, fecha);
				return RedirectToAction("listaestacion", "MDViaje_Cabecera", new { plac_desc = mplac_desc, id_vijcab = id_vijcab, nro_trans = nro_trans });
			}
			catch (Exception ex)
			{
				TempData["success"] = "Error por favor vuelva a ingresar.";
				return RedirectToAction("listaestacion", "MDViaje_Cabecera", new { plac_desc = mplac_desc, id_vijcab = id_vijcab, nro_trans = nro_trans });
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="plac_desc"></param>
		/// <param name="id_vijcab"></param>
		/// <param name="nro_trans"></param>
		/// <returns></returns>
		public async Task<IActionResult> listacanallibre()
		{
			try
			{
				ClaimsPrincipal currentUser = this.User;
				var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
				var id_user = _context.Usuarios.Where(x => x.Usua_user == currentUserID).Select(x => x.IdUsuario).SingleOrDefault();
				var id_sede = _context.Accesos.Where(x => x.IdUsuario == id_user).Select(x => x.id_sede).SingleOrDefault();
				ViewBag.Canales = await _operaciones.mCheckCanalesocupados(id_sede);
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
		public async Task<IActionResult> liberarcanal(int id_canal)
		{
			DateTime fecha = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");
			try
			{
				await _operaciones.mLiberarcanaldes(id_canal);
				//return View();
				return RedirectToAction("listacanallibre", "MDViaje_Cabecera");
			}
			catch (Exception ex)
			{
				TempData["success"] = "Ocurrio un problema por favor consulte con su area de sistemas";
				return RedirectToAction("listacanallibre", "MDViaje_Cabecera");
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
				TempData["success"] = "Error por favor vuelva a ingresar.";
				return View();
			}

		}

		public async Task<IActionResult> Updateanexos(int id_anexo, string mplac_desc, int id_vijcab, string nro_trans)
		{
			DateTime fecha = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");
			try
			{
				nro_trans = "";
				await _operaciones.mUpdateAnexoSeguridad(id_anexo, id_vijcab, mplac_desc, nro_trans, fecha);
				return RedirectToAction("listanexos", "MDViaje_Cabecera", new { plac_desc = mplac_desc, id_vijcab = id_vijcab, nro_trans = nro_trans });
			}
			catch (Exception ex)
			{
				TempData["success"] = "Error por favor vuelva a ingresar.";
				return RedirectToAction("listanexos", "MDViaje_Cabecera", new { plac_desc = mplac_desc, id_vijcab = id_vijcab, nro_trans = nro_trans });
			}

		}

		public async Task<IActionResult> UpdatePicking(int id_vijcab, string tipcab)
		{
			DateTime fecha = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");
			try
			{
				await _operaciones.mUpdatePicking(id_vijcab, fecha);
				TempData["success"] = "Registro ingresado";
				if (tipcab == "C")
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

		public async Task<IActionResult> UpdateFacturacion(int id_vijcab, string tipcab)
		{
			DateTime fecha = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");
			try
			{
				await _operaciones.mUpdateFacturacion(id_vijcab, fecha);
				TempData["success"] = "Registro ingresado";
				if (tipcab == "C")
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

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id_canal"></param>
		/// <param name="mplac_desc"></param>
		/// <param name="id_vijcab"></param>
		/// <param name="nro_trans"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<string> Updatecanal(int id_canal, string mplac_desc, int id_vijcab, string nro_trans)
		{
			DateTime fecha = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");

			try
			{
				await _operaciones.mUpdatecanal(id_canal, mplac_desc, nro_trans, fecha);
				var reponse = JsonConvert.SerializeObject("Done");
				return reponse;
			}
			catch (Exception ex)
			{
				TempData["success"] = "Ocurrio un problema por favor consulte con su area de sistemas";
				return "mal";
			}

		}

		[HttpPost]
		public async Task<IActionResult> listacanal(string mplac_desc, int id_vijcab, string nro_trans)
		{
			try
			{
				ClaimsPrincipal currentUser = this.User;
				var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
				var id_user = _context.Usuarios.Where(x => x.Usua_user == currentUserID).Select(x => x.IdUsuario).SingleOrDefault();
				var id_sede = _context.Accesos.Where(x => x.IdUsuario == id_user).Select(x => x.id_sede).SingleOrDefault();
				ViewBag.Canales = await _operaciones.mCheckCanales(id_sede);
				return View();
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
				return RedirectToAction("viajecarga", "MDViaje_Cabecera");
			}
			catch (Exception ex)
			{
				TempData["success"] = "Ocurrio un problema por favor consulte con su area de sistemas";
				return View();
			}
		}

		public async Task<IActionResult> UpdatePrepcomp(int mid_vijdet, int mid_vijcab, int mid_estcam, int mid_tiptran, int id_cab)
		{
			DateTime fecha = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");
			try
			{
				var indest = await _operaciones.mIndestado(mid_vijcab, mid_estcam);
				if (indest == 0)
				{
					TempData["error"] = "Tiene que finalizar Proc. Preparacion";
					return RedirectToAction("viajecarga", "MDViaje_Cabecera");
				}
				else
				{
					await _operaciones.mEstadoViaje(mid_vijdet, mid_vijcab, mid_estcam, fecha);
					TempData["success"] = "Registro ingresado";
					return RedirectToAction("viajecarga", "MDViaje_Cabecera");
				}
			}
			catch (Exception ex)
			{
				TempData["success"] = "Ocurrio un problema por favor consulte con su area de sistemas";
				return View();
			}
		}

		public async Task<IActionResult> UpdateRecojo(int mid_vijdet, int mid_vijcab, int mid_estcam, int mid_tiptran, int id_cab)
		{
			DateTime fecha = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");
			try
			{
				await _operaciones.mEstadoViaje(mid_vijdet, mid_vijcab, mid_estcam, fecha);
				TempData["success"] = "Registro ingresado";
				return RedirectToAction("viajecarga", "MDViaje_Cabecera");
			}
			catch (Exception ex)
			{
				TempData["success"] = "Ocurrio un problema por favor consulte con su area de sistemas";
				return View();
			}
		}

		public async Task<IActionResult> Updateprepa(int mid_vijdet, int mid_vijcab, int mid_estcam, int mid_tiptran, int id_cab)
		{
			DateTime fecha = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");
			try
			{
				var canal = await _operaciones.mvalcanal(mid_vijcab);
				var fase = await _operaciones.mvalfase(mid_vijcab);
				if (canal != 0 && fase != 0)
				{
					await _operaciones.mEstadoViaje(mid_vijdet, mid_vijcab, mid_estcam, fecha);
					TempData["success"] = "Registro ingresado";
					return RedirectToAction("viajecarga", "MDViaje_Cabecera");
				}
				else
				{
					TempData["Error"] = "Asegurese de ingresar Fase y/o Canal";
					return RedirectToAction("viajecarga", "MDViaje_Cabecera");
				}

			}
			catch (Exception ex)
			{
				TempData["success"] = "Ocurrio un problema por favor consulte con su area de sistemas";
				return View();
			}
		}

		private bool MDViaje_CabeceraExists(int id)
		{
			return _context.Viaje_Cabeceras.Any(e => e.id_vijcab == id);
		}
	}
}

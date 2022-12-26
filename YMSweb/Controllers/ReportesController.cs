using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using YMSweb.Data;
using YMSweb.Data.DataSql;
using YMSweb.Models.ViewModels;

namespace YMSweb.Controllers
{
    public class ReportesController : Controller
    {
        VMReporte1 _mReporte1;
        private readonly IConfiguration _config;
        SP_Reportes _reporte;
        private readonly DataContext _context;
        public ReportesController(DataContext context, IConfiguration config)
        {
            _mReporte1 = new VMReporte1();
            _config = config;
            _reporte = new SP_Reportes();
            _context = context;
        }

        public async Task<IActionResult> Index(DateTime fecini, DateTime fecfin, int nro_viaje, string nro_trans)
        {
            ClaimsPrincipal currentUser = this.User;
            var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
            var id_user = _context.Usuarios.Where(x => x.Usua_user == currentUserID).Select(x => x.IdUsuario).SingleOrDefault();
            var id_sede = _context.Accesos.Where(x => x.IdUsuario == id_user).Select(x => x.id_sede).SingleOrDefault();

            if (nro_trans == null)
            {
                nro_trans = "";
            }
            if (fecini == DateTime.MinValue)
            {
                fecini = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time"); 
            }

            if (fecfin == DateTime.MinValue)
            {
                fecfin = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SA Pacific Standard Time");
            }

            string conn = _config["ConnectionStrings:DefaultConnection"];
            var mReporte = await _reporte.mReporteviaje(fecini, fecfin, nro_viaje, nro_trans);
            return View(mReporte);
        }
    }
}

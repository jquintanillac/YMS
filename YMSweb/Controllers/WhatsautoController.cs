using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using YMSweb.Data;
using YMSweb.Data.DataSql;
using YMSweb.Data.Entities;
using YMSweb.Models.ViewModels;
using static YMSweb.Models.ViewModels.VMWhatsap;

namespace YMSweb.Controllers
{
    public class WhatsautoController : Controller
    {
        private readonly IConfiguration _config;
        private readonly DataContext _context;
        private readonly SP_Operaciones _operaciones;

        public WhatsautoController(IConfiguration config, DataContext context)
        {
            _config = config;
            _context = context;
            _operaciones = new SP_Operaciones();
        }

        // GET: WhatsautoController
        public ActionResult Index()
        {
            return View();
        }

        // GET: WhatsautoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WhatsautoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Whatsauto/alibot
        //[HttpPost]        
        public ActionResult<messagewp> alibot([FromForm] Peticionwp oPeticion)
        {
            try
            {                
                var app = oPeticion.app;
                var sender = oPeticion.sender;
                var message = oPeticion.message;

                string oIterar = "";
                var oResp = _operaciones.mWhatsapauto(message);
                foreach (var item in oResp)
                {
                    oIterar = oIterar + " \n" +
                              "Placa: " + item.plac_desc + " \n" +
                              "Nro. Transporte: " + item.campla_nrotrans + " \n" +
                              "Canales: " + item.viaj_canales + " \n" +
                              "Estado: " + item.estado + " \n" +
                              "Transportista: " + item.transp_desc + " \n" +
                              "Hora propuesta de carga: " + item.vijcab_horapropuesta + " \n";
                }

                if (oIterar == "")
                {
                    oIterar = "";
                }
                //var json = app + "/" + sender + "/" + message;
                messagewp oResponse = new messagewp
                {
                    reply = oIterar
                };
                return oResponse;
            }
            catch (Exception ex)
            {
                var json = "";
                messagewp oResponse = new messagewp
                {
                    reply = json
                };
                return oResponse;
            }
        }

        // GET: WhatsautoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WhatsautoController/Edit/5
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

        // GET: WhatsautoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WhatsautoController/Delete/5
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

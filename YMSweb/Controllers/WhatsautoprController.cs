using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using YMSweb.Data;
using YMSweb.Data.DataSql;
using static YMSweb.Models.ViewModels.VMWhatsautoprueba;

namespace YMSweb.Controllers
{
    public class WhatsautoprController : Controller
    {
        private readonly IConfiguration _config;
        private readonly DataContext _context;
        private readonly SP_Operaciones _operaciones;

        public WhatsautoprController(IConfiguration config, DataContext context)
        {
            _config = config;
            _context = context;
            _operaciones = new SP_Operaciones();
        }



        // GET: WhatsautoprController
        public ActionResult Index()
        {
            return View();
        }

        // GET: WhatsautoprController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WhatsautoprController/Create
        public async Task<ActionResult<Message>> whatsapauto([FromForm] Peticion oPeticion)
        {
            var app = oPeticion.app;
            var sender = oPeticion.sender;
            var message = oPeticion.message;

            string oIterar = "";
            var oResp = _operaciones.mWhatsapauto(message);
            foreach (var item in oResp)
            {
                oIterar = oIterar + " \n " +
                          "Placa: " + item.plac_desc + " \n " +
                          "Nro. Transporte: " + item.campla_nrotrans + " \n " +
                          "Canales: " + item.viaj_canales + " \n " +
                          "Hora propuesta de carga: " + item.vijcab_horapropuesta + " \n ";
            }

            if (oIterar == "")
            {
                oIterar = "No se encontraron resultados";
            }
            //var json = app + "/" + sender + "/" + message;
            Message oResponse = new Message
            {
                reply = oIterar
            };
            return oResponse;


        }

        // POST: WhatsautoprController/Create
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

        // GET: WhatsautoprController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WhatsautoprController/Edit/5
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

        // GET: WhatsautoprController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WhatsautoprController/Delete/5
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

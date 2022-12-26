using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YMSweb.Data;
using YMSweb.Data.DataSql;
using YMSweb.Data.Entities;
using YMSweb.Models.ViewModels;
using System.Text.Json;
using System.Text.Json.Serialization;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Net.Http;
using System.Text;
using WhatzMeApiApp.Requests;
using static YMSweb.Models.ViewModels.VMWhatsap;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace YMSweb.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class WSwhatsappwhoController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly DataContext _context;
        private readonly SP_Operaciones _operaciones;
        public WSwhatsappwhoController(IConfiguration config, DataContext context)
        {
            _config = config;
            _context = context;
            _operaciones = new SP_Operaciones();
        }

        // GET: api/WSwhatsappwho
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        // POST api/WSwhatsappwho --> Localhost
        // POST http://asplearning-001-site4.itempurl.com/api/WSwhatsappwho  --> Pruebas
        [HttpPost]
        public async Task<ActionResult<messagewp>> alibot([FromBody] Peticionwp oPeticion)
        {
            try
            {                
                var app = oPeticion.app;
                var sender = oPeticion.sender;
                var message = oPeticion.message;
                //oreply = await _operaciones.mWhatsapauto(oPeticion.message);
                var json = app + sender + message;
                messagewp oResponse = new messagewp
                {
                    reply = json
                };
                return oResponse;
            }
            catch (Exception ex)
            {           
                var json = "No se pudo realizar su consulta, pruebe nuevamente.";
                messagewp oResponse = new messagewp
                {
                    reply = json
                };
                return oResponse;
            }
        }

        // PUT api/<WSwhatsappwhoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {

        }

        // DELETE api/<WSwhatsappwhoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Models.ViewModels
{
    public class VMviajes
    {
        [Display(Name = "Nro. Viaje")]
        public int id_camplacab { get; set; }
        [Display(Name = "Nro. Orden")]
        public int campla_orden { get; set; }
        [Display(Name = "Placa")]
        public string placa { get; set; }
        [Display(Name = "Nro. Transporte")]
        public string Nro_Trans { get; set; }
        [Display(Name = "Observacion")]
        public string campla_obse { get; set; }
        [Display(Name = "Fecha Generacion")]
        public DateTime Fec_gen { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Models.ViewModels
{
    public class VMCamiones_Planificados
    {
        [Display(Name = "Nro. Plani")]
        public int id_campla { get; set; }
        [Display(Name = "Nro. Viaje")]
        public int id_camplacab { get; set; }
        [Display(Name = "Tipo Transp.")]
        public string tiptran { get; set; }
        [Display(Name = "Placa")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string placa { get; set; }
        [Display(Name = "Nro. Transporte")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [MaxLength(7, ErrorMessage = "El campo {0} no permite mas de {1} characters.")]
        public string campla_nrotrans { get; set; }
        [Display(Name = "Peso")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string campla_peso { get; set; }
        [Display(Name = "Volumen")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string campla_volumen { get; set; }
        [Display(Name = "Observaciones")]
        public string campla_obse { get; set; }
        public int campla_orden { get; set; }
    }
}

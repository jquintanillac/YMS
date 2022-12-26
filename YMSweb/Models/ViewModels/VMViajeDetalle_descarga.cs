using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Models.ViewModels
{
    public class VMViajeDetalle_descarga
    {
        [Display(Name = "id")]
        public int id_vijcab { get; set; }
        [Display(Name = "Placa")]
        public string plac_desc { get; set; }
        [Display(Name = "Nro. Transporte")]
        public string campla_nrotrans { get; set; }
        [Display(Name = "Peso")]
        public string campla_peso { get; set; }
        [Display(Name = "Volumen")]
        public string campla_volumen { get; set; }
        [Display(Name = "Observacion")]
        public string campla_obse { get; set; }
        [Display(Name = "Tipo Transporte")]
        public string tiptran_desc { get; set; }
        [Display(Name = "Estados del Camion")]
        public string estcam_desc { get; set; }
        [Display(Name = "Emp. Transporte")]
        public string transp_desc { get; set; }
        [Display(Name = "Canales")]
        public string canales { get; set; }      
        [Display(Name = "Fase")]
        public string campla_fase { get; set; }              
        [Display(Name = "Fecha facturacion")]
        public string vijdet_fecini { get; set; }
        [Display(Name = "Fecha Picking")]
        public string vijcab_fecpick { get; set; }
    }
}

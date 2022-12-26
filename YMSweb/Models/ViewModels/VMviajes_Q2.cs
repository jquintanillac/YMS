using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Models.ViewModels
{
    public class VMviajes_Q2
    {
        [Display(Name = "Placa")]
        public string plac_desc { get; set; }
        [Display(Name = "Nro. Transporte")]
        public string campla_nrotrans { get; set; }
        [Display(Name = "Tipo Transporte")]
        public string tiptran_desc { get; set; }
        [Display(Name = "Peso")]
        public string campla_peso { get; set; }
        [Display(Name = "Volumen")]
        public string campla_volumen { get; set; }
        [Display(Name = "Chofer")]
        public string Chofer { get; set; }
        [Display(Name = "Transportista")]
        public string transp_desc { get; set; }
        [Display(Name = "Recojo Picking")]
        public bool vijcab_pick { get; set; }
        [Display(Name = "Fecha Picking")]
        public DateTime vijcab_fecpick { get; set; }
        [Display(Name = "Cuadrilla")]
        public string cua_desc { get; set; }
        [Display(Name = "cua_libre")]
        public bool cua_libre { get; set; }
        [Display(Name = "Estacionamiento")]
        public string esta_desc { get; set; }
        [Display(Name = "esta_libre")]
        public bool esta_libre { get; set; }
        [Display(Name = "Muelle")]
        public string mue_desc { get; set; }
        [Display(Name = "mue_libre")]
        public bool mue_libre { get; set; }
        [Display(Name = "Inspeccion")]
        public bool vijcab_insp { get; set; }
        [Display(Name = "vijcab_fecinsp")]
        public DateTime vijcab_fecinsp { get; set; }
        [Display(Name = "vijcab_ingunidad")]
        public bool vijcab_ingunidad { get; set; }
        [Display(Name = "vijcab_fecunidad")]
        public DateTime vijcab_fecunidad { get; set; }
        [Display(Name = "vijcab_horapropuesta")]
        public DateTime vijcab_horapropuesta { get; set; }

        [Display(Name = "Canal")]
        public string can_desc { get; set; }
        [Display(Name = "canal libre")]
        public bool can_act { get; set; }
        public int id_vijcab { get; set; }

    }
}

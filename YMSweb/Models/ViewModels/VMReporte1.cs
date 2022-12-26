using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Models.ViewModels
{
    public class VMReporte1
    {
        [Display(Name = "Placa")]
        public string placa { get; set; }
        [Display(Name = "Nro. Viaje")]
        public string nro_viaje { get; set; }
        [Display(Name = "Empresa")]
        public string empresa { get; set; }

        [Display(Name = "Volumen")]
        public string volumen { get; set; }

        [Display(Name = "Peso")]
        public string peso { get; set; }

        [Display(Name = "Tipo Transporte")]
        public string tipo_transporte { get; set; }

        [Display(Name = "Hora Propuesta")]
        public string hora_propuesta { get; set; }

        [Display(Name = "Nro. Fase")]
        public string fase { get; set; }

        [Display(Name = "Fecha Viaje")]
        public string fecha_viaje { get; set; }
        [Display(Name = "Fecha Llegada")]
        public string vijcab_fecllegada { get; set; }
        [Display(Name = "Fecha Unidad")]
        public string vijcab_fecunidad { get; set; }

        [Display(Name = "Nro. Transporte")]
        public string nro_transportes { get; set; }
        [Display(Name = "Estados Camion")]
        public string estcam_desc { get; set; }
        [Display(Name = "Fecha Inicio")]
        public string vijdet_fecini { get; set; }
        [Display(Name = "Fecha Fin")]
        public string vijdet_fecfin { get; set; }

        [Display(Name = "Nro. Canales")]
        public string nro_canales { get; set; }
        [Display(Name = "Fecha Inicio Canal")]
        public string can_fecini { get; set; }
        [Display(Name = "Fecha Fin Canal")]
        public string can_fecfin { get; set; }
        [Display(Name = "Nro. Muelles")]
        public string nro_muelles { get; set; }
        [Display(Name = "Fecha Inicio Muelle")]
        public string muell_fecini { get; set; }
        [Display(Name = "Fecha Fin Muelle")]
        public string muell_fecfin { get; set; }
        [Display(Name = "Nro. Estacionamiento")]
        public string nro_estacionamiento { get; set; }
        [Display(Name = "Fecha Inicio Estacionamiento")]
        public string estacion_fecini { get; set; }
        [Display(Name = "Fecha Fin Estacionamiento")]
        public string estacion_fecfin { get; set; }
        [Display(Name = "Nro. Cuadrilla")]
        public string nro_cuadrilla { get; set; }
        [Display(Name = "Fecha Inicio Cuadrilla")]
        public string cuadri_fecini { get; set; }
        [Display(Name = "Fecha Fin Cuadrilla")]
        public string cuadri_fecfin { get; set; }
        [Display(Name = "Nro. Montacarga")]
        public string nro_montacarga { get; set; }
        [Display(Name = "Fecha Inicio Montacarga")]
        public string monta_fecini { get; set; }
        [Display(Name = "Fecha Fin Montacarga")]
        public string monta_fecfin { get; set; }
    }
}

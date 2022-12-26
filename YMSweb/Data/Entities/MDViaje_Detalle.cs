using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Data.Entities
{
    [Table("Viaje_Detalle")]
    public class MDViaje_Detalle
    {
        [Key]
        [Display(Name = "ID")]
        public  int id_vijdet { get; set; }
        [Display(Name = "ID Viaje Cabecera")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int id_vijcab { get; set; }
        [Display(Name = "Estado Camion")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int id_estcam { get; set; }
        [Display(Name = "Muelle")]
        public string viaj_muelles { get; set; }
        [Display(Name = "Canal")]
        public string viaj_canales { get; set; }
        [Display(Name = "Cuadrilla")]
        public string viaj_cuadrillas { get; set; }
        [Display(Name = "Estacionamiento")]
        public string viaj_estacionamientos { get; set; }
        [Display(Name = "Fecha/Hora Inicio")]
        public DateTime vijdet_fecini_muelle { get; set; }
        [Display(Name = "Fecha/Hora Fin")]
        public DateTime vijdet_fecfin_muelle { get; set; }

        [Display(Name = "Fecha/Hora Inicio")]
        public DateTime vijdet_fecini_canal { get; set; }
        [Display(Name = "Fecha/Hora Fin")]
        public DateTime vijdet_fecfin_canal { get; set; }

        [Display(Name = "Fecha/Hora Inicio")]
        public DateTime vijdet_fecini_cuadril { get; set; }
        [Display(Name = "Fecha/Hora Fin")]
        public DateTime vijdet_fecfin_cuadril { get; set; }

        [Display(Name = "Fecha/Hora Inicio")]
        public DateTime vijdet_fecini_estacio { get; set; }
        [Display(Name = "Fecha/Hora Fin")]
        public DateTime vijdet_fecfin_estacio { get; set; }
        [Display(Name = "Fecha/Hora Fin")]
        public DateTime vijdet_fecini { get; set; }
        [Display(Name = "Fecha/Hora Fin")]
        public DateTime vijdet_fecfin { get; set; }
        [Display(Name = "Estado")]
        public bool vijdet_est { get; set; }
        public int id_sede { get; set; }
        public virtual MDEstados_Camion DEstados_Camions { get; set; }
        public virtual MDViaje_Cabecera DViaje_Cabeceras { get; set; }
        public virtual MDMuelle DMuelles { get; set; }
        public virtual MDCanal DCanals { get; set; }
        public virtual MDEstacionamiento DEstacionamiento { get; set; }
        public virtual MDCuadrilla DCuadrillas { get; set; }

    }
}

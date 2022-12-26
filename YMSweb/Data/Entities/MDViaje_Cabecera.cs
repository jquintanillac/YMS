using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Data.Entities
{
    [Table("Viaje_Cabecera")]
    public class MDViaje_Cabecera
    {
        [Key]
        [Display(Name = "ID")]
        public int id_vijcab { get; set; }
        [Display(Name = "Camion Planificado")]        
        public int id_campla { get; set; }
        public bool vijcab_pick { get; set; }
        public DateTime vijcab_fecpick { get; set; }
        public bool vijcab_insp { get; set; }
        public DateTime vijcab_fecinsp { get; set; }
        public bool vijcab_ingunidad { get; set; }
        public DateTime vijcab_fecunidad { get; set; }
        public bool vijcab_llegada { get; set; }
        public DateTime vijcab_fecllegada { get; set; }
        public DateTime vijcab_horapropuesta { get; set; }
        public int id_sede { get; set; }
        public bool vijcab_segsal { get; set; }
        public virtual MDCamiones_Planificados DCamiones_Planificados { get; set; }
        public virtual ICollection<MDViaje_Detalle> DViaje_Detalles { get; set; }

    }
}

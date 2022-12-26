using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Data.Entities
{
    [Table("Camiones_Planificados_Cabecera")]
    public class MDCamiones_Planificados_Cabecera
    {
        [Key]

        public int id_camplacab { get; set; }
        [Display(Name = "Fecha registro")]        
        public DateTime camplacab_fecha { get; set; }
        public bool camplacab_act { get; set; }
        public string camplacab_fin { get; set; }
        public string camplacab_obs { get; set; }
        public int id_sede { get; set; }

    }
}

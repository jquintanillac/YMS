using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Data.Entities
{
    [Table("Cuadrilla")]
    public class MDCuadrilla
    {
        [Key]
        [Display(Name = "ID")]
        public int id_cuadrilla { get; set; }
        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string cua_desc { get; set; }
        [Display(Name = "Activo")]
        public bool cua_act { get; set; }
        [Display(Name = "Libre")]
        public bool cua_libre { get; set; }
        public string cua_plac { get; set; }
        public int id_sede { get; set; }
        public int cua_cod { get; set; }
        public string cua_obs { get; set; }
        public virtual ICollection<MDViaje_Detalle> DViaje_Detalle { get; set; }
    }
}

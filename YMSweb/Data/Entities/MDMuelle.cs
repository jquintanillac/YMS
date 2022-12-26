using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Data.Entities
{
    [Table("Muelle")]
    public class MDMuelle
    {
        [Key]
        [Display(Name = "ID")]
        public int id_muelle { get; set; }
        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string mue_desc { get; set; }
        [Display(Name = "Activo")]
        public bool mue_act { get; set; }
        [Display(Name = "Libre")]
        public bool mue_libre { get; set; }
        public string mue_plac { get; set; }
        public int id_sede { get; set; }
        public int mue_cod { get; set; }
        public string mue_obs { get; set; }
        public virtual ICollection<MDViaje_Detalle> DViaje_Detalle { get; set; }

    }
}

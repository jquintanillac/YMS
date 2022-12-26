using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Data.Entities
{
    [Table("Canal")]
    public class MDCanal
    {
        [Key]
        [Display(Name = "ID")]
        public int id_canal { get; set; }
        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string can_desc { get; set; }
        [Display(Name = "Activo")]
        public bool can_act { get; set; }
        public string can_plac { get; set; }
        public string can_esta { get; set; }
        public int id_sede { get; set; }
        public int can_cod { get; set; }
        public string can_obs { get; set; }
        public virtual ICollection<MDViaje_Detalle> DViaje_Detalles  { get; set; }
    }
}

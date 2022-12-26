using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Data.Entities
{
    [Table("Rol")]
    public class MDRol
    {
        [Key]
        [Display(Name = "ID")]
        public int Idrol { get; set; }
        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string rol_desc { get; set; }
        public int id_sede { get; set; }
        public virtual ICollection<MDRol_Usuario> DRol_Usuarios { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Data.Entities
{
    [Table("Rol_Usuario")]
    public class MDRol_Usuario
    {
        [Key]
        [Display(Name = "ID")]
        public int Idrol_usua { get; set; }
        [Display(Name = "Rol")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public  int Idrol { get; set; }
        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int IdUsuario { get; set; }
        public int id_sede { get; set; }
        [ForeignKey("Idrol")]
        public virtual MDRol DRol { get; set; }
        public virtual MDUsuario DUsuario { get; set; }

    }
}

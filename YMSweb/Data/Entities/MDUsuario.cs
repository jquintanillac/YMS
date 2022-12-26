using DataAnnotationsExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Data.Entities
{
    [Table("Usuario")]
    public class MDUsuario
    {
        [Key]
        [Display(Name = "ID")]
        public int IdUsuario { get; set; }
        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Usua_user { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Usua_nombres { get; set; }
        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Usua_apellidos { get; set; }
        [Display(Name = "email")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        [Email(ErrorMessage = "Ingrese un Correo valido.")]
        public string Usua_email { get; set; }
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string Usua_pass { get; set; }    
        [Display(Name = "Activo")]
        public string Usua_Hash { get; set; }
        public bool Usua_act { get; set; }
        public string Usua_imagen { get; set; }
        [ForeignKey("IdUsuario")]
        public int id_sede { get; set; }
        public virtual List<MDRol_Usuario> DRol_Usuarios { get; set; }

    }
}

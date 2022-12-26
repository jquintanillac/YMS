using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Models.ViewModels
{
    public class VMRol_Usuario
    {
        [Display(Name="IdUsua")]
        public string Idrol_usua { get; set; }
        [Display(Name = "Usuario")]
        public string Usuario { get; set; }
        [Display(Name = "Nombre Completo")]
        public string Nombre_Completo { get; set; }
        [Display(Name = "Rol Asignado")]
        public string Rol { get; set; }
    }
}

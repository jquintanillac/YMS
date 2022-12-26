using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Models.ViewModels
{
    public class VMRolUsarios
    {
        public string Idrol_usua { get; set; }
        public string Usuario { get; set; }
        public string Nombre_Completo { get; set; }
        public string Rol { get; set; }
        public string Usua_pass { get; set; }
        public string Usua_Hash { get; set; }
        public string Usua_email { get; set; }
    }
}

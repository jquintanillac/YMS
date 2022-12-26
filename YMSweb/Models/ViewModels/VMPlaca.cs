using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Models.ViewModels
{
    public class VMPlaca
    {
        [Display(Name = "id_placa")]
        public string id_placa { get; set; }
        [Display(Name = "Chofer")]
        public string Chofer { get; set; }
        [Display(Name = "Transportista")]
        public string Transportista { get; set; }
        [Display(Name = "Placa")]
        public string Placa { get; set; }
        public string Tipo { get; set; }
        [Display(Name = "Activa")]
        public bool Activa { get; set; }
        [Display(Name = "Libre")]
        public bool Libre { get; set; }
    }
}

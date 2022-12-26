using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Data.Entities
{
    [Table("Estacionamiento")]
    public class MDEstacionamiento
    {
        [Key]
        [Display(Name = "ID")]
        public int id_estacionamiento { get; set; }
        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string esta_desc { get; set; }
        [Display(Name = "Activo")]
        public bool esta_act { get; set; }
        [Display(Name = "Libre")]
        public bool esta_libre { get; set; }
        public string esta_plac { get; set; }
        public int id_sede { get; set; }
        public int esta_cod { get; set; }
        public string esta_obs { get; set; }
    }
}

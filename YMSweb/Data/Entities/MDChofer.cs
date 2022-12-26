using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Data.Entities
{
    [Table("Chofer")]
    public class MDChofer
    {
        [Key]
        [Display(Name = "ID")]
        public int id_chofer { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string chof_nomb { get; set; }
        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string chof_apell { get; set; }
        [Display(Name = "DNI")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string chof_dni { get; set; }
        [Display(Name = "Brevette")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string chof_brevette { get; set; }
        [Display(Name = "Activo")]
        public bool chof_act { get; set; }
        public int id_sede { get; set; }
        public virtual ICollection<MDPlaca> DPlacas { get; set; }
    }
}

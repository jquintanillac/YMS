using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Data.Entities
{
    [Table("Transportista")]
    public class MDTransportista
    {
        [Key]
        [Display(Name = "ID")]
        public int id_transp { get; set; }
        [Display(Name = "Razon Social")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string transp_desc { get; set; }
        [Display(Name = "RUC")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string transp_ruc { get; set; }
        [Display(Name = "Activo")]
        public bool transp_act { get; set; }
        [Display(Name = "Libre")]
        public bool transp_libre { get; set; }
        public int id_sede { get; set; }
        public virtual ICollection<MDPlaca> DPlacas { get; set; }
    }
}

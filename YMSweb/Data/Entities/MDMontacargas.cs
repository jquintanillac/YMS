using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Data.Entities
{
    [Table("Montacargas")]
    public class MDMontacargas
    {
        [Key]
        [Display(Name = "ID")]
        public int id_monta { get; set; }
        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string monta_desc { get; set; }
        [Display(Name = "Activo")]
        public bool monta_act { get; set; }
        public string monta_plac { get; set; }
        public int id_sede { get; set; }
        public int monta_cod { get; set; }

    }
}

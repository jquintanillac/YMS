using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Data.Entities
{
    [Table("Tipo_Transporte")]
    public class MDTipo_Transporte
    {
        [Key]
        [Display(Name = "ID")]
        public int id_tiptran { get; set; }
        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string tiptran_desc { get; set; }
        [Display(Name = "Activo")]
        public bool? tiptran_act { get; set; }
        public int id_sede { get; set; }
        public virtual ICollection<MDCamiones_Planificados> DCamiones_Planificados { get; set; }
    }
}

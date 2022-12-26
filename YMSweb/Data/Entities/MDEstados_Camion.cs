using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Data.Entities
{
    [Table("Estados_Camion")]
    public class MDEstados_Camion
    {
        [Key]
        [Display(Name = "ID")]
        public int id_estcam { get; set; }
        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string estcam_desc { get; set; }
        [Display(Name = "Activo")]
        public bool estcam_act { get; set; }
        [Display(Name = "Busqueda")]
        public bool estcam_busq { get; set; }
        public int estcam_codigo { get; set; }
        public int id_sede { get; set; }
        public virtual ICollection<MDViaje_Detalle> DViaje_Detalle { get; set; }
    }
}

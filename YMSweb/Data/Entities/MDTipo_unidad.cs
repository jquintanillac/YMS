using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Data.Entities
{
    [Table("Tipo_Unidad")]
    public class MDTipo_unidad
    {
        [Key]
        [Display(Name = "ID")]
        public int id_tipuni { get; set; }
        [Display(Name = "Codigo")]
        public int tipuni_cod { get; set; }
        [Display(Name = "Descripcion")]
        public string tipuni_desc { get; set; }
        [Display(Name = "Sede")]
        public int id_sede { get; set; }

    }
}

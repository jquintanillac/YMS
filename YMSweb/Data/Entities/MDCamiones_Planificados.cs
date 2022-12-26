using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Data.Entities
{
    [Table("Camiones_Planificados")]
    public class MDCamiones_Planificados
    {
        [Key]
        [Display(Name ="ID")]
        public int id_campla { get; set; }
        public int id_camplacab { get; set; }
        [Display(Name = "Tipo Transporte")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int id_tiptran { get; set; }
        [Display(Name = "Placa")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int id_placa { get; set; }
        [Display(Name = "Nro. Transporte")]
        [MaxLength(10, ErrorMessage = "El campo {0} no permite mas de {1} characters.")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string campla_nrotrans { get; set; }
        [Display(Name = "Peso")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string campla_peso { get; set; }
        [Display(Name = "Volumen")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string campla_volumen { get; set; }
        public DateTime campla_fecha { get; set; }
        [Display(Name = "Observaciones")]        
        public string campla_obse { get; set; }
        public string campla_cardesc { get; set; }
        public int campla_orden { get; set; }
        public int id_sede { get; set; }
        public string  campla_fase { get; set; }
        public virtual MDPlaca DPlaca { get; set; }
        public virtual MDTipo_Transporte DTipo_Transporte { get; set; }
        public virtual ICollection<MDViaje_Cabecera> DViaje_Cabecera { get; set; }
    }
}

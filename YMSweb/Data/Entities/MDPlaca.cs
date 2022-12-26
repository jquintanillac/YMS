using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Data.Entities
{
    [Table("Placa")]
    public class MDPlaca
    {
        [Key]
        [Display(Name = "ID")]
        public int id_placa { get; set; }
        [Display(Name = "Chofer")]
        [ForeignKey("id_chofer")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int id_chofer { get; set; }
        [Display(Name = "Transportista")]
        [ForeignKey("id_transp")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public int id_transp { get; set; }
        [Display(Name = "Placa")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string plac_desc  { get; set; }
        [Display(Name = "Tipo_Unidad")]
        public string plac_tipo { get; set; }
        [Display(Name = "Activo")]
        public bool plac_act { get; set; }
        [Display(Name = "Libre")]
        public bool plac_libre { get; set; }
        public int id_sede { get; set; }
        public int id_tipo { get; set; }
        public virtual MDChofer DChofer { get; set; }
        public virtual MDTransportista DTransportista { get; set; }
        public virtual ICollection<MDCamiones_Planificados> DCamiones_Planificados { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Models.ViewModels
{
    public class VMviajes_Q1
    {
        [Display(Name = "id_vijdet")]
        public int id_vijdet { get; set; }
        [Display(Name = "id_vijcab")]
        public int id_vijcab { get; set; }

        [Display(Name = "id_estcam")]
        public int id_estcam { get; set; }

        [Display(Name ="EStado Camion")]
        public string estcam_desc { get; set; }
        [Display(Name = "Fecha Registro")]
        public string vijdet_fecini { get; set; }
        [Display(Name = "Activo")]
        public bool vijdet_est { get; set; }
        public int id_tiptran { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Models.ViewModels
{
    public class VMSeguridad
    {
        public string plac_desc { get; set; }
        public string campla_nrotrans { get; set; }
        public int  id_vijcab { get; set; }
        public string campla_obse { get; set; }
        public bool vijcab_ingunidad { get; set; }
        public bool vijcab_llegada { get; set; }

    }
}

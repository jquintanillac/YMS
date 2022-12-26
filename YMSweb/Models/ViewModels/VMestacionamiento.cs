using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Models.ViewModels
{
    public class VMestacionamiento
    {
        public int id_estacionamiento { get; set; }
        public int esta_cod { get; set; }
        public string plac_desc { get; set; }
        public string nro_trans { get; set; }
        public bool esta_act { get; set; }
        public string esta_obs { get; set; }

    }
}

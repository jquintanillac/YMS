using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YMSweb.Models.ViewModels
{
    public class VMCarga
    {
        public string placa { get; set; } = "";
        public string Nro_transp { get; set; } = "";
        public string peso { get; set; } = "";
        public string volumen { get; set; } = "";
        public string tipo_trans { get; set; } = "";
        public string ind_viaj { get; set; } = "";
        public string observacion { get; set; } = "";
    }
}

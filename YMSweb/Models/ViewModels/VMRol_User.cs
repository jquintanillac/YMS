namespace YMSweb.Models.ViewModels
{
    public class VMRol_User
    {
        public int Idrol { get; set; }        
        public int IdUsuario { get; set; }
        public int id_sede { get; set; }
        public string Usua_user { get; set; }
        public string Usua_nombres { get; set; }
        public string Usua_email { get; set; }
        public string Usua_pass { get; set; } 
        public string Usua_Hash { get; set; }

    }
}

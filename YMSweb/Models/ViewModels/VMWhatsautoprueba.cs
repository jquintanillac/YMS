namespace YMSweb.Models.ViewModels
{
    public class VMWhatsautoprueba
    {
       public class Peticion
        {
            public string app { get; set; }
            public string sender { get; set; }
            public string message { get; set; }
        }

        public class Message
        {
            public string reply { get; set; }
        }
    }
}

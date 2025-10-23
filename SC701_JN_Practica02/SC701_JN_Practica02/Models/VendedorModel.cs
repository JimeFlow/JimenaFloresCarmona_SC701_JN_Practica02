namespace SC701_JN_Practica02.Models
{
    public class VendedorModel
    {
        public long IdVendedor { get; set; }
        public string Cedula { get; set; } = string.Empty;

        public string Nombre { get; set; } = string.Empty;


        public string Correo { get; set; } = string.Empty;

        public bool Estado { get; set; }
    }
}

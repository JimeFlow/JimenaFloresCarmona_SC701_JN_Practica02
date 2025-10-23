namespace SC701_JN_Practica02.Models
{
    public class VehiculoModel
    {
        public long IdVehiculo { get; set; }
        public string Marca { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string Color { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public long IdVendedor { get; set; }
    }
}

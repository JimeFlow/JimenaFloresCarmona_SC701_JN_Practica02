using System.ComponentModel.DataAnnotations;

namespace SC701_JN_Practica02.Models
{
    public class VehiculoModel
    {
        public long IdVehiculo { get; set; }

        [Required(ErrorMessage = "La marca es obligatoria")]
        public string Marca { get; set; } = string.Empty;

        [Required(ErrorMessage = "El modelo es obligatorio")]
        public string Modelo { get; set; } = string.Empty;

        [Required(ErrorMessage = "El color es obligatorio")]
        public string Color { get; set; } = string.Empty;

        [Required(ErrorMessage = "El precio es obligatorio")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor que cero")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El vendedor es obligatorio")]
        public long IdVendedor { get; set; }
    }
}

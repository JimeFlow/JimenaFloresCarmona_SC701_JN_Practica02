using System.ComponentModel.DataAnnotations;

namespace SC701_JN_Practica02.Models
{
    public class VendedorModel
    {
        public long IdVendedor { get; set; }

        [Required(ErrorMessage = "La cédula es obligatoria")]
        [StringLength(20)]
        public string Cedula { get; set; } = string.Empty;

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "El correo es obligatorio")]
        [EmailAddress(ErrorMessage = "Correo inválido")]
        [StringLength(200)]
        public string Correo { get; set; } = string.Empty;

        public bool Estado { get; set; }
    }
}

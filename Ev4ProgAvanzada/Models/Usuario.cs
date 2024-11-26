using System.ComponentModel.DataAnnotations;

namespace Ev4ProgAvanzada.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del usuario es obligatorio.")]
        [StringLength(50, ErrorMessage = "El nombre no puede superar los 50 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "Debe ser una dirección de correo válida.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El rol es obligatorio.")]
        [StringLength(20, ErrorMessage = "El rol no puede superar los 20 caracteres.")]
        public string Rol { get; set; } // "Agente" o "Administrador"

        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La contraseña debe tener entre 6 y 100 caracteres.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ev4ProgAvanzada.Models
{
    public class Agente
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio.")]
        [EmailAddress(ErrorMessage = "Debe ser una dirección de correo válida.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [StringLength(20, ErrorMessage = "El teléfono no puede superar los 20 caracteres.")]
        public string Telefono { get; set; }

        public bool EnOficina { get; set; } // Indica si el agente está en la oficina

        // Relación con proyectos
        public ICollection<Proyecto> Proyectos { get; set; } = new List<Proyecto>();
    }
}

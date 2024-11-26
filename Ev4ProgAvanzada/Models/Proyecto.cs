using System.ComponentModel.DataAnnotations;

namespace Ev4ProgAvanzada.Models
{
    public class Proyecto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del proyecto es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El nombre de la empresa es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre de la empresa no puede superar los 100 caracteres.")]
        public string Empresa { get; set; }

        [Required(ErrorMessage = "El representante es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre del representante no puede superar los 100 caracteres.")]
        public string Representante { get; set; }

        [Required(ErrorMessage = "El contacto es obligatorio.")]
        [StringLength(50, ErrorMessage = "El contacto no puede superar los 50 caracteres.")]
        public string Contacto { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        public bool Completado { get; set; } // Indica si el proyecto está completado

        [Required]
        public int AgenteId { get; set; } // Clave foránea para el agente

        public Agente Agente { get; set; } // Relación con el modelo Agente
    }
}

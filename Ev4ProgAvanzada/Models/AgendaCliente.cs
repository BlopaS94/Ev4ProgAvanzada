using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ev4ProgAvanzada.Models
{
    [Table("agenda_clientes")]
    public class AgendaCliente
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(200)]
        public string Proyecto { get; set; }

        [Required]
        [StringLength(100)]
        public string Empresa { get; set; }

        [Required]
        [StringLength(20)]
        public string Telefono { get; set; }

        [Required]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        [Column("fecha_de_ingreso")] // Mapea al nombre de la columna en la base de datos
        public DateTime FechaDeIngreso { get; set; }

        [Required]
        [Column("hora_de_agenda")] // Mapea al nombre de la columna en la base de datos
        public DateTime HoraDeAgenda { get; set; }

        [Column("fecha_hora_atencion_oficina")] // Mapea al nombre de la columna en la base de datos
        public DateTime? FechaHoraAtencionOficina { get; set; }
    }
}
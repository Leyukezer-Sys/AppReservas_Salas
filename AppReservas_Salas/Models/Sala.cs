using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppReservas_Salas.Models
{
    [Table("sala"), PrimaryKey(nameof(IdSala))]
    public class Sala
    {
        [Column("id_sala")]
        public int IdSala { get; set; }

        [Column("numero")]
        public int? Numero { get; set; }

        [Column("capacidade")]
        public int? Capacidade { get; set; }

        [Column("bloco")]
        public string? Bloco { get; set; }

        [Column("id_tipo_fk")]
        public int IdTipo { get; set; }

        [ForeignKey(nameof(IdTipo))]
        public TipoSala? Tipo { get; set; }

        public List<Reserva>? Reservas { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppReservas_Salas.Models
{
    [Table("usuario"), PrimaryKey(nameof(IdUsuario))]
    public class Usuario
    {
        [Column("id_usuario")]
        public int IdUsuario { get; set; }

        [Column("nome")]
        public string? Nome { get; set; }

        [Column("matricula")]
        public string? Matricula { get; set; }

        [Column("senha")]
        public string? Senha { get; set; }

        [Column("id_tipo_fk")]
        public int IdTipo { get; set; }

        [ForeignKey(nameof(IdTipo))]
        public TipoUsuario? Tipo { get; set; }

        public List<Reserva>? Reservas { get; set; }
    }
}

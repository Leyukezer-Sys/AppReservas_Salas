using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppReservas_Salas.Models
{
    [Table("tipo_usuario"), PrimaryKey(nameof(Id))]
    public class TipoUsuario
    {
        [Column("id_tipo")]
        public int Id { get; set; }
        [Column("nome_tipo")]
        public string? Nome { get; set; }
        public List<Usuario>? Usuarios { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace AppReservas_Salas.Models
{
    [Table("tipo_usuario")]
    public class TipoUsuario
    {
        [Column("id_tipo")]
        public int Id { get; set; }
        [Column("nome_tipo")]
        public int Nome { get; set; }
        public List<Usuario>? Usuarios { get; set; }
    }
}

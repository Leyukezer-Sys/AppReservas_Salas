using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppReservas_Salas.Models
{
    [Table("tipo_sala"), PrimaryKey(nameof(Id))]
    public class TipoSala
    {
        [Column("id_tipo")]
        public int Id { get; set; }
        [Column("nome_tipo")]
        public string? Nome { get; set; }
        public List<Sala>? Salas { get; set; }
    }
}

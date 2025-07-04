using System.ComponentModel.DataAnnotations.Schema;

namespace AppReservas_Salas.Models
{
    [Table("reserva")]
    public class Reserva
    {
        [Column("id_reserva")]
        public int Id { get; set; }

        [Column("data_reserva")]
        public DateTime DataReserva { get; set; } = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day);
        
        [Column("hora_inicio_reserva")]
        public TimeOnly HoraInicioReserva { get; set; } 
            //= new TimeOnly(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

        [Column("hora_fim_reserva")]
        public TimeOnly HoraFimReserva { get; set; } 
            //= new TimeOnly(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

        [Column("id_usuario_fk")]
        public int IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }

        [Column("id_sala_fk")]
        public int IdSala { get; set; }

        [ForeignKey(nameof(IdSala))]
        public Sala? Sala { get; set; }
    }
}

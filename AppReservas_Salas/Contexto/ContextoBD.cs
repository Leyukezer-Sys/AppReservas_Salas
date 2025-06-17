using AppReservas_Salas.Models;
using Microsoft.EntityFrameworkCore;

namespace AppReservas_Salas.Contexto
{
    public class ContextoBD : DbContext
    {
        public ContextoBD(DbContextOptions<ContextoBD> options) : base(options)
        {

        }

        public DbSet<Sala> Salas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<TipoSala> TiposSalas { get; set; }
        public DbSet<TipoUsuario> TiposUsuarios { get; set; }
    }
}
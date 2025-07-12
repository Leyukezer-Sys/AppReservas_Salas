using AppReservas_Salas.Contexto;
using AppReservas_Salas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppReservas_Salas.Controllers
{
    public class ReservaController : Controller
    {
        private readonly ContextoBD _context;
        public ReservaController(ContextoBD context)
        {
            _context = context;
        }

        public async Task<List<Reserva>>? Reservas()
        {
            var reservas = await _context.Reservas.Include(r => r.Sala).Include(r => r.Usuario).ToListAsync();

            return reservas;
        }

        public async Task<bool> VerificarDisponibilidade(int idSala, DateOnly dataReserva, TimeOnly horaInicio, TimeOnly horaFim)
        {
            try
            {
                // Verifica se o DbContext ou o DbSet está nulo
                if (_context?.Reservas == null)
                {
                    Console.WriteLine("⚠️ Contexto ou DbSet 'Reservas' está nulo.");
                    return false; // Ou 'true', se quiser bloquear reservas por precaução
                }

                bool conflito = await _context.Reservas.AnyAsync(r =>
                    r.IdSala == idSala &&
                    r.DataReserva == dataReserva &&
                    (
                        (horaInicio >= r.HoraInicioReserva && horaInicio < r.HoraFimReserva) ||
                        (horaFim > r.HoraInicioReserva && horaFim <= r.HoraFimReserva) ||
                        (horaInicio <= r.HoraInicioReserva && horaFim >= r.HoraFimReserva)
                    )
                );

                return conflito;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"🛑 Erro ao verificar disponibilidade: {ex.Message}");
                return false;
            }
        }


        public async Task<bool> SalaEstaReservada(int idSala, DateOnly data)
        {
            if (_context?.Reservas == null)
            {
                Console.WriteLine("⚠️ Contexto ou DbSet Reservas está nulo.");
                return false; // ou true, se quiser assumir como “ocupado” por segurança
            }

            try
            {
                return await _context.Reservas
                    .AnyAsync(r => r.IdSala == idSala && r.DataReserva == data);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"🛑 Erro ao verificar reserva: {ex.Message}");
                return false;
            }
        }



        public async Task<Reserva>? GetReserva(int id)
        {
            var reserva = await _context.Reservas.Include(r => r.Sala).Include(r => r.Usuario).Where(r => r.Id == id).FirstOrDefaultAsync();

            return reserva;
        }

        public async Task<Reserva>? GetReserva(DateOnly dataReserva)
        {
            var reserva = await _context.Reservas.Include(r => r.Sala).Include(r => r.Usuario).Where(r => r.DataReserva == dataReserva).FirstOrDefaultAsync();

            return reserva;
        }

        public async Task Add(Reserva Reserva)
        {
            if (Reserva != null)
            {
                await _context.Reservas.AddAsync(Reserva);
            }
            else
            {
                Console.WriteLine("Reserva Nula, Inválida!");
            }
        }

        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }
    }
}

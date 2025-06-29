using AppReservas_Salas.Contexto;
using AppReservas_Salas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppReservas_Salas.Controllers
{
    public class ReservaController : Controller
    {
        private readonly ContextoBD _context;

        public async Task<List<Reserva>>? Reservas()
        {
            var reservas = await _context.Reservas.Include(r => r.Sala).Include(r => r.Usuario).ToListAsync();

            return reservas;
        }

        public async Task<Reserva>? GetReserva(int id)
        {
            var reserva = await _context.Reservas.Include(r => r.Sala).Include(r => r.Usuario).Where(r => r.Id == id).FirstOrDefaultAsync();

            return reserva;
        }

        public async Task<Reserva>? GetReserva(DateTime dataReserva)
        {
            var Reserva = await _context.Reservas.Include(r => r.Sala).Include(r => r.Usuario).Where(r => r.DataReserva == dataReserva).FirstOrDefaultAsync();

            return Reserva;
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

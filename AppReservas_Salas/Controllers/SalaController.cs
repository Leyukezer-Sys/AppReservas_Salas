using AppReservas_Salas.Contexto;
using AppReservas_Salas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppReservas_Salas.Controllers
{
    public class SalaController : Controller
    {
        private readonly ContextoBD _context;

        public SalaController(ContextoBD context)
        {
            _context = context;
        }

        public async Task<List<Sala>>? Salas()
        {
            var salas = await _context.Salas.Include(u => u.Tipo).ToListAsync();

            return salas;
        }

        public async Task<Sala>? GetSala(int id)
        {
            var sala = await _context.Salas.Include(s => s.Tipo).Where(s => s.IdSala == id).FirstOrDefaultAsync();

            return sala;
        }

        public async Task<Sala>? GetSala(int numero, string bloco)
        {
            var sala = await _context.Salas.Include(s => s.Tipo).Where(s => s.Numero == numero).Where(s => s.Bloco == bloco).FirstOrDefaultAsync();

            return sala;
        }

        public async Task Add(Sala sala)
        {
            if (sala != null)
            {
                await _context.Salas.AddAsync(sala);
            }
            else
            {
                Console.WriteLine("Salas Nulo, Inválido!");
            }
        }
        public async Task Update(Sala sala)
        {
            _context.Salas.Update(sala);
        }

        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }
    }
}
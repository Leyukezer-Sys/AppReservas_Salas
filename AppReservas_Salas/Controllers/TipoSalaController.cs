using AppReservas_Salas.Contexto;
using AppReservas_Salas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppReservas_Salas.Controllers
{
    public class TipoSalaController : Controller
    {
        private readonly ContextoBD _context;

        public TipoSalaController(ContextoBD context)
        {
            _context = context;
        }

        public async Task<List<TipoSala>>? TiposSalas()
        {
            var tipos = await _context.TiposSalas.Include(ts => ts.Salas).ToListAsync();

            return tipos;
        }

        public async Task Add(TipoSala tipo)
        {
            if (tipo != null)
            {
                await _context.TiposSalas.AddAsync(tipo);
            }
        }

        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }
    }
}

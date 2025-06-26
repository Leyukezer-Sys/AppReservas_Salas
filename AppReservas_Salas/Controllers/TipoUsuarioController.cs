using AppReservas_Salas.Contexto;
using AppReservas_Salas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace AppReservas_Salas.Controllers
{
    public class TipoUsuarioController : Controller
    {
        private readonly ContextoBD _context;

        public TipoUsuarioController(ContextoBD context)
        {
            _context = context;
        }

        public async Task<List<TipoUsuario>>? TiposUsuario()
        {
            var tipos = await _context.TiposUsuarios.Include(tu => tu.Usuarios).ToListAsync();

            return tipos;
        }

        public async Task Add(TipoUsuario tipo)
        {
            if (tipo != null)
            {
                await _context.TiposUsuarios.AddAsync(tipo);
            }
        }

        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }
    }
}
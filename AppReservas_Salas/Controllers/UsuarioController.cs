using AppReservas_Salas.Contexto;
using AppReservas_Salas.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppReservas_Salas.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ContextoBD _context;

        public UsuarioController(ContextoBD context)
        {
            _context = context;
        }

        public async Task<List<Usuario>>? Usuarios()
        {
            var usuarios = await _context.Usuarios.Include(u => u.Tipo).ToListAsync();

            return usuarios;
        }

        public async Task<Usuario>? GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.Include(u => u.Tipo).Where(u => u.IdUsuario == id).FirstOrDefaultAsync();

            return usuario;
        }

        public async Task<Usuario>? GetUsuario(string matricula)
        {
            var usuario = await _context.Usuarios.Include(u => u.Tipo).Where(u => u.Matricula == matricula).FirstOrDefaultAsync();

            return usuario;
        }

        public async Task Add(Usuario usuario)
        {
            if (usuario != null)
            {
                await _context.Usuarios.AddAsync(usuario);
            }
            else
            {
                Console.WriteLine("Usuario Nulo, Inválido!");
            }
        }

        public async Task Salvar()
        {
            await _context.SaveChangesAsync();
        }

    }
}

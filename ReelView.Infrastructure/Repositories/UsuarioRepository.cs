using Microsoft.EntityFrameworkCore;
using ReelView.Core.Models; // Confirme se é .Models ou .Entities
using ReelView.Core.Interfaces.Repositories; // Confirme se a pasta é Repositories ou Repositorios
using ReelView.Infrastructure.Data;

namespace ReelView.Infrastructure.Repositories
{
    // A classe herda de BaseRepository E implementa a interface específica IUsuarioRepository
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(AppDbContext context) : base(context)
        {
        }

        // ESTE é o método que estava faltando para cumprir o contrato da Interface
        public async Task<Usuario> BuscarPorEmailAsync(string email)
        {
            return await _context.Usuarios
                                 .FirstOrDefaultAsync(u => u.Email == email);
        }
    }
}
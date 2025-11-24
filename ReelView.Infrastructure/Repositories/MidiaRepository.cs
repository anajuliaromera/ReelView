using Microsoft.EntityFrameworkCore;
using ReelView.Core.Interfaces.Repositories;
using ReelView.Core.Models;
using ReelView.Infrastructure.Data;

namespace ReelView.Infrastructure.Repositories
{
    public class MidiaRepository : BaseRepository<Midia>, IMidiaRepository
    {
        public MidiaRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<Midia>> BuscarPorTituloAsync(string titulo)
        {
            return await _dbSet
                .Where(m => m.Titulo.Contains(titulo))
                .ToListAsync();
        }

        public async Task<IEnumerable<Midia>> BuscarPorTipoAsync(string tipo)
        {
            return await _dbSet
                .Where(m => m.Tipo == tipo)
                .ToListAsync();
        }
    }
}

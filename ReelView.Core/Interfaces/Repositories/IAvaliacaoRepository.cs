using ReelView.Core.Models;

namespace ReelView.Core.Interfaces.Repositories
{
    public interface IAvaliacaoRepository : IBaseRepository<Avaliacao>
    {
        Task<IEnumerable<Avaliacao>> GetByMidiaIdAsync(int midiaId);
    }
}
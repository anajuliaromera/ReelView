using ReelView.Core.Models;

namespace ReelView.Core.Interfaces.Repositories
{
    public interface IMidiaRepository : IBaseRepository<Midia>
    {
        Task<IEnumerable<Midia>> BuscarPorTituloAsync(string titulo);
        Task<IEnumerable<Midia>> BuscarPorTipoAsync(string tipo);
    }
}

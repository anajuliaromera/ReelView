using ReelView.Core.Models;

namespace ReelView.Core.Interfaces.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<Usuario> BuscarPorEmailAsync(string email);
    }
}

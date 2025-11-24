using ReelView.Core.DTOs.Usuario;

namespace ReelView.Core.Interfaces.Service
{
    public interface IUsuarioService
    {
        Task<UsuarioResponseDTO> RegisterAsync(UsuarioCreateDTO dto);
        Task<UsuarioResponseDTO> LoginAsync(UsuarioLoginDTO dto);
        Task<IEnumerable<UsuarioResponseDTO>> GetAllAsync();
        Task<UsuarioResponseDTO> GetByIdAsync(int id);
        Task UpdateAsync(int id, UsuarioUpdateDTO dto);
        Task DeleteAsync(int id);
    }
}
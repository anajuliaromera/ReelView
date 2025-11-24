using ReelView.Core.DTOs.Filme;
using ReelView.Core.DTOs.Midia;
using ReelView.Core.DTOs.Serie;

namespace ReelView.Core.Interfaces.Service
{
    public interface IMidiaService
    {
        
        Task<MidiaDTO> CreateFilmeAsync(FilmeCreateDTO dto);
        Task<MidiaDTO> CreateSerieAsync(SerieCreateDTO dto);

        Task<MidiaDTO> GetByIdAsync(int id);
        Task<IEnumerable<MidiaDTO>> GetAllAsync();

        Task UpdateAsync(int id, MidiaUpdateDTO dto);
        Task DeleteAsync(int id);
    }
}
using ReelView.Core.DTOs.Filme;
using ReelView.Core.DTOs.Midia;
using ReelView.Core.DTOs.Serie;
using ReelView.Core.Models;
using ReelView.Core.Interfaces.Repositories;
using ReelView.Core.Interfaces.Service;

namespace ReelView.Api.Service
{
    public class MidiaService : IMidiaService
    {
        private readonly IMidiaRepository _repository;

        public MidiaService(IMidiaRepository repository)
        {
            _repository = repository;
        }

        public async Task<MidiaDTO> CreateFilmeAsync(FilmeCreateDTO dto)
        {
            var filme = new Filme
            {
                Titulo = dto.Titulo,
                Descricao = dto.Descricao ?? "",
                Ano = dto.Ano,
                Genero = dto.Genero,
                DuracaoMinutos = dto.DuracaoMinutos,
                Tipo = "Filme"
            };

            await _repository.AddAsync(filme);
            return MapToDTO(filme);
        }

        public async Task<MidiaDTO> CreateSerieAsync(SerieCreateDTO dto)
        {
            var serie = new Serie
            {
                Titulo = dto.Titulo,
                Descricao = dto.Descricao ?? "",
                Ano = dto.Ano,
                Genero = dto.Genero,
                Temporadas = dto.Temporadas,
                Tipo = "Serie"
            };

            await _repository.AddAsync(serie);
            return MapToDTO(serie);
        }

        public async Task<IEnumerable<MidiaDTO>> GetAllAsync()
        {
            var midias = await _repository.GetAllAsync();
            return midias.Select(MapToDTO);
        }

        public async Task<MidiaDTO> GetByIdAsync(int id)
        {
            var midia = await _repository.GetByIdAsync(id);
            return midia == null ? null : MapToDTO(midia);
        }

        public async Task UpdateAsync(int id, MidiaUpdateDTO dto)
        {
            var midia = await _repository.GetByIdAsync(id);
            if (midia != null)
            {
                midia.Titulo = dto.Titulo;
                midia.Descricao = dto.Descricao;
                midia.Genero = dto.Genero;
                await _repository.UpdateAsync(midia);
            }
        }

        public async Task DeleteAsync(int id)
        {
            // Busca antes de deletar para passar a entidade ao repositório
            var midia = await _repository.GetByIdAsync(id);
            if (midia != null)
            {
                await _repository.DeleteAsync(midia);
            }
        }

        private MidiaDTO MapToDTO(Midia m)
        {
            return new MidiaDTO
            {
                Id = m.Id,
                Titulo = m.Titulo,
                Ano = m.Ano,
                Tipo = m.Tipo,
                NotaMedia = m.NotaMedia
            };
        }
    }
}
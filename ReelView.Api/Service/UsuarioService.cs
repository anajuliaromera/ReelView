using ReelView.Core.DTOs.Usuario;
using ReelView.Core.Models;
using ReelView.Core.Interfaces.Repositories;
using ReelView.Core.Interfaces.Service;
using BCrypt.Net;

namespace ReelView.Api.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<UsuarioResponseDTO> RegisterAsync(UsuarioCreateDTO dto)
        {
            // Criptografa a senha antes de salvar no banco
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(dto.Senha);

            var usuario = new Usuario
            {
                Nome = dto.Nome,
                Email = dto.Email,
                SenhaHash = passwordHash
            };

            await _repository.AddAsync(usuario);

            return new UsuarioResponseDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email
            };
        }

        public async Task<UsuarioResponseDTO> LoginAsync(UsuarioLoginDTO dto)
        {
            var usuario = await _repository.BuscarPorEmailAsync(dto.Email);

            // Verifica se o utilizador existe e se a senha bate com o Hash
            if (usuario == null || !BCrypt.Net.BCrypt.Verify(dto.Senha, usuario.SenhaHash))
            {
                throw new Exception("Email ou senha inválidos");
            }

            // Retorna os dados do utilizador (Token é fake por enquanto)
            return new UsuarioResponseDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email,
                Token = "token_jwt_fake_123456"
            };
        }

        public async Task<IEnumerable<UsuarioResponseDTO>> GetAllAsync()
        {
            var usuarios = await _repository.GetAllAsync();
            return usuarios.Select(u => new UsuarioResponseDTO
            {
                Id = u.Id,
                Nome = u.Nome,
                Email = u.Email
            });
        }

        public async Task<UsuarioResponseDTO> GetByIdAsync(int id)
        {
            var u = await _repository.GetByIdAsync(id);
            if (u == null) return null;

            return new UsuarioResponseDTO
            {
                Id = u.Id,
                Nome = u.Nome,
                Email = u.Email
            };
        }

        public async Task UpdateAsync(int id, UsuarioUpdateDTO dto)
        {
            var usuario = await _repository.GetByIdAsync(id);
            if (usuario != null)
            {
                usuario.Nome = dto.Nome;
                usuario.Email = dto.Email;
                // Se quiseres permitir troca de senha aqui, terias de fazer o Hash novamente

                await _repository.UpdateAsync(usuario);
            }
        }

        public async Task DeleteAsync(int id)
        {
            // Busca a entidade completa antes de deletar (necessário para o EF Core)
            var usuario = await _repository.GetByIdAsync(id);
            if (usuario != null)
            {
                await _repository.DeleteAsync(usuario);
            }
        }
    }
}
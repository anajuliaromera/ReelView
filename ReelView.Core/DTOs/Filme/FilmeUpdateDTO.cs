namespace ReelView.Core.DTOs.Filme
{
	public class FilmeUpdateDTO
	{
		public string Titulo { get; set; } = string.Empty;
		public string Descricao { get; set; } = string.Empty;
		public int Ano { get; set; }
		public string Genero { get; set; } = string.Empty;
		public int DuracaoMinutos { get; set; }
	}
}

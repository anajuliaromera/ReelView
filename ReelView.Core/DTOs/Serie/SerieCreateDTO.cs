namespace ReelView.Core.DTOs.Serie
{
    public class SerieCreateDTO
    {
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int Ano { get; set; }
        public string Genero { get; set; } = string.Empty;

        public int Temporadas { get; set; }
        public int Episodios { get; set; }
    }
}

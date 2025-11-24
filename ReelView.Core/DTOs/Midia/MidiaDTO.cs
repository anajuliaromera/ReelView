namespace ReelView.Core.DTOs.Midia
{
    public class MidiaDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int Ano { get; set; }
        public string Genero { get; set; } = string.Empty;
        public double NotaMedia { get; set; }
        public string Tipo { get; set; } = string.Empty;
    }
}


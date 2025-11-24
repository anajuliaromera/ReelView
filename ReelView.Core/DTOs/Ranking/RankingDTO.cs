namespace ReelView.Core.DTOs.Ranking
{
    public class RankingDTO
    {
        public int MidiaId { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public double NotaMedia { get; set; }
        public string CapaUrl { get; set; } = string.Empty;
    }
}
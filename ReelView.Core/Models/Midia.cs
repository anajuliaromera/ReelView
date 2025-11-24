using System.Collections.Generic;
using System.Linq;

namespace ReelView.Core.Models
{
    public abstract class Midia
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int Ano { get; set; }
        public string Genero { get; set; } = string.Empty;
        public List<Avaliacao> Avaliacoes { get; set; } = new();
        public string Tipo { get; set; }
        public double NotaMedia => Avaliacoes.Count == 0 ? 0 : Avaliacoes.Average(a => a.Nota);

        public override string ToString() => $"{Titulo} ({Ano}) - {NotaMedia:N1}/10";
    }
}

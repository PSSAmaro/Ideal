using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Classes
{
    public class Ideia
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public Pessoa Autor { get; set; }
        public DateTime Data { get; set; }
        public bool Partilha { get; set; }
        public Estado.EstadoIdeia Estado { get; set; }
        public int Pontuacao { get; set; }
        public List<Classes.Tag> Tags { get; set; }

        public List<Classes.Comentario> Comentarios { get; set; }
        public List<Classes.Pessoa> Pessoas { get; set; }
        public List<Classes.Pessoa> Votos { get; set; }

        public string Hora => Data.ToString("hh:mm");
        public string Dia => Data.ToString("dd/MM/yyyy");
    }
}

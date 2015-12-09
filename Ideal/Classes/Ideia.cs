using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Classes
{
    public class Ideia
    {
        public enum LEstado { Pendente, EmAnalise, AImplementar, Implementado, Descartado };

        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public DateTime Data { get; set; }
        public bool Partilha { get; set; }
        private int _estado;
        public int Estado
        {
            get
            {
                return _estado;
            }
            set
            {
                // Confirmar que o estado pertence à lista de estados, caso contrário usa a predefinição (1º estado)
                _estado = value < Enum.GetNames(typeof(LEstado)).Length ? value : 0;
            }
        }

        public Ideia()
        {
            Titulo = "Erro";
            Conteudo = "Erro";
            Data = DateTime.Now;
            Partilha = false;
            Estado = (int)LEstado.Pendente;
        }

        public Ideia(string tit, string con)
        {
            Titulo = tit;
            Conteudo = con;
            Data = DateTime.Now;
            Partilha = false;
            Estado = (int)LEstado.Pendente;
        }

        public void Partilhar()
        {
            // Cria uma ligação de partilha da ideia
            Partilha = true;
        }

        public void MudaEstado(LEstado novo)
        {
            Estado = (int)novo;
        }
    }
}

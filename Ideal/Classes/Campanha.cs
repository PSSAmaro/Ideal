using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Classes
{
    public class Campanha
    {
        public List<Classes.Ideia> Ideias { get; set; }
        public List<Classes.Pessoa> Pessoas { get; set; }
        public List<Classes.Pessoa> Votos { get; set; }
    }
}

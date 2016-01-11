using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ideal.Classes.Tipo;

namespace Ideal.Classes
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public TipoPessoa Tipo { get; set; }
        public List<Classes.Ideia> IdeiasSubscritas { get; set; }
        public List<Classes.Campanha> CampanhasSubscritas { get; set; }
    }
}

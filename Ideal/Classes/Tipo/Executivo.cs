using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Classes.Tipo
{
    class Executivo : TipoPessoa
    {
        public Executivo()
        {
            Nome = "Executivo";
            Admin = true;
        }
    }
}

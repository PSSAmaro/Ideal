using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Classes.Tipo
{
    class Colaborador : TipoPessoa
    {
        public Colaborador()
        {
            Nome = "Colaborador";
            Admin = false;
        }
    }
}

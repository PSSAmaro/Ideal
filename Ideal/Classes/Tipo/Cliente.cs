using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal.Classes.Tipo
{
    class Cliente : TipoPessoa
    {
        public Cliente()
        {
            Nome = "Cliente";
            Admin = false;
        }
    }
}

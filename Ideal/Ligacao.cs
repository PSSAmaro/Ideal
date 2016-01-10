using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideal
{
    public class Ligacao
    {
        static Ligacao ligacao = null;

        public Ligacao() { }

        public static Ligacao connect
        {
            get
            {
                if (ligacao == null)
                {
                    ligacao = new Ligacao();
                }
                return ligacao;
            }
        }
    }
}

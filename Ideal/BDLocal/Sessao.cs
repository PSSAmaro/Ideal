using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace Ideal.BDLocal
{
    public class Sessao
    {
        [PrimaryKey]
        public int Id { get; set; }
        public int Oid { get; set; }
        public string Nome { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool Admin { get; set; }
        public bool Login { get; set; }
    }
}

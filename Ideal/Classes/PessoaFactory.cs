using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Ideal.Classes.Estado;
using Ideal.Classes.Tipo;

namespace Ideal.Classes
{
    class PessoaFactory
    {
        public List<Classes.Pessoa> Items { get; set; }

        public PessoaFactory(JsonArray jsonArray)
        {
            Items = new List<Classes.Pessoa>();
            foreach (IJsonValue jsonValue in jsonArray)
            {
                JsonObject ideia = jsonValue.GetObject();
                TipoPessoa tipo;
                switch (ideia.GetNamedString("tipo", ""))
                {
                    case "executivo":
                        tipo = new Executivo();
                        break;
                    case "gestor":
                        tipo = new Gestor();
                        break;
                    case "colaborador":
                        tipo = new Colaborador();
                        break;
                    case "cliente":
                        tipo = new Cliente();
                        break;
                    default:
                        tipo = new Executivo();
                        break;
                }
                Items.Add(new Classes.Pessoa()
                {
                    Nome = ideia.GetNamedString("nome", ""),
                    Tipo = tipo
                });
            }
        }
    }
}

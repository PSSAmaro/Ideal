using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Ideal.Classes.Estado;

namespace Ideal.Classes
{
    public class IdeiaFactory
    {
        public List<Classes.Ideia> Items { get; set; }

        public IdeiaFactory(JsonArray jsonArray)
        {
            Items = new List<Classes.Ideia>();
            foreach (IJsonValue jsonValue in jsonArray)
            {
                JsonObject ideia = jsonValue.GetObject();
                EstadoIdeia est;
                switch (ideia.GetNamedString("estado", ""))
                {
                    case "pendente":
                        est = new Pendente();
                        break;
                    case "emAnalise":
                        est = new EmAnalise();
                        break;
                    case "aImplementar":
                        est = new AImplementar();
                        break;
                    case "implementado":
                        est = new Implementado();
                        break;
                    case "descartado":
                        est = new Descartado();
                        break;
                    default:
                        est = new Pendente();
                        break;
                }
                Items.Add(new Classes.Ideia()
                {
                    Id = (int)ideia.GetNamedNumber("id", 0),
                    Titulo = ideia.GetNamedString("titulo", ""),
                    Conteudo = ideia.GetNamedString("conteudo", ""),
                    Autor = new Pessoa() {Nome = ideia.GetNamedString("utilizador", "")},
                    Data = Convert.ToDateTime(ideia.GetNamedString("data", "")),
                    Partilha = ideia.GetNamedBoolean("partilha", false),
                    Estado = est,
                    Pontuacao = (int)ideia.GetNamedNumber("pontuacao", 0)
                });
            }
        }
    }
}

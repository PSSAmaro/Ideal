using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;
using Ideal.Classes.Estado;

namespace Ideal.Classes
{
    public class ComentarioFactory
    {
        public List<Classes.Comentario> Items { get; set; }

        public ComentarioFactory(JsonArray jsonArray)
        {
            Items = new List<Classes.Comentario>();
            foreach (IJsonValue jsonValue in jsonArray)
            {
                JsonObject comentario = jsonValue.GetObject();
                Items.Add(new Classes.Comentario()
                {
                    Id = (int)comentario.GetNamedNumber("id", 0),
                    Conteudo = comentario.GetNamedString("conteudo", ""),
                    Nome = comentario.GetNamedString("utilizador", "")
                });
            }
        }
    }
}

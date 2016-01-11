using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ideal;
using Ideal.Classes;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace IdealTeste
{
    [TestClass]
    public class IdeiaTeste
    {
        // Teste velho

        private bool Data(DateTime data)
        {
            // Para o caso do teste ser feito em cima da viragem do segundo (Procurar melhor maneira de testar a data)
            int segundos = DateTime.Now.Second;
            if (segundos == 0)
                segundos = 60;
            return (segundos - data.Second <= 1);
        }

        [TestMethod]
        public void IdeiaVaziaTeste()
        {
            Ideia ideia = new Ideia();

            Assert.AreEqual("Erro", ideia.Titulo);
            Assert.AreEqual("Erro", ideia.Conteudo);
            Assert.AreEqual(Data(ideia.Data), true);
            Assert.AreEqual(ideia.Partilha, false);
            Assert.AreEqual(ideia.Estado, (int)Ideia.LEstado.Pendente);
        }

        [TestMethod]
        public void IdeiaSimplesTeste()
        {
            Ideia ideia = new Ideia("Ideia", "Conteúdo da ideia", DateTime.Now);

            Assert.AreEqual("Ideia", ideia.Titulo);
            Assert.AreEqual("Conteúdo da ideia", ideia.Conteudo);
            Assert.AreEqual(Data(ideia.Data), true);
            Assert.AreEqual(ideia.Partilha, false);
            Assert.AreEqual(ideia.Estado, (int)Ideia.LEstado.Pendente);
        }

        [TestMethod]
        public void PartilhaIdeiaTeste()
        {
            Ideia ideia = new Ideia("Ideia", "Conteúdo da ideia", DateTime.Now);

            ideia.Partilhar();

            Assert.AreEqual(ideia.Partilha, true);
        }

        [TestMethod]
        public void MudaEstadoIdeiaTeste()
        {
            Ideia ideia = new Ideia("Ideia", "Conteúdo da ideia", DateTime.Now);

            Assert.AreEqual(ideia.Estado, (int)Ideia.LEstado.Pendente);

            ideia.MudaEstado(Ideia.LEstado.EmAnalise);
            Assert.AreEqual(ideia.Estado, (int)Ideia.LEstado.EmAnalise);

            ideia.MudaEstado(Ideia.LEstado.AImplementar);
            Assert.AreEqual(ideia.Estado, (int)Ideia.LEstado.AImplementar);

            ideia.MudaEstado(Ideia.LEstado.Implementado);
            Assert.AreEqual(ideia.Estado, (int)Ideia.LEstado.Implementado);

            ideia.MudaEstado(Ideia.LEstado.Descartado);
            Assert.AreEqual(ideia.Estado, (int)Ideia.LEstado.Descartado);
        }

        [TestMethod]
        public void EditaIdeiaTeste()
        {
            Ideia ideia = new Ideia("Ideia", "Conteúdo da ideia", DateTime.Now);

            ideia.Titulo = "Ideia modificada";
            ideia.Conteudo = "Conteúdo modificado";

            Assert.AreEqual(ideia.Titulo, "Ideia modificada");
            Assert.AreEqual(ideia.Conteudo, "Conteúdo modificado");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeTarefas.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TesteControladorTarefa.Contato
{
    [TestClass]
    public class TesteContato
    {


        [TestMethod]
        public void DeveRetornarEmailInvalido()
        {
            ControleDeTarefas.Model.Contato contato = new
            ControleDeTarefas.Model.Contato("Pedro", "pedrogmail.com", "4999591517", "NDD", "DEV ");

            Assert.AreEqual("Email inválido", contato.Validar());
        }

        [TestMethod]
        public void DeveRetornarTelefoneInvalido()
        {
            ControleDeTarefas.Model.Contato contato = new
            ControleDeTarefas.Model.Contato("Pedro", "pedro@gmail.com", "499", "NDD", "DEV ");

            Assert.AreEqual("Telefone inválido", contato.Validar());
        }
    }
}

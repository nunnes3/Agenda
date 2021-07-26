using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteControladorTarefa.Compromisso
{
    [TestClass]
    public class  TesteCompromisso
    {
        [TestMethod]
        public void DeveRetornarDataInvalida()
        {

            DateTime dataFimDeSemana = new DateTime(2021,06,27);

            ControleDeTarefas.Model.Compromisso compromisso =
            new ControleDeTarefas.Model.Compromisso("TESTANDO O EDITAR ", "NDD", dataFimDeSemana, "18:00", "19:00", 53);

            Assert.AreEqual("Reuniões podem ser marcadas apenas em dias de trabalho", compromisso.Validar());
            
        }


    }
}

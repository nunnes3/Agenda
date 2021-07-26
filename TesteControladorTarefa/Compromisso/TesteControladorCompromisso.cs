using ControleDeTarefas.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteControladorTarefa.Compromisso
{
    [TestClass]
   public  class TesteControladorCompromisso
   {
        private ControladorCompromisso controladorCompromisso;
        public TesteControladorCompromisso()
        {
            controladorCompromisso = new ControladorCompromisso();
        }

        [TestMethod]
        public void InserirCompromisso()
        {
            DateTime dataCompromisso = DateTime.Now;

            ControleDeTarefas.Model.Compromisso compromisso = 
            new ControleDeTarefas.Model.Compromisso("TESTES","NDD", dataCompromisso,"18:00","19:00",53);

            controladorCompromisso.InserirCompromisso(compromisso);
            int id = compromisso.Id;

            Assert.IsTrue(id > 0);
        }

        [TestMethod]
        public void EditarCompromisso()
        {
            DateTime dataCompromisso = DateTime.Now;

            ControleDeTarefas.Model.Compromisso compromisso =
            new ControleDeTarefas.Model.Compromisso("TESTANDO O EDITAR ", "NDD", dataCompromisso, "18:00", "19:00", 53);

            controladorCompromisso.InserirCompromisso(compromisso);

            int id = compromisso.Id;


            ControleDeTarefas.Model.Compromisso compromissoDois =
             new ControleDeTarefas.Model.Compromisso("EDITAR DEU CERTO", "NDD", dataCompromisso, "18:00", "19:00", 53);

            controladorCompromisso.EditarCompromisso(id, compromissoDois);
            compromissoDois.Id = id;

            Assert.IsTrue(compromissoDois.Assunto == "EDITAR DEU CERTO" && compromissoDois.Id == id);


        }

        [TestMethod]
        public void ExluirCompromisso()
        {
            DateTime dataCompromisso = new DateTime(2025,12,03);

            ControleDeTarefas.Model.Compromisso compromisso =
            new ControleDeTarefas.Model.Compromisso("TESTANDO O EXCLUIR ", "NDD", dataCompromisso, "18:00", "19:00", 53);

            controladorCompromisso.InserirCompromisso(compromisso);

            int id = compromisso.Id;

            controladorCompromisso.ExcluirCompromisso(id);

            Assert.IsFalse(controladorCompromisso.ListarCompromissosFuturos().Contains(compromisso));


        }

    }
}

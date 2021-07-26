using ControleDeTarefas.Controller;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDeTarefas.Model;

namespace TesteControladorTarefa.Contato
{
    [TestClass]
    public class TesteControladorContato
    {
        private ControladorContato controladorContato;
        public TesteControladorContato()
        {
            controladorContato = new ControladorContato();
        }

        //[TestMethod]
        //public void InserirContato()
        //{
        //    ControleDeTarefas.Model.Contato contato = new
        //    ControleDeTarefas.Model.Contato("Carlos", "carlos@gmail.com", "4999591517", "NDD", "DEV");


        //    controladorContato.InserirContato(contato);
        //    int id = contato.Id;

        //    Assert.IsTrue(id > 0);

        //}

        //[TestMethod]
        //public void EditarContato()
        //{
        //    ControleDeTarefas.Model.Contato contato = new
        //    ControleDeTarefas.Model.Contato("Pedro", "pedro@gmail.com", "4999591517", "NDD", "DEV ");
        //    int id = contato.Id;

        //    controladorContato.InserirContato(contato);


        //    ControleDeTarefas.Model.Contato contatoDois = new
        //    ControleDeTarefas.Model.Contato("Marcelo", "marcelo@gmail.com", "4999591517", "NDD", "TESTER");

        //    controladorContato.EditarContato(id, contatoDois);

        //    Assert.IsTrue(contatoDois.Nome == "Marcelo" && contatoDois.Id == id);


        //}


        //[TestMethod]
        //public void ExcluirContato()
        //{
        //    ControleDeTarefas.Model.Contato contato = new
        //    ControleDeTarefas.Model.Contato("Lucas", "lucas@gmail.com", "4999591517", "NDD", "DEV");


        //    controladorContato.InserirContato(contato);
        //    int id = contato.Id;

        //    controladorContato.ExcluirContato(id);

        //    Assert.IsFalse(controladorContato.ListarContatos().Contains(contato));

        //}


    }
}

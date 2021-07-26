using ControleDeTarefas.Controller;
using ControleDeTarefas.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TesteControladorTarefa
{
    [TestClass]
    public class TesteControladorTarefa
    {
        private ControladorTarefa controladorTarefa;
        public  TesteControladorTarefa()
        {
            controladorTarefa = new ControladorTarefa();
        }

        //[TestMethod]
        //public void InserirTarefa()
        //{
        //    DateTime dataCriacao = DateTime.Now;
        //    DateTime dataConclusao = new DateTime(2022, 12, 19);
        //    Tarefa tarefa = new Tarefa("Limpar a fonte", dataCriacao, dataConclusao, 0, "Alta");

        //    controladorTarefa.InserirTarefa(tarefa);
        //    int id = tarefa.Id;

        //    Assert.IsTrue(id > 0);
        //}

        //[TestMethod]
        //public void EditarTarefa()
        //{
        //    DateTime dataCriacao = DateTime.Now;
        //    DateTime dataConclusao = new DateTime(2022, 12, 19);
        //    Tarefa tarefa = new Tarefa("Instalar televisão na recepcção", dataCriacao, dataConclusao, 0, "Alta");
        //    int id = tarefa.Id;

        //    controladorTarefa.InserirTarefa(tarefa);

        //    Tarefa tarefaDois = new Tarefa("Instalar televisão na copa", dataConclusao, 20, "Baixa");
        //    controladorTarefa.EditarTarefa(id, tarefaDois);

        //    Assert.IsTrue(tarefaDois.Titulo == "Instalar televisão na copa" && tarefaDois.Id == id);
        //}

        //[TestMethod]
        //public void ExcluirTarefa()
        //{
        //    DateTime dataCriacao = DateTime.Now;
        //    DateTime dataConclusao = new DateTime(2022, 12, 19);
        //    Tarefa tarefa = new Tarefa("Arrumar computadores no laborátorio 8", dataCriacao, dataConclusao, 0, "Alta");

        //    controladorTarefa.InserirTarefa(tarefa);
        //    int id = tarefa.Id;
        //    controladorTarefa.ExcluirTarefa(id);

        //    Assert.IsFalse(controladorTarefa.ListarTodasAsTarefas().Contains(tarefa));
        //}



        //[TestMethod]
        //public void RetornaTarefaPendente()
        //{
        //    DateTime dataCriacao = DateTime.Now;
        //    DateTime dataConclusao = new DateTime(2022, 12, 19);
        //    Tarefa tarefa = new Tarefa("Erro no sistema da escola", dataCriacao, dataConclusao, 50, "Alta");

        //    controladorTarefa.InserirTarefa(tarefa);

        //    Assert.IsTrue(controladorTarefa.ListarTarefasPendentes().Contains(tarefa));
        //}
    }
}

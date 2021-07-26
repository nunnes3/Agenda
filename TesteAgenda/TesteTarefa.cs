using ControleDeTarefas.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using ControleDeTarefas.Controller;

namespace TesteAgenda
{
    [TestClass]
    public class TesteTarefa
    {
        private ControladorTarefa controlador;
        public TesteTarefa(ControladorTarefa ctrl)
        {

            controlador = ctrl;
        }


        [TestMethod]
        public void InserirTarefa()
        {
            DateTime dataCriacao = DateTime.Now;
            DateTime dataConclusao = new DateTime(2022,12,02) ;
            Tarefa tarefa = new Tarefa("Trocar a fonte", dataCriacao, dataConclusao,80,"Alta");

            
        }
    }
}

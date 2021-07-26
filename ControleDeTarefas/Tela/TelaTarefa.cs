using ControleDeTarefas.Controller;
using ControleDeTarefas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Tela
{
    public class TelaTarefa : TelaBase
    {
        private ControladorTarefa controladorTarefa;

        public TelaTarefa(ControladorTarefa ctrlTarefa)
        {
            controladorTarefa = ctrlTarefa;
        }
        
        public void InserirTarefa()
        {
            LimparTela();
            controladorTarefa.InserirTarefa(ObterInformacoes());
            LimparTela();
        }

        public void Listar()
        {
            Console.Clear();
            Console.WriteLine("1 - Para registros pendentes");
            Console.WriteLine("2 - Para registros finalizados");
            Console.WriteLine("3 - Para todos os registros");

            Console.Write("Informe qual tela deseja acessar: ");
            string opcao = Console.ReadLine();

            if (opcao == "1")
            {
                ListarPendentes();
                LimparTela();

            }
            else if (opcao == "2")
            {
                ListarFinalizadas();
                LimparTela();
            }
            else if (opcao == "3")
            {
                ListarTodos();
                LimparTela();
            }
            else
            {
                Console.WriteLine("Opção inválida, tente novamente");
                Console.ReadLine();
                Console.Clear();
                Listar();
            }
        }

        public void EditarTarefa()
        {
            LimparTela();

            ListarPendentes();

            Console.Write("Informe o Id da tarefa que deseja editar: ");
            int idParaEdicao = Convert.ToInt32(Console.ReadLine());

            controladorTarefa.EditarTarefa(idParaEdicao, ObterInformacoesEdicao());
            LimparTela();

        }

        public void ExcluirTarefa()
        {
            LimparTela();

            ListarPendentes();

            Console.Write("Informe o Id da tarefa que deseja exluir: ");
            int idParaExclusao = Convert.ToInt32(Console.ReadLine());

            controladorTarefa.ExcluirTarefa(idParaExclusao);
            Console.WriteLine(FormataMensagemDeSucesso("Excluido com sucesso"));
            Console.ReadLine();

            LimparTela();


        }


        private Tarefa ObterInformacoes()
        {
            Console.Write("Informe o título da tarefa: ");
            string titulo = Console.ReadLine();

            DateTime dataCriacao = DateTime.Now;

            Console.Write("Informe a data de conclusao da tarefa: ");
            DateTime dataConclusao = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Informe o precentual da tarefa: ");
            int percentual = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Alta");
            Console.WriteLine("Normal");
            Console.WriteLine("Baixa");

            Console.Write("Informe a prioridade: ");
            string prioridade = Console.ReadLine();

            Tarefa tarefa = new Tarefa(titulo, dataCriacao, dataConclusao, percentual, prioridade);
            string resultadoValidacao = tarefa.Validar();

            if (resultadoValidacao == "ESTA_VALIDO"){
                Console.WriteLine(FormataMensagemDeSucesso("Registrado com Sucesso"));
                Console.ReadLine();
                return tarefa;
            }
            else
            {
                Console.WriteLine(resultadoValidacao);
                Console.ReadLine();
                LimparTela();
                ObterInformacoes();
            }
            return tarefa;
        }

        private Tarefa ObterInformacoesEdicao()
        {
            Tarefa tarefa = null;

            Console.Write("Informe o título da tarefa: ");
            string titulo = Console.ReadLine();

            Console.Write("Informe a data de conclusao da tarefa: ");
            DateTime dataConclusao = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Informe o precentual da tarefa: ");
            int percentual = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine();
            Console.WriteLine("Alta");
            Console.WriteLine("Normal");
            Console.WriteLine("Baixa");

            Console.Write("Informe a prioridade: ");
            string prioridade = Console.ReadLine();

            tarefa = new Tarefa(titulo, dataConclusao, percentual, prioridade);
            string resultadoValidacao = tarefa.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                Console.WriteLine(FormataMensagemDeSucesso("Registrado com sucesso"));
                Console.ReadLine();
                return tarefa;
            }
            else
            {
                Console.WriteLine(resultadoValidacao);
                Console.ReadLine();
                tarefa = ObterInformacoes();
            }
            return tarefa;
        }
        private void ListarPendentes()
        {
            string configuracaoColunasTabela = "{0,-5}|{1,-30}|{2,-25}|{3,-25}|{4,-10}";
            MontarCabecalho(configuracaoColunasTabela, "ID", "TITULO", "DATA CONCLUSAO","PERCENTUAL", "PRIORIDADE");

            List<Tarefa> tarefas = controladorTarefa.ListarTarefasPendentes();
            foreach (Tarefa tarefa in tarefas)
            {
                string recebeDataSemHoras = FormataData(tarefa.DataConclusao);
                Console.WriteLine(configuracaoColunasTabela, tarefa.Id, tarefa.Titulo, recebeDataSemHoras, tarefa.Percentual, tarefa.Prioridade);
            }

            Console.ReadLine();
        }

        private void ListarFinalizadas() {

            string configuracaoColunasTabela = "{0,-5}|{1,-30}|{2,-25}|{3,-25}|{4,-10}";
            MontarCabecalho(configuracaoColunasTabela, "ID", "TITULO", "DATA CONCLUSAO", "PERCENTUAL", "PRIORIDADE");

            List<Tarefa> tarefas = controladorTarefa.ListarTarefasFinalizadas();
            foreach (Tarefa tarefa in tarefas)
            {
                string recebeDataSemHoras = FormataData(tarefa.DataConclusao);
                Console.WriteLine(configuracaoColunasTabela, tarefa.Id, tarefa.Titulo, recebeDataSemHoras, tarefa.Percentual, tarefa.Prioridade);
            }

            Console.ReadLine();
        }

        private void ListarTodos()
        {
            string configuracaoColunasTabela = "{0,-5}|{1,-30}|{2,-25}|{3,-25}|{4,-10}";
            MontarCabecalho(configuracaoColunasTabela, "ID", "TITULO", "DATA CONCLUSAO", "PERCENTUAL", "PRIORIDADE");

            
            List<Tarefa> tarefas = controladorTarefa.ListarTodasAsTarefas();
            foreach (Tarefa tarefa in tarefas)
            {
                string recebeDataSemHoras = FormataData(tarefa.DataConclusao);
                Console.WriteLine(configuracaoColunasTabela, tarefa.Id, tarefa.Titulo, recebeDataSemHoras, tarefa.Percentual, tarefa.Prioridade);
            }

            Console.ReadLine();
        }
    }
}

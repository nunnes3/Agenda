using ControleDeTarefas.Controller;
using ControleDeTarefas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Tela
{
    public class TelaContato : TelaBase
    {
        ControladorContato controladorContato; 

        public TelaContato(ControladorContato ctrlContato)
        {
            controladorContato = ctrlContato;
        }

        public void InserirContato()
        {
            LimparTela();
            controladorContato.InserirContato(ObterInformacoes());
            LimparTela();

        }

        private Contato ObterInformacoes()
        {
            Contato contato = null;

            Console.Write("Informe o nome: ");
            string nome = Console.ReadLine();

            Console.Write("Infomre o email: ");
            string email = Console.ReadLine();

            Console.Write("Informe o telefone com DDD: ");
            string telefone = Console.ReadLine();

            Console.Write("Informe a empresa: ");
            string empresa = Console.ReadLine();
          
            Console.Write("Informe o cargo: ");
            string cargo = Console.ReadLine();


            contato = new Contato(nome, email, telefone,empresa,cargo);

            string resultadoValidacao = contato.Validar();

            if (resultadoValidacao == "ESTA_VALIDO")
            {
                Console.WriteLine(FormataMensagemDeSucesso("Registrado com sucesso"));
                Console.ReadLine();
                return contato;
            }
            else
            {
                Console.WriteLine(resultadoValidacao);
                Console.ReadLine();
                LimparTela();
                contato = ObterInformacoes();
            }

            return contato;
        }

        public void ListarContatos()
        {
            
            string configuracaoColunasTabela = "{0,-5}|{1,-30}|{2,-25}|{3,-25}|{4,-10}|{5,-10}";
            MontarCabecalho(configuracaoColunasTabela, "ID", "NOME", "EMAIL", "TELEFONE", "EMPRESA","CARGO");

            List<Contato> contatos = controladorContato.ListarContatos();
            foreach (Contato contato in contatos)
            {
              
                
                Console.WriteLine(configuracaoColunasTabela, contato.Id, contato.Nome, 
                                  contato.Email, contato.Telefone, contato.Empresa,
                                  contato.Cargo);
            }

            Console.ReadLine();
           
        }


        public void EditarContato()
        {
            LimparTela();

            ListarContatos();

            Console.Write("Informe o id do contato que deseja editar: ");
            int idParaEdicao = Convert.ToInt32(Console.ReadLine());

            controladorContato.EditarContato(idParaEdicao, ObterInformacoes());

            LimparTela();

        }

        public void ExcluirContato()
        {
            LimparTela();

            ListarContatos();

            Console.Write("Informe o Id do contato que deseja exluir: ");
            int idParaExclusao = Convert.ToInt32(Console.ReadLine());

            controladorContato.ExcluirContato(idParaExclusao);
            Console.WriteLine(FormataMensagemDeSucesso("Excluido com sucesso"));
            Console.ReadLine();

            LimparTela();

        }

    }
}

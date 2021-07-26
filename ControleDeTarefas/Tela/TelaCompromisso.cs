﻿using ControleDeTarefas.Controller;
using ControleDeTarefas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Tela
{
    public class TelaCompromisso : TelaBase
    {
        private TelaContato telaContato;
        private ControladorCompromisso controladorCompromisso;
        public TelaCompromisso(ControladorCompromisso ctrlCompromisso, TelaContato tlContato)
        {
            controladorCompromisso = ctrlCompromisso;
            telaContato = tlContato;
        }

        public void InserirCompromisso()
        {
            LimparTela();
            controladorCompromisso.InserirCompromisso(ObterInformacoes());
            LimparTela();
        }

        public void ListarCompromissos()
        {
            LimparTela();
            string opcao = String.Empty;

            Console.WriteLine("1- Para Compromissos Finalizados");
            Console.WriteLine("2- Para Compromissos Futuros");
            Console.WriteLine("3- Para Compromissos Semanais");
            Console.WriteLine("4- Para Compromissos Diários");
            Console.WriteLine();
            Console.Write("Opção: ");

            opcao = Console.ReadLine();
            
            if (opcao == "1")
            {
                ListarCompromissosFinalizados();
            }
            else if (opcao == "2"){

                ListarCompromissosFuturos();

            }else if(opcao == "3")
            {
                ListarCompromissosSemanais();

            } else if(opcao == "4")
            {
                ListarCompromissosDiarios();
            }
            else
            {
                FormataMensagemDeErro("Opção inváldia, tente novamente");
                Console.ReadLine();
                ListarCompromissos();
            }
        }

        public void EditarCompromisso()
        {
            LimparTela();

            if(ListarCompromissosFuturos() == true)
            {
                Console.Write("Informe o id do compromisso que deseja editar: ");
                int id = Convert.ToInt32(Console.ReadLine());

                controladorCompromisso.EditarCompromisso(id, ObterInformacoes());

                Console.WriteLine(FormataMensagemDeSucesso("Editado com sucesso"));
                Console.ReadLine();
                LimparTela();
            }

            LimparTela();
        }

        public void ExcluirCompromisso()
        {
            LimparTela();

            if (ListarCompromissosFuturos() == true) {

                Console.Write("Informe o id do compromisso que deseja excluir: ");
                int id = Convert.ToInt32(Console.ReadLine());
                controladorCompromisso.ExcluirCompromisso(id);

                Console.WriteLine(FormataMensagemDeSucesso("Excluido com sucesso"));
                Console.ReadLine();
                LimparTela();
            };

            
            LimparTela();
        }

        private void ListarCompromissosFinalizados()
        {
            List<Compromisso> compromissos = controladorCompromisso.ListarCompromissosFinalizados();

            if (compromissos.Count == 0)
            {
                Console.WriteLine(FormataMensagemDeAtencao("Nenhum compromisso finalizado"));
                Console.ReadLine();

            }
            else
            {
                ConfigurandoTela(compromissos);
            }

            Console.ReadLine();
        }

        private bool ListarCompromissosFuturos()
        {

            List<Compromisso> compromissos = controladorCompromisso.ListarCompromissosFuturos();

            if (compromissos.Count == 0)
            {
                Console.WriteLine(FormataMensagemDeAtencao("Nenhum compromisso futuro"));
                Console.ReadLine();
                return false;
            }
            else
            {
                ConfigurandoTela(compromissos);
                Console.ReadLine();
                return true;
                
            }
            
            return true;
            
        }

     
        private void ListarCompromissosDiarios()
        {

            List<Compromisso> compromissos = controladorCompromisso.ListarCompromissosDiarios();

            if(compromissos.Count == 0)
            {
                Console.WriteLine(FormataMensagemDeAtencao("Nenhum compromisso para hoje"));
                Console.ReadLine();
            }
            else
            {
                ConfigurandoTela(compromissos);
            }
            Console.ReadLine();
        }


        private void ListarCompromissosSemanais()
        {
            List<Compromisso> compromissos = controladorCompromisso.ListarCompromissosSemanais();

            if (compromissos.Count == 0)
            {
                Console.WriteLine(FormataMensagemDeAtencao("Nenhum compromisso pra essa semana"));
                Console.ReadLine();
            }
            else
            {
                ConfigurandoTela(compromissos);
            }
            Console.ReadLine();
        }

        private void ConfigurandoTela(List<Compromisso> compromissos)
        {
            string configuracaoColunasTabela = "{0,-5}|{1,-15}|{2,-20}|{3,-20}|{4,-15}|{5,-15}|{6,-20}";
            MontarCabecalho(configuracaoColunasTabela, "ID", "ASSUNTO", "LOCAL", "DATA", "HORA INÍCIO", "HORA TERMINO", "CONTATO");
            foreach (Compromisso compromisso in compromissos)
            {

                string recebeDataSemHoras = FormataData(compromisso.Data);
                Console.WriteLine(configuracaoColunasTabela, compromisso.Id, compromisso.Assunto,
                                  compromisso.Local, recebeDataSemHoras, compromisso.HoraInicio, compromisso.HoraTermino,
                                  compromisso.NomeContato);
            }

            
        }
      
        private Compromisso ObterInformacoes()
        {
            Compromisso compromisso = null;
            string resultadoValidacao = String.Empty;

            Console.Write("Compromisso sera remoto(Sim/Não) :");
            string ehRemoto = Console.ReadLine();

            if(ehRemoto == "Sim")
            {

                Console.Write("Informe o assunto da reunião: ");
                string assunto = Console.ReadLine();

                Console.Write("Informe o link da reunião: ");
                string linkReuniao = Console.ReadLine();

                Console.Write("Infomre a data do compromisso: ");
                DateTime dataCompromisso = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Informe o a hora de início: ");
                DateTime horaInicio = Convert.ToDateTime(Console.ReadLine());
                string recebeFormatacaoHoraInicio = FormataHora(horaInicio);


                Console.Write("Informe o a hora de termino: ");
                DateTime horaTermino = Convert.ToDateTime(Console.ReadLine());
                string recebeFormatacaoHoraTermino = FormataHora(horaTermino);

                telaContato.ListarContatos();

                Console.Write("Informe o id do contato: ");
                
                int idContato = Convert.ToInt32(Console.ReadLine());

                 compromisso = new Compromisso(assunto,linkReuniao, dataCompromisso, recebeFormatacaoHoraInicio, recebeFormatacaoHoraTermino, idContato);

                resultadoValidacao = compromisso.Validar();

                if(resultadoValidacao == "ESTA_VALIDO")
                {
                    Console.WriteLine(FormataMensagemDeSucesso("Registrado com sucesso"));
                    Console.ReadLine();
                    return compromisso;
                }
                else
                {
                    Console.WriteLine(resultadoValidacao);
                    Console.ReadLine();
                    LimparTela();
                    compromisso = ObterInformacoes();
                }


            }else if(ehRemoto == "Não")
            {
                Console.Write("Informe o assunto da reunião: ");
                string assunto = Console.ReadLine();

                Console.Write("Informe o local: ");
                string local = Console.ReadLine();

                Console.Write("Infomre a data do compromisso: ");
                DateTime dataCompromisso = Convert.ToDateTime(Console.ReadLine());

                Console.Write("Informe o a hora de início: ");
                DateTime horaInicio = Convert.ToDateTime(Console.ReadLine());
                string recebeFormatacaoHoraInicio = FormataHora(horaInicio);


                Console.Write("Informe o a hora de termino: ");
                DateTime horaTermino = Convert.ToDateTime(Console.ReadLine());
                string recebeFormatacaoHoraTermino = FormataHora(horaTermino);


                telaContato.ListarContatos();

                Console.Write("Informe o id do contato: ");
                int idContato = Convert.ToInt32(Console.ReadLine());

                 compromisso = new Compromisso(assunto,local, dataCompromisso, recebeFormatacaoHoraInicio, recebeFormatacaoHoraTermino, idContato);

                resultadoValidacao = compromisso.Validar();

                if (resultadoValidacao == "ESTA_VALIDO")
                {
                    Console.WriteLine(FormataMensagemDeSucesso("Registrado com sucesso"));
                    Console.ReadLine();
                    return compromisso;
                }
                else
                {
                    Console.WriteLine(resultadoValidacao);
                    Console.ReadLine();
                    LimparTela();
                    compromisso = ObterInformacoes();
                }
            }
            else
            {
                Console.WriteLine(FormataMensagemDeErro("Opção inválida, tente novamente"));
                Console.ReadLine();
                LimparTela();
                compromisso = ObterInformacoes();
               
            }

            return compromisso;
        }
            
     }
}


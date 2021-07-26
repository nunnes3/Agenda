using ControleDeTarefas.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Tela
{
    public class TelaBase
    {

        protected void MontarCabecalho(string configuracaoTituloColunas, params object[] colunas)
        {
            Console.WriteLine();
            Console.WriteLine(configuracaoTituloColunas,colunas);
            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");
        }

        protected void LimparTela()
        {
            Console.ResetColor();
            Console.Clear();
           
        }

        protected string FormataMensagemDeSucesso (string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            return mensagem;
        }

        protected string FormataMensagemDeErro(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            return mensagem;
        }

        protected string FormataMensagemDeAtencao(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            return mensagem;
        }

        protected string FormataData(DateTime data)
        {
            string recebeData = data.ToString("dd/MM/yyyy");

            return recebeData;
        }

        protected string FormataHora(DateTime horas)
        {
            string recebeData = horas.ToString("HH:mm");

            return recebeData;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Model
{
    public class Tarefa
    {
        private int id;
        private string titulo;
        private DateTime dataCriacao;
        private DateTime dataConclusao;
        private int percentual;
        private string prioridade;

        public int Id { get => id; set => id = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public DateTime DataCriacao { get => dataCriacao; set => dataCriacao = value; }
        public DateTime DataConclusao { get => dataConclusao; set => dataConclusao = value; }
        public int Percentual { get => percentual; set => percentual = value; }
        public string Prioridade { get => prioridade; set => prioridade = value; }


        public Tarefa(string Titulo,DateTime DataCriacao,DateTime DataConclusao,int Percentual, string Prioridade)
        {
            titulo = Titulo;
            dataCriacao = DataCriacao;
            dataConclusao = DataConclusao;
            percentual = Percentual;
            prioridade = Prioridade;

        }

        public Tarefa(int id,string titulo,DateTime dataConclusao, int percentual, string prioridade)
        {
            Id = id;
            Titulo = titulo;
            DataConclusao = dataConclusao;
            Percentual = percentual;
            Prioridade = prioridade;
        }

        public Tarefa(string titulo, DateTime dataConclusao, int percentual, string prioridade)
        {
            this.titulo = titulo;
            this.dataConclusao = dataConclusao;
            this.percentual = percentual;
            this.prioridade = prioridade;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if(percentual < 0 || percentual > 100) {

                resultadoValidacao += "Percentual não pode ser menor que 0 nem maior que 100 \n";
            }

            if (prioridade != "Alta" && prioridade !="Normal" && prioridade !="Baixa")
            {

                resultadoValidacao += "Prioridade inavalida \n";
            }

            if(dataCriacao > dataConclusao)
            {
                resultadoValidacao += "Data de criação não pode ser maior que data conclusão \n";
            }

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "ESTA_VALIDO";

            return resultadoValidacao;
        }
    }
}

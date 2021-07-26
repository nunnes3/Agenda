using ControleDeTarefas.Conexao;
using ControleDeTarefas.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Controller
{
    public class ControladorTarefa 
    {
        private Conexao conexao;
        private readonly SqlTarefa sqlTarefa;
        public ControladorTarefa()
        {
            conexao = new Conexao();
            sqlTarefa = new SqlTarefa();
        }

        public void InserirTarefa(Tarefa tarefa)
        {
           
                SqlCommand comandoInsercao = new SqlCommand();
                comandoInsercao.Connection = conexao.CriarConexao();
                string recebeComandoInsercao = sqlTarefa.SqlInsercaoTarefa();

                comandoInsercao.CommandText = recebeComandoInsercao;
                comandoInsercao.Parameters.AddWithValue("Titulo", tarefa.Titulo);
                comandoInsercao.Parameters.AddWithValue("DataCriacao", tarefa.DataCriacao);
                comandoInsercao.Parameters.AddWithValue("DataConclusao", tarefa.DataConclusao);
                comandoInsercao.Parameters.AddWithValue("Percentual", tarefa.Percentual);
                comandoInsercao.Parameters.AddWithValue("Prioridade", tarefa.Prioridade);

                object id = comandoInsercao.ExecuteScalar();
                tarefa.Id = Convert.ToInt32(id);

            conexao.FecharConexao();

        }

        public List<Tarefa> ListarTarefasPendentes()
        {

            SqlCommand comandoBusca = new SqlCommand();
            comandoBusca.Connection = conexao.CriarConexao();
            string recebeConsultaTarefasPendentes = sqlTarefa.SqlTarefasPendentes();

            comandoBusca.CommandText = recebeConsultaTarefasPendentes;
            SqlDataReader leitorConsultas = comandoBusca.ExecuteReader();

            List<Tarefa> tarefas = new List<Tarefa>();
            PopulandoListaTarefas(leitorConsultas, tarefas);

            conexao.FecharConexao();
            return tarefas;
        }

        public List<Tarefa> ListarTarefasFinalizadas()
        {
            
            SqlCommand comandoBusca = new SqlCommand();
            comandoBusca.Connection = conexao.CriarConexao();
            string recebeConsultaTarefasFinalizadass = sqlTarefa.SqlTarefasFinalizadas();

            comandoBusca.CommandText = recebeConsultaTarefasFinalizadass;
            SqlDataReader leitorConsultas = comandoBusca.ExecuteReader();

            List<Tarefa> tarefas = new List<Tarefa>();
            PopulandoListaTarefas(leitorConsultas, tarefas);

            conexao.FecharConexao();
            return tarefas;
        }

        public List<Tarefa> ListarTodasAsTarefas()
        {
            
            SqlCommand comandoBusca = new SqlCommand();
            comandoBusca.Connection = conexao.CriarConexao();
            string recebeConsultaTodasAsTarefas = sqlTarefa.SqlTodasAsTarefas();

            comandoBusca.CommandText = recebeConsultaTodasAsTarefas;
            SqlDataReader leitorConsultas = comandoBusca.ExecuteReader();

            List<Tarefa> tarefas = new List<Tarefa>();
            PopulandoListaTarefas(leitorConsultas, tarefas);

            conexao.FecharConexao();
            return tarefas;
        }

        private static void PopulandoListaTarefas(SqlDataReader leitorConsultas, List<Tarefa> tarefas)
        {
            while (leitorConsultas.Read())
            {
                int id = Convert.ToInt32(leitorConsultas["Id"]);
                string titulo = Convert.ToString(leitorConsultas["Titulo"]);
                DateTime dataConclusao = Convert.ToDateTime(leitorConsultas["DataConclusao"]);
                int percentual = Convert.ToInt32(leitorConsultas["Percentual"]);
                string prioridade = Convert.ToString(leitorConsultas["Prioridade"]);

                Tarefa tarefa = new Tarefa(id, titulo, dataConclusao, percentual, prioridade);
                tarefas.Add(tarefa);

            }
        }

        public void EditarTarefa(int id,Tarefa tarefa)
        {
            
            SqlCommand comandoEdicao = new SqlCommand();
            comandoEdicao.Connection = conexao.CriarConexao();
            string recebeComandoEdicao = sqlTarefa.SqlEdicaoTarefa();

            comandoEdicao.CommandText = recebeComandoEdicao;
            comandoEdicao.Parameters.AddWithValue("Id", id);
            comandoEdicao.Parameters.AddWithValue("Titulo", tarefa.Titulo);
            comandoEdicao.Parameters.AddWithValue("DataConclusao", tarefa.DataConclusao);
            comandoEdicao.Parameters.AddWithValue("Percentual", tarefa.Percentual);
            comandoEdicao.Parameters.AddWithValue("Prioridade", tarefa.Prioridade);

            comandoEdicao.ExecuteNonQuery();
            conexao.FecharConexao();
        }

        public void ExcluirTarefa(int id)
        {
            
            SqlCommand comandoExclusao = new SqlCommand();
            comandoExclusao.Connection = conexao.CriarConexao();
            string recebeComandoExclusao = sqlTarefa.SqlExclusaoTarefa();

            comandoExclusao.CommandText = recebeComandoExclusao;
            comandoExclusao.Parameters.AddWithValue("Id", id);

            comandoExclusao.ExecuteNonQuery();
            conexao.FecharConexao();
        }
    }
}

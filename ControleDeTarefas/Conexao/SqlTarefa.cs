using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Conexao
{
    public class SqlTarefa
    {
        public string SqlInsercaoTarefa()
        {

            string sqlInsercao =
           @"INSERT INTO TB_TAREFA ([TITULO],[DATACRIACAO],[DATACONCLUSAO],[PERCENTUAL],[PRIORIDADE])
           VALUES (@TITULO,@DATACRIACAO,@DATACONCLUSAO,@PERCENTUAL,@PRIORIDADE)";

            sqlInsercao += @"SELECT SCOPE_IDENTITY()";

            return sqlInsercao;
        }

        public string SqlTarefasPendentes()
        {
            string sqlTarefasPendentes = @"SELECT [ID],[TITULO],[DATACONCLUSAO],[PERCENTUAL],[PRIORIDADE] 
                                          FROM 
                                          TB_TAREFA 
                                          WHERE PERCENTUAL < 100 ORDER BY PRIORIDADE";
            return sqlTarefasPendentes;
        }

        public string SqlTarefasFinalizadas()
        {
            string sqlTarefasFinalizadas = @"SELECT [ID],[TITULO],[DATACONCLUSAO],[PERCENTUAL],
                                        CASE [PRIORIDADE] 
                                        WHEN 'ALTA' THEN 'FINALIZADA'
                                        WHEN 'NORMAL' THEN 'FINALIZADA'
                                        WHEN 'BAIXA' THEN 'FINALIZADA'
                                        END AS [PRIORIDADE]                                      
                                        FROM 
                                        TB_TAREFA 
                                        WHERE PERCENTUAL = 100 ORDER BY PRIORIDADE";
            return sqlTarefasFinalizadas;
        }

        public string SqlTodasAsTarefas()
        {
            string sqlTodasAsTarefas = @"SELECT [ID],[TITULO],[DATACONCLUSAO],[PERCENTUAL],[PRIORIDADE] 
                                          FROM 
                                          TB_TAREFA ORDER BY ID ASC";
            return sqlTodasAsTarefas;
        }

        public string SqlEdicaoTarefa()
        {
            string sqlEdicao = @"UPDATE TB_TAREFA SET
                                            [TITULO] = @TITULO,
                                            [DATACONCLUSAO] = @DATACONCLUSAO,
                                            [PERCENTUAL] = @PERCENTUAL,
                                            [PRIORIDADE] = @PRIORIDADE 
                                            WHERE [ID] = @ID";

            return sqlEdicao;
        }

        public string SqlExclusaoTarefa()
        {
            string sqlEdicao = @"DELETE FROM TB_TAREFA 
                                            WHERE [ID] = @ID";
            return sqlEdicao;
        }
    }
}


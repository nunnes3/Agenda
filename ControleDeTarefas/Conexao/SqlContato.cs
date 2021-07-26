using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Conexao
{
    public class SqlContato
    {

        public string SqlInsercaoContato()
        {

          string sqlInsercao =
          @"INSERT INTO TB_CONTATO([NOME],[EMAIL],[TELEFONE],[EMPRESA],[CARGO])
           VALUES (@NOME,@EMAIL,@TELEFONE,@EMPRESA,@CARGO)";

            sqlInsercao += @"SELECT SCOPE_IDENTITY()";

            return sqlInsercao;
        }

        public string SqlListarContato()
        {

            string sqlBusca =
            @"SELECT [ID],[NOME],[EMAIL],[TELEFONE],[EMPRESA],[CARGO] FROM TB_CONTATO 
            ORDER BY [CARGO] ;";

            return sqlBusca;
        }

        public string SqlExclusaoContato()
        {

            string sqlExcluir =
            @"DELETE FROM TB_CONTATO WHERE [ID] = @ID;";

            return sqlExcluir;
        }

        public string SqlEdicaoContato()
        {
            string sqlEdicao = @"UPDATE TB_CONTATO SET
                                            [NOME] = @NOME,
                                            [EMAIL] = @EMAIL,
                                            [TELEFONE] = @TELEFONE,
                                            [EMPRESA] = @EMPRESA, 
                                            [CARGO] = @CARGO
                                            WHERE [ID] = @ID";

            return sqlEdicao;
        }
    }
}

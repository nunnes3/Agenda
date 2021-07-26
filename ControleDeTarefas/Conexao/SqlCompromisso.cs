using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDeTarefas.Conexao
{
    public class SqlCompromisso
    {
        public string SqlInsercaoCompromisso()
        {
            string sqlInsercao = @"INSERT INTO TB_COMPROMISSO(
			[ASSUNTO],
			[LOCAL],
			[DATA],
			[HORAINICIO],
			[HORATERMINO],
			[IDCONTATO])
			
			VALUES (
			@ASSUNTO,
			@LOCAL,
			@DATA,
			@HORAINICIO,
			@HORATERMINO,
			@IDCONTATO)";

			sqlInsercao += @"SELECT SCOPE_IDENTITY()";

			return sqlInsercao;
        }

		public string SqlEdicaoCompromisso()
        {
			string sqlEdicao = @"UPDATE
						SET TB_COMPROMISSO(
						[ASSUNTO] = ASSUNTO,
						[LOCAL] = LOCAL,
						[DATA] = DATA,
						[HORAINICIO] = HORAINICIO,
						[HORATERMINO] = HORATERMINO,
						[IDCONTATO] = IDCONTATO,
						WHERE [IDCONTATO] = @IDCONTATO";

			return sqlEdicao;
		}

		public string SqlExlusaoCompromisso()
		{
			string sqlExcluso =
						@"DELETE FROM TB_COMPROMISSO WHERE [ID] = @ID";



			return sqlExcluso;
		}

		public string SqlListarCompromissosFinalizados()
		{
			string sqlBusca = @"SELECT 
			[TB_COMPROMISSO].ID,
			[ASSUNTO],
			[LOCAL],
			[DATA],
			[HORAINICIO],
			[HORATERMINO],
			[TB_CONTATO].NOME 
			
			FROM 
			
			TB_COMPROMISSO INNER JOIN 
			TB_CONTATO ON 
			TB_COMPROMISSO.IDCONTATO = TB_CONTATO.ID
			WHERE [DATA]< GETDATE();";

			return sqlBusca;
		}

		public string SqlListarCompromissosFuturos()
		{
			string sqlBusca = @"SELECT 
			[TB_COMPROMISSO].ID,
			[ASSUNTO],
			[LOCAL],
			[DATA],
			[HORAINICIO],
			[HORATERMINO],
			[TB_CONTATO].NOME 
			
			FROM 
			
			TB_COMPROMISSO INNER JOIN 
			TB_CONTATO ON 
			TB_COMPROMISSO.IDCONTATO = TB_CONTATO.ID
			WHERE [DATA] > GETDATE();";

			return sqlBusca;
		}

		public string SqlListarCompromissosDiarios()
		{
			string sqlBusca = @"SELECT 
			[TB_COMPROMISSO].ID,
			[ASSUNTO],
			[LOCAL],
			[DATA],
			[HORAINICIO],
			[HORATERMINO],
			[TB_CONTATO].NOME 
			
			FROM 
			
			TB_COMPROMISSO INNER JOIN 
			TB_CONTATO ON 
			TB_COMPROMISSO.IDCONTATO = TB_CONTATO.ID
			WHERE [DATA] = CONVERT(date,GETDATE())";

			return sqlBusca;
		}

		public string SqlListarCompromissosSemanais()
		{
			string sqlBusca = @"SELECT 
			[TB_COMPROMISSO].ID,
			[ASSUNTO],
			[LOCAL],
			[DATA],
			[HORAINICIO],
			[HORATERMINO],
			[TB_CONTATO].NOME 
			
			FROM 
			
			TB_COMPROMISSO INNER JOIN 
			TB_CONTATO ON 
			TB_COMPROMISSO.IDCONTATO = TB_CONTATO.ID
			
			WHERE DATEDIFF(DAY,GETDATE (),[DATA]) <= 7 AND DATEDIFF(DAY,GETDATE (),[DATA]) >= 1;";

			return sqlBusca;
		}

	}
}

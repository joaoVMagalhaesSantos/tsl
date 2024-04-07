using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace tol.Class
{
    internal class Conexao
    {
        public string? Base { get; set; }
        public string? Descricao { get; set; }
        public string? Driver { get; set; }
        public string? Flag { get; set; }
        public string? Password { get; set; }
        public string? Porta { get; set; }
        public string? Server { get; set; }
        public string? Usuario { get; set; }

        public class MySqlParametro
        {
            public string nome { get; set; }
            public object valor { get; set; }

            public MySqlParametro(string parametro, object valor)
            {
                this.nome = parametro;
                this.valor = valor;
            }
        }

        public static MySqlConnectionStringBuilder StrConexao()
        {
            try
            {
                string filepath = "C:\\tolsistemas\\sistema\\Conectar.ini";
                string[] lines = File.ReadAllLines(filepath);

                if (lines.Length < 9)
                {
                    throw new Exception("O arquivo de conexão está incompleto");
                }

                var builder = new MySqlConnectionStringBuilder
                {
                    Server = lines[7].Substring(7),
                    UserID = lines[8].Substring(8),
                    Password = lines[5].Substring(9),
                    Database = lines[1].Substring(5),
                    Port = Convert.ToUInt32(lines[6].Substring(6)),
                    AllowZeroDateTime = true,

                };

                return builder;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao ler o Arquivo de conexao " + ex.Message);
            }
        }

        public static void NOM_QUERY(string query, List<MySQLParametro> parametros)
        {
            using var myConnection = new MySqlConnection(StrConexao().ConnectionString);
            myConnection.Open();

            MySqlCommand comando = new MySqlCommand(query, myConnection);

            foreach (MySQLParametro parametro in parametros)
            {
                comando.Parameters.Add(new MySqlParameter(parametro.nome, parametro.valor));
            }

            comando.ExecuteNonQuery();

            comando.Dispose();
            myConnection.Close();
            myConnection.Dispose();
        }

        public static void NOM_QUERY(string query)
        {
            using var myConnection = new MySqlConnection(StrConexao().ConnectionString);
            myConnection.Open();

            MySqlCommand comando = new MySqlCommand(query, myConnection);

            comando.ExecuteNonQuery();

            comando.Dispose();
            myConnection.Close();
            myConnection.Dispose();
        }

        public static DataTable EXE_QUERY(string query, List<MySQLParametro> parametros)
        {
            using var myConnection = new MySqlConnection(StrConexao().ToString());
            myConnection.Open();

            MySqlDataAdapter adaptador = new MySqlDataAdapter(query,myConnection);

            MySqlCommand comando = new MySqlCommand(query, myConnection);

            foreach (MySQLParametro parametro in parametros)
            {
                adaptador.SelectCommand.Parameters.Add(new MySqlParameter(parametro.nome, parametro.valor));
            }

            Console.WriteLine(adaptador);
            
            DataTable dados = new DataTable();
            adaptador.Fill(dados); 
            return dados;

        }

        public static DataTable EXE_QUERY(string query)
        {
            MySqlConnection myConnection = new MySqlConnection(StrConexao().ToString());
            myConnection.Open();

            MySqlDataAdapter adaptador = new MySqlDataAdapter(query, myConnection);

            using MySqlCommand comando = new MySqlCommand(query, myConnection);

            DataTable dados = new DataTable();
            adaptador.Fill(dados);
            return dados;
        }
    }

    public class MySQLParametro
    {
        public string nome { get; set; }
        public object valor { get; set; }

        public MySQLParametro(string parametro, object valor)
        {
            this.nome = parametro;
            this.valor = valor;
        }
    }
}

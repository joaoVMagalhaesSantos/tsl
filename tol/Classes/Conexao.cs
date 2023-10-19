using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


public class Conexao
{
    public string banco { get; set; }
    public string descricao { get; set; }
    public string driver { get; set; }
    public string flag { get; set; }
    public string password { get; set; }
    public string porta { get; set; }
    public string server { get; set; }
    public string usuario { get; set; }

}

public class StrConecta
{
    public static string LerConectar()
    {
        try
        {
            string caminhoConectar = "C:\\tolsistemas\\sistema\\conectar.ini";

            var lines = File.ReadAllLines(caminhoConectar);
            if(lines.Length < 9)
            {
                throw new Exception("O arquivo de conexão está incompleto");
            }

            var configuracao = new Conexao
            {
                banco = lines[1],
                descricao = lines[2],
                driver = lines[3],
                flag = lines[4],
                password = lines[5],
                porta = lines[6],
                server = lines[7],
                usuario = lines[8]
            };

            string strConexao = configuracao.server + ";" + configuracao.usuario + ";" + configuracao.banco + ";" + configuracao.porta + ";" + configuracao.password ;

            return strConexao;
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao ler o Arquivo de configuração " + ex.Message);
        }
    }

    public static void Conecta ()
    {
        string strConexao = LerConectar();
        var conexao = new MySqlConnection(strConexao);
        
        try
        {
            Console.WriteLine("Conectando ao MySQL...");
            conexao.Open();
        }
        catch (Exception ex)
        {
            throw new Exception("Erro ao conectar ao Banco de Dados " + ex.Message);
        }
    }

}

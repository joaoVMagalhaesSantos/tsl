using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Cliente
{
    public int Clicod { get; set; }
    public string Clinom { get; set; }
    public string Clifan { get; set; }
    public string Clicnpj { get; set; }
    public string Cliend { get; set; }
    public string Clibai { get; set; }
    public string Clicid { get; set; }
    public string Numero { get; set; }
    public string Clicep { get; set; }
    public string Clicom { get; set; }
    public string Clitel { get; set; }
    public string Clitel2 { get; set; }
    public string Celular { get; set; }
    public string Email { get; set; }
    public string Abertura { get; set; }
    public string Status { get; set; }
    public string Porte { get; set; }
    public string Seq004 { get; set; }

}

public class ClienteConst {
    public static void cadClie(int cliCod, string cliNom, string clicnpj, string cliEnd, string cliBai, string cliCid, string numero, string cliCep, string cliTel, string cliTel2, string celular, string cliCom, string email, string seq004) {
        List<MySqlParametro> novoCliente = new List<MySqlParametro>();

        novoCliente.Add(new MySqlParametro("@clicod", cliCod));
        novoCliente.Add(new MySqlParametro("@clinom", cliNom));
        novoCliente.Add(new MySqlParametro("@clicnpj", clicnpj));
        novoCliente.Add(new MySqlParametro("@cliend", cliEnd));
        novoCliente.Add(new MySqlParametro("@clibai", cliBai));
        novoCliente.Add(new MySqlParametro("@clicid", cliCid));
        novoCliente.Add(new MySqlParametro("@numero", numero));
        novoCliente.Add(new MySqlParametro("@clicep", cliCep));
        novoCliente.Add(new MySqlParametro("@clitel", cliTel));
        novoCliente.Add(new MySqlParametro("@clitel2", cliTel2));
        novoCliente.Add(new MySqlParametro("@celular", celular));
        novoCliente.Add(new MySqlParametro("@clicon", cliCom));
        novoCliente.Add(new MySqlParametro("@email", email));
        novoCliente.Add(new MySqlParametro("@seq004", seq004));


    }


}

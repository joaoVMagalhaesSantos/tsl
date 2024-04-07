using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

public class Cnpj
{
    public string status { get; set; }
    public string ultima_atualizacao { get; set; }
    public string cnpj { get; set; }
    public string tipo { get; set; }
    public string porte { get; set; }
    public string nome { get; set; }
    public string fantasia { get; set; }
    public string abertura { get; set; }
    public string logradouro { get; set; }
    public string numero { get; set; }
    public string complemento { get; set; }
    public string municipio { get; set; }
    public string bairro { get; set; }
    public string uf { get; set; }
    public string cep { get; set; }
    public string email { get; set; }
    public string telefone { get; set; }
    public string capitalSocial { get; set; }

}


public class LerCnpjRetorno
{
    public static async Task<Cnpj> DadosCnpjAsync (string cnpj)
    {
        RestClientOptions options = new RestClientOptions("https://receitaws.com.br/v1");
        RestClient client = new RestClient(options);
        RestRequest request = new RestRequest(string.Format("/cnpj/{0}", cnpj));

        var response = await client.GetAsync<Cnpj>(request);

        return response;

    }
}
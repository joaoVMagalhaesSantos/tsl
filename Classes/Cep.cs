using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

public class Cep
{
    public string cep { get; set; }
    public string logradouro { get; set; }
    public string complemento { get; set; }
    public string bairro { get; set; }
    public string localidade { get; set; }
    public string uf { get; set; }
    public string ibge { get; set; }
    public string ddd { get; set; }
    public string siafi { get; set; }

}

public class LerDadosRetorno
{
    public static async Task<Cep> DadosRetoroAsync (string cep)
    {
        RestClientOptions options = new RestClientOptions("http://viacep.com.br/ws/");
        RestClient client = new RestClient(options);
        RestRequest request = new RestRequest(string.Format("{0}/json", cep));

        var response = await client.GetAsync<Cep>(request);

        return response;
    }
}


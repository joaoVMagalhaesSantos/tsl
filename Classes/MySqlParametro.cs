using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

using System.Data;
using System.Text.Json;
using System.Text.Json.Serialization;
using Google.Protobuf.WellKnownTypes;
using MySqlConnector;
using RestSharp;
using tol.Class;
using tol.Forms;


namespace tol
{
    public partial class tslc001 : Form
    {

        public tslc001()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void LimpaCampos()
        {
            txtCodigo.Text = "";
            txtNome.Text = "";
            txtFant.Text = "";
            txtCep.Text = "";
            txtEnd.Text = "";
            txtNum.Text = "";
            txtComp.Text = "";
            txtBai.Text = "";
            txtCodcid.Text = "";
            txtCid.Text = "";
            txtCNPJ.Text = "";
            txtAbertura.Text = "";
            txtSatus.Text = "";
            txtPorte.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
            txtCelular.Text = "";

        }

        private void LiberaCampos()
        {
            txtCodigo.Enabled = false;
            txtNome.Enabled = true;
            txtFant.Enabled = true;
            txtCep.Enabled = true;
            txtEnd.Enabled = true;
            txtNum.Enabled = true;
            txtComp.Enabled = true;
            txtBai.Enabled = true;
            txtCodcid.Enabled = true;
            txtCid.Enabled = true;
            txtCNPJ.Enabled = true;
            txtAbertura.Enabled = true;
            txtSatus.Enabled = true;
            txtPorte.Enabled = true;
            txtTelefone.Enabled = true;
            txtEmail.Enabled = true;
            txtCelular.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LiberaCampos();
            LimpaCampos();


            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button8.Enabled = false;
            button7.Enabled = true;
            button5.Enabled = true;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCep_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            MessageBox.Show("Formato incorreto");
        }

        private async void txtCep_Leave_1(object sender, EventArgs e)
        {
            if (txtCep.Text.Length > 0)
            {
                string cep = txtCep.Text;
                Cep response = await LerDadosRetorno.DadosRetoroAsync(cep);
                try
                {
                    txtEnd.Text = response.logradouro.ToString();
                    txtNum.Text = response.complemento.ToString();
                    txtBai.Text = response.bairro.ToString();
                    txtCodcid.Text = response.ibge.ToString();
                    txtCid.Text = response.localidade.ToString();

                }
                catch
                {
                    MessageBox.Show("Erro na consulta");
                }

            }
        }

        private async void txtCNPJ_Leave(object sender, EventArgs e)
        {
            if (txtCNPJ.TextLength >= 18 && txtCNPJ.TextLength <= 18)
            {
                string cnpj = txtCNPJ.Text;
                Cnpj response = await LerCnpjRetorno.DadosCnpjAsync(cnpj);
                try
                {
                    txtNome.Text = response.nome.ToString();
                    txtFant.Text = response.fantasia.ToString();
                    txtAbertura.Text = response.abertura.ToString();
                    txtPorte.Text = response.porte.ToString();
                    txtSatus.Text = response.status.ToString();
                    txtEnd.Text = response.logradouro.ToString();
                    txtNum.Text = response.numero.ToString();
                    txtComp.Text = response.complemento.ToString();
                    txtBai.Text = response.bairro.ToString();
                    txtCep.Text = response.cep.ToString();
                    txtCid.Text = response.municipio.ToString();

                }
                catch
                {
                    MessageBox.Show("Erro na Consulta");
                }

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text == "")
            {
                txtCodigo.Text = 0.ToString();
            }

            if (Convert.ToInt32(txtCodigo.Text) > 0)
            {
                try
                {
                    List<MySQLParametro> consultaCli = new List<MySQLParametro>
                    {
                        new MySQLParametro("@clicod",Convert.ToInt32(txtCodigo.Text))
                    };

                    DataTable dados = Conexao.EXE_QUERY("SELECT * FROM tslc001 WHERE tslc001.clicod = @clicod ", consultaCli);
                    if (dados.Rows.Count > 0)
                    {
                        List<MySQLParametro> alteraClie = new List<MySQLParametro>
                        {
                            new MySQLParametro("@clicod",txtCodigo.Text),
                            new MySQLParametro("@clinom",txtNome.Text),
                            new MySQLParametro("@clifan",txtFant.Text),
                            new MySQLParametro("@clicnpj",txtCNPJ.Text),
                            new MySQLParametro("@cliend",txtEnd.Text),
                            new MySQLParametro("@clibai",txtBai.Text),
                            new MySQLParametro("@clicid",txtCid.Text),
                            new MySQLParametro("@numero",txtNum.Text),
                            new MySQLParametro("@clicep",txtCep.Text),
                            new MySQLParametro("@clitel",txtTelefone.Text),
                            new MySQLParametro("@clitel2",txtCelular.Text),
                            new MySQLParametro("@clicom",txtComp.Text),
                            new MySQLParametro("@email",txtEmail.Text),
                            new MySQLParametro("@abertura",txtAbertura.Text),
                            new MySQLParametro("@status",txtSatus.Text),
                            new MySQLParametro("@porte",txtPorte.Text),

                        };

                        Conexao.NOM_QUERY("UPDATE tslc001 SET clinom = @clinom," +
                            "clifan = @clifan," +
                            "clicnpj = @clicnpj," +
                            "cliend = @cliend," +
                            "clibai = @clibai," +
                            "clicid = @clicid," +
                            "numero = @numero," +
                            "clicep = @clicep," +
                            "clitel = @clitel," +
                            "clitel2 = @clitel2," +
                            "clicom = @clicom," +
                            "email = @email," +
                            "abertura = @abertura," +
                            "status = @status," +
                            "porte = @porte" +
                            " WHERE tslc001.clicod = @clicod", alteraClie);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao consultar o cliente: " + ex);
                }
            }
            else
            {
                try
                {
                    List<MySQLParametro> insereClie = new List<MySQLParametro>
                    {
                        new MySQLParametro("@clinom",txtNome.Text),
                        new MySQLParametro("@clifan",txtFant.Text),
                        new MySQLParametro("@clicnpj",txtCNPJ.Text),
                        new MySQLParametro("@cliend",txtEnd.Text),
                        new MySQLParametro("@clibai",txtBai.Text),
                        new MySQLParametro("@clicid",txtCid.Text),
                        new MySQLParametro("@numero",txtNum.Text),
                        new MySQLParametro("@clicep",txtCep.Text),
                        new MySQLParametro("@clitel",txtTelefone.Text),
                        new MySQLParametro("@clitel2",txtCelular.Text),
                        new MySQLParametro("@clicom",txtComp.Text),
                        new MySQLParametro("@email",txtEmail.Text),
                        new MySQLParametro("@abertura",txtAbertura.Text),
                        new MySQLParametro("@status",txtSatus.Text),
                        new MySQLParametro("@porte",txtPorte.Text),

                    };

                    Conexao.NOM_QUERY("INSERT INTO tslc001 (clinom,clifan,clicnpj,cliend,clibai,clicid,numero,clicep,clitel,clitel2,clicom,email,abertura,status,porte) values (" +
                        "@clinom," +
                        "@clifan," +
                        "@clicnpj," +
                        "@cliend," +
                        "@clibai," +
                        "@clicid," +
                        "@numero," +
                        "@clicep," +
                        "@clitel," +
                        "@clitel2," +
                        "@clicom," +
                        "@email," +
                        "@abertura," +
                        "@status," +
                        "@porte)", insereClie);

                    DataTable dados = Conexao.EXE_QUERY("SELECT MAX(clicod) FROM tslc001");
                    txtCodigo.Text = dados.Rows[0]["MAX(clicod)"].ToString();



                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao cadastrar: " + ex);
                }
            }
            
            txtCodigo.Enabled = true;
            txtCNPJ.Enabled = false;
            txtAbertura.Enabled = false;
            txtSatus.Enabled = false;
            txtNome.Enabled = false;
            txtPorte.Enabled = false;
            txtFant.Enabled = false;
            txtCep.Enabled = false;
            txtEnd.Enabled = false;
            txtNum.Enabled = false;
            txtBai.Enabled = false;
            txtComp.Enabled = false;
            txtCodcid.Enabled = false;
            txtCid.Enabled = false;
            txtTelefone.Enabled = false;
            txtEmail.Enabled = false;
            txtCelular.Enabled = false;

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = false;
            button6.Enabled = true;
            button7.Enabled = false;
            button8.Enabled = true;

            MessageBox.Show("Salvo com sucesso!", "Alerta");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LiberaCampos();

            button4.Enabled = false;
            button5.Enabled = true;
            button7.Enabled = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtCodigo.Text) > 0)
            {
                try
                {
                    List<MySQLParametro> consultaCli = new List<MySQLParametro>
                    {
                        new MySQLParametro("@clicod",Convert.ToInt32(txtCodigo.Text))
                    };

                    DataTable dados = Conexao.EXE_QUERY("SELECT * FROM tslc001 WHERE tslc001.clicod = @clicod ", consultaCli);
                    if (dados.Rows.Count > 0)
                    {
                        List<MySQLParametro> excluiClie = new List<MySQLParametro>
                        {
                            new MySQLParametro("@clicod",txtCodigo.Text),
                            new MySQLParametro("@exclui",1),

                        };

                        Conexao.NOM_QUERY("UPDATE tslc001 SET exclui = @exclui" +
                            " WHERE tslc001.clicod = @clicod", excluiClie);
                    }
                    LimpaCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao consultar o cliente: " + ex);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Consulta consulta = new Consulta();
            consulta.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LimpaCampos();
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = true;
            button5.Enabled = false;
            button6.Enabled = true;
            button7.Enabled = false;
            button8.Enabled = true;

            txtCodigo.Enabled = true;
            txtCNPJ.Enabled = false;
            txtAbertura.Enabled = false;
            txtSatus.Enabled = false;
            txtNome.Enabled = false;
            txtPorte.Enabled = false;
            txtFant.Enabled = false;
            txtCep.Enabled = false;
            txtEnd.Enabled = false;
            txtNum.Enabled = false;
            txtBai.Enabled = false;
            txtComp.Enabled = false;
            txtCodcid.Enabled = false;
            txtCid.Enabled = false;
            txtTelefone.Enabled = false;
            txtEmail.Enabled = false;
            txtCelular.Enabled = false;
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            if (txtCodigo.Text != "")
            {
                List<MySQLParametro> parametro1 = new List<MySQLParametro>
                {
                    new MySQLParametro("@clicod",Convert.ToInt32(txtCodigo.Text))
                };

                try
                {
                    DataTable dados = Conexao.EXE_QUERY("SELECT * FROM tslc001 WHERE tslc001.clicod = @clicod ", parametro1);

                    if (dados.Rows.Count > 0)
                    {

                        if (Convert.ToInt32(dados.Rows[0]["exclui"].ToString()) == 0)
                        {
                            txtCodigo.Text = dados.Rows[0]["clicod"].ToString();
                            txtNome.Text = dados.Rows[0]["clinom"].ToString();
                            txtFant.Text = dados.Rows[0]["clifan"].ToString();
                            txtCep.Text = dados.Rows[0]["clicep"].ToString();
                            txtEnd.Text = dados.Rows[0]["cliend"].ToString();
                            txtNum.Text = dados.Rows[0]["numero"].ToString();
                            txtComp.Text = dados.Rows[0]["clicom"].ToString();
                            txtBai.Text = dados.Rows[0]["clibai"].ToString();
                            txtCodcid.Text = dados.Rows[0]["clicodcid"].ToString();
                            txtCid.Text = dados.Rows[0]["clicid"].ToString();
                            txtCNPJ.Text = dados.Rows[0]["clicnpj"].ToString();
                            txtAbertura.Text = dados.Rows[0]["abertura"].ToString();
                            txtSatus.Text = dados.Rows[0]["status"].ToString();
                            txtPorte.Text = dados.Rows[0]["porte"].ToString();
                            txtTelefone.Text = dados.Rows[0]["clitel"].ToString();
                            txtEmail.Text = dados.Rows[0]["email"].ToString();
                            txtCelular.Text = dados.Rows[0]["clitel2"].ToString();

                            button2.Enabled = true;
                            button3.Enabled = true;
                        }
                        else
                        {
                            LimpaCampos();
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao consultar cliente:" + ex.Message);
                }
            }
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }
    }
}

using System.Text.Json;
using System.Text.Json.Serialization;
using RestSharp;


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

        private void button1_Click(object sender, EventArgs e)
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
            MessageBox.Show("Faz direito ai porra");
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
                    MessageBox.Show("Deu caquita");
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
                    MessageBox.Show("Deu caquita");
                }

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }
    }
}

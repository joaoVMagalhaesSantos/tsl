using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tol.Class;

namespace tol.Forms
{
    public partial class Consulta : Form
    {
        public Consulta()
        {
            InitializeComponent();
        }

        private void Consulta_Load(object sender, EventArgs e)
        {
            try
            {
                DataTable dados = Conexao.EXE_QUERY("SELECT * FROM tslc001 WHERE exclui = 0");

                if (dados.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dados;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar " + ex.Message);
            }
        }
    }
}

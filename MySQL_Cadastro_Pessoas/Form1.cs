using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySQL_Cadastro_Pessoas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void bntCadastrar_Click(object sender, EventArgs e)
        {
            DateTime nascimento = Convert.ToDateTime(txtNascimento.Text);

            string conexao = "Server=127.0.0.1;Database=cadastro;Uid=root;Pwd=root;";

            string Insert = $@"
            insert into pessoas(nome, nascimento, sexo, peso, altura, nacionalidade)
            values
            ('{ txtNome.Text}', '{nascimento.ToString("yyyy-MM-dd")}', '{txtSexo.Text}', '{txtPeso.Text}', '{txtAltura.Text}', '{txtNacionalidade.Text}')";

            MySqlConnection conexaoMySql = new MySqlConnection(conexao);

            try
            {
                conexaoMySql.Open();
                MySqlCommand executarComando = new MySqlCommand(Insert, conexaoMySql);
                executarComando.ExecuteNonQuery();

                MessageBox.Show($"Cadastro Efetuado Com Sucesso", "Sucesso", MessageBoxButtons.OK , MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conexaoMySql.Close();
            }
        }
        private void bntLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Text = string.Empty;
            txtNascimento.Text = string.Empty;
            txtSexo.Text = string.Empty;
            txtPeso.Text = string.Empty;
            txtAltura.Text = string.Empty;
            txtNacionalidade.Text = string.Empty;
        }
    }
}

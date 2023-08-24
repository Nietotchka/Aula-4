using MySql.Data.MySqlClient;
using ReaLTaiizor.Controls;
using ReaLTaiizor.Forms;
using System.Data;

namespace Projeto3
{
    public partial class FormAluno : MaterialForm
    {

        bool isAlteracao = false;
        string cs = @"server=localhost;" +
                     "uid=root;" +
                     "pwd=;" +
                     "database=academico";
        public FormAluno()
        {
            InitializeComponent();
        }

        private void FormAluno_Load(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void materialTextBoxEdit1_Click(object sender, EventArgs e)
        {

        }

        private void materialMaskedTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void materialComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void materialTextBoxEdit3_Click(object sender, EventArgs e)
        {

        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja realmente cancelar?", "IFSP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LimpaCampos();
                materialTabControl1.SelectedIndex = 1;
            }
        }

        private void textNome_Click(object sender, EventArgs e)
        {

        }

        private void materialTextBoxEdit5_Click(object sender, EventArgs e)
        {

        }

        private void btn_salvar_Click(object sender, EventArgs e)
        {
            if (ValidarFormulario())
            {
                Salvar();
                materialTabControl1.SelectedIndex = 1;
            }
        }

        private void Salvar()
        {
            var con = new MySqlConnection(cs);
            con.Open();
            if (!isAlteracao)
            {
                var sql = "INSERT INTO aluno" +
                          "(matricula, dt_nascimento, nome, endereco, " +
                          "bairro, cidade, estado senha)" +
                          " VALUES " +
                          "(@matricula, @dt_nascimento, @nome, @endereco," +
                          "@bairro, @cidade, @estado, @senha)";

                var cmd = new MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@matricula", txt_Matricula.Text);
                DateTime.TryParse(txt_Data.Text, out var dataNascimento);
                cmd.Parameters.AddWithValue("@nome", txt_Name.Text);
                cmd.Parameters.AddWithValue("@endereco", txt_Endereço.Text);
                cmd.Parameters.AddWithValue("@bairro", txt_Bairro.Text);
                cmd.Parameters.AddWithValue("@cidade", txt_Cidade.Text);
                cmd.Parameters.AddWithValue("@estado", txt_UF.Text);
                cmd.Parameters.AddWithValue("@senha", txt_Senha.Text);
                cmd.Prepare();
                cmd.ExecuteNonQuery();

            }
            else
            {
            }
            //LimparCampos();
        }

        private bool ValidarFormulario()
        {
            if (string.IsNullOrEmpty(txt_Matricula.Text))
            {
                MessageBox.Show("Matricula é obrigatória", "IFSP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Matricula.Focus();
                return false;

            }

            if (string.IsNullOrEmpty(txt_Name.Text))
            {
                MessageBox.Show("Nome é obrigatório", "IFSP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Name.Focus();
                return false;

            }
            if (string.IsNullOrEmpty(txt_Endereço.Text))
            {
                MessageBox.Show("Endereço é obrigatório", "IFSP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Endereço.Focus();
                return false;

            }
            if (string.IsNullOrEmpty(txt_Bairro.Text))
            {
                MessageBox.Show("Bairro é obrigatório", "IFSP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Bairro.Focus();
                return false;

            }
            if (string.IsNullOrEmpty(txt_Cidade.Text))
            {
                MessageBox.Show("Cidade é obrigatória", "IFSP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Cidade.Focus();
                return false;

            }
            if (string.IsNullOrEmpty(txt_Senha.Text))
            {
                MessageBox.Show("Senha é obrigatória", "IFSP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Senha.Focus();
                return false;

            }
            if (!DateTime.TryParse(txt_Data.Text, out DateTime _))
            {
                MessageBox.Show("Data é obrigatória", "IFSP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Data.Focus();
                return false;

            }

            return true;
        }

        private void CarregaGrid()
        {
            var con = new MySqlConnection(cs);
            con.Open();
            var sql = "SELECT * FROM aluno";
            var dt = new DataTable();
            var sqlAd = new MySqlDataAdapter();
            sqlAd.SelectCommand = new MySqlCommand(sql, con);
            sqlAd.Fill(dt);
            dataGridView1.DataSource = dt;

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void tabPage2_Enter(object sender, EventArgs e)
        {
            
        }

        private void listView_Alunos_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
            if (e.ItemIndex % 2 == 1)
            {
                e.Item.BackColor = Color.FromArgb(230, 230, 255);
                e.Item.UseItemStyleForSubItems = true;
            }
        }

        private void txt_Cidade_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void btn_excluir_Click(object sender, EventArgs e)
        {
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_novo_Click(object sender, EventArgs e)
        {
            LimpaCampos();
            materialTabControl1.SelectedIndex = 0;
            txt_Matricula.Focus();
        }

        private void LimpaCampos()
        {
            isAlteracao = false;
            foreach (var control in tabPage1.Controls)
            {
                if (control is MaterialTextBoxEdit)
                {
                    ((MaterialTextBoxEdit)control).Clear();
                }
                if (control is MaterialMaskedTextBox)
                {
                    ((MaterialMaskedTextBox)control).Clear();
                }
            }
        }

       
           

        private void listView_Alunos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }

        private void listView_Alunos_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void materialTabControl1_Enter(object sender, EventArgs e)
        {
            CarregaGrid();
        }
    }


}

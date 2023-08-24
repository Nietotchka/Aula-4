using Projeto3;
using ReaLTaiizor.Forms;

namespace WinFormsApp1
{
    public partial class FormPrincipal : MaterialForm
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void opçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void cadastroDeAlunosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAluno formAluno = new FormAluno();
            //formAluno.MdiParent = this;
            formAluno.Show();
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.ApplicationExitCall)
            {
                e.Cancel = true;
            }
        }
    }
}
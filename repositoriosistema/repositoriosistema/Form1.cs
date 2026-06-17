using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace repositoriosistema
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private Form formularioActivo = null;
        private void AbrirFormulario(Form form)
        {
            if (formularioActivo != null)
                formularioActivo.Close();

            formularioActivo = form;

            form.TopLevel = false;

            panelContenedor.Controls.Clear();
            panelContenedor.Controls.Add(form);

            form.Show();
         
        }

        private void cLIENTESToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new frmClientes());
        }

        private void pRODUCTOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmProducto());
        }

        private void eMPLEADOSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmEmpleados());
        }
    }
}

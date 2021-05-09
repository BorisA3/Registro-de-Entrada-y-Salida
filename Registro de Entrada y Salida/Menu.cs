using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Registro_de_Entrada_y_Salida
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            Registro registro = new Registro();
            registro.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuarios usuario = new Usuarios();
            usuario.Show();
        }

        private void btnPuesto_Click(object sender, EventArgs e)
        {
            Puesto puesto = new Puesto();
            puesto.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Departamento departamento = new Departamento();
            departamento.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ControldePersonal control = new ControldePersonal();
            control.Show();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

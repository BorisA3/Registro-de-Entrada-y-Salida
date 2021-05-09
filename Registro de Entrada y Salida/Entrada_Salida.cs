using Microsoft.OData.Edm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Registro_de_Entrada_y_Salida
{
    public partial class Entrada_Salida : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=ControldePersonal;Integrated Security=True; user Id=sa ;Password=1234");
        Conexion conexion = new Conexion();
        SqlCommand cmd;
        SqlDataReader dr;
        public Entrada_Salida()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Hora
            txtHora.Text = DateTime.Now.ToString("HH:mm:ss");
            txtFecha.Text = DateTime.Now.ToString("D");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 btnlogin = new Form1();
            btnlogin.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void btnEntrada_Click(object sender, EventArgs e)
        {
            if (conexion.RegistroEntrada(txtIdentidad.Text) == 0)
            {

                MessageBox.Show(conexion.InsertarEntrada(txtIdentidad.Text, txtHora.Text));


                txtIdentidad.Text = "";
                
            }
            else
            {
                MessageBox.Show("Imposible de registrar, El registro ya existe");
            }
        }

        private void btnSalida_Click(object sender, EventArgs e)
        {
            if (conexion.RegistroSalida(txtIdentidad.Text) == 0)
            {

                MessageBox.Show(conexion.InsertarSalida(txtIdentidad.Text, txtHora.Text));


                txtIdentidad.Text = "";



            }
            else
            {
                MessageBox.Show("Imposible de registrar, El registro ya existe");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}

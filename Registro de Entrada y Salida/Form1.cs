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
    public partial class Form1 : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=ControldePersonal;Integrated Security=True; user Id=sa ;Password=1234");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Login (string usuario, string contraseña)
        {

            try
            {
                SqlCommand cmd = new SqlCommand("SELECT LoginId From Login where LoginUsuario = @usuario and LoginPassword =@pas", cn);
                cmd.Parameters.AddWithValue("Usuario", usuario);
                cmd.Parameters.AddWithValue("pas", contraseña);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count == 1)
                {
                    this.Hide();
                    Menu menu = new Menu();
                    menu.Show();

                }
                else
                {
                    MessageBox.Show("Usuario o Contraseña incorrectas");
                }

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }


        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login(this.txtUsuario.Text, this.txtPassword.Text);
        }
    }
}

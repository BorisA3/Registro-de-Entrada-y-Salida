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

    public partial class Usuarios : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=ControldePersonal;Integrated Security=True; user Id=sa ;Password=1234");
        Conexion conexion = new Conexion();
        SqlCommand cmd;
        SqlDataReader dr;
        public Usuarios()
        {
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {

        }
        
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (conexion.RegistroUsuario(txtIUsuario.Text, txtPassword.Text) == 0)
            {

                MessageBox.Show(conexion.InsertarUsuario(txtIUsuario.Text, txtPassword.Text));

                
                txtIUsuario.Text = "";
                txtPassword.Text = "";
                

            }
            else
            {
                MessageBox.Show("Imposible de registrar, El registro ya existe");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {

                txtId.Text = dgUsuarios.CurrentRow.Cells[0].Value.ToString();
                txtIUsuario.Text = dgUsuarios.CurrentRow.Cells[1].Value.ToString();
                txtPassword.Text = dgUsuarios.CurrentRow.Cells[2].Value.ToString();

            }
            catch
            {
                MessageBox.Show("Error al extraer los datos");
            }

            conexion.VisualizarUsuarios(dgUsuarios);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
           
            conexion.VisualizarUsuarios(dgUsuarios);
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int flag = 0;

            SqlCommand cone = new SqlCommand("Delete from Login Where LoginUsuario = '" + txtIUsuario.Text + "'", cn);
            cn.Open();
            flag = cone.ExecuteNonQuery();

            if (flag == 1)
            {
                MessageBox.Show("Usuario Eliminado");
            }
            else
            {
                MessageBox.Show("Usuario No eliminado");
            }
            cn.Close();
            conexion.VisualizarUsuarios(dgUsuarios);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cone = new SqlCommand("UPDATE Login SET LoginUsuario=@Usuario,LoginPassword=@Password Where loginId = '" + txtId.Text + "'", cn);


            cone.Parameters.AddWithValue("@Usuario", txtIUsuario.Text);
            cone.Parameters.AddWithValue("@Password", txtPassword.Text);
            

             cone.ExecuteNonQuery();
             MessageBox.Show("Los Datos fueron actualizados correctamente");
             conexion.VisualizarUsuarios(dgUsuarios);
             txtIUsuario.Text = "";
             txtPassword.Text = "";
             cn.Close();


        }

        private void vc(object sender, EventArgs e)
        {

        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            txtId.Enabled = false;
        }

        private void text_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtIUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

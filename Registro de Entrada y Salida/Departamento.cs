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
    public partial class Departamento : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=ControldePersonal;Integrated Security=True; user Id=sa ;Password=1234");
        Conexion conexion = new Conexion();
        SqlCommand cmd;
        SqlDataReader dr;
        public Departamento()
        {
            InitializeComponent();
        }

        private void dgDepartamentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                txtNombreDepartamento.Text = dgDepartamentos.CurrentRow.Cells[0].Value.ToString();

            }
            catch
            {
                MessageBox.Show("Error al extraer los datos");
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cone = new SqlCommand("UPDATE Departamento SET DepartamentoNombre=@Nombre Where DepartamentoNombre = '" + txtNombreDepartamento.Text + "'", cn);


            cone.Parameters.AddWithValue("@Nombre", txtNombreDepartamento.Text);


            cone.ExecuteNonQuery();
            MessageBox.Show("Los Datos fueron actualizados correctamente");
            conexion.VisualizarDepartamento(dgDepartamentos);
            txtNombreDepartamento.Text = ""; 
            cn.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (conexion.RegistroDepartamento(txtNombreDepartamento.Text) == 0)
            {

                MessageBox.Show(conexion.InsertarDepartamento(txtNombreDepartamento.Text));


                txtNombreDepartamento.Text = "";
             


            }
            else
            {
                MessageBox.Show("Imposible de registrar, El registro ya existe");
            }
            conexion.VisualizarDepartamento(dgDepartamentos);

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            conexion.VisualizarDepartamento(dgDepartamentos);
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int flag = 0;

            SqlCommand cone = new SqlCommand("Delete from Departamento Where DepartamentoNombre = '" + txtNombreDepartamento.Text + "'", cn);
            cn.Open();
            flag = cone.ExecuteNonQuery();

            if (flag == 1)
            {
                MessageBox.Show("Departamento Eliminado");
            }
            else
            {
                MessageBox.Show("Departamento No eliminado");
            }
            cn.Close();
            conexion.VisualizarDepartamento(dgDepartamentos);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Departamento_Load(object sender, EventArgs e)
        {

        }
    }
}

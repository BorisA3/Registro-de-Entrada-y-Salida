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
    public partial class Registro : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=ControldePersonal;Integrated Security=True; user Id=sa ;Password=1234");
        Conexion conexion = new Conexion();
        SqlCommand cmd;
        SqlDataReader dr;
        public Registro()
        {
            InitializeComponent();
        }

        private void Registro_Load(object sender, EventArgs e)
        {
            SqlCommand cm = new SqlCommand("Select PuestoNombre From Puesto", cn);
            cn.Open();
            SqlDataReader registro = cm.ExecuteReader();

            while (registro.Read())
            {
                cmbPuesto.Items.Add(registro["PuestoNombre"].ToString());

            }

            cn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Puesto puesto = new Puesto();
            puesto.Show();
        }

        private void dgRegistro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                txtIdentidad.Text = dgRegistro.CurrentRow.Cells[0].Value.ToString();
                txtNombreRegistro.Text = dgRegistro.CurrentRow.Cells[1].Value.ToString();
                txtApellido.Text = dgRegistro.CurrentRow.Cells[2].Value.ToString();
                cmbPuesto.Text = dgRegistro.CurrentRow.Cells[3].Value.ToString();

            }
            catch
            {
                MessageBox.Show("Error al extraer los datos");
            }

            conexion.VisualizarPersonal(dgRegistro);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

            conexion.VisualizarPersonal(dgRegistro);
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int flag = 0;

            SqlCommand cone = new SqlCommand("Delete from Empleado Where EmpleadoId = '" + txtIdentidad.Text + "'", cn);
            cn.Open();
            flag = cone.ExecuteNonQuery();

            if (flag == 1)
            {
                MessageBox.Show("Empleado Eliminado");
            }
            else
            {
                MessageBox.Show("Empleado No eliminado");
            }
            cn.Close();
            conexion.VisualizarPersonal(dgRegistro);
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (conexion.RegistroPersonal(txtIdentidad.Text) == 0)
            {

                MessageBox.Show(conexion.InsertarPersonal(txtIdentidad.Text, txtNombreRegistro.Text, txtApellido.Text, (string)cmbPuesto.Text));


                txtIdentidad.Text = "";
                txtNombreRegistro.Text = "";
                txtApellido.Text = "";


            }
            else
            {
                MessageBox.Show("Imposible de registrar, El registro ya existe");
            }

            conexion.VisualizarPersonal(dgRegistro);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cone = new SqlCommand("UPDATE Empleado SET EmpleadoId=@id,EmpleadoNombre=@nombre, EmpleadoApellido=@apellido," +
                " PuestoNombre=@puesto Where EmpleadoNombre = '" + txtNombreRegistro.Text + "'", cn);


            cone.Parameters.AddWithValue("@id", txtIdentidad.Text);
            cone.Parameters.AddWithValue("@nombre", txtNombreRegistro.Text);
            cone.Parameters.AddWithValue("@apellido", txtApellido.Text);
            cone.Parameters.AddWithValue("@puesto", cmbPuesto.Text);


            cone.ExecuteNonQuery();
            MessageBox.Show("Los Datos fueron actualizados correctamente");
            conexion.VisualizarPersonal(dgRegistro);
            txtIdentidad.Text = "";
            txtNombreRegistro.Text = "";
            txtApellido.Text = "";
            cmbPuesto.Text = "";
            cn.Close();
        }
    }
}

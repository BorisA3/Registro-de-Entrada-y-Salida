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
    public partial class Puesto : Form
    {
        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=ControldePersonal;Integrated Security=True; user Id=sa ;Password=1234");
        Conexion conexion = new Conexion();
        SqlCommand cmd;
        SqlDataReader dr;
        public Puesto()
        {
            InitializeComponent();
        }
        public int Value { get; private set; }
        public string DisplayMember { get; private set; }
        public void ComboboxValue(string name, int id)
        {
            Value = id;
            DisplayMember = name;

        }
        private void Puesto_Load(object sender, EventArgs e)
        {
            //Inicio Combobox Departamento
            SqlCommand cm = new SqlCommand("Select DepartamentoNombre From Departamento", cn);
            cn.Open();
            SqlDataReader registro = cm.ExecuteReader();

            while (registro.Read())
            {
                cbDepartamento.Items.Add( registro["DepartamentoNombre"].ToString());

            }

            cn.Close();
            //Fin Combobox  Departamento
        }
        
        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int flag = 0;

            SqlCommand cone = new SqlCommand("Delete from Puesto Where PuestoNombre = '" + txtNombrePuesto.Text + "'", cn);
            cn.Open();
            flag = cone.ExecuteNonQuery();

            if (flag == 1)
            {
                MessageBox.Show("Puesto Eliminado");
            }
            else
            {
                MessageBox.Show("Puesto No eliminado");
            }
            cn.Close();
            conexion.VisualizarPuesto(dgPuesto);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Departamento departamento = new Departamento();
            departamento.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (conexion.RegistroPuesto(txtNombrePuesto.Text, (string)cbDepartamento.Text) == 0)
             {

                 MessageBox.Show(conexion.InsertarPuesto(txtNombrePuesto.Text, (string)cbDepartamento.Text));


                 txtNombrePuesto.Text = "";
                 cbDepartamento.Text = "";


             }
             else
             {
                 MessageBox.Show("Imposible de registrar, El registro ya existe");
             }
            conexion.VisualizarPuesto(dgPuesto);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            conexion.VisualizarPuesto(dgPuesto);
        }

        private void dgPuesto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                txtNombrePuesto.Text = dgPuesto.CurrentRow.Cells[0].Value.ToString();
                cbDepartamento.Text = dgPuesto.CurrentRow.Cells[1].Value.ToString();

            }
            catch
            {
                MessageBox.Show("Error al extraer los datos");
            }

            conexion.VisualizarPuesto(dgPuesto);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            cn.Open();
            SqlCommand cone = new SqlCommand("UPDATE Puesto SET PuestoNombre=@Nombre,DepartamentoId=@Id Where PuestoNombre = '" + txtNombrePuesto.Text + "'", cn);


            cone.Parameters.AddWithValue("@Nombre", txtNombrePuesto.Text);
            cone.Parameters.AddWithValue("@Id", cbDepartamento.Text);


            cone.ExecuteNonQuery();
            MessageBox.Show("Los Datos fueron actualizados correctamente");
            conexion.VisualizarPuesto(dgPuesto);
            txtNombrePuesto.Text = "";
            cbDepartamento.Text = "";
            cn.Close();
        }

        private void cbDepartamento_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}

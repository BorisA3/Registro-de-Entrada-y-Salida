using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Registro_de_Entrada_y_Salida
{
   public class Conexion
    {

        SqlConnection cn;
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt;
        SqlDataAdapter da;

        public Conexion()
        {
            try
            {
                cn = new SqlConnection("Data Source=.;Initial Catalog=ControldePersonal;Integrated Security=True; user Id=sa ;Password=1234");

                cn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se a encontrado la base de datos: " + ex.ToString());
            }
        }

        public void VisualizarUsuarios (DataGridView dgv)
        {
            try
            {
                da = new SqlDataAdapter("select LoginId, LoginUsuario, LoginPassword from Login", cn);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pueden mostrar los datos" + ex.ToString());
            }
        }

        public void VisualizarDepartamento(DataGridView dgv)
        {
            try
            {
                da = new SqlDataAdapter("select DepartamentoNombre from Departamento", cn);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pueden mostrar los datos" + ex.ToString());
            }
        }

        public void VisualizarPuesto(DataGridView dgv)
        {
            try
            {
                da = new SqlDataAdapter("select p.PuestoNombre , d.DepartamentoNombre from Puesto p, Departamento d where p.DepartamentoNombre = d.DepartamentoNombre", cn);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pueden mostrar los datos" + ex.ToString());
            }
        }

        public void VisualizarPersonal(DataGridView dgv)
        {
            try
            {
                da = new SqlDataAdapter("select e.EmpleadoId, e.EmpleadoNombre, e.EmpleadoApellido, p.PuestoNombre  from Empleado e, Puesto p where p.PuestoNombre = e.PuestoNombre", cn);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pueden mostrar los datos" + ex.ToString());
            }
        }
       



        // Insertar Usuario
        public string InsertarUsuario(string usuario, string contraseña)
        {
            string salida = "Usuario ingresado exitosamente!";

            try
            {
                cmd = new SqlCommand("Insert Into Login (LoginUsuario, LoginPassword) values " +
                    "('" + usuario + "','" + contraseña + "')", cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                salida = "Usuario no ingresado: " + ex.ToString();
            }
            return salida;
        }
        public int RegistroUsuario(string usuario, string contraseña)
        {
            int contadora = 0;

            try
            { 
                cmd = new SqlCommand("Select * from Login Where LoginUsuario =  '" + usuario + "'", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    contadora++;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No valido" + ex.ToString());
            }
            return contadora;
        }
        // Fin insertar Usuario

        // Insertar Departamento
        public string InsertarDepartamento(string nombre)
        {
            string salida = "Departamento ingresado exitosamente!";

            try
            {
                cmd = new SqlCommand("Insert Into Departamento (DepartamentoNombre) values " +
                    "('" + nombre + "')", cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                salida = "Departamento no ingresado: " + ex.ToString();
            }
            return salida;
        }
        public int RegistroDepartamento(string nombre)
        {
            int contadora = 0;

            try
            {
                cmd = new SqlCommand("Select * from Departamento Where DepartamentoNombre =  '" + nombre + "'", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    contadora++;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No valido" + ex.ToString());
            }
            return contadora;
        }
        //Fin Insertar departamento

        // Insertar Puesto
        public string InsertarPuesto(string nombre, string departamento)
        {
            string salida = "¨Puesto ingresado exitosamente!";

            try
            {
                cmd = new SqlCommand("Insert Into Puesto (PuestoNombre, DepartamentoNombre) values " +
                    "('" + nombre + "','" + departamento + "')", cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                salida = "Puesto no ingresado: " + ex.ToString();
            }
            return salida;
        }
        public int RegistroPuesto(string nombre, string departamento)
        {
            int contadora = 0;

            try
            {
                cmd = new SqlCommand("Select * from Puesto Where PuestoNombre =  '" + nombre + "'", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    contadora++;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No valido" + ex.ToString());
            }
            return contadora;
        }

        //Fin insertar Puesto

        // empleado
        public string InsertarPersonal(string identidad,string nombre, string apellido, string puesto)
        {
            string salida = "¨Empleado ingresado exitosamente!";

            try
            {
                cmd = new SqlCommand("Insert Into Empleado (EmpleadoId, EmpleadoNombre, EmpleadoApellido, PuestoNombre) values " +
                    "('" + identidad + "','" + nombre + "','" + apellido + "','" + puesto + "')", cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                salida = "Puesto no ingresado: " + ex.ToString();
            }
            return salida;
        }
        public int RegistroPersonal(string identidad)
        {
            int contadora = 0;

            try
            {
                cmd = new SqlCommand("Select * from Empleado Where EmpleadoId =  '" + identidad + "'", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    contadora++;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No valido" + ex.ToString());
            }
            return contadora;
        }

        //fin empleado

        public string InsertarEntrada(string identidad, string hora)
        {
            string salida = "¨Entrada ingresada exitosamente!";

            try
            {
                cmd = new SqlCommand("Insert Into Entrada (EmpleadoId,EntradaHora) values " +
                    "('" + identidad + "','" + hora + "')", cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                salida = "Entrada no ingresada: " + ex.ToString();
            }
            return salida;
        }
        public int RegistroEntrada(string identidad)
        {
            int contadora = 0;

            try
            {
                cmd = new SqlCommand("Select * from Entrada Where EmpleadoId =  '" + identidad + "'", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    contadora++;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No valido" + ex.ToString());
            }
            return contadora;
        }

        public string InsertarSalida(string identidad, string hora)
        {
            string salida = "¨Salida ingresada exitosamente!";

            try
            {
                cmd = new SqlCommand("Insert Into Salida (EmpleadoId,SalidaHora) values " +
                    "('" + identidad + "','" + hora + "')", cn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                salida = "Salida no ingresada: " + ex.ToString();
            }
            return salida;
        }
        public int RegistroSalida(string identidad)
        {
            int contadora = 0;

            try
            {
                cmd = new SqlCommand("Select * from Salida Where EmpleadoId =  '" + identidad + "'", cn);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    contadora++;
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No valido" + ex.ToString());
            }
            return contadora;
        }

        private SqlConnection Open()
        {
            throw new NotImplementedException();
        }
        
    }
}

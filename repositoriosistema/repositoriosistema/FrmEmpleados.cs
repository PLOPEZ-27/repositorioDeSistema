using MySql.Data.MySqlClient;
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
    public partial class FrmEmpleados : Form
    {
        public FrmEmpleados()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string error = "";
            if (txtNombre.Text == string.Empty)
                error += "el campo de Nombre no puede estar vacio";
            else if (txtNombre.Text.Length < 5)
                error += "\nel campo Nombre tiene que tener 3 caracteres minimo";
            if (txtTelefono.Text == string.Empty)
                error += "\nel campo de Telefono no puede estar vacio";
            if (txtCorreoElectro.Text == string.Empty)
                error += "\nel campo de Correo Electronico no puede estar vacio";
            if (txtDireccion.Text == string.Empty)
                error += "\nel campo de Direccion no puede estar vacio";
            if (txtArea.Text == string.Empty)
                error += "\nel campo de Area no puede estar vacio";
            if (txtAniosTrabajo.Text == string.Empty)
                error += "\nel campo de Anios de TYrabajo esta vacio";

            if (error == "")
            {
                try
                {

                    Conexion conexion = new Conexion();
                    using (MySqlConnection conn = conexion.ObtenerConexion())
                    {
                        conn.Open();
                        string query = "INSERT INTO empleados (nombre, telefono, correo, area, direccion, anios_trabajando) VALUES (@nombre, @telefono, @correo, @area, @direccion, @anios_trabajando)";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                            cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                            cmd.Parameters.AddWithValue("@correo", txtCorreoElectro.Text);
                            cmd.Parameters.AddWithValue("@area", txtArea.Text);
                            cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                            cmd.Parameters.AddWithValue("@anios_trabajando", txtAniosTrabajo.Text);
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("empleados guardado exitosamente");
                                txtNombre.Clear();
                                txtCorreoElectro.Clear();
                                txtTelefono.Clear();
                                txtDireccion.Clear();
                                txtArea.Clear();
                                txtAniosTrabajo.Clear();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo guardar el empleado");
                            }

                        }
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

            }
            else
                MessageBox.Show(error, "Error");
        }


        private void CargarEmpleados(string buscar = "")
        {
            try
            {
                Conexion conexion = new Conexion();

                using (MySqlConnection conn = conexion.ObtenerConexion())
                {
                    conn.Open();

                    string query = @"SELECT
                                    id,
                                    nombre,
                                    telefono,
                                    correo,
                                    area,
                                    direccion,
                                    anios_ trabajando
                                    FROM empleados
                                    WHERE nombre LIKE @buscar
                                       OR correo LIKE @buscar
                                       OR telefono LIKE @buscar";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@buscar", "%" + buscar + "%");
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);
                    dgvEmpleados.DataSource = tabla;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error; " + ex.Message);
            }
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarEmpleados(btnBuscador.Text);
        }

        private void btnBuscador_Click(object sender, EventArgs e)
        {

        }
    }
    
}

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
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Conexion conexion = new Conexion();
                using (MySqlConnection conn = conexion.ObtenerConexion())
                {
                    conn.Open();
                    string query = "INSERT INTO clientes (nombre, correo, telefono, direccion) VALUES (@nombre, @correo, @telefono, @direccion)";
                    using (MySqlCommand cmd = new MySqlCommand (query, conn))
                    {
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@correo", txtCorreoElectro.Text);
                        cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                        cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cliente guardado exitosamente");
                            txtNombre.Clear();
                            txtCorreoElectro.Clear();
                            txtTelefono.Clear();
                            txtDireccion.Clear();
                        }
                        else
                        {
                            MessageBox.Show("No se pudo guardar el cliente");
                        }

                    }
                }
                    
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void CargarClientes(string buscar = "")
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
                                    correo,
                                    telefono,
                                    direccion
                                    FROM clientes
                                    WHERE nombre LIKE @buscar
                                       OR correo LIKE @buscar
                                       OR telefono LIKE @buscar";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@buscar", "%" + buscar + "%");
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);
                    dgvClientes.DataSource = tabla;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error; " + ex.Message);
            }
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarClientes(txtBuscar.Text);
        }
    }
}

using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Pqc.Crypto.Lms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;

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
            string error = "";
            if (txtNombre.Text == string.Empty)
                error += "el campo de Nombre no puede estar vacio";
            else if (txtNombre.Text.Length < 5)
                error += "\nel campo Nombre tiene que tener 3 caracteres minimo";
            if (txtTelefono.Text == string.Empty)
                error += "\nel campo de Telefono no puede estar vacio";
            else if (txtTelefono.Text.Length < 8)
                error += "\nel campo Telefono tiene que tener al menos 8 cacteres";
            if (txtCorreoElectro.Text == string.Empty)
                error += "\nel campo de Correo Electronico no puede estar vacio";
            if (txtDireccion.Text == string.Empty)
                error += "\nel campo de Direccion no puede estar vacio";
            if (error == "")
            {

                try
                {

                    Conexion conexion = new Conexion();
                    using (MySqlConnection conn = conexion.ObtenerConexion())
                    {
                        conn.Open();
                        string query = "INSERT INTO clientes (nombre, correo, telefono, direccion) VALUES (@nombre, @correo, @telefono, @direccion)";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
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
            else
            {
                MessageBox.Show(error, "Error");
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

        private void lbErrorNombre_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                lbErrorNombre.Text = "No dejar vacío";
            }
            else if (txtNombre.Text.Length < 5)
            {
                lbErrorNombre.Text = "El nombre debe de tener mínimo 5 caracteres";
            }
            else
            {
                lbErrorNombre.Text = "";
            }
        }

        private void lbErrortelefono_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                lbErrortelefono.Text = "No dejar vacío";
            }
            else if (txtTelefono.Text.Length < 8)
            {
                lbErrortelefono.Text = "El Telefono debe de tener mínimo 8 caracteres";
            }
            else
            {
                lbErrortelefono.Text = "";
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbErrorCorreo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCorreoElectro.Text))
            {
                lbErrorCorreo.Text = "No dejar vacío";
            }
            else if (txtCorreoElectro.Text.Length < 100)
            {
                lbErrorCorreo.Text = "El Correo electronico no puede quedar vacio";
            }
            else
            {
                lbErrorCorreo.Text = "";
            }
        }

        private void lbErrorDireccion_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                lbErrorDireccion.Text = "No dejar vacío";
            }
            else if (txtDireccion.Text.Length < 100)
            {
                lbErrorDireccion.Text = "La Direccion no puede quedar vacio";
            }
            else
            {
                lbErrorDireccion.Text = "";
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar");
                return;
            }
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "Archivos de Excel (*.xlsx)|*.xlsx";
            guardar.FileName = "Clientes.xlsx";

            if (guardar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XLWorkbook libro = new XLWorkbook();

                    //Crear Hoja
                    var Hoja = libro.Worksheets.Add("Clientes");

                    DataTable tabla = (DataTable)dgvClientes.DataSource;

                    Hoja.Cell(1, 1).InsertTable(tabla);

                    //Guardar el archivo
                   libro.SaveAs(guardar.FileName);
                    MessageBox.Show("Se exporto exitosamente el archivo.");


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar: " + ex.Message);
                }
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                lbErrorNombre.Text = "No dejar vacío";
            }
            else if (txtNombre.Text.Length < 5)
            {
                lbErrorNombre.Text = "El nombre debe de tener mínimo 5 caracteres";
            }
            else
            {
                lbErrorNombre.Text = "";
            }
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                lbErrortelefono.Text = "No dejar vacío";
            }
            else if (txtTelefono.Text.Length < 8)
            {
                lbErrortelefono.Text = "El Telefono debe de tener mínimo 8 caracteres";
            }
            else
            {
                lbErrortelefono.Text = "";
            }
        }

        private void txtCorreoElectro_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCorreoElectro.Text))
            {
                lbErrorCorreo.Text = "No dejar vacío";
            }
            else if (txtCorreoElectro.Text.Length < 100)
            {
                lbErrorCorreo.Text = "El Correo electronico no puede quedar vacio";
            }
            else
            {
                lbErrorCorreo.Text = "";
            }
        }
        
        private void txtDireccion_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                lbErrorDireccion.Text = "No dejar vacío";
            }
            else if (txtDireccion.Text.Length < 100)
            {
                lbErrorDireccion.Text = "La Direccion no puede quedar vacio";
            }
            else
            {
                lbErrorDireccion.Text = "";
            }
        }
    }
}

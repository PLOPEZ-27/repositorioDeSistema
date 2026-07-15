using ClosedXML.Excel;
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
using static System.Windows.Forms.MonthCalendar;

namespace repositoriosistema
{
    public partial class FrmProveedores : Form
    {
        public FrmProveedores()
        {
            InitializeComponent();
        }

        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            CargarProveedor();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string error = "";
            if (txtNombre.Text == string.Empty)
                error += "el campo de Nombre no puede estar vacio";
            else if (txtNombre.Text.Length < 5)
                error += "\nel campo Nombre tiene que tener 5 caracteres minimo";
            if (txtTelefono.Text == string.Empty)
                error += "\nel campo de Telefono no puede estar vacio";
            else if (txtTelefono.Text.Length < 8)
                error += "\nel campo de telefono tiene que tener 8 caracteres minimo";
            if (txtContacto.Text == string.Empty)
                error += "\nel campo de Contacto no puede estar vacio";
            if (txtCorreo.Text == string.Empty)
                error += "\nel campo de Correo Electronico no puede estar vacio";
            if (txtDireccion.Text == string.Empty)
                error += "\nel campo de Direccion no puede estar vacio";
            if (txtProductosSumis.Text == string.Empty)
                error += "\nel campo de Productos de suminstro no puede estar esta vacio";
            if (error == "")
            {
                try
                {

                    Conexion conexion = new Conexion();
                    using (MySqlConnection conn = conexion.ObtenerConexion())
                    {
                        conn.Open();
                        string query = "INSERT INTO proveedores (nombre, contacto, telefono, correo, direccion, productosuministra) VALUES (@nombre, @contacto, @telefono, @correo, @direccion, @productosuministra)";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                            cmd.Parameters.AddWithValue("@contacto", txtContacto.Text);
                            cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                            cmd.Parameters.AddWithValue("@correo", txtCorreo.Text);
                            cmd.Parameters.AddWithValue("@direccion", txtDireccion.Text);
                            cmd.Parameters.AddWithValue("@productosuministra", txtProductosSumis.Text);
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("proveedor guardado exitosamente");
                                txtNombre.Clear();
                                txtContacto.Clear();
                                txtTelefono.Clear();
                                txtCorreo.Clear();
                                txtDireccion.Clear();
                                txtProductosSumis.Clear();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo guardar el proveedor");
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

        private void CargarProveedor(string buscar = "")
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
                                    contacto,
                                    telefono,
                                    correo,
                                    direccion,
                                    productosuministra
                                    FROM proveedores
                                    WHERE nombre LIKE @buscar
                                       OR correo LIKE @buscar
                                       OR telefono LIKE @buscar";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@buscar", "%" + buscar + "%");
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);
                    dgvProveedores.DataSource = tabla;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error; " + ex.Message);
            }
        }

        private void txtbuscar_TextChanged(object sender, EventArgs e)
        {
            CargarProveedor(txtbuscar.Text);
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar");
                return;
            }
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "Archivos de Excel (*.xlsx)|*.xlsx";
            guardar.FileName = "Proveedores.xlsx";

            if (guardar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XLWorkbook libro = new XLWorkbook();

                    //Crear Hoja
                    var Hoja = libro.Worksheets.Add("Proveedores");

                    DataTable tabla = (DataTable)dgvProveedores.DataSource;

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

        private void txtContacto_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtContacto.Text))
            {
                lbErrorContacto.Text = "No dejar vacío";
            }
            else if (txtContacto.Text.Length < 100)
            {
                lbErrorContacto.Text = "El camo de contacto no puede estar vacio";
            }
            else
            {
                lbErrorContacto.Text = "";
            }
        }

        private void txtTelefono_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                lbErrorTelefono.Text = "No dejar vacío";
            }
            else if (txtTelefono.Text.Length < 5)
            {
                lbErrorTelefono.Text = "El nombre debe de tener mínimo 5 caracteres";
            }
            else
            {
                lbErrorTelefono.Text = "";
            }
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                lbErrorCorreo.Text = "No dejar vacío";
            }
            else if (txtCorreo.Text.Length < 5)
            {
                lbErrorCorreo.Text = "El campo de correo no puede estar vacio";
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
                lbErrorDirrecion.Text = "No dejar vacío";
            }
            else if (txtDireccion.Text.Length < 100)
            {
                lbErrorDirrecion.Text = "El campo de direccion no puede estar vacio";
            }
            else
            {
                lbErrorDirrecion.Text = "";
            }
        }

        private void txtProductosSumis_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductosSumis.Text))
            {
                lbErrorSumis.Text = "No dejar vacío";
            }
            else if (txtProductosSumis.Text.Length < 100)
            {
                lbErrorSumis.Text = "El campo de Producos que suministra no puede quedar vacio";
            }
            else
            {
                lbErrorSumis.Text = "";
            }
        }
    }
}

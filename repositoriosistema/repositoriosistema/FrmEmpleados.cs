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
                error += "\nel campo Nombre tiene que tener 5 caracteres minimo";
            if (txtTelefono.Text == string.Empty)
                error += "\nel campo de Telefono no puede estar vacio";
            else if (txtTelefono.Text.Length < 8)
                error += "\nel campo de telefono tiene que tener 8 caracteres minimoo";
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
                                    anios_trabajando
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



        private void btnBuscador_Click(object sender, EventArgs e)
        {

        }

        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar");
                return;
            }
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "Archivos de Excel (*.xlsx)|*.xlsx";
            guardar.FileName = "Empleados.xlsx";

            if (guardar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XLWorkbook libro = new XLWorkbook();

                    //Crear Hoja
                    var Hoja = libro.Worksheets.Add("Empleados");

                    DataTable tabla = (DataTable)dgvEmpleados.DataSource;

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
                lbErrorTelefono.Text = "No dejar vacío";
            }
            else if (txtTelefono.Text.Length < 8)
            {
                lbErrorTelefono.Text = "El nombre debe de tener mínimo 8 caracteres";
            }
            else
            {
                lbErrorTelefono.Text = "";
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
                lbErrorCorreo.Text = "El campo de Correo no puede quedar vacio";
            }
            else
            {
                lbErrorCorreo.Text = "";
            }
        }

        private void txtArea_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtArea.Text))
            {
                lbErrorArea.Text = "No dejar vacío";
            }
            else if (txtArea.Text.Length < 100)
            {
                lbErrorArea.Text = "El campo de Area no puede quedar vacia";
            }
            else
            {
                lbErrorArea.Text = "";
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
                lbErrorDireccion.Text = "el campo de Direccion no puede quedar vacia";
            }
            else
            {
                lbErrorDireccion.Text = "";
            }
        }

        private void txtAniosTrabajo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDireccion.Text))
            {
                lbErrorAnios.Text = "No dejar vacío";
            }
            else if (txtAniosTrabajo.Text.Length < 5)
            {
                lbErrorAnios.Text = "El campo de anios no puede quedar vacio";
            }
            else
            {
                lbErrorAnios.Text = "";
            }
        }

        private void txtbuscar_TextChanged_1(object sender, EventArgs e)
        {
            CargarEmpleados(txtbuscar.Text);
        }
    }
    
}

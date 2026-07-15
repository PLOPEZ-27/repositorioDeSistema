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
    public partial class FrmCategoria : Form
    {
        public FrmCategoria()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string error = "";
            if (txtNombreProduc.Text == string.Empty)
                error += "\nel campo de Nombre no puede estar vacio";
            else if (txtNombreProduc.Text.Length < 3)
                error += "\nel campo Nombre tiene que tener 3 caracteres minimo";
            if (txtdescripcion.Text == string.Empty)
                error += "\nel campo de Descripcion del Producto no puede estar vacio";
            if (error == "")
            {

                try
                {

                    Conexion conexion = new Conexion();
                    using (MySqlConnection conn = conexion.ObtenerConexion())
                    {
                        conn.Open();
                        string query = "INSERT INTO categoria (nombre, descripcion) VALUES (@nombre, @descripcion)";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@nombre", txtNombreProduc.Text);
                            cmd.Parameters.AddWithValue("@descripcion", txtdescripcion.Text);
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("categoria guardado exitosamente");
                                txtNombreProduc.Clear();
                                txtdescripcion.Clear();
                            }
                            else
                            {
                                MessageBox.Show("No se pudo guardar el categoria");
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

        private void CargarCategoria(string buscar = "")
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
                                    descripcion
                                    FROM categoria
                                    WHERE nombre LIKE @buscar
                                       OR descripcion LIKE @buscar";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@buscar", "%" + buscar + "%");
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);
                    dgvCategoria.DataSource = tabla;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error; " + ex.Message);
            }
        }

        private void FrmCategoria_Load(object sender, EventArgs e)
        {
            CargarCategoria();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarCategoria(txtBuscar.Text);
        }

        private void txtNombreProduc_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreProduc.Text))
            {
                lbErrorNombre.Text = "No dejar vacío";
            }
            else if (txtNombreProduc.Text.Length < 5)
            {
                lbErrorNombre.Text = "El nombre debe de tener mínimo 5 caracteres";
            }
            else
            {
                lbErrorNombre.Text = "";
            }
        }

        private void txtdescripcion_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreProduc.Text))
            {
                lbErrorDescrip.Text = "No dejar vacío";
            }
            else if (txtNombreProduc.Text.Length < 100)
            {
                lbErrorDescrip.Text = "la descripcion no puede quedar vacia";
            }
            else
            {
                lbErrorDescrip.Text = "";
            }
        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dgvCategoria.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar");
                return;
            }
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "Archivos de Excel (*.xlsx)|*.xlsx";
            guardar.FileName = "Categoria.xlsx";

            if (guardar.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XLWorkbook libro = new XLWorkbook();

                    //Crear Hoja
                    var Hoja = libro.Worksheets.Add("categoria");

                    DataTable tabla = (DataTable)dgvCategoria.DataSource;

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
    }
}

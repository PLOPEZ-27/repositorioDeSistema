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
                error += "el campo de Nombre no puede estar vacio";
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
    }
}

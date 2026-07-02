using MySql.Data.MySqlClient;
using Org.BouncyCastle.Pqc.Crypto.Frodo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace repositoriosistema
{
    public partial class FrmProducto : Form
    {
        public FrmProducto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string error = "";
            if (txtNombreProduc.Text == string.Empty)
                error += "Error. El campo de Nombre esta vacio, complete";
            else if (txtNombreProduc.Text.Length < 3)
                error += "\nError. Tener como minimo 3 caractereres, completar";
            if (txtCategoria.Text == string.Empty)
                error += "\nError. el campo de categoria esta vacio, complete";
            if (txtPrecioVenta.Text == string.Empty)
                error += "\nError. el campo de Precio de venta esta vacio, complete";
            if (txtStock.Text == string.Empty)
                error += "\nError. el campo de Stock Actual esta vacio, complete";
            if (error == "")
            {
                try
                {
                    Conexion conexion = new Conexion();
                    using (MySqlConnection conn = conexion.ObtenerConexion())
                    {
                        conn.Open();
                        string query = "INSERT INTO productos (nombre, categoria, precio, stock) VALUES (@nombre, @categoria, @precio, @stock)";
                        using (MySqlCommand cmd = new MySqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@nombre", txtNombreProduc.Text);
                            cmd.Parameters.AddWithValue("@categoria", txtCategoria.Text);
                            cmd.Parameters.AddWithValue("@precio", txtPrecioVenta.Text);
                            cmd.Parameters.AddWithValue("@stock", txtStock.Text);
                            int rowsAffected = cmd.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Cliente guardado exitosamente");
                                txtNombreProduc.Clear();
                                txtCategoria.Clear();
                                txtPrecioVenta.Clear();
                                txtStock.Clear();
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
                    MessageBox.Show("Error" + ex.Message);
                }


            }
            else
                MessageBox.Show(error, "Error");
        }

       private void CargarProductos(string buscar = "")
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
                                    categoria,
                                    precio,
                                    stock
                                    FROM productos
                                    WHERE nombre like @buscar
                                       OR categoria like @buscar
                                       OR precio like @buscar";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@buscar", "%" + buscar + "%");
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable tabla = new DataTable();
                    adapter.Fill(tabla);
                    dgvProductos.DataSource = tabla;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
            }
       }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarProductos(txtBuscar.Text);
        }
    }
}
 
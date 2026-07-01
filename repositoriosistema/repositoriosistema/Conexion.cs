using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace repositoriosistema
{
    internal class Conexion
    {
        private string cadenaConexion =
            "server=localhost;database=pos;uid=root;pwd=realhastalamuerte27_";

        public MySqlConnection ObtenerConexion()
        {
            MySqlConnection conexion = new MySqlConnection(cadenaConexion);

                return conexion;
        }
    }
}

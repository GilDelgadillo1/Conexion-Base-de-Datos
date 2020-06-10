using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Drawing;
using System.IO;

namespace Base_de_Datos
{
    class Conexion
    {
        public DataTable dt = new DataTable();

        public String strConexion = "server = localhost; user id = root; password =123456; database = net";

        public MySqlConnection conectar;

        public bool abrir()

        {

            try
            {
                conectar = new MySqlConnection(strConexion);
                conectar.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void cerrar()
        {
            conectar.Close();
        }

        public bool ejecutarQuery(string query)

        {

            try

            {

                abrir();

                MySqlCommand comando = new MySqlCommand(query, conectar);

                comando.ExecuteNonQuery();

                cerrar();

                return true;

            }

            catch (Exception er)

            {

                System.Windows.Forms.MessageBox.Show(er.Message);

                return false;

            }

        }


        public DataTable cargarDatos(String query)

        {

            try

            {

                abrir();

                MySqlDataAdapter comando = new MySqlDataAdapter(query,strConexion);

                comando.Fill(dt);

                return dt;

            }

            catch (Exception er)

            {

                return dt;

            }

        }
    }
}

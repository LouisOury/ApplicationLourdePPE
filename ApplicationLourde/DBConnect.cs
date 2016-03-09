using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLourde
{
    public class DBConnect
    {
        public MySqlConnection con;
        public MySqlCommand com;
        public DataTable dt;
        public DataSet ds;
        public DataView myview;

        public DBConnect()
        {
            string server = "localhost";
            string database = "megacastingv2";
            string uid = "root";
            string password = "";
            string connectionString;

            connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            con = new MySqlConnection(connectionString);
        }

        public void openConnect()
        {
            if (con != null && con.State == ConnectionState.Closed)
            {
                con.Open();
                //MessageBox.Show("Connexion BDD réussie !");
            }
        }

        public void closeConnect()
        {
            if (con != null && con.State == ConnectionState.Open)
            {
                con.Close();
                //MessageBox.Show("Déconnexion BDD réussi");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace C969_Kee.Database
{
    public class DBConnection
    {

        public static MySqlConnection Conn { get; set; }

        

        public static void startConnection()
        {
            try
            {
                string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
                Conn = new MySqlConnection(constr);

                //open the connection
                Conn.Open();

                //MessageBox.Show("Connection is open");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        public static void closeConnection()
        {
            try
            {
                if (Conn != null)
                {
                    Conn.Close();
                }
                Conn = null;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);

            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C969_Kee.Database;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Math.Field;
using Calendar = C969_Kee.Forms.Calendar;


namespace C969_Kee
{
    public partial class loginForm : Form
    {
        public MySqlCommand command;
        public MySqlDataReader dr;
        public loginForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        


        private void checkB_Click(object sender, EventArgs e)
        {
            MySqlConnection c = DBConnection.Conn;

            if (c.State == ConnectionState.Open)
            {
                MessageBox.Show("Connection Open");
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string userName, password;

            userName = usernameTextBox.Text;
            password = passwordTextBox.Text;

            try
            {
                String selectQuery = "SELECT * FROM user WHERE userName = '" + userName + "' AND password = '" + password + "'";
                command = new MySqlCommand(selectQuery, DBConnection.Conn);
                command.Parameters.AddWithValue("userName", userName);
                command.Parameters.AddWithValue("@password", password);
                dr = command.ExecuteReader();

                if (dr.Read())
                {
                    MessageBox.Show("Login Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    //string LoggedUserName = userName;
                    dr.Close();
                    Calendar calendarForm = new Calendar();
                    calendarForm.Show();
                    

                }
                else
                {
                    MessageBox.Show("Invalid login details: 'Error' ");
                    usernameTextBox.Clear();
                    passwordTextBox.Clear();
                    
                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            
            
        }
    }
}

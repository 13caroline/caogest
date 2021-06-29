using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Add MySQL library
using MySql.Data.MySqlClient;

namespace CaoGest.src
{
    class DbConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string dbId;
        private string dbPassword;

        //assign the atributes
        public DbConnect()
        {
            server = "localhost";
            database = "caogest";
            dbId = "root";
            dbPassword = "root";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + dbId + ";" + "PASSWORD=" + dbPassword + ";";
            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection(){
            try
            {
                connection.Open();
                return true; 
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break; 

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Insert statement
        public void Insert()
        {
            string query = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";

      
            if (this.OpenConnection() == true)
            {
               
                MySqlCommand cmd = new MySqlCommand(query, connection);

             
                cmd.ExecuteNonQuery();

               
                this.CloseConnection();
            }
        }

        //Update statement
        public void Update(string nome)
        {
            string query = "UPDATE Canil SET CapacidadeTotal=30 WHERE Nome=nome";

            //Open connection
            if (this.OpenConnection() == true)
            {
                
                MySqlCommand cmd = new MySqlCommand();
         
                cmd.CommandText = query;
              
                cmd.Connection = connection;

                
                cmd.ExecuteNonQuery();

               
                this.CloseConnection();
            }
        }

        //Delete statement
        public void Delete()
        {
            string query = "DELETE FROM tableinfo WHERE name='John Smith'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }


    }
}

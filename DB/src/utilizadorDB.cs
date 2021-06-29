using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace CaoGest.src
{
    public class utilizadorDB
    {
        //-----------------------------------------------------------------------------------INSERT---------------------------------------------------------------------------
        public static void insereUser(string email, string nome, string password, DateTime nasc, string distrito, string rua, string localidade, string cc,int sexo,string contacto)
        {
            try
            {
                DbConnect dB = new DbConnect();
                string sqlFormattedDate = nasc.ToString("yyyy-MM-dd HH:mm:ss.fff");
                //  Console.Write(email+","+nome+","+password+","+distrito+","+rua+","+localidade+","+cc+","+sexo+'\n');
               
                string query = "INSERT INTO User VALUES ('" + email + "'" + "," + "'" + password + "'" + "," + 1 +")";
                string query2 = "INSERT INTO Utilizador (User_Email,Nome,Data_de_Nascimento,Distrito,Rua,Localidade,CC,Sexo,Contacto) VALUES (" + "'" + email + "'" + ", " + "'" + nome + "'" + "," + "'" + sqlFormattedDate + "'" + ", " + "'" + distrito + "'" + "," + "'" + rua + "'" + "," + "'" + localidade + "'" + "," + "'" + cc + "'"  + ","+sexo+","+"'"+contacto+"'"+")";
               // Console.Write(query2);
                //open connection
                if (dB.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, dB.getConnection());
                    MySqlCommand cmd1 = new MySqlCommand(query2, dB.getConnection());



                    //Execute command
                    cmd.ExecuteNonQuery();
                    cmd1.ExecuteNonQuery();

                    //close connection
                    dB.CloseConnection();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException) { };

        }



        //---------------------------------------------------------------------DELETS-----------------------------------------------------------------------

        //DELETE Canil
        public static void deleteUser(string email)
        {
            try
            {
                DbConnect dB = new DbConnect();
                string query = "DELETE FROM User WHERE Email=" + "'" + email + "'";
                string query2 = "DELETE FROM Utilizador WHERE User_Email = '" + email + "'";
                Console.Write(query);
                //open connection
                if (dB.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, dB.getConnection());
                    MySqlCommand cmd1 = new MySqlCommand(query2, dB.getConnection());
                    //Execute command
                    cmd1.ExecuteNonQuery();
                    cmd.ExecuteNonQuery();

                    //close connection
                    dB.CloseConnection();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException) { };

        }

        //---------------------------------------------------------------------UPDATES-----------------------------------------------------------------------

        //UPDATE Password
        public static void updatePass(string email, string newPass)
        {
            try
            {
                DbConnect dB = new DbConnect();
                string query = "UPDATE User SET Password=" + "'" + newPass + "'" + " WHERE Email=" + "'" + email + "'";

                //open connection
                if (dB.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, dB.getConnection());

                    //Execute command
                    cmd.ExecuteNonQuery();
                    //cmd.ExecuteScalar();

                    //close connection
                    dB.CloseConnection();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException) { };

        }

        /*/UPDATE Email
        public static void updateEmail(string email, string newContacto)
        {
            try
            {
                DbConnect dB = new DbConnect();
                string query = "UPDATE User SET Email=" + "'" + newContacto + "'" + " WHERE Email=" + "'" + email + "'";
                string query2 = "UPDATE Utilizador SET User_Email='" + newContacto + "'" + " WHERE User_Email='" + email + "'";
                Console.Write(query);

                //open connection
                if (dB.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, dB.getConnection());
                    MySqlCommand cmd1 = new MySqlCommand(query2, dB.getConnection());


                    //Execute command
                    cmd1.ExecuteNonQuery();
                    cmd.ExecuteNonQuery();

                    //close connection
                    dB.CloseConnection();
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException) { };

        }
        */

        //---------------------------------------------------------------------SELECTS-----------------------------------------------------------------------

        public static bool containsKey(string key)
        {
            try
            {
                DbConnect dB = new DbConnect();
                string query = "SELECT COUNT(*) FROM User WHERE Email = '" +key + "'";

                //open connection
                if (dB.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, dB.getConnection());

                    //Execute command
                    Int32 valor  = Convert.ToInt32(cmd.ExecuteScalar());

                    //close connection
                    dB.CloseConnection();

                    if (valor == 0)
                    {
                        return false;
                    }
                    else return true;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException) { };
            return false;
        }

        public static bool valPass(string key, string value)
        {
            try
            {
                DbConnect dB = new DbConnect();
                string query = "SELECT Password FROM User WHERE Email = '" + (String)key + "'";

                //open connection
                if (dB.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, dB.getConnection());

                    String res = null;

                    //Execute command
                    MySqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        res = (string)dataReader["Password"];
                    }
                    //cmd.ExecuteScalar();

                    dataReader.Close();
                    //close connection
                    dB.CloseConnection();

                    if (res == value)
                    {
                        return true;
                    }
                    else return false;
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException) { };
            return false;
        }

        public static List<String> getFavoritos(string email)
        {

            List<String> list = new List<String>();
            try
            {
                DbConnect dB = new DbConnect();
                string query = "SELECT * from Favoritos WHERE Utilizador_User_Email=" + "'" + email + "'";
                Console.Write(query + '\n');

                //Open connection
                if (dB.OpenConnection() == true)
                {

                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, dB.getConnection());
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    
                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        int x = (int)dataReader["Cao_idCao"];
                        list.Add(x.ToString());


                    }

                    //close Data Reader
                    dataReader.Close();

                    //close Connection
                    dB.CloseConnection();

                    //return list to be displayed
                    return list;
                }
                else
                {
                    return list;
                }
            }
            catch (System.ArgumentOutOfRangeException) { }
            catch (System.InvalidCastException) { }
            return list;
        }


        public static List<String> selectFavoritos(string email)
        {

            List<String> list = new List<String>();
            try
            {
                DbConnect dB = new DbConnect();
                string query = "SELECT * from Favoritos WHERE Utilizador_User_Email=" + "'" + email + "'";
                Console.Write(query + '\n');

                //Open connection
                if (dB.OpenConnection() == true)
                {

                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, dB.getConnection());
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();


                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        int x = (int)dataReader["Cao_idCao"];
                        list.Add(x.ToString());


                    }

                    //close Data Reader
                    dataReader.Close();

                    //close Connection
                    dB.CloseConnection();

                    //return list to be displayed
                    return list;
                }
                else
                {
                    return list;
                }
            }
            catch (System.ArgumentOutOfRangeException) { }
            catch (System.InvalidCastException) { }
            return list;
        }


    }
}

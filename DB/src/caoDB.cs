using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace CaoGest.src
{
    class caoDB
    {
        public static void insereCao(int idcao,string nome,string sexo,string descricao,int estado,string raca,string cor,string canilemail,int idade,int esterilizacao,string porte)
        {
            try
            {
                DbConnect dB = new DbConnect();
                string query = "INSERT INTO Cao (idCao,Nome,Sexo,Descricao,Estado,Raca,Cor,Canil_Email,Idade,Esterilizacao,Porte) " +
                    "VALUES ("  + idcao + ", " + "'" + nome + "'" + ", " + "'" + sexo + "'" + "," + "'"+ descricao + "'"+", " + estado + ", " + "'" + raca + "'" + ", " + "'" + cor + "'" + ","+"'"+canilemail+"'"+"," + idade + "," + esterilizacao+ "," + "'" + porte + "'" + ")";
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


        public static void insereFoto(int idF, string path,int id)
        {
            try
            {
                DbConnect dB = new DbConnect();
                string query = "INSERT INTO Fotografia VALUES(" + idF + ","+ "'" + path + "'"+"," + id + ")";
                Console.Write(query);
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



        //UPDATE capacidade Total 
        public static void updateIdade(int id, int idade)
        {
            try
            {
                DbConnect dB = new DbConnect();
                string query = "UPDATE Cao SET Idade=" + idade + " WHERE Cao.IdCao=" + id ;

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


        public static void updateDescricao(int id, string descricao)
        {
            try
            {

                DbConnect dB = new DbConnect();
                string query = "UPDATE Cao SET Descricao=" + "'"+descricao+"'" + " WHERE Cao.IdCao=" + id;

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

        public static void updateEstado(int id, int estado)
        {
            try
            {

                DbConnect dB = new DbConnect();
                string query = "UPDATE Cao SET Estado=" + estado + " WHERE Cao.IdCao=" + id;

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

        public static void updateEsterilizacao(int id, int esterilizacao)
        {
            try
            {

                DbConnect dB = new DbConnect();
                string query = "UPDATE Cao SET Esterilizacao=" + esterilizacao + " WHERE Cao.IdCao=" + id;

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

        public static void deleteCao(int id)
        {
            try
            {
                DbConnect dB = new DbConnect();
                string query = "DELETE FROM Cao WHERE idCao=" + id;

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


        public static List<string> SelectCao(int id)
        {
            DbConnect dB = new DbConnect();
            string query = "SELECT * FROM Cao WHERE idCao=" +id;

            //Create a list to store the result
            List<string> list = new List<string>();
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
                    
                    int x = (int)dataReader["idCao"];
                    list.Add(x.ToString());
                    list.Add((string)dataReader["Nome"]);
                    list.Add((string)dataReader["Sexo"]);
                    list.Add((string)dataReader["Descricao"]);
                    int y = (int)dataReader["Estado"];
                    list.Add(y.ToString());
                    list.Add((string)dataReader["Raca"]);
                    list.Add((string)dataReader["Cor"]);
                    list.Add((string)dataReader["Canil_Email"]);
                    int z = (int)dataReader["Idade"];
                    list.Add(z.ToString());
                    bool w = (bool)dataReader["Esterilizacao"];
                    list.Add(w.ToString());
                    list.Add((string)dataReader["Porte"]);                 

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


        public static List<List<String>> pesquisaCaesCanil(string raca, int idade, char sexo, string cor, char porte, string emailC)
        {
            List<List<String>> list = new List<List<String>>();
            try
            {
                DbConnect dB = new DbConnect();
                string query = "SELECT * from Cao WHERE idCao=idCao AND Raca=" + "'" + raca + "'" + "AND Idade=" + "'" + idade + "'" + "AND Sexo=" + "'" + sexo + "'" + "AND cor=" + "'" + cor + "'" + "AND Porte=" + "'" + porte + "'" + "AND CAnil_Email=" + "'" + emailC + "'";

                //Open connection
                if (dB.OpenConnection() == true)
                {

                    //Create Command
                    MySqlCommand cmd = new MySqlCommand(query, dB.getConnection());
                    //Create a data reader and Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    int i = 0;
                    //Read the data and store them in the list
                    while (dataReader.Read())
                    {
                        List<String> subList = new List<String>();
                        int x = (int)dataReader["IdCao"];
                        subList.Add(x.ToString());
                        subList.Add((string)dataReader["Nome"]);
                        subList.Add((string)dataReader["Sexo"]);
                        subList.Add((string)dataReader["Descricao"]);
                        int y = (int)dataReader["Estado"];
                        subList.Add(y.ToString());
                        subList.Add((string)dataReader["Raca"]);
                        subList.Add((string)dataReader["Cor"]);
                        DateTime d = (DateTime)dataReader["DataAdocao"];
                        subList.Add(d.ToString());
                        int z = (int)dataReader["Idade"];
                        subList.Add(z.ToString());
                        bool w = (bool)dataReader["Esterilizacao"];
                        subList.Add(w.ToString());
                        subList.Add((string)dataReader["Porte"]);
                        list.Add(subList);
                        i++;


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

        public static List<int> pesquisaCaes(string sexo, string porte,List<string> cor,int idade,string raca,string distrito)
        {
            List<int> list = new List<int>();
            try
            {
                DbConnect dB = new DbConnect();
                string querySexo = "";
                string queryPorte = "";
                string queryCor = "";
                string queryIdade = "";
                string queryRaca = "";
                string queryDistrito = "";

                if (!(sexo.Equals("NA")))
                 querySexo = " AND Sexo='" + sexo + "'";
                if(!(porte.Equals("NA")))
                 queryPorte = " AND Porte='" + porte + "'";
                if (cor.Count != 0) {
                    queryCor = " AND Cor='" + cor[0] + "'";
                    for (int i = 1; i < cor.Count; i++)
                    {
                        queryCor = queryCor + "OR Cor='" + cor[i] + "'";
                    } }
                if(idade!=-1)
                 queryIdade = " AND Idade=" + idade.ToString();
                if(!(raca.Equals("NA")))
                 queryRaca = " AND Raca='" + raca + "'";
                if(!(distrito.Equals("NA")))
                 queryDistrito = " And Canil.Distrito='" + distrito + "'";

                string query = "SELECT idCao FROM Cao JOIN Canil ON Canil_Email=Email WHERE idCao>=-2 "+querySexo+queryPorte+queryCor+queryIdade+queryRaca+queryDistrito;
                Console.Write(query);
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
                        int x = (int)dataReader["IdCao"];
                        list.Add(x);

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

        public static bool containsKey(int key)
        {
            try
            {
                DbConnect dB = new DbConnect();
                string query = "SELECT COUNT(*) FROM Cao WHERE idCao =" +key;

                //open connection
                if (dB.OpenConnection() == true)
                {
                    //create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, dB.getConnection());

                    //Execute command
                    Int32 valor = Convert.ToInt32(cmd.ExecuteScalar());

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

        public static List<string> getFotografias(int id)
        {
            DbConnect dB = new DbConnect();
            string query = "SELECT * FROM Fotografia WHERE Cao_idCao=" + id;

            //Create a list to store the result
            List<string> list = new List<string>();
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

                    int x = (int)dataReader["idFotografia"];
                    list.Add(x.ToString());
                    list.Add((string)dataReader["Path"]);
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
    }
}

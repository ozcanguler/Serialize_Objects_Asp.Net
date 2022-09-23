using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace Button.Utility
{
    public class GamesDAO
    {
        bool success = false;
        public bool SaveGame(GameObject gameObject)
        {
            String connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            string queryString = "INSERT INTO dbo.Games (GameString) VALUES (@GameString)";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection))
                {
                    sqlCommand.Parameters.Add("@GameString", SqlDbType.Text).Value = gameObject.JSONstring;
                    try
                    {
                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();
                        sqlConnection.Close();
                        success = true;
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine("failure");
                        Debug.WriteLine(e.Message);
                    }

                }
            }
            return success;
        }
        public GameObject LoadGame()
        {
           
            GameObject gameObject = new GameObject(1, "");


            String connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Test;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            string queryString = "SELECT TOP 1 * FROM dbo.Games ORDER BY Id DESC";

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection))
                {

                    try
                    {
                        sqlConnection.Open();
                        SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                        

                        while (sqlDataReader.Read())
                        {
                            gameObject.Id = sqlDataReader.GetInt32(0);
                            gameObject.JSONstring= sqlDataReader.GetString(1);
                        }

                        sqlConnection.Close();
                        
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine("failure");
                        Debug.WriteLine(e.Message);
                    }

                }
            }
            return gameObject;

        }
    }
}
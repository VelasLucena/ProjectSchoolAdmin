using MySqlConnector;
using System.Data;
using SystemModels;
using Microsoft.Extensions.Configuration;

namespace DataBase
{
    public class SystemDAO
    {
        public static Token GetTokenExist()
        {
            DateTime today = DateTime.Now;

            try
            {
                var myConnectionString1 = Configuration.GetConnectionString("MyConn");

                using (var connection = new MySqlConnection(connectionString))
                {
                    MySqlCommand command = new MySqlCommand("loopData", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("newGameID", 1);
                    command.Connection.Open();
                    var result = command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return;
        }
    }
}
using ProjectApi.DataBase;
using System.Data;
using ServicesEnum;
using MySqlConnector;
using System.Reflection;

namespace ProjectApi.ConnectDB
{
    public class ConnectDataBase
    {
        public static DataTable DbPost(string procedure, SchemaDB schema, object parameters)
        {
            ConnectStringManager manager = new ConnectStringManager();

            using (MySqlConnection connection = new MySqlConnection(manager.GetConnectString(schema)))
            {
                using(MySqlCommand command = new MySqlCommand(procedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    foreach(PropertyInfo model in parameters.GetType().GetProperties())
                    {
                        command.Parameters.AddWithValue("Param" + model.Name, model.GetValue(parameters, null));
                    }
                    command.Connection.Open();
                    var result = command.ExecuteNonQuery();
                    command.Connection.Close();
                }

                return null;
            }
        }

        public static DataTable DbGet(Procedures proc, SchemaDB schema, object parameters)
        {
            string? procedure= Enum.GetName(typeof(Procedures), proc);

            ConnectStringManager manager = new ConnectStringManager();

            DataTable data = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(manager.GetConnectString(schema)))
            {
                using (MySqlCommand command = new MySqlCommand(procedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    foreach (PropertyInfo model in parameters.GetType().GetProperties())
                    {
                        command.Parameters.AddWithValue("Param" + model.Name, model.GetValue(parameters, null));
                    }

                    command.Connection.Open();

                    data.Load(command.ExecuteReader());

                    command.Connection.Close();
                }

                return data;
            }
        }
    }
}



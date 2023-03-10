using ProjectApi.DataBase;
using System.Data;
using ServicesEnum;
using MySqlConnector;
using System.Reflection;

namespace ProjectApi.ConnectDB
{
    public class ConnectDataBase
    {
        public static bool DbPost(Procedures proc, SchemaDB schema, List<object> parameters)
        {
            string? procedure = Enum.GetName(typeof(Procedures), proc);

            ConnectStringManager manager = new ConnectStringManager();

            DataTable data = new DataTable();

            string connecString = manager.GetConnectString(schema);

            using (MySqlConnection connection = new MySqlConnection(connecString))
            {
                using (MySqlCommand command = new MySqlCommand(procedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    List<string> paramList = new List<string>();

                    foreach(var parameter in parameters)
                    {
                        foreach (PropertyInfo model in parameter.GetType().GetProperties())
                        {
                            string param = "Param" + model.Name;

                            if (!paramList.Any(s => param.IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0))
                            {
                                command.Parameters.AddWithValue(param, model.GetValue(parameter, null));
                                paramList.Add(param);
                            }
                        }
                    }

                    connection.Open();

                    data.Load(command.ExecuteReader());

                    connection.Close();
                }

                return true;
            }
        }

        public static DataTable DbGet(Procedures proc, SchemaDB schema, List<object> parameters)
        {
            string? procedure= Enum.GetName(typeof(Procedures), proc);

            ConnectStringManager manager = new ConnectStringManager();

            DataTable data = new DataTable();

            string connecString = manager.GetConnectString(schema);

            using (MySqlConnection connection = new MySqlConnection(connecString))
            {
                using (MySqlCommand command = new MySqlCommand(procedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    List<string> paramList = new List<string>();

                    foreach (var parameter in parameters)
                    {
                        if(parameter != null)
                        {
                            foreach (PropertyInfo model in parameter.GetType().GetProperties())
                            {
                                if (model.GetValue(parameter, null) == null)
                                    continue;

                                string param = "Param" + model.Name;

                                if (!paramList.Any(s => param.IndexOf(s, StringComparison.OrdinalIgnoreCase) >= 0))
                                {
                                    command.Parameters.AddWithValue(param, model.GetValue(parameter, null));
                                    paramList.Add(param);
                                }
                            }
                        }                  
                    }

                    connection.Open();

                    data.Load(command.ExecuteReader());

                    connection.Close();
                }

                return data;
            }
        }
    }
}



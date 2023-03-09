using SystemModels;
using ServicesEnum;
using ProjectApi.ConnectDB;
using System.Data;
using System.Reflection;
using ProfileModels;

namespace ProjectApi.SystemDAO
{
    public class SchemaProfileDAO
    {
        #region Get

        public static UserModel GetUserByRegisterNumber(UserModel user)
        {
            DataTable datatable = new DataTable();

            try
            {
                object consult = user;

                datatable = ConnectDataBase.DbGet(Procedures.GetUserByRegisterNumber, SchemaDB.Profile, consult);

                if (datatable.Rows.Count > 0)
                {
                    foreach (DataRow row in datatable.Rows)
                    {
                        foreach (DataColumn column in row.Table.Columns)
                        {
                            if (row[column] != DBNull.Value)
                            {
                                PropertyInfo prop = user.GetType().GetProperty(column.ColumnName);

                                if (prop != null)
                                {
                                    object result = Convert.ChangeType(row[column], prop.PropertyType);
                                    prop.SetValue(user, result, null);
                                    continue;
                                }
                                else
                                {
                                    FieldInfo fld = user.GetType().GetField(column.ColumnName);
                                    if (fld != null)
                                    {
                                        object result = Convert.ChangeType(row[column], fld.FieldType);
                                        fld.SetValue(user, result);
                                    }
                                }
                            }
                        }
                    }                   
                }
                else
                    return null;

            }
            catch (Exception ex)
            {

            }

            return user;
        }

        #endregion

        #region Post

        public static bool InsertUser(UserModel createUser)
        {
            bool result = true;

            try
            {
                List<object> list = new List<object>();
                list.Add(createUser);
                list.Add(createUser.UserDetails);
                list.Add(createUser.UserPermissions);

                result = ConnectDataBase.DbPost(Procedures.InsertUser, SchemaDB.Profile, list);

            }
            catch (Exception ex)
            {

            }

            return result;
        }

        #endregion
    }
}

using SystemModels;
using ServicesEnum;
using ProjectApi.ConnectDB;
using System.Data;
using System.Reflection;
using ProfileModels;
using InfoEnum;

namespace ProjectApi.SystemDAO
{
    public class SchemaProfileDAO
    {
        #region Get

        public static UserModel GetUserByRegisterNumberAndPassword(UserModel user)
        {
            DataTable datatable = new DataTable();

            try
            {
                List<object> list = new List<object>();
                list.Add(user);

                datatable = ConnectDataBase.DbGet(Procedures.GetUserByRegisterNumberAndPassword, SchemaDB.Profile, list);

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
                                    object result;

                                    Type typeCode = prop.PropertyType;

                                    if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                                    {
                                        typeCode = prop.PropertyType.GetGenericArguments()[0];

                                        if (typeCode.IsEnum)
                                            typeCode = prop.PropertyType;
                                    }

                                    switch (Type.GetTypeCode(typeCode))
                                    {
                                        case TypeCode.DateTime:
                                            result = Convert.ToDateTime(row[column].ToString());
                                            prop.SetValue(user, result, null);
                                            continue;
                                        case TypeCode.Decimal:
                                            result = Convert.ToDecimal(row[column].ToString());
                                            prop.SetValue(user, result, null);
                                            continue;
                                        case TypeCode.String:
                                            result = row[column].ToString();
                                            prop.SetValue(user, result, null);
                                            continue;
                                        case TypeCode.Int32:
                                            result = Convert.ToInt32(row[column].ToString());
                                            prop.SetValue(user, result, null);
                                            continue;
                                        case TypeCode.Boolean:
                                            result = Convert.ToInt32(row[column].ToString());
                                            prop.SetValue(user, result, null);
                                            continue;
                                        case TypeCode.Object:
                                            result = Enum.Parse(prop.PropertyType.GetGenericArguments()[0], row[column].ToString());
                                            prop.SetValue(user, result, null);
                                            continue;
                                        default:
                                            result = Convert.ChangeType(row[column], prop.PropertyType);
                                            prop.SetValue(user, result, null);
                                            continue;
                                    }
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

        public static UserModel GetUserByRegisterNumber(UserModel user)
        {
            DataTable datatable = new DataTable();

            try
            {
                List<object> list = new List<object>();
                list.Add(user);

                datatable = ConnectDataBase.DbGet(Procedures.GetUserByRegisterNumber, SchemaDB.Profile, list);

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
                                    object result;

                                    Type typeCode = prop.PropertyType;

                                    if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                                    {
                                        typeCode = prop.PropertyType.GetGenericArguments()[0];

                                        if (typeCode.IsEnum)
                                            typeCode = prop.PropertyType;
                                    }

                                    switch (Type.GetTypeCode(typeCode))
                                    {
                                        case TypeCode.DateTime:
                                            result = Convert.ToDateTime(row[column].ToString());
                                            prop.SetValue(user, result, null);
                                            continue;
                                        case TypeCode.Decimal:
                                            result = Convert.ToDecimal(row[column].ToString());
                                            prop.SetValue(user, result, null);
                                            continue;
                                        case TypeCode.String:
                                            result = row[column].ToString();
                                            prop.SetValue(user, result, null);
                                            continue;
                                        case TypeCode.Int32:
                                            result = Convert.ToInt32(row[column].ToString());
                                            prop.SetValue(user, result, null);
                                            continue;
                                        case TypeCode.Boolean:
                                            result = Convert.ToInt32(row[column].ToString());
                                            prop.SetValue(user, result, null);
                                            continue;
                                        case TypeCode.Object:
                                            result = Enum.Parse(prop.PropertyType.GetGenericArguments()[0], row[column].ToString());
                                            prop.SetValue(user, result, null);
                                            continue;
                                        default:
                                            result = Convert.ChangeType(row[column], prop.PropertyType);
                                            prop.SetValue(user, result, null);
                                            continue;
                                    }
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

        public static UserModel GetUserById(UserModel user)
        {
            DataTable datatable = new DataTable();
            Type type;

            try
            {
                List<object> list = new List<object>();
                list.Add(user);

                datatable = ConnectDataBase.DbGet(Procedures.GetUserById, SchemaDB.Profile, list);

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
                                    object result;

                                    Type typeCode = prop.PropertyType;

                                    if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                                    {
                                        typeCode = prop.PropertyType.GetGenericArguments()[0];

                                        if (typeCode.IsEnum)
                                            typeCode = prop.PropertyType;
                                    }

                                    switch (Type.GetTypeCode(typeCode))
                                    {
                                        case TypeCode.DateTime:
                                            result = Convert.ToDateTime(row[column].ToString());
                                            prop.SetValue(user, result, null);
                                            continue;
                                        case TypeCode.Decimal:
                                            result = Convert.ToDecimal(row[column].ToString());
                                            prop.SetValue(user, result, null);
                                            continue;
                                        case TypeCode.String:
                                            result = row[column].ToString();
                                            prop.SetValue(user, result, null);
                                            continue;
                                        case TypeCode.Int32:
                                            result = Convert.ToInt32(row[column].ToString());
                                            prop.SetValue(user, result, null);
                                            continue;
                                        case TypeCode.Boolean:
                                            result = Convert.ToInt32(row[column].ToString());
                                            prop.SetValue(user, result, null);
                                            continue;
                                        case TypeCode.Object:
                                            result = Enum.Parse(prop.PropertyType.GetGenericArguments()[0], row[column].ToString());
                                            prop.SetValue(user, result, null);
                                            continue;
                                        default:
                                            result = Convert.ChangeType(row[column], prop.PropertyType);
                                            prop.SetValue(user, result, null);
                                            continue;
                                    }
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

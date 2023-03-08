using SystemModels;
using ServicesEnum;
using ProjectApi.ConnectDB;
using System.Data;
using System.Reflection;

namespace ProjectApi.SystemDAO
{
    public class SchemaSystemDAO
    {
        #region Get

        public static Token GetTokenGovByDate()
        {
            Token token = new Token();
            DataTable datatable = new DataTable();

            try
            {
                object consult = token;

                datatable = ConnectDataBase.DbGet(Procedures.GetTokenByDate, SchemaDB.System, consult);

                if (datatable != null)
                {
                    foreach (DataRow row in datatable.Rows)
                    {
                        foreach (DataColumn column in row.Table.Columns)
                        {
                            if (row[column] != DBNull.Value)
                            {
                                PropertyInfo prop = token.GetType().GetProperty(column.ColumnName);

                                if (prop != null)
                                {
                                    object result = Convert.ChangeType(row[column], prop.PropertyType);
                                    prop.SetValue(token, result, null);
                                    continue;
                                }
                                else
                                {
                                    FieldInfo fld = token.GetType().GetField(column.ColumnName);
                                    if (fld != null)
                                    {
                                        object result = Convert.ChangeType(row[column], fld.FieldType);
                                        fld.SetValue(token, result);
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

            return token;
        }

        #endregion

        #region Post

        public static Token InsertTokenGov()
        {
            Token token = new Token();
            DataTable dataRow = new DataTable();

            try
            {
                object consult = token;

                dataRow = ConnectDataBase.DbGet(Procedures.GetTokenByDate, SchemaDB.System, consult);

                if (dataRow != null)
                {
                    foreach (DataRow row in dataRow.Rows)
                    {
                        foreach (DataColumn column in dataRow.Columns)
                        {
                            if (row[column] != DBNull.Value)
                            {
                                PropertyInfo prop = token.GetType().GetProperty(column.ColumnName);

                                if (prop != null)
                                {
                                    object result = Convert.ChangeType(row[column], prop.PropertyType);
                                    prop.SetValue(token, result, null);
                                    continue;
                                }
                                else
                                {
                                    FieldInfo fld = token.GetType().GetField(column.ColumnName);
                                    if (fld != null)
                                    {
                                        object result = Convert.ChangeType(row[column], fld.FieldType);
                                        fld.SetValue(token, result);
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

            return token;
        }

        #endregion
    }
}

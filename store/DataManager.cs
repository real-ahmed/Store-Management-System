using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace store
{
    internal class DataManager
    {
        private static SqlConnection cn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=StoreManageDB;Integrated Security=True;");
        private static SqlCommand cm = new SqlCommand();

        public static DataTable SelectData(string procedureName, Dictionary<string, object> parameters = null)
        {
            DataTable resultTable = new DataTable();
            try
            {
                Open();
                cm.Connection = cn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = procedureName;
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        cm.Parameters.AddWithValue(parameter.Key, parameter.Value);
                    }
                }
                SqlDataAdapter DA = new SqlDataAdapter(cm);
                DA.Fill(resultTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Close();
            }
            return resultTable;
        }


        public static void ExecuteProcedure(string procedureName, Dictionary<string, object> parameters = null)
        {
            try
            {
                Open();
                cm.Connection = cn;
                cm.CommandType = CommandType.StoredProcedure;
                cm.CommandText = procedureName;
                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        cm.Parameters.AddWithValue(parameter.Key, parameter.Value);
                    }
                }
                cm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Close();
            }
        }

        static void Open()
        {
            if (cn.State != ConnectionState.Open)
            {
                cn.Open();
            }
        }

        static void Close()
        {
            if (cn.State != ConnectionState.Closed)
            {
                cm.Parameters.Clear();
                cn.Close();

            }
        }
    }
}

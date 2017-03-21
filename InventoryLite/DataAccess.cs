using System;
using System.Data;
using System.Net;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryLite
{
    class DataAccess
    {
        public static string DSNHost = @"SERVER=localhost\SQLEXPRESS;DATABASE=InventoryLite;Trusted_Connection=Yes;";

        public DataAccess()
        {

        }

        public static DataSet GetItems()
        {
            string query = "Select * FROM VAD ORDER BY Category ASC";

            DataSet dataSet = SendSelectQuery(DSNHost, query);

            if (dataSet.Tables[0].Rows.Count > 0)
            {
                return dataSet;
            }
            return null;
        }

        public static int InsertNewItem(string category, string sku, string description, decimal price, decimal quantity, decimal cost)
        {
            decimal value = price * quantity;
            string query = $"INSERT INTO VAD VALUES ('{category}', '{sku}', '{description}', {price}, {quantity}, {cost}, {value})";

            int response = SendNonSelectQuery(DSNHost, query);

            return response;
        }

        public static DataSet SendSelectQuery(string connectionString, string query)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                DataSet dataSet = new DataSet();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, connection);
                sqlDataAdapter.Fill(dataSet);
                connection.Close();
                return dataSet;
            }
        }

        public static int SendNonSelectQuery(string connectionString, string query)
        {
            int result = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    result = cmd.ExecuteNonQuery();
                }
                connection.Close();
            }
            return result;
        }
    }
}

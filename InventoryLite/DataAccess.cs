﻿using System;
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
            string createDbQuery = @"USE [InventoryLite]
                CREATE TABLE [dbo].[VAD](
	                [Category] [varchar](50) NULL,
	                [SKU] [nvarchar](50) NULL,
	                [Description] [nvarchar](50) NULL,
	                [Price] [decimal](5, 2) NULL,
	                [Quantity] [int] NULL,
	                [Cost] [decimal](5, 2) NULL,
	                [Value] [decimal](18, 0) NULL
                ) ON [PRIMARY]";

            SendNonSelectQuery(DSNHost, createDbQuery);
        }

        public static DataSet GetItems()
        {
            string query = "Select * FROM VAD ORDER BY Category ASC";
            DataSet dataSet = SendSelectQuery(DSNHost, query);
            return dataSet;
        }

        public static int InsertNewItem(string category, string sku, string description, decimal price, decimal quantity, decimal cost)
        {
            decimal value = price * quantity;
            string query = $"INSERT INTO VAD VALUES ('{category}', '{sku}', '{description}', {price}, {quantity}, {cost}, {value})";
            int response = SendNonSelectQuery(DSNHost, query);
            return response;
        }

        public static DataSet GetSpecificItem(string sku)
        {
            string query = $"SELECT * FROM VAD WHERE SKU = '{sku}'";
            DataSet dataSet = SendSelectQuery(DSNHost, query);
            return dataSet;
        }

        public static int ModifySpecificItem(string category, string sku, string description, decimal price, decimal quantity, decimal cost)
        {
            decimal value = price * quantity;
            string query = $"UPDATE VAD SET Category = '{category}', Description = '{description}', Price = {price}, Quantity = {quantity}, Cost = {cost}, Value = {value} WHERE SKU = '{sku}'";
            int response = SendNonSelectQuery(DSNHost, query);
            return response;
        }

        public static int DeleteSpecificItem(string sku)
        {
            string query = $"DELETE FROM VAD WHERE SKU = '{sku}'";
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

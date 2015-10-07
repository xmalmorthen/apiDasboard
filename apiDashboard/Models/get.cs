using NLog;
using System;
using System.Data;
using System.Data.SqlClient;

namespace apiDashboard.Models
{
    public static class get
    {
        public static DataTable select(string query) {
            DataTable table = null;
            try
            {
                table = new DataTable();
                using (SqlConnection connection = new SqlConnection(apiDashboard.Properties.Settings.Default.cnnDB))
                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(table);                    
                    connection.Close();
                }                
            }
            catch (System.Exception ex)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error(ex, ex.Message);
                throw;
            }
            return table;
        }

        public static Boolean insert(string query)
        {
            Boolean response = false;
            try
            {
                SqlConnection connection = new SqlConnection(apiDashboard.Properties.Settings.Default.cnnDB);
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                if (cmd.ExecuteNonQuery() > 0) {
                    response = true;
                }
                cmd.Dispose();
                cmd = null;
                connection.Close();
                connection.Dispose();
                connection = null;

            }
            catch (System.Exception ex)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error(ex, ex.Message);
                throw;
            }
            return response;
        }

        public static DataTable exec(string query)
        {
            DataTable table = null;
            try
            {
                table = new DataTable();
                using (SqlConnection connection = new SqlConnection(apiDashboard.Properties.Settings.Default.cnnDB))
                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(table);
                }

            }
            catch (System.Exception ex)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error(ex, ex.Message);
                throw;
            }
            return table;
        }
    }
}
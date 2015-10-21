using apiDashboard.Clases;
using MySql.Data.MySqlClient;
using NLog;
using System;
using System.Data;


namespace apiDashboard.Models
{
    public static class getMySqlServer
    {
        public static DataTable genericQuery(TSQLCommands command, string query)
        {
            DataTable table = null;
            DataSet ds = null; 
            try
            {
                ds = new DataSet();
                table = new DataTable();
                ds.Tables.Add(table);
                ds.EnforceConstraints = false;

                MySqlConnection cnn;
                cnn = new MySqlConnection(WebApiConfig.DbCnnCnfg["CnnString"]);

                MySqlCommand cmd = new MySqlCommand(query, cnn);

                cnn.Open();
                
                MySqlDataReader dr = cmd.ExecuteReader();

                table.Load(dr);

                dr.Close();
                cmd.Dispose();
                cnn.Close();
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
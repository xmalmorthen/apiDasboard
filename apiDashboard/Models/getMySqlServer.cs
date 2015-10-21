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
            try
            {
                table = new DataTable();

                MySqlConnection cnn;
                cnn = new MySqlConnection(WebApiConfig.DbCnnCnfg["CnnString"]);
                cnn.Open();
                
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
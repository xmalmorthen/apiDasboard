using apiDashboard.Clases;
using NLog;
using System;
using System.Data;
using System.Data.SqlClient;

namespace apiDashboard.Models
{
    public static class getSqlServer
    {
        public static DataTable genericQuery(TSQLCommands command, string query)
        {
            DataTable table = null;
            try
            {
                table = new DataTable();
                SqlConnection connection = new SqlConnection(WebApiConfig.DbCnnCnfg["CnnString"]);
                SqlCommand cmd = new SqlCommand(query, connection);

                switch (command)
                {
                    case TSQLCommands.create:
                    case TSQLCommands.alter:
                    case TSQLCommands.drop:
                    case TSQLCommands.delete:
                    case TSQLCommands.insert:
                    case TSQLCommands.update:
                    case TSQLCommands.trunctate:
                    case TSQLCommands.truncate:
                        cmd.ExecuteNonQuery();
                    break;
                    case TSQLCommands.select:
                    case TSQLCommands.execute:
                    case TSQLCommands.dynamic:
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        connection.Open();
                        adapter.Fill(table);
                    break;
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
            return table;
        }
    }
}
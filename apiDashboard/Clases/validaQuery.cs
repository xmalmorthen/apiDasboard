using apiDashboard.Properties;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace apiDashboard.Clases
{
    public static class valida
    {
        #region headers

        public static string header(System.Net.Http.HttpRequestMessage Request, string headerName, Boolean throwInError = true) { 
            string response = null;

            if (Request.Headers.Contains(headerName))
            {
                var header = Request.Headers.GetValues(headerName).FirstOrDefault();
                if (header != null)
                {
                    response = header;
                }
            }
            else {
                if (throwInError)
                    throw new System.Security.VerificationException(Resources.REST_Service_Message_CABECERAS_INCOMPLETAS);
            }
            return response;
        }

        #endregion headers


        #region validaQuery

        public static Boolean query(string query, TSQLCommands ignoreCommand)
        {
            return valida.query(new List<string> { query }, new List<TSQLCommands> { ignoreCommand });
        }

        public static Boolean query(string query, List<TSQLCommands> ignoreCommands)
        {
            return valida.query(new List<string> { query }, ignoreCommands);
        }

        public static Boolean query(List<string> querys, TSQLCommands ignoreCommand)
        {
            return valida.query(querys, new List<TSQLCommands> { ignoreCommand });
        }

        public static Boolean query(List<string> querys, List<TSQLCommands> ignoreCommands)
        {
            Boolean response = false;
            try
            {
                switch (WebApiConfig.DbCnnCnfg["Provider"].Trim().ToLower())
                {
                    case "sqlserver":
                        foreach (string item in Enum.GetNames(typeof(TSQLCommands)))
                        {
                            if (ignoreCommands.Exists(qry => qry.ToString().Equals(item)))
                                continue;
                            foreach (string qry in querys)
                            {
                                if (qry.Contains(item))
                                {
                                    if (qry.IndexOf(item) > 0)
                                    {
                                        if (qry[qry.IndexOf(item) - 1] == '[' && qry[qry.IndexOf(item) + item.Length] == ']')
                                        {
                                            continue;
                                        }
                                    }
                                    throw new Exception(string.Format("Comando no permitido [ {0} ] infringe la restricción [ {1} ]", qry, item));
                                }
                            }
                        }
                        response = true;
                    break;
                    case "mysqlserver":
                        response = true;
                    break;
                }                
            }
            catch (Exception ex)
            {
                Logger logger = LogManager.GetCurrentClassLogger();
                logger.Error(ex, ex.Message);
            }
            return response;
        }

        #endregion validaQuery

        #region validaParameter

        public static Boolean parameter(string parameter)
        {
            return string.IsNullOrEmpty(parameter);
        }

        #endregion validaParameter
    }

    
}
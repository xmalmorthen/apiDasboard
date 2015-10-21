
using apiDashboard.Clases;
using apiDashboard.Models;
using apiDashboard.Models.structs;
using apiDashboard.Properties;
using NLog;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;

namespace apiDashboard.Controllers
{
    public class apiV1Controller : ApiController
    {
        private service invoque(TSQLCommands command, string query)
        { 
            try 
            {
                WebApiConfig.DbCnnCnfg.Clear();
                WebApiConfig.DbCnnCnfg.Add("Provider", valida.header(Request, "Provider"));
                WebApiConfig.DbCnnCnfg.Add("CnnString",System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(valida.header(Request, "CnnString"))));

                if (valida.parameter(query))
                    new System.ArgumentException(Resources.REST_Service_Parametros_Incorrectos);

                query = HttpContext.Current.Server.UrlDecode(query);

                List<string> querys = new List<string>(query.Split(';'));
                if (!valida.query(querys, command))
                    throw new System.FormatException(Resources.REST_Service_Message_PERMISO_DENEGADO);

                List<Models.structs.response> dataResults = new List<Models.structs.response>();
                foreach (string item in querys)
                {
                    if (!string.IsNullOrEmpty(item.Trim()))
                    {
                        Models.structs.response data = new Models.structs.response();

                        data.Command = item.Replace(System.Environment.NewLine, string.Empty);
                        switch (WebApiConfig.DbCnnCnfg["Provider"].Trim().ToLower())
                        {
                            case "sqlserver":
                                data.Result = getSqlServer.genericQuery(command, item);
                                break;
                            case "mysqlserver":
                                data.Result = getMySqlServer.genericQuery(command, item);
                                break;
                        }

                        dataResults.Add(data);
                    }
                }
                return Libs.response.make(dataResults);
            }
            catch (Exception ex)
            {
                return Libs.response.make(Resources.REST_Service_Status_code_ERROR, Resources.REST_Service_Status_response_ERROR, ex.Message);
            }
        }

        // GET apiV1/select
        [HttpGet]
        public service select(string query)
        {
            return this.invoque(TSQLCommands.select, query);
        }

        // GET apiV1/insert
        [HttpGet]
        public service insert(string query)
        {
            return this.invoque(TSQLCommands.insert, query);
        }

        // GET apiV1/insert
        [HttpGet]
        public service update(string query)
        {
            return this.invoque(TSQLCommands.update, query);
        }

        // GET apiV1/exec
        [HttpGet]
        public service exec(string query)
        {
            return this.invoque(TSQLCommands.execute, query);
        }
        
        // GET apiV1/call
        [HttpGet]
        public service call(string query)
        {
            return this.invoque(TSQLCommands.execute, query);
        }


        // GET apiV1/dynamic
        [HttpGet]
        public service dynamic(string query)
        {
            return this.invoque(TSQLCommands.dynamic, query);
        }

    }
}
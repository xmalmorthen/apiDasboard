
using apiDashboard.Models;
using apiDashboard.Models.structs;
using apiDashboard.Properties;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Http;

namespace apiDashboard.Controllers
{
    public class apiController : ApiController
    {
        // GET apiV1/select
        [HttpGet]
        public service select(string query)
        {            
            try
            {
                if (string.IsNullOrEmpty(query))
                {
                    return Libs.response.make(Resources.REST_Service_Status_code_ERROR, Resources.REST_Service_Status_response_ERROR, Resources.REST_Service_Parametros_Incorrectos);
                }

                query = HttpContext.Current.Server.UrlDecode(query);

                string[] exceptionsQry = new string[] { "insert", "update", "delete","exec"};
                foreach (string item in exceptionsQry)
	            {
                    if (query.Contains(item))
                    {
                        return Libs.response.make(Resources.REST_Service_Status_code_ERROR, Resources.REST_Service_Status_response_ERROR, string.Format("Solo se permite ejecutar selecciones - [ {0} ]", query));
                    }
	            }

                string[] querys = query .Split(';');
                Dictionary<short, Models.structs.response> dataResults = new Dictionary<short, Models.structs.response>();
                short idx = 1;
                foreach (string item in querys)
                {
                    Models.structs.response data = new Models.structs.response();

                    data.Command = item.Replace(System.Environment.NewLine, string.Empty);
                    data.Result = get.select(item);

                    dataResults.Add(idx, data);
                    idx++;
                }

                return Libs.response.make(dataResults);
                            
            }
            catch (Exception)
            {
                return Libs.response.make(Resources.REST_Service_Status_code_ERROR, Resources.REST_Service_Status_response_ERROR, string.Format("{0} - [ {1} ]", Resources.REST_Service_Message_ERROR, query));
            }
        }

        // GET apiV1/insert
        [HttpGet]
        public service insert(string query)
        {
            try
            {
                if (string.IsNullOrEmpty(query))
                {
                    return Libs.response.make(Resources.REST_Service_Status_code_ERROR, Resources.REST_Service_Status_response_ERROR, Resources.REST_Service_Parametros_Incorrectos);
                }

                query = HttpContext.Current.Server.UrlDecode(query);

                string[] exceptionsQry = new string[] { "select", "update", "delete", "exec" };
                foreach (string item in exceptionsQry)
                {
                    if (query.Contains(item))
                    {
                        return Libs.response.make(Resources.REST_Service_Status_code_ERROR, Resources.REST_Service_Status_response_ERROR, string.Format("Solo se permite ejecutar inserciones - [ {0} ]", query));
                    }
                }

                string[] querys = query.Split(';');
                Dictionary<short, Models.structs.response> dataResults = new Dictionary<short, Models.structs.response>();
                short idx = 1;
                foreach (string item in querys)
                {
                    Models.structs.response data = new Models.structs.response();

                    data.Command = item.Replace(System.Environment.NewLine, string.Empty);
                    if (!string.IsNullOrEmpty(item))
                    {
                        get.insert(item);
                    }

                    dataResults.Add(idx, data);
                    idx++;
                }

                return Libs.response.make(dataResults,false);

            }
            catch (Exception)
            {
                return Libs.response.make(Resources.REST_Service_Status_code_ERROR, Resources.REST_Service_Status_response_ERROR, string.Format("{0} - [ {1} ]", Resources.REST_Service_Message_ERROR, query));
            }
        }

        // GET apiV1/exec
        [HttpGet]
        public service exec(string query)
        {
            try
            {
                if (string.IsNullOrEmpty(query))
                {
                    return Libs.response.make(Resources.REST_Service_Status_code_ERROR, Resources.REST_Service_Status_response_ERROR, Resources.REST_Service_Parametros_Incorrectos);
                }

                query = HttpContext.Current.Server.UrlDecode(query);

                string[] exceptionsQry = new string[] { "insert", "update", "delete", "select" };
                foreach (string item in exceptionsQry)
                {
                    if (query.Contains(item))
                    {
                        return Libs.response.make(Resources.REST_Service_Status_code_ERROR, Resources.REST_Service_Status_response_ERROR, string.Format("Solo se permite ejecutar selecciones - [ {0} ]", query));
                    }
                }

                string[] querys = query.Split(';');
                Dictionary<short, Models.structs.response> dataResults = new Dictionary<short, Models.structs.response>();
                short idx = 1;
                foreach (string item in querys)
                {
                    Models.structs.response data = new Models.structs.response();

                    data.Command = item.Replace(System.Environment.NewLine, string.Empty);
                    data.Result = get.exec(item);

                    dataResults.Add(idx, data);
                    idx++;
                }

                return Libs.response.make(dataResults);

            }
            catch (Exception)
            {
                return Libs.response.make(Resources.REST_Service_Status_code_ERROR, Resources.REST_Service_Status_response_ERROR, string.Format("{0} - [ {1} ]", Resources.REST_Service_Message_ERROR, query));
            }
        }

        // GET apiV1/query
        [HttpGet]
        public service query(string query)
        {
            try
            {
                if (string.IsNullOrEmpty(query))
                {
                    return Libs.response.make(Resources.REST_Service_Status_code_ERROR, Resources.REST_Service_Status_response_ERROR, Resources.REST_Service_Parametros_Incorrectos);
                }

                query = HttpContext.Current.Server.UrlDecode(query);
                
                string[] querys = query.Split(';');
                Dictionary<short, Models.structs.response> dataResults = new Dictionary<short, Models.structs.response>();
                short idx = 1;
                foreach (string item in querys)
                {
                    Models.structs.response data = new Models.structs.response();

                    data.Command = item.Replace(System.Environment.NewLine, string.Empty);
                    data.Result = get.select(item);

                    dataResults.Add(idx, data);
                    idx++;
                }
                return Libs.response.make(dataResults);
            }
            catch (Exception)
            {
                return Libs.response.make(Resources.REST_Service_Status_code_ERROR, Resources.REST_Service_Status_response_ERROR, string.Format("{0} - [ {1} ]", Resources.REST_Service_Message_ERROR, query));
            }
        }

    }
}
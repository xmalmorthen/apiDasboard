using apiDashboard.Models.structs;
using apiDashboard.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiDashboard.Libs
{
    public static class response
    {
        public static service make(List<Models.structs.response> Response = null)
        {
            return response.make(Resources.REST_Service_Status_code_EXITO,Resources.REST_Service_Status_response_EXITO, Resources.REST_Service_Message_EXITO, Response);
        }

        public static service make(List<Models.structs.response> Response = null, Boolean validateResponse = false)
        {
            return response.make(Resources.REST_Service_Status_code_EXITO, Resources.REST_Service_Status_response_EXITO, Resources.REST_Service_Message_EXITO, Response, validateResponse);
        }

        public static service make(string Status_code,
                                   string Status_response, 
                                   string Message,
                                   List<Models.structs.response> Response = null,
                                   Boolean validateResponse = true)
        {
            service Service = new service();

            #region REST_Service response

            if (validateResponse)
            {
                if (Response != null && Response.Count == 0)
                {
                    Status_response = Resources.REST_Service_Status_response_AVISO;
                    Message = Resources.REST_Service_NoResultado;
                }
            }
            
            Service.REST_Service.Status_code = Status_code;
            Service.REST_Service.Status_response = Status_response;
            Service.REST_Service.Message = Message;
            #endregion

            #region response data result
            Service.Response = Response;
            #endregion

            return Service;
        }

        public static service error(string Message) {
            service Service = new service();
            Service.REST_Service.Status_code = Resources.REST_Service_Status_code_ERROR;
            Service.REST_Service.Status_response = Resources.REST_Service_Status_response_ERROR;
            Service.REST_Service.Message = Message;
            return Service;
        }


    }
}
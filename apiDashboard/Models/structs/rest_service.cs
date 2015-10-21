using apiDashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiDashboard.Models.structs
{
      public class rest_service
    {
        string status_code;
        public string Status_code
        {
            get { return status_code; }
            set { status_code = value; }
        }
          
        string status_response;
        public string Status_response
        {
            get { return status_response; }
            set { status_response = value; }
        }

        string message;
        public string Message
        {
            get { return message; }
            set { message = value; }
        }
        
        public string Fecha
        {
            get {return String.Format("{0:dd/MM/yyyy}", DateTime.Now); }
        }

        string hora;
        public string Hora
        {
            get { return String.Format("{0:HH:mm:ss}", DateTime.Now); }
        }

        string response_key;
        public string Response_key
        {
            get { return Guid.NewGuid().ToString(); }
        }

        string response_time;
        public string Response_time
        {
            get {
                WebApiConfig.stopWatch.Stop();
                TimeSpan ts = WebApiConfig.stopWatch.Elapsed;
                string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
                return elapsedTime;
            }
        }

    }
}
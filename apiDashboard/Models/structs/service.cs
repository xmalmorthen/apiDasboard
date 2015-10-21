using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace apiDashboard.Models.structs
{
    public class service
    {
        private rest_service _REST_Service = new rest_service();
        public rest_service REST_Service
        {
            get { return _REST_Service; }
            set { _REST_Service = value; }
        }


        private List<Models.structs.response> _Response = new List<Models.structs.response>();
        public List<Models.structs.response> Response
        {
            get { return _Response; }
            set { _Response = value; }
        }
    }
}
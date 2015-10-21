using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace apiDashboard.Models.structs
{
    public class response
    {
        string command;
        public string Command
        {
          get { return command; }
          set { command = value; }
        }

        DataTable result;
        public DataTable Result
        {
            get { return result; }
            set { result = value; }
        }
    }

}
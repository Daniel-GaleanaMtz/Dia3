using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceLogin" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceLogin.svc or ServiceLogin.svc.cs at the Solution Explorer and start debugging.
    public class ServiceLogin : IServiceLogin
    {
        public bool isCorrect(string user, string pass)
        {
            bool success = false;
            if (user == "Daniel" && pass == "1234")
            {
                success = true;
            }
            return success;
        }
    }
}

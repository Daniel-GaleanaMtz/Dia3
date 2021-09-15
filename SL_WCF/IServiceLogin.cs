﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceLogin" in both code and config file together.
    [ServiceContract]
    public interface IServiceLogin
    {
        [OperationContract]
        bool isCorrect(string user, string pass);
    }
}
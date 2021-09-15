using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceDepartamento" in both code and config file together.
    [ServiceContract]
    public interface IServiceDepartamento
    {
        [OperationContract]
        Result Add(ML.Departamento departamento);

        [OperationContract]
        Result Update(ML.Departamento departamento);

        [OperationContract]
        Result Delete(ML.Departamento departamento);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Departamento))]
        Result GetAll(ML.Departamento departamento);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Departamento))]
        Result GetById(ML.Departamento departamento);
    }

    public class Result
    {

        [DataMember]
        public bool Correct { get; set; }

        [DataMember]
        public object Object { get; set; }

        [DataMember]
        public List<object> Objects { get; set; }
        [DataMember]
        public string ErrorMessage { get; set; }
        [DataMember]
        public Exception Ex { get; set; }
    }
}

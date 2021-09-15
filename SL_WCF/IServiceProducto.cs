using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IServiceProducto" in both code and config file together.
    [ServiceContract]
    public interface IServiceProducto
    {
        [OperationContract]
        Result Add(ML.Producto producto);

        [OperationContract]
        Result Update(ML.Producto producto);

        [OperationContract]
        Result Delete(ML.Producto producto);

        [OperationContract]
        [ServiceKnownType (typeof(ML.Producto))]
        Result GetAll(ML.Producto producto);

        [OperationContract]
        [ServiceKnownType(typeof(ML.Producto))]
        Result GetById(ML.Producto producto);


    }
}

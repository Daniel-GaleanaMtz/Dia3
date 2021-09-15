using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceDepartamento" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceDepartamento.svc or ServiceDepartamento.svc.cs at the Solution Explorer and start debugging.
    public class ServiceDepartamento : IServiceDepartamento
    {
        public Result Add(ML.Departamento departamento)
        {
           
            ML.Result result = BL.Departamento.AddEF(departamento);

            return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex };
        }

        public Result Update(ML.Departamento departamento)
        {
            ML.Result result = BL.Departamento.UpdateEF(departamento);

            return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex };
        }

        public Result Delete(ML.Departamento departamento)
        {

            ML.Result result = BL.Departamento.DeleteEF(departamento);

            return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex };
        }

        public Result GetAll(ML.Departamento departamento)
        {

            ML.Result result = BL.Departamento.GetAllEF();

            return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex, Objects = result.Objects };
        }

        public Result GetById(ML.Departamento departamento)
        {

            ML.Result result = BL.Departamento.GetByIdEF(departamento);

            return new Result { Correct = result.Correct, ErrorMessage = result.ErrorMessage, Ex = result.Ex, Object = result.Object };
        }
    }
}

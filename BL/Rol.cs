using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
        public static ML.Result RolGetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.DGaleanaEcommerceEntities1 context = new DL_EF.DGaleanaEcommerceEntities1())
                {
                    var roles = context.RolGetAll().ToList();
                    result.Objects = new List<object>();
                    if (roles != null)
                    {
                        foreach (var objs in roles)
                        {
                            ML.Rol rol = new ML.Rol();

                            rol.IdRol = objs.IdRol;
                            rol.Nombre = objs.Nombre;

                            result.Objects.Add(rol);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error: No existen datos en la base de datos";
                    }
                }
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
            }
            return result;
        }       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Area
    {
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.DGaleanaEcommerceEntities1 context = new DL_EF.DGaleanaEcommerceEntities1())
                {
                    var areas = context.AreaGetAll().ToList();
                    result.Objects = new List<object>();
                    if (areas != null)
                    {
                        foreach (var objs in areas)
                        {
                            ML.Area area = new ML.Area();

                            area.IdArea = objs.IdArea;
                            area.Nombre = objs.Nombre;

                            result.Objects.Add(area);
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

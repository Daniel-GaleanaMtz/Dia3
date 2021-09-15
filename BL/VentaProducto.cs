using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class VentaProducto
    {
        public static ML.Result AddPS(ML.VentaProducto ventaproducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "VentaProductoAdd";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[3];
                        collection[0] = new SqlParameter("IdVenta", SqlDbType.VarChar);
                        collection[0].Value = ventaproducto.Venta.IdVenta;

                        collection[1] = new SqlParameter("Cantidad", SqlDbType.VarChar);
                        collection[1].Value = ventaproducto.Cantidad;

                        collection[2] = new SqlParameter("IdProducto", SqlDbType.VarChar);
                        collection[2].Value = ventaproducto.Producto.IdProducto;

                        cmd.Parameters.AddRange(collection);

                        context.Open();
                        int RowsAfected = cmd.ExecuteNonQuery();
                        if (RowsAfected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ha ocurrido un error al momento de insertar";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        /* Metodos utilizando Entity Framework */

        public static ML.Result AddEF(ML.VentaProducto ventaproducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.DGaleanaEcommerceEntities1 context = new DL_EF.DGaleanaEcommerceEntities1())
                {
                    var query = context.VentaProductoAdd(ventaproducto.Venta.IdVenta, ventaproducto.Cantidad, ventaproducto.Producto.IdProducto);
                        if (query >= 1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ha ocurrido un error al momento de insertar";
                        }
                    }
                }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}

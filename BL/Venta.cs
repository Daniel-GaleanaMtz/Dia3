using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Objects;


namespace BL
{
    public class Venta
    {
        public static ML.Result AddSP(ML.Venta venta, List<object> Objects)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "VentaAdd";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[4];
                        collection[0] = new SqlParameter("IdCliente", SqlDbType.Int);
                        collection[0].Value = venta.Cliente.IdCliente;

                        collection[1] = new SqlParameter("Total", SqlDbType.Decimal);
                        collection[1].Value = venta.Total;

                        collection[2] = new SqlParameter("IdMetodoPago", SqlDbType.Int);
                        collection[2].Value = venta.MetodoPago.IdMetodoPago;

                        /* Prueba de OUTPUT */
                        collection[3] = new SqlParameter("@IdVenta", SqlDbType.Int);
                        collection[3].Direction = ParameterDirection.Output;
                        

                        cmd.Parameters.AddRange(collection);

                        context.Open();
                        int RowsAfected = cmd.ExecuteNonQuery();
                        venta.IdVenta = (int)cmd.Parameters["@IdVenta"].Value;
                        foreach (ML.VentaProducto ventaproducto in Objects)
                        {
                            ventaproducto.Venta = new ML.Venta();
                            ventaproducto.Venta.IdVenta = venta.IdVenta;
                            BL.VentaProducto.AddPS(ventaproducto);
                        }
                        if (RowsAfected > 0)
                        {
                            result.Correct = true;
                            Console.WriteLine("El id agregado es: " + cmd.Parameters["@IdVenta"].Value.ToString());
                            Console.ReadKey();
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

        /* Metodo con EF */

        public static ML.Result AddEF(ML.Venta venta, List<object> Objects)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.DGaleanaEcommerceEntities1 context = new DL_EF.DGaleanaEcommerceEntities1())
                {
                    var IdVenta = new System.Data.Entity.Core.Objects.ObjectParameter("IdVenta", typeof(int));
                    var query = context.VentaAdd(venta.Cliente.IdCliente, venta.Total, venta.MetodoPago.IdMetodoPago, IdVenta);

                    foreach (ML.VentaProducto ventaproducto in Objects)
                    {
                        ventaproducto.Venta = new ML.Venta();
                        ventaproducto.Venta.IdVenta = (int)IdVenta.Value;
                        BL.VentaProducto.AddEF(ventaproducto);

                        ventaproducto.Producto.Stock = ventaproducto.Producto.Stock - ventaproducto.Cantidad;
                        BL.Producto.UpdateEF(ventaproducto.Producto);
                    }
                        if (query >= 1)
                        {
                            result.Correct = true;
                            Console.WriteLine("El id agregado es: " + (int)IdVenta.Value);     
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

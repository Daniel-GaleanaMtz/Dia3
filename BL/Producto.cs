using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace BL
{
    public class Producto
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try{
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string Query = "SELECT [IdProducto],[Nombre],[Precio],[Stock],[IdProveedor],[IdDepartamento],[Descripcion] FROM [Producto]";
                        cmd.CommandText = Query;
                        cmd.Connection = context;
                        context.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable tableProducto = new DataTable();
                        da.Fill(tableProducto);
                        if(tableProducto.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in tableProducto.Rows)
                            {
                                ML.Producto producto = new ML.Producto();

                                producto.IdProducto = int.Parse(row[0].ToString());
                                producto.Nombre = row[1].ToString();
                                producto.Precio = decimal.Parse(row[2].ToString());
                                producto.Stock = int.Parse(row[3].ToString());

                                producto.Proveedor = new ML.Proveedor();
                                producto.Proveedor.IdProveedor = int.Parse(row[4].ToString());

                                producto.Departamento = new ML.Departamento();
                                producto.Departamento.IdDepartamento = int.Parse(row[5].ToString());

                                producto.Descripcion = row[6].ToString();

                                result.Objects.Add(producto);
                            }
                            result.Correct = true;
                        }else{
                            result.Correct = false;
                            result.ErrorMessage = "Error: No existen datos en la base de datos";
                        }
                        }
                    }
                }
            catch(Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
            }
            return result;
        }
        public static ML.Result Add(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try{
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string Query = "INSERT INTO [Producto]([Nombre],[Precio],[Stock],[IdProveedor],[IdDepartamento],[Descripcion]) VALUES (@Nombre, @Precio, @Stock, @IdProveedor, @IdDepartamento, @Descripcion)";
                        cmd.CommandText = Query;
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[6];
                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = producto.Nombre;

                        collection[1] = new SqlParameter("Precio", SqlDbType.VarChar);
                        collection[1].Value = producto.Precio;

                        collection[2] = new SqlParameter("Stock", SqlDbType.VarChar);
                        collection[2].Value = producto.Stock;

                        collection[3] = new SqlParameter("IdProveedor", SqlDbType.VarChar);
                        collection[3].Value = producto.Proveedor.IdProveedor;

                        collection[4] = new SqlParameter("IdDepartamento", SqlDbType.VarChar);
                        collection[4].Value = producto.Departamento.IdDepartamento;

                        collection[5] = new SqlParameter("Descripcion", SqlDbType.VarChar);
                        collection[5].Value = producto.Descripcion;

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
            }catch(Exception ex){
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Update(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string Query = "UPDATE [Producto] SET Nombre = @Nombre ,Precio = @Precio ,Stock = @Stock ,IdProveedor = @IdProveedor ,IdDepartamento = @IdDepartamento ,Descripcion = @Descripcion WHERE IdProducto = @IdProducto";
                        cmd.CommandText = Query;
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[7];
                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = producto.Nombre;

                        collection[1] = new SqlParameter("Precio", SqlDbType.VarChar);
                        collection[1].Value = producto.Precio;

                        collection[2] = new SqlParameter("Stock", SqlDbType.VarChar);
                        collection[2].Value = producto.Stock;

                        collection[3] = new SqlParameter("IdProveedor", SqlDbType.VarChar);
                        collection[3].Value = producto.Proveedor.IdProveedor;

                        collection[4] = new SqlParameter("IdDepartamento", SqlDbType.VarChar);
                        collection[4].Value = producto.Departamento.IdDepartamento;

                        collection[5] = new SqlParameter("Descripcion", SqlDbType.VarChar);
                        collection[5].Value = producto.Descripcion;

                        collection[6] = new SqlParameter("IdProducto", SqlDbType.VarChar);
                        collection[6].Value = producto.IdProducto;

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
                            result.ErrorMessage = "Ha ocurrido un error al momento de actualizar";
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
        public static ML.Result Delete(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string Query = "DELETE FROM [Producto] WHERE IdProducto = @IdProducto";
                        cmd.CommandText = Query;
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("IdProducto", SqlDbType.VarChar);
                        collection[0].Value = producto.IdProducto;
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
                            result.ErrorMessage = "Ha ocurrido un error al momento de eliminar";
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
        /* Metodos de Stored Procedures */

        public static ML.Result GetById(int IdProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string Query = "ProductoGetById";
                        cmd.CommandText = Query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("IdProducto", SqlDbType.Int);
                        collection[0].Value = IdProducto;
                        cmd.Parameters.AddRange(collection);
                        context.Open();
                                            
                        
                        DataTable tableProducto = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd); 
                        da.Fill(tableProducto);
                        if (tableProducto.Rows.Count > 0)
                        {
                                DataRow row = tableProducto.Rows[0];
                                ML.Producto producto = new ML.Producto();
                                producto.IdProducto = int.Parse(row[0].ToString());

                                producto.Nombre = row[1].ToString();
                                producto.Precio = decimal.Parse(row[2].ToString());
                                producto.Stock = int.Parse(row[3].ToString());

                                producto.Proveedor = new ML.Proveedor();
                                producto.Proveedor.IdProveedor = int.Parse(row[4].ToString());

                                producto.Departamento = new ML.Departamento();
                                producto.Departamento.IdDepartamento = int.Parse(row[5].ToString());

                                producto.Descripcion = row[6].ToString();

                                result.Object = producto;
                            
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Error: No existen datos en la base de datos";
                        }
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
        public static ML.Result GetAllSP()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string Query = "ProductoGetAll";
                        cmd.CommandText = Query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;
                        context.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable tableProducto = new DataTable();
                        da.Fill(tableProducto);
                        if (tableProducto.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in tableProducto.Rows)
                            {
                                ML.Producto producto = new ML.Producto();

                                producto.IdProducto = int.Parse(row[0].ToString());
                                producto.Nombre = row[1].ToString();
                                producto.Precio = decimal.Parse(row[2].ToString());
                                producto.Stock = int.Parse(row[3].ToString());

                                producto.Proveedor = new ML.Proveedor();
                                producto.Proveedor.IdProveedor = int.Parse(row[4].ToString());

                                producto.Departamento = new ML.Departamento();
                                producto.Departamento.IdDepartamento = int.Parse(row[5].ToString());

                                producto.Descripcion = row[6].ToString();

                                result.Objects.Add(producto);
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
            }
            catch (Exception Ex)
            {
                result.Correct = false;
                result.ErrorMessage = Ex.Message;
            }
            return result;
        }
        public static ML.Result AddSP(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "ProductoAdd";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;
                    
                        SqlParameter[] collection = new SqlParameter[6];
                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = producto.Nombre;

                        collection[1] = new SqlParameter("Precio", SqlDbType.VarChar);
                        collection[1].Value = producto.Precio;

                        collection[2] = new SqlParameter("Stock", SqlDbType.VarChar);
                        collection[2].Value = producto.Stock;

                        collection[3] = new SqlParameter("IdProveedor", SqlDbType.VarChar);
                        collection[3].Value = producto.Proveedor.IdProveedor;

                        collection[4] = new SqlParameter("IdDepartamento", SqlDbType.VarChar);
                        collection[4].Value = producto.Departamento.IdDepartamento;

                        collection[5] = new SqlParameter("Descripcion", SqlDbType.VarChar);
                        collection[5].Value = producto.Descripcion;

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
        public static ML.Result UpdateSP(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "ProductoUpdate";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[7];
                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = producto.Nombre;

                        collection[1] = new SqlParameter("Precio", SqlDbType.VarChar);
                        collection[1].Value = producto.Precio;

                        collection[2] = new SqlParameter("Stock", SqlDbType.VarChar);
                        collection[2].Value = producto.Stock;

                        collection[3] = new SqlParameter("IdProveedor", SqlDbType.VarChar);
                        collection[3].Value = producto.Proveedor.IdProveedor;

                        collection[4] = new SqlParameter("IdDepartamento", SqlDbType.VarChar);
                        collection[4].Value = producto.Departamento.IdDepartamento;

                        collection[5] = new SqlParameter("Descripcion", SqlDbType.VarChar);
                        collection[5].Value = producto.Descripcion;

                        collection[6] = new SqlParameter("IdProducto", SqlDbType.VarChar);
                        collection[6].Value = producto.IdProducto;

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
                            result.ErrorMessage = "Ha ocurrido un error al momento de actualizar";
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
        public static ML.Result DeleteSP(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "ProductoDelete";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("IdProducto", SqlDbType.VarChar);
                        collection[0].Value = producto.IdProducto;
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
                            result.ErrorMessage = "Ha ocurrido un error al momento de eliminar";
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

        public static ML.Result GetByIdEF(ML.Producto productoItem)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.DGaleanaEcommerceEntities1 context = new DL_EF.DGaleanaEcommerceEntities1())
                {
                    var query = context.ProductoGetById(productoItem.IdProducto).FirstOrDefault();
                    
                    ML.Producto producto = new ML.Producto();
                    producto.Nombre = query.ProductoNombre;
                    producto.Precio = query.Precio.Value;
                    producto.Stock = query.Stock.Value;

                    producto.Proveedor = new ML.Proveedor();
                    producto.Proveedor.IdProveedor = query.IdProveedor.Value;
                    producto.Proveedor.Nombre = query.ProductoNombre;

                    producto.Departamento = new ML.Departamento();
                    producto.Departamento.IdDepartamento = query.IdDepartamento.Value;
                    producto.Departamento.Nombre = query.DepartamentoNombre;

                    producto.Departamento.Area = new ML.Area();
                    producto.Departamento.Area.IdArea = query.IdArea;
                    producto.Departamento.Area.Nombre = query.AreaNombre;

                    producto.Descripcion = query.Descripcion;
                    producto.Imagen = query.Images;
                 
                    result.Object = producto;
                        if (query != null)
                        {                     
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

        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.DGaleanaEcommerceEntities1 context = new DL_EF.DGaleanaEcommerceEntities1())
                {
                    var productos = context.ProductoGetAll().ToList();
                    result.Objects = new List<object>();
                    if (productos != null)
                    {
                        foreach (var objs in productos)
                        {
                            ML.Producto producto = new ML.Producto();

                            producto.IdProducto = objs.IdProducto;
                            producto.Nombre = objs.ProductoNombre;
                            producto.Precio = objs.Precio.Value;
                            producto.Stock = objs.Stock.Value;

                            producto.Proveedor = new ML.Proveedor();
                            producto.Proveedor.IdProveedor = objs.IdProveedor.Value;
                            producto.Proveedor.Nombre = objs.ProveedorNombre;

                            producto.Departamento = new ML.Departamento();
                            producto.Departamento.IdDepartamento = objs.IdDepartamento.Value;
                            producto.Departamento.Nombre = objs.DepartamentoNombre;

                            producto.Departamento.Area = new ML.Area();
                            producto.Departamento.Area.IdArea = objs.IdArea;
                            producto.Departamento.Area.Nombre = objs.AreaNombre;

                            producto.Descripcion = objs.Descripcion;
                            producto.Imagen = objs.Images; //Mostrar imagen

                            result.Objects.Add(producto);
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

        public static ML.Result AddEF(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.DGaleanaEcommerceEntities1 context = new DL_EF.DGaleanaEcommerceEntities1())
                {
                    var query = context.ProductoAdd(producto.Nombre, producto.Precio, producto.Stock, producto.Proveedor.IdProveedor, producto.Departamento.IdDepartamento, producto.Descripcion, producto.Imagen);
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

        public static ML.Result UpdateEF(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.DGaleanaEcommerceEntities1 context = new DL_EF.DGaleanaEcommerceEntities1())
                {
                    var query = context.ProductoUpdate(producto.IdProducto, producto.Nombre, producto.Precio, producto.Stock, producto.Proveedor.IdProveedor, producto.Departamento.IdDepartamento, producto.Descripcion, producto.Imagen);
                        if (query >= 1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ha ocurrido un error al momento de actualizar";
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

        public static ML.Result DeleteEF(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.DGaleanaEcommerceEntities1 context = new DL_EF.DGaleanaEcommerceEntities1())
                {
                    var query = context.ProductoDelete(producto.IdProducto);
                        
                        if (query >= 1)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ha ocurrido un error al momento de eliminar";
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

        /* Metodos utilizando Entity Framework Y LinQ*/

        public static ML.Result GetAllLinQ()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.DGaleanaEcommerceEntities1 context = new DL_EF.DGaleanaEcommerceEntities1())
                {
                    var query = (from productosDL in context.Productoes
                                 select productosDL).ToList();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach (var objs in query)
                        {
                            ML.Producto producto = new ML.Producto();

                            producto.IdProducto = objs.IdProducto;
                            producto.Nombre = objs.Nombre;
                            producto.Precio = objs.Precio.Value;
                            producto.Stock = objs.Stock.Value;

                            producto.Proveedor = new ML.Proveedor();
                            producto.Proveedor.IdProveedor = objs.IdProveedor.Value;

                            producto.Departamento = new ML.Departamento();
                            producto.Departamento.IdDepartamento = objs.IdDepartamento.Value;

                            producto.Descripcion = objs.Descripcion;

                            result.Objects.Add(producto);
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

        public static ML.Result AddLinQ(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.DGaleanaEcommerceEntities1 context = new DL_EF.DGaleanaEcommerceEntities1())
                {
                    DL_EF.Producto productoDL = new DL_EF.Producto();

                    productoDL.Nombre = producto.Nombre;
                    productoDL.Precio = producto.Precio;
                    productoDL.Stock = producto.Stock;
                    productoDL.IdProveedor = producto.Proveedor.IdProveedor;
                    productoDL.IdDepartamento = producto.Departamento.IdDepartamento;
                    productoDL.Descripcion = producto.Descripcion;

                    context.Productoes.Add(productoDL);
                    context.SaveChanges();

                    result.Correct = true;
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result UpdateLinQ(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.DGaleanaEcommerceEntities1 context = new DL_EF.DGaleanaEcommerceEntities1())
                {
                    var query = (from productoDL in context.Productoes
                                 where productoDL.IdProducto == producto.IdProducto
                                 select productoDL).SingleOrDefault();
                    if (query != null)
                    {
                        query.Nombre = producto.Nombre;
                        query.Precio = producto.Precio;
                        query.Stock = producto.Stock;
                        query.IdProveedor = producto.Proveedor.IdProveedor;
                        query.IdDepartamento = producto.Departamento.IdDepartamento;
                        query.Descripcion = producto.Descripcion;

                        context.SaveChanges();

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ha ocurrido un error al momento de actualizar";
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

        public static ML.Result DeleteLinQ(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.DGaleanaEcommerceEntities1 context = new DL_EF.DGaleanaEcommerceEntities1())
                {
                    var query = (from productosDL in context.Productoes
                                 where productosDL.IdProducto == producto.IdProducto
                                 select productosDL).First();

                    context.Productoes.Remove(query);
                    context.SaveChanges();

                    result.Correct = true;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BL
{
    public class Departamento
    {
        public static ML.Result GetAll() 
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string Query = "SELECT [IdDepartamento],[Nombre],[IdArea] FROM [Departamento]";
                        cmd.CommandText = Query;
                        cmd.Connection = context;
                        context.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable tableDepartamento = new DataTable();
                        da.Fill(tableDepartamento);
                        if (tableDepartamento.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in tableDepartamento.Rows)
                            {
                                ML.Departamento departamento = new ML.Departamento();

                                departamento.IdDepartamento = int.Parse(row[0].ToString());
                                departamento.Nombre = row[1].ToString();

                                departamento.Area = new ML.Area();
                                departamento.Area.IdArea = int.Parse(row[2].ToString());

                                result.Objects.Add(departamento);
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
        public static ML.Result Add(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string Query = "INSERT INTO [Departamento]([Nombre],[IdArea]) VALUES (@Nombre, @IdArea)";
                        cmd.CommandText = Query;
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[2];
                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = departamento.Nombre;

                        collection[1] = new SqlParameter("IdArea", SqlDbType.VarChar);
                        collection[1].Value = departamento.Area.IdArea;

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
        public static ML.Result Update(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string Query = "UPDATE [Departamento] SET Nombre = @Nombre ,IdArea = @IdArea WHERE IdDepartamento = @IdDepartamento";
                        cmd.CommandText = Query;
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[3];
                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = departamento.Nombre;

                        collection[1] = new SqlParameter("IdArea", SqlDbType.VarChar);
                        collection[1].Value = departamento.Area.IdArea;

                        collection[2] = new SqlParameter("IdDepartamento", SqlDbType.VarChar);
                        collection[2].Value = departamento.IdDepartamento;

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
        public static ML.Result Delete(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string Query = "DELETE FROM [Departamento] WHERE IdDepartamento = @IdDepartamento";
                        cmd.CommandText = Query;
                        cmd.Connection = context;

                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("IdDepartamento", SqlDbType.VarChar);
                        collection[0].Value = departamento.IdDepartamento;
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
        /* Metodo Stored procedures */
        public static ML.Result GetAllSP()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        string Query = "DepartamentoGetAll";
                        cmd.CommandText = Query;
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;
                        context.Open();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable tableDepartamento = new DataTable();
                        da.Fill(tableDepartamento);
                        if (tableDepartamento.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in tableDepartamento.Rows)
                            {
                                ML.Departamento departamento = new ML.Departamento();

                                departamento.IdDepartamento = int.Parse(row[0].ToString());
                                departamento.Nombre = row[1].ToString();

                                departamento.Area = new ML.Area();
                                departamento.Area.IdArea = int.Parse(row[2].ToString());

                                result.Objects.Add(departamento);
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
        public static ML.Result AddSP(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "DepartamentoAdd";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[2];
                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = departamento.Nombre;

                        collection[1] = new SqlParameter("IdArea", SqlDbType.VarChar);
                        collection[1].Value = departamento.Area.IdArea;

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
        public static ML.Result UpdateSP(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "DepartamentoUpdate";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[3];
                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = departamento.Nombre;

                        collection[1] = new SqlParameter("IdArea", SqlDbType.VarChar);
                        collection[1].Value = departamento.Area.IdArea;

                        collection[2] = new SqlParameter("IdDepartamento", SqlDbType.VarChar);
                        collection[2].Value = departamento.IdDepartamento;

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
        public static ML.Result DeleteSP(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandText = "DepartamentoDelete";
                        cmd.Connection = context;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];
                        collection[0] = new SqlParameter("IdDepartamento", SqlDbType.VarChar);
                        collection[0].Value = departamento.IdDepartamento;
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

        /* Metodo Stored procedures con Entity Framework */
        public static ML.Result GetByIdEF(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.DGaleanaEcommerceEntities1 context = new DL_EF.DGaleanaEcommerceEntities1())
                {
                    var query = context.DepartamentoGetById(departamento.IdDepartamento).FirstOrDefault();

                    departamento.Nombre = query.Nombre;
                    departamento.Area = new ML.Area();
                    departamento.Area.IdArea = query.IdArea.Value;

                    result.Object = departamento;
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
                using(DL_EF.DGaleanaEcommerceEntities1 context = new DL_EF.DGaleanaEcommerceEntities1())
                {
                    var departamentos = context.DepartamentoGetAll().ToList();
                    result.Objects = new List<object>();
                    if (departamentos != null)
                    {
                        foreach (var objs in departamentos)
                        {
                            ML.Departamento departamento = new ML.Departamento();

                            departamento.IdDepartamento = objs.IdDepartamento;
                            departamento.Nombre = objs.DepartamentoNombre;

                            departamento.Area = new ML.Area();
                            departamento.Area.IdArea = objs.IdArea.Value;
                            departamento.Area.Nombre = objs.AreaNombre;

                            result.Objects.Add(departamento);
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

        public static ML.Result AddEF(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result(); 
            try
            {
                using (DL_EF.DGaleanaEcommerceEntities1 context = new DL_EF.DGaleanaEcommerceEntities1())
                {
                    var query = context.DepartamentoAdd(departamento.Nombre, departamento.Area.IdArea);
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

        public static ML.Result UpdateEF(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.DGaleanaEcommerceEntities1 context = new DL_EF.DGaleanaEcommerceEntities1())
                {
                    var updateResult = context.DepartamentoUpdate(departamento.IdDepartamento, departamento.Nombre, departamento.Area.IdArea);

                        if (updateResult >= 1)
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

        public static ML.Result DeleteEF(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.DGaleanaEcommerceEntities1 context = new DL_EF.DGaleanaEcommerceEntities1())
                {
                    var query = context.DepartamentoDelete(departamento.IdDepartamento);
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

        /* Metodos EF con LinQ */
        public static ML.Result GetAllLinQ()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.DGaleanaEcommerceEntities1 context = new DL_EF.DGaleanaEcommerceEntities1())
                {
                    var query = (from departamento in context.Departamentoes
                                 select departamento).ToList();
                    result.Objects = new List<object>();
                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var objs in query)
                        {
                            ML.Departamento departamento = new ML.Departamento();

                            departamento.IdDepartamento = objs.IdDepartamento;
                            departamento.Nombre = objs.Nombre;

                            departamento.Area = new ML.Area();
                            departamento.Area.IdArea = objs.IdArea.Value;

                            result.Objects.Add(departamento);
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

        public static ML.Result AddLinQ(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.DGaleanaEcommerceEntities1 context = new DL_EF.DGaleanaEcommerceEntities1())
                {
                    DL_EF.Departamento departamentoDL = new DL_EF.Departamento();
                    departamentoDL.Nombre = departamento.Nombre;
                    departamentoDL.IdArea = departamento.Area.IdArea;

                    context.Departamentoes.Add(departamentoDL);
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

        public static ML.Result UpdateLinQ(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.DGaleanaEcommerceEntities1 context = new DL_EF.DGaleanaEcommerceEntities1())
                {
                    var query = (from departamentoDL in context.Departamentoes
                                 where departamentoDL.IdDepartamento == departamento.IdDepartamento
                                 select departamentoDL).SingleOrDefault();

                    if (query != null)
                    {
                        query.Nombre = departamento.Nombre;
                        query.IdArea = departamento.Area.IdArea;

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

        public static ML.Result DeleteLinQ(ML.Departamento departamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.DGaleanaEcommerceEntities1 context = new DL_EF.DGaleanaEcommerceEntities1())
                {
                    var query = (from departamentoDL in context.Departamentoes
                                 where departamentoDL.IdDepartamento == departamento.IdDepartamento
                                 select departamentoDL).First();

                    context.Departamentoes.Remove(query);
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

        /* Metodo GetArea By Id */
        public static ML.Result GetByIdArea(int IdArea)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.DGaleanaEcommerceEntities1 context = new DL_EF.DGaleanaEcommerceEntities1())
                {
                    var departamentos = context.DepartamentoGetByIdArea(IdArea).ToList();
                    result.Objects = new List<object>();
                    if (departamentos != null)
                    {
                        foreach (var objs in departamentos)
                        {
                            ML.Departamento departamento = new ML.Departamento();

                            departamento.IdDepartamento = objs.IdDepartamento;
                            departamento.Nombre = objs.DepartamentoNombre;

                            departamento.Area = new ML.Area();
                            departamento.Area.IdArea = objs.IdArea.Value;
                            departamento.Area.Nombre = objs.AreaNombre;

                            result.Objects.Add(departamento);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects;
using System.Data.Entity.Core.Objects;
namespace BL
{
    public class Usuario
    {

        public static ML.Result UsuarioGetAll(ML.Usuario usuarioItem)
        {
            ML.Result result = new ML.Result();
            try
            {
            using (DL_EF.DGaleanaEcommerceEntities1 context = new DL_EF.DGaleanaEcommerceEntities1())
            {
                var usuarios = context.UsuarioGetAll(usuarioItem.Nombre, usuarioItem.ApellidoPaterno, usuarioItem.ApellidoMaterno);
                result.Objects = new List<object>();
                if (usuarios != null)
                {
                    foreach (var objs in usuarios)
                    {
                        ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario = objs.IdUsuario;
                        usuario.Email = objs.Email;
                        usuario.UserPassword = objs.UserPassword;
                        usuario.Nombre = objs.UsuarioNombre;
                        usuario.ApellidoPaterno = objs.ApellidoPaterno;
                        usuario.ApellidoMaterno = objs.ApellidoMaterno;
                        usuario.FechaNacimiento = objs.FechaNacimiento.Value;
                        usuario.Sexo = objs.Sexo;
                        usuario.Estado = objs.Estado.Value;

                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = objs.IdRol;
                        usuario.Rol.Nombre = objs.RolNombre;
                        usuario.Telefono = objs.Telefono;

                        result.Objects.Add(usuario);
                    }
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "Se ha producido un error al traer los datos";
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

        public static ML.Result UsuarioAdd(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.DGaleanaEcommerceEntities1 context = new DL_EF.DGaleanaEcommerceEntities1())
                {
                    var query = Convert.ToString(context.UsuarioAdd(usuario.Email, usuario.UserPassword, usuario.Nombre, usuario.ApellidoPaterno,
                                                        usuario.ApellidoMaterno, usuario.FechaNacimiento.ToShortDateString(), usuario.Sexo, usuario.Estado,
                                                        usuario.Rol.IdRol, usuario.Telefono).FirstOrDefault());
                    if (query == "Usuario Insertado")
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        if (query.Length >= 49 && query.Substring(0, 50) == "Violation of UNIQUE KEY constraint 'UniqueEmail'.")
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ya existe el nombre de la materia registrado";
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Error al insertar los datos";
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

        public static ML.Result UsuarioUpdate(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.DGaleanaEcommerceEntities1 context = new DL_EF.DGaleanaEcommerceEntities1())
                {
                    var query = Convert.ToString(context.UsuarioUpdate(usuario.IdUsuario, usuario.Email, usuario.UserPassword, usuario.Nombre, usuario.ApellidoPaterno,
                                                        usuario.ApellidoMaterno, usuario.FechaNacimiento.ToString("dd-MM-yyyy") , usuario.Sexo, usuario.Estado,
                                                        usuario.Rol.IdRol, usuario.Telefono).FirstOrDefault());
                    if (query == "Usuario Actualizado")
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        if (query.Length >= 49 && query.Substring(0, 50) == "Violation of UNIQUE KEY constraint 'uniqueNombre'.")
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ya existe el nombre de la materia registrado";
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ha ocurrido un error al momento de actualizar";
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

        public static ML.Result UsuarioGetById(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL_EF.DGaleanaEcommerceEntities1 context = new DL_EF.DGaleanaEcommerceEntities1())
                {
                    var query = context.UsuarioGetById(usuario.IdUsuario).FirstOrDefault();

                    usuario.Email = query.Email;
                    usuario.UserPassword = query.UserPassword;
                    usuario.Nombre = query.UsuarioNombre;
                    usuario.ApellidoPaterno = query.ApellidoPaterno;
                    usuario.ApellidoMaterno = query.ApellidoMaterno;
                    usuario.FechaNacimiento = query.FechaNacimiento.Value;
                    usuario.Sexo = query.Sexo;
                    usuario.Estado = query.Estado.Value;

                    usuario.Rol = new ML.Rol();
                    usuario.Rol.IdRol = query.IdRol;
                    usuario.Rol.Nombre = query.RolNombre;
                    usuario.Telefono = query.Telefono;

                    result.Object = usuario;

                    if (query != null)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Se produjo un error al traer los datos";
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

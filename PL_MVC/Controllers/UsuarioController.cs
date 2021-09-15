using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Xml;

namespace PL_MVC.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Usuario/

        [HttpPost]
        public ActionResult AddUsers(HttpPostedFileBase url)
        { 
            //var File = url.InputStream;
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();
            //using (var reader = new StreamReader(@"File"))
            var reader = new StreamReader(url.InputStream);
            

                string line;
                bool IsFirstLine = true;
                while ((line = reader.ReadLine()) != null)
                {
                    var temp = line.Split('|');
                    ML.Usuario usuario = new ML.Usuario();
                    if (!IsFirstLine)
                    {
                        usuario.Email = temp[0];
                        usuario.UserPassword = temp[1];
                        usuario.Nombre = temp[2];
                        usuario.ApellidoPaterno = temp[3];
                        usuario.ApellidoMaterno = temp[4];
                        usuario.FechaNacimiento = Convert.ToDateTime(temp[5]);
                        usuario.Sexo = temp[6];
                        usuario.Estado = Convert.ToBoolean(temp[7]);
                        usuario.Rol = new ML.Rol();
                        usuario.Rol.IdRol = int.Parse(temp[8]);
                        usuario.Telefono = temp[9];
                        result.Objects.Add(usuario);
                        BL.Usuario.UsuarioAdd(usuario);
                    }
                    else
                    {
                        IsFirstLine = false;
                    }
                }
            
            return RedirectToAction("GetAll");
        }

        [HttpPost]
        public ActionResult GetAll(ML.Usuario usuario)
        {
            if (usuario.Nombre == null)
            {
                usuario.Nombre = "";
            }
            if (usuario.ApellidoPaterno == null)
            {
                usuario.ApellidoPaterno = "";
            }
            if (usuario.ApellidoMaterno == null)
            {
                usuario.ApellidoMaterno = "";
            }
            ML.Result result = BL.Usuario.UsuarioGetAll(usuario);
            usuario.Usuarios = result.Objects;
            return View(usuario);
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Usuario usuario = new ML.Usuario();
            if (usuario.Nombre == null)
            {
                usuario.Nombre = "";
            }
            if (usuario.ApellidoPaterno == null)
            {
                usuario.ApellidoPaterno = "";
            }
            if (usuario.ApellidoMaterno == null)
            {
                usuario.ApellidoMaterno = "";
            }
            ML.Result result = BL.Usuario.UsuarioGetAll(usuario);
            usuario.Usuarios = result.Objects;
            return View(usuario);
        }

        [HttpGet]
        public ActionResult Form(int? IdUsuario) 
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.IdUsuario = IdUsuario.GetValueOrDefault();

            ML.Result resultRoles = BL.Rol.RolGetAll();
            usuario.Rol = new ML.Rol();
            usuario.Rol.Rols = resultRoles.Objects;

            if (IdUsuario == null)//Add
            {
                return View(usuario);
            }
            else //Update
            {            
                ML.Result result = BL.Usuario.UsuarioGetById(usuario);

                if(result.Correct){
                usuario.Rol.Rols = resultRoles.Objects;

                usuario.IdUsuario = ((ML.Usuario)result.Object).IdUsuario;
                usuario.Email = ((ML.Usuario)result.Object).Email;
                usuario.UserPassword = ((ML.Usuario)result.Object).UserPassword;
                usuario.UserPassword = ((ML.Usuario)result.Object).UserPassword;
                usuario.Nombre = ((ML.Usuario)result.Object).Nombre;
                usuario.ApellidoPaterno = ((ML.Usuario)result.Object).ApellidoPaterno;
                usuario.ApellidoMaterno = ((ML.Usuario)result.Object).ApellidoMaterno;
                usuario.FechaNacimiento = ((ML.Usuario)result.Object).FechaNacimiento;
                usuario.Sexo = ((ML.Usuario)result.Object).Sexo;
                usuario.Estado = ((ML.Usuario)result.Object).Estado;
                usuario.Rol.IdRol = ((ML.Usuario)result.Object).Rol.IdRol;
                usuario.Telefono = ((ML.Usuario)result.Object).Telefono;

                return View(usuario);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return PartialView("Modal");
                }
                
            }
        }

        [HttpPost]
        public ActionResult Form(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            if (usuario.IdUsuario == 0)
            {
                result = BL.Usuario.UsuarioAdd(usuario);
                ViewBag.Message = "El Usuario se agregó correctamente ";
            }
            else
            {
                result = BL.Usuario.UsuarioUpdate(usuario);
                ViewBag.Message = "El Usuario se actualizó correctamente ";
            }
            if (!result.Correct)
            {
                ViewBag.Message = "Hubo un problema al momento de agregar " + result.ErrorMessage;
            }
            return PartialView("Modal");
        }

        public ActionResult UpdateEstado(int? IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.IdUsuario = IdUsuario.GetValueOrDefault();
            ML.Result result = BL.Usuario.UsuarioGetById(usuario);

            if (result.Correct)
            {
                usuario.IdUsuario = ((ML.Usuario)result.Object).IdUsuario;
                usuario.Email = ((ML.Usuario)result.Object).Email;
                usuario.UserPassword = ((ML.Usuario)result.Object).UserPassword;
                usuario.UserPassword = ((ML.Usuario)result.Object).UserPassword;
                usuario.Nombre = ((ML.Usuario)result.Object).Nombre;
                usuario.ApellidoPaterno = ((ML.Usuario)result.Object).ApellidoPaterno;
                usuario.ApellidoMaterno = ((ML.Usuario)result.Object).ApellidoMaterno;
                usuario.FechaNacimiento = ((ML.Usuario)result.Object).FechaNacimiento;
                usuario.Sexo = ((ML.Usuario)result.Object).Sexo;               
                usuario.Estado = ((ML.Usuario)result.Object).Estado;
                if (usuario.Estado == true)
                {
                    usuario.Estado = false;
                }
                else
                {
                    usuario.Estado = true;
                }
                usuario.Rol.IdRol = ((ML.Usuario)result.Object).Rol.IdRol;
                usuario.Telefono = ((ML.Usuario)result.Object).Telefono;

                result = BL.Usuario.UsuarioUpdate(usuario);
                if (result.Correct)
                {
                    return RedirectToAction("GetAll");
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return PartialView("Modal");
                }
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
                return PartialView("Modal");
            }
        }

        public FileResult GetTxt(int IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.IdUsuario = IdUsuario;
            ML.Result result = BL.Usuario.UsuarioGetById(usuario);
            string body = "";

            usuario = (ML.Usuario)result.Object;
            body += "Id: " + usuario.IdUsuario + "\n";
            body += "Email: " + usuario.Email + "\n";
            body += "UserPassword: " + usuario.UserPassword + "\n";
            body += "Nombre: " + usuario.Nombre + "\n";
            body += "ApellidoPaterno: " + usuario.ApellidoPaterno + "\n";
            body += "ApellidoMaterno: " + usuario.ApellidoMaterno + "\n";
            body += "FechaNacimiento: " + usuario.FechaNacimiento + "\n";
            body += "Sexo: " + usuario.Sexo + "\n";
            body += "IdRol: " + usuario.Rol.IdRol + "\n";
            body += "Nombre de Rol: " + usuario.Rol.Nombre + "\n";
            body += "Telefono: " + usuario.Telefono + "\n";         
               
            byte[] contenido = System.Text.Encoding.ASCII.GetBytes(body);

            return File(contenido, "text/plain", "User.txt");
        }

        public FileResult GetXml(int IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.IdUsuario = IdUsuario;
            ML.Result result = BL.Usuario.UsuarioGetById(usuario);
            usuario = (ML.Usuario)result.Object;

            string fileName = "file.xml";

            var XML = new System.Xml.Serialization.XmlSerializer(typeof(ML.Usuario));
            var xml = "";
            using (var sw = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(sw))
                {
                    XML.Serialize(writer, usuario);
                    xml = sw.ToString();
                }
            }    
            byte[] contenido = System.Text.Encoding.ASCII.GetBytes(xml);
            return File(contenido, "application/xml", fileName);
            
        }
	}
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
     class Usuario
    {
         public static void LeerTxt()
         {
             ML.Result result = new ML.Result();
             result.Objects = new List<object>();
             using (var reader = new StreamReader(@"C:\Users\digis\Desktop\txt\test.txt"))
             {

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
                         //BL.Usuario.UsuarioAdd(usuario);
                     }
                     else
                     {
                         IsFirstLine = false;
                     }
                     Console.WriteLine(result.Objects);
                         
                 }
             }  
         }

    }
}

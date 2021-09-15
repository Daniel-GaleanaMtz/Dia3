using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    class Departamento
    {
        public static void GetAll()
        {
            ML.Result result = BL.Departamento.GetAll();

            foreach (ML.Departamento departamento in result.Objects)
            {
                Console.WriteLine("IdDepartamento: " + departamento.IdDepartamento);
                Console.WriteLine("Nombre: " + departamento.Nombre);
                Console.WriteLine("IdArea: " + departamento.Area.IdArea);
                Console.WriteLine();
            }
        }
        public static void Add()
        {
            ML.Departamento departamento = new ML.Departamento();

            Console.WriteLine("Escribe el nombre del departamento: ");
            departamento.Nombre = Console.ReadLine();

            Console.WriteLine("Escribe el id del Area: ");
            departamento.Area = new ML.Area();
            departamento.Area.IdArea = int.Parse(Console.ReadLine());

            ML.Result result = BL.Departamento.Add(departamento);

            if (result.Correct)
            {
                Console.WriteLine("Datos agregados exitosamente");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error" + result.ErrorMessage);
            }
        }
        public static void Update()
        {
            ML.Departamento departamento = new ML.Departamento();

            Console.WriteLine("Escribe el Id el cual vamos a actualizar: ");
            departamento.IdDepartamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el nuevo nombre del departamento: ");
            departamento.Nombre = Console.ReadLine();

            Console.WriteLine("Escribe el nuevo id del Area: ");
            departamento.Area = new ML.Area();
            departamento.Area.IdArea = int.Parse(Console.ReadLine());

            ML.Result result = BL.Departamento.Update(departamento);

            if (result.Correct)
            {
                Console.WriteLine("Datos agregados exitosamente");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error" + result.ErrorMessage);
            }
        }
        public static void Delete()
        {
            ML.Departamento departamento = new ML.Departamento();

            Console.WriteLine("Introduce el Id del departamento a eliminar: ");
            departamento.IdDepartamento = int.Parse(Console.ReadLine());

            ML.Result result = BL.Departamento.Delete(departamento);

            if (result.Correct)
            {
                Console.WriteLine("Datos agregados exitosamente");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error" + result.ErrorMessage);
            }
        }
        /* Metodos de Stored procedures */
        public static void GetAllSP()
        {
            ML.Result result = BL.Departamento.GetAllSP();

            foreach (ML.Departamento departamento in result.Objects)
            {
                Console.WriteLine("IdDepartamento: " + departamento.IdDepartamento);
                Console.WriteLine("Nombre: " + departamento.Nombre);
                Console.WriteLine("IdArea: " + departamento.Area.IdArea);
                Console.WriteLine();
            }
        }
        public static void AddSP()
        {
            ML.Departamento departamento = new ML.Departamento();

            Console.WriteLine("Escribe el nombre del departamento: ");
            departamento.Nombre = Console.ReadLine();

            Console.WriteLine("Escribe el id del Area: ");
            departamento.Area = new ML.Area();
            departamento.Area.IdArea = int.Parse(Console.ReadLine());

            ML.Result result = BL.Departamento.AddSP(departamento);

            if (result.Correct)
            {
                Console.WriteLine("Datos agregados exitosamente");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error" + result.ErrorMessage);
            }
        }
        public static void UpdateSP()
        {
            ML.Departamento departamento = new ML.Departamento();

            Console.WriteLine("Escribe el Id el cual vamos a actualizar: ");
            departamento.IdDepartamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el nuevo nombre del departamento: ");
            departamento.Nombre = Console.ReadLine();

            Console.WriteLine("Escribe el nuevo id del Area: ");
            departamento.Area = new ML.Area();
            departamento.Area.IdArea = int.Parse(Console.ReadLine());

            ML.Result result = BL.Departamento.UpdateSP(departamento);

            if (result.Correct)
            {
                Console.WriteLine("Datos agregados exitosamente");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error" + result.ErrorMessage);
            }
        }
        public static void DeleteSP()
        {
            ML.Departamento departamento = new ML.Departamento();

            Console.WriteLine("Introduce el Id del departamento a eliminar: ");
            departamento.IdDepartamento = int.Parse(Console.ReadLine());

            ML.Result result = BL.Departamento.DeleteSP(departamento);

            if (result.Correct)
            {
                Console.WriteLine("Datos agregados exitosamente");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error" + result.ErrorMessage);
            }
        }
        /* Metodo Stored procedures con Entity Framework */
        public static void GetAllEF()
        {
            ML.Result result = BL.Departamento.GetAllEF();

            foreach (ML.Departamento departamento in result.Objects)
            {
                Console.WriteLine("IdDepartamento: " + departamento.IdDepartamento);
                Console.WriteLine("Nombre: " + departamento.Nombre);
                Console.WriteLine("IdArea: " + departamento.Area.IdArea);
                Console.WriteLine();
            }
        }

        public static void AddEF()
        {
            ML.Departamento departamento = new ML.Departamento();

            Console.WriteLine("Escribe el nombre del departamento: ");
            departamento.Nombre = Console.ReadLine();

            Console.WriteLine("Escribe el id del Area: ");
            departamento.Area = new ML.Area();
            departamento.Area.IdArea = int.Parse(Console.ReadLine());

            ML.Result result = BL.Departamento.AddEF(departamento);

            if (result.Correct)
            {
                Console.WriteLine("Datos agregados exitosamente");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error" + result.ErrorMessage);
            }
        }

        public static void UpdateEF()
        {
            ML.Departamento departamento = new ML.Departamento();

            Console.WriteLine("Escribe el Id el cual vamos a actualizar: ");
            departamento.IdDepartamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el nuevo nombre del departamento: ");
            departamento.Nombre = Console.ReadLine();

            Console.WriteLine("Escribe el nuevo id del Area: ");
            departamento.Area = new ML.Area();
            departamento.Area.IdArea = int.Parse(Console.ReadLine());

            ML.Result result = BL.Departamento.UpdateEF(departamento);

            if (result.Correct)
            {
                Console.WriteLine("Datos agregados exitosamente");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error" + result.ErrorMessage);
            }
        }

        public static void DeleteEF()
        {
            ML.Departamento departamento = new ML.Departamento();

            Console.WriteLine("Introduce el Id del departamento a eliminar: ");
            departamento.IdDepartamento = int.Parse(Console.ReadLine());

            ML.Result result = BL.Departamento.DeleteEF(departamento);

            if (result.Correct)
            {
                Console.WriteLine("Datos eliminados exitosamente");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error" + result.ErrorMessage);
            }
        }

        /* Metodo LinQ */

        public static void GetAllLinQ()
        {
            ML.Result result = BL.Departamento.GetAllLinQ();

            foreach (ML.Departamento departamento in result.Objects)
            {
                Console.WriteLine("IdDepartamento: " + departamento.IdDepartamento);
                Console.WriteLine("Nombre: " + departamento.Nombre);
                Console.WriteLine("IdArea: " + departamento.Area.IdArea);
                Console.WriteLine();
            }
        }

        public static void AddLinQ()
        {
            ML.Departamento departamento = new ML.Departamento();

            Console.WriteLine("Escribe el nombre del departamento: ");
            departamento.Nombre = Console.ReadLine();

            Console.WriteLine("Escribe el id del Area: ");
            departamento.Area = new ML.Area();
            departamento.Area.IdArea = int.Parse(Console.ReadLine());

            ML.Result result = BL.Departamento.AddLinQ(departamento);

            if (result.Correct)
            {
                Console.WriteLine("Datos agregados exitosamente");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error" + result.ErrorMessage);
            }
        }

        public static void UpdateLinQ()
        {
            ML.Departamento departamento = new ML.Departamento();

            Console.WriteLine("Escribe el Id el cual vamos a actualizar: ");
            departamento.IdDepartamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el nuevo nombre del departamento: ");
            departamento.Nombre = Console.ReadLine();

            Console.WriteLine("Escribe el nuevo id del Area: ");
            departamento.Area = new ML.Area();
            departamento.Area.IdArea = int.Parse(Console.ReadLine());

            ML.Result result = BL.Departamento.UpdateLinQ(departamento);

            if (result.Correct)
            {
                Console.WriteLine("Datos agregados exitosamente");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error" + result.ErrorMessage);
            }
        }

        public static void DeleteLinQ()
        {
            ML.Departamento departamento = new ML.Departamento();

            Console.WriteLine("Introduce el Id del departamento a eliminar: ");
            departamento.IdDepartamento = int.Parse(Console.ReadLine());

            ML.Result result = BL.Departamento.DeleteLinQ(departamento);

            if (result.Correct)
            {
                Console.WriteLine("Datos eliminados exitosamente");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error" + result.ErrorMessage);
            }
        }


    }
}

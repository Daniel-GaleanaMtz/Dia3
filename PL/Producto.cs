using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    class Producto
    {
        public static void GetAll()
        {
            ML.Result result = BL.Producto.GetAll();

            foreach (ML.Producto producto in result.Objects)
            {
                Console.WriteLine("IdProducto: " + producto.IdProducto);
                Console.WriteLine("Nombre: " + producto.Nombre);
                Console.WriteLine("Precio: " + producto.Precio);
                Console.WriteLine("Stock: " + producto.Stock);
                Console.WriteLine("Proveedor: " + producto.Proveedor.IdProveedor);
                Console.WriteLine("Departamento: " + producto.Departamento.IdDepartamento);
                Console.WriteLine("Descripcion: " + producto.Descripcion);
                Console.WriteLine();
            }
        }
        public static void Add()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Escribe el nombre del producto: ");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Introduce el precio del producto: ");
            producto.Precio = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el Stock del producto:  ");
            producto.Stock = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el Id del proveedor");
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el Id del departamento");
            producto.Departamento = new ML.Departamento();
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Agrega la descripción del producto:");
            producto.Descripcion = Console.ReadLine();

            ML.Result result = BL.Producto.Add(producto);

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
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Escribe el id del cual quieres actualizar");
            producto.IdProducto = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el nombre del producto: ");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Escribe el precio del producto a actualizar: ");
            producto.Precio = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el nuevo Stock ");
            producto.Stock = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el Id del proveedor");
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el Id del departamento");
            producto.Departamento = new ML.Departamento();
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Actualiza la descripción");
            producto.Descripcion = Console.ReadLine();

            ML.Result result = BL.Producto.Update(producto);

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
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Escribe el id de la fila a eliminar: ");
            producto.IdProducto = int.Parse(Console.ReadLine());

            ML.Result result = BL.Producto.Delete(producto);

            if (result.Correct)
            {
                Console.WriteLine("Datos agregados exitosamente");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error" + result.ErrorMessage);
            }

        }
        /* Metodos de Stored Procedures */
        public static void GetAllSP()
        {
            ML.Result result = BL.Producto.GetAllSP();

            foreach (ML.Producto producto in result.Objects)
            {
                Console.WriteLine("IdProducto: " + producto.IdProducto);
                Console.WriteLine("Nombre: " + producto.Nombre);
                Console.WriteLine("Precio: " + producto.Precio);
                Console.WriteLine("Stock: " + producto.Stock);
                Console.WriteLine("Proveedor: " + producto.Proveedor.IdProveedor);
                Console.WriteLine("Departamento: " + producto.Departamento.IdDepartamento);
                Console.WriteLine("Descripcion: " + producto.Descripcion);
                Console.WriteLine();
            }
        }
        public static void AddSP()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Escribe el nombre del producto: ");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Introduce el precio del producto: ");
            producto.Precio = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el Stock del producto:  ");
            producto.Stock = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el Id del proveedor");
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el Id del departamento");
            producto.Departamento = new ML.Departamento();
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Agrega la descripción del producto:");
            producto.Descripcion = Console.ReadLine();

            ML.Result result = BL.Producto.AddSP(producto);

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
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Escribe el id del cual quieres actualizar");
            producto.IdProducto = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el nombre del producto: ");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Escribe el precio del producto a actualizar: ");
            producto.Precio = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el nuevo Stock ");
            producto.Stock = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el Id del proveedor");
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el Id del departamento");
            producto.Departamento = new ML.Departamento();
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Actualiza la descripción");
            producto.Descripcion = Console.ReadLine();

            ML.Result result = BL.Producto.UpdateSP(producto);

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
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Escribe el id de la fila a eliminar: ");
            producto.IdProducto = int.Parse(Console.ReadLine());

            ML.Result result = BL.Producto.DeleteSP(producto);

            if (result.Correct)
            {
                Console.WriteLine("Datos agregados exitosamente");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error" + result.ErrorMessage);
            }

        }
        /* Metodos utilizando Entity Framework */

        public static void GetByIdEF()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Lista de productos: ");
            GetAllEF();
            Console.WriteLine("Escribe el Id a seleccionar: ");
            producto.IdProducto = int.Parse(Console.ReadLine());

            ML.Result result = BL.Producto.GetByIdEF(producto);

            if (result.Correct)
            {
                Console.WriteLine("Producto Seleccionado: ");
                Console.WriteLine("IdProducto: " + producto.IdProducto);
                Console.WriteLine("Nombre: " + producto.Nombre);
                Console.WriteLine("Precio: " + producto.Precio);
                Console.WriteLine("Stock: " + producto.Stock);
                Console.WriteLine("Proveedor: " + producto.Proveedor.IdProveedor);
                Console.WriteLine("Departamento: " + producto.Departamento.IdDepartamento);
                Console.WriteLine("Descripcion: " + producto.Descripcion);
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error" + result.ErrorMessage);
            }
        }

        public static void GetAllEF()
        {
            ML.Result result = BL.Producto.GetAllEF();

            foreach (ML.Producto producto in result.Objects)
            {
                Console.WriteLine("IdProducto: " + producto.IdProducto);
                Console.WriteLine("Nombre: " + producto.Nombre);
                Console.WriteLine("Precio: " + producto.Precio);
                Console.WriteLine("Stock: " + producto.Stock);
                Console.WriteLine("Proveedor: " + producto.Proveedor.IdProveedor);
                Console.WriteLine("Departamento: " + producto.Departamento.IdDepartamento);
                Console.WriteLine("Descripcion: " + producto.Descripcion);
                Console.WriteLine();
            }
        }

        public static void AddEF()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Escribe el nombre del producto: ");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Introduce el precio del producto: ");
            producto.Precio = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el Stock del producto:  ");
            producto.Stock = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el Id del proveedor");
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el Id del departamento");
            producto.Departamento = new ML.Departamento();
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Agrega la descripción del producto:");
            producto.Descripcion = Console.ReadLine();

            ML.Result result = BL.Producto.AddEF(producto);

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
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Escribe el id del cual quieres actualizar");
            producto.IdProducto = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el nombre del producto: ");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Escribe el precio del producto a actualizar: ");
            producto.Precio = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el nuevo Stock ");
            producto.Stock = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el Id del proveedor");
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el Id del departamento");
            producto.Departamento = new ML.Departamento();
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Actualiza la descripción");
            producto.Descripcion = Console.ReadLine();

            ML.Result result = BL.Producto.UpdateEF(producto);

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
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Escribe el id de la fila a eliminar: ");
            producto.IdProducto = int.Parse(Console.ReadLine());

            ML.Result result = BL.Producto.DeleteEF(producto);

            if (result.Correct)
            {
                Console.WriteLine("Datos eliminados exitosamente");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error" + result.ErrorMessage);
            }

        }

        /* Metodos utilizando Entity Framework y LinQ*/

        public static void GetAllLinQ()
        {
            ML.Result result = BL.Producto.GetAllLinQ();

            foreach (ML.Producto producto in result.Objects)
            {
                Console.WriteLine("IdProducto: " + producto.IdProducto);
                Console.WriteLine("Nombre: " + producto.Nombre);
                Console.WriteLine("Precio: " + producto.Precio);
                Console.WriteLine("Stock: " + producto.Stock);
                Console.WriteLine("Proveedor: " + producto.Proveedor.IdProveedor);
                Console.WriteLine("Departamento: " + producto.Departamento.IdDepartamento);
                Console.WriteLine("Descripcion: " + producto.Descripcion);
                Console.WriteLine();
            }
        }

        public static void AddLinQ()
        {
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Escribe el nombre del producto: ");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Introduce el precio del producto: ");
            producto.Precio = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el Stock del producto:  ");
            producto.Stock = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el Id del proveedor");
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el Id del departamento");
            producto.Departamento = new ML.Departamento();
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Agrega la descripción del producto:");
            producto.Descripcion = Console.ReadLine();

            ML.Result result = BL.Producto.AddLinQ(producto);

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
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Escribe el id del cual quieres actualizar");
            producto.IdProducto = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el nombre del producto: ");
            producto.Nombre = Console.ReadLine();

            Console.WriteLine("Escribe el precio del producto a actualizar: ");
            producto.Precio = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el nuevo Stock ");
            producto.Stock = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el Id del proveedor");
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.IdProveedor = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el Id del departamento");
            producto.Departamento = new ML.Departamento();
            producto.Departamento.IdDepartamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Actualiza la descripción");
            producto.Descripcion = Console.ReadLine();

            ML.Result result = BL.Producto.UpdateLinQ(producto);

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
            ML.Producto producto = new ML.Producto();

            Console.WriteLine("Escribe el id de la fila a eliminar: ");
            producto.IdProducto = int.Parse(Console.ReadLine());

            ML.Result result = BL.Producto.DeleteLinQ(producto);

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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    class Services_WCF
    {
        public static void DepartamentoAdd()
        {
            ML.Departamento departamento = new ML.Departamento();
            SL_WCF.Result result = new SL_WCF.Result();
            Console.WriteLine("Escribe el nombre del departamento: ");
            departamento.Nombre = Console.ReadLine();

            Console.WriteLine("Escribe el id del Area: ");
            departamento.Area = new ML.Area();
            departamento.Area.IdArea = int.Parse(Console.ReadLine());

            ServiceReferenceDepartamento.ServiceDepartamentoClient service = new ServiceReferenceDepartamento.ServiceDepartamentoClient();
            service.Add(departamento);

            if (result.Correct)
            {
                Console.WriteLine("Datos agregados exitosamente");
            }
            else
            {
                Console.WriteLine("Ocurrio un error" + result.ErrorMessage);
            }
        }

        public static void DepartamentoUpdate()
        {
            ML.Departamento departamento = new ML.Departamento();
            SL_WCF.Result result = new SL_WCF.Result();

            Console.WriteLine("Escribe el Id el cual vamos a actualizar: ");
            departamento.IdDepartamento = int.Parse(Console.ReadLine());

            Console.WriteLine("Escribe el nuevo nombre del departamento: ");
            departamento.Nombre = Console.ReadLine();

            Console.WriteLine("Escribe el nuevo id del Area: ");
            departamento.Area = new ML.Area();
            departamento.Area.IdArea = int.Parse(Console.ReadLine());

            ServiceReferenceDepartamento.ServiceDepartamentoClient service = new ServiceReferenceDepartamento.ServiceDepartamentoClient();
            service.Update(departamento);

            if (result.Correct)
            {
                Console.WriteLine("Datos actualizados exitosamente");
            }
            else
            {
                Console.WriteLine("Ocurrio un error" + result.ErrorMessage);
            }
            
        }

        public static void DepartamentoDelete()
        {
            ML.Departamento departamento = new ML.Departamento();
            SL_WCF.Result result = new SL_WCF.Result();

            Console.WriteLine("Introduce el Id del departamento a eliminar: ");
            departamento.IdDepartamento = int.Parse(Console.ReadLine());

            ServiceReferenceDepartamento.ServiceDepartamentoClient service = new ServiceReferenceDepartamento.ServiceDepartamentoClient();
            service.Delete(departamento);

            if (result.Correct)
            {
                Console.WriteLine("Datos eliminados exitosamente");
            }
            else
            {
                Console.WriteLine("Ocurrio un error" + result.ErrorMessage);
            }
        }

        public static void DepartamentoGetAll()
        {
            ML.Departamento depto = new ML.Departamento();
            ML.Result result = new ML.Result();
            ServiceReferenceDepartamento.ServiceDepartamentoClient service = new ServiceReferenceDepartamento.ServiceDepartamentoClient();
            var SL_result= service.GetAll(depto);
            result.Objects = SL_result.Objects;
            
            foreach (ML.Departamento departamento in result.Objects)
            {
                Console.WriteLine("IdDepartamento: " + departamento.IdDepartamento);
                Console.WriteLine("Nombre: " + departamento.Nombre);
                Console.WriteLine("IdArea: " + departamento.Area.IdArea);
                Console.WriteLine();
            }
        }

        public static void DepartamentoGetById()
        {
            ML.Departamento departamento = new ML.Departamento();
            ML.Result result = new ML.Result();
            Console.WriteLine("Escribe el id del Departamento a mostrar: ");
            departamento.IdDepartamento = int.Parse(Console.ReadLine());

            ServiceReferenceDepartamento.ServiceDepartamentoClient service = new ServiceReferenceDepartamento.ServiceDepartamentoClient();
            var SL_result = service.GetById(departamento);
            result.Correct = SL_result.Correct;
            result.ErrorMessage = SL_result.ErrorMessage;

            if (result.Correct)
            {
                Console.WriteLine("Departamento Seleccionado: ");
                Console.WriteLine("IdDepartamento: " + ((ML.Departamento)SL_result.Object).IdDepartamento);
                Console.WriteLine("Nombre: " + ((ML.Departamento)SL_result.Object).Nombre);
                Console.WriteLine("IdArea: " + ((ML.Departamento)SL_result.Object).Area.IdArea);
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error" + result.ErrorMessage);
            }

        }

        //-----------------    Producto     -----------------------
        public static void ProductoAdd()
        {
            SL_WCF.Result result = new SL_WCF.Result();
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

            ServiceReferenceProducto.ServiceProductoClient service = new ServiceReferenceProducto.ServiceProductoClient();
            service.Add(producto);

            if (result.Correct)
            {
                Console.WriteLine("Datos agregados exitosamente");
            }
            else
            {
                Console.WriteLine("Ocurrio un error" + result.ErrorMessage);
            }
        }

        public static void ProductoUpdate()
        {
            SL_WCF.Result result = new SL_WCF.Result();
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

            ServiceReferenceProducto.ServiceProductoClient service = new ServiceReferenceProducto.ServiceProductoClient();
            service.Update(producto);

            if (result.Correct)
            {
                Console.WriteLine("Datos actualizados exitosamente");
            }
            else
            {
                Console.WriteLine("Ocurrio un error" + result.ErrorMessage);
            }
        }

        public static void DeleteProducto()
        {
            ML.Producto producto = new ML.Producto();
            SL_WCF.Result result = new SL_WCF.Result();

            Console.WriteLine("Escribe el id de la fila a eliminar: ");
            producto.IdProducto = int.Parse(Console.ReadLine());

            ServiceReferenceProducto.ServiceProductoClient service = new ServiceReferenceProducto.ServiceProductoClient();
            service.Delete(producto);
            if (result.Correct)
            {
                Console.WriteLine("Datos eliminados exitosamente");
            }
            else
            {
                Console.WriteLine("Ocurrio un error" + result.ErrorMessage);
            }
        }

        public static void ProductoGetAll()
        {
            ML.Producto producto = new ML.Producto();
            ML.Result result = new ML.Result();
            ServiceReferenceProducto.ServiceProductoClient service = new ServiceReferenceProducto.ServiceProductoClient();
            var SL_result = service.GetAll(producto);
            result.Objects = SL_result.Objects;

            foreach (ML.Producto productos in result.Objects)
            {
                Console.WriteLine("IdProducto: " + productos.IdProducto);
                Console.WriteLine("Nombre: " + productos.Nombre);
                Console.WriteLine("Precio: " + productos.Precio);
                Console.WriteLine("Stock: " + productos.Stock);
                Console.WriteLine("Proveedor: " + productos.Proveedor.IdProveedor);
                Console.WriteLine("Departamento: " + productos.Departamento.IdDepartamento);
                Console.WriteLine("Descripcion: " + productos.Descripcion);
                Console.WriteLine();
            }
        }

        public static void ProductoGetById()
        {
            ML.Producto producto = new ML.Producto();
            ML.Result result = new ML.Result();
            Console.WriteLine("Escribe el id del Departamento a mostrar: ");
            producto.IdProducto = int.Parse(Console.ReadLine());

            ServiceReferenceProducto.ServiceProductoClient service = new ServiceReferenceProducto.ServiceProductoClient();
            var SL_result = service.GetById(producto);
            result.Objects = SL_result.Objects;
            result.Correct = SL_result.Correct;
            result.ErrorMessage = SL_result.ErrorMessage;

            if (result.Correct)
            {
                Console.WriteLine("Producto Seleccionado: ");
                Console.WriteLine("IdProducto: " + ((ML.Producto)SL_result.Object).IdProducto);
                Console.WriteLine("Nombre: " + ((ML.Producto)SL_result.Object).Nombre);
                Console.WriteLine("Precio: " + ((ML.Producto)SL_result.Object).Precio);
                Console.WriteLine("Stock: " + ((ML.Producto)SL_result.Object).Stock);
                Console.WriteLine("Proveedor: " + ((ML.Producto)SL_result.Object).Proveedor.IdProveedor);
                Console.WriteLine("Departamento: " + ((ML.Producto)SL_result.Object).Departamento.IdDepartamento);
                Console.WriteLine("Descripcion: " + ((ML.Producto)SL_result.Object).Descripcion);
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error" + result.ErrorMessage);
            }
        }

        public static void Login()
        {
            string user, pass;
            ServiceReferenceLogin.ServiceLoginClient service = new ServiceReferenceLogin.ServiceLoginClient();

            Console.WriteLine("Ingresa tú usuario: ");
            user = Console.ReadLine();
            Console.WriteLine("Ingresa la contraseña: ");
            pass = Console.ReadLine();
            if (service.isCorrect(user, pass))
            {
                Console.WriteLine("Conexion Exitosa");
            }
            else
            {
                Console.WriteLine("Acceso Denegado");
            }
            Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    class Venta
    {
        public static void AddSP()
        {
            ML.Venta venta = new ML.Venta();
            string respuesta;
            Console.WriteLine("Quieres realizar una compra? Y/N: ");
            respuesta = Console.ReadLine();
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();
            venta.Total = 0;
            while (respuesta == "Y")
            {
                Console.WriteLine("Lista de Productos: \n");
                PL.Producto.GetAllSP();

                Console.WriteLine("Escribe el id del Cliente: ");
                venta.Cliente = new ML.Cliente();
                venta.Cliente.IdCliente = int.Parse(Console.ReadLine());

                Console.WriteLine("Introduce el id del metodo de Pago ");
                venta.MetodoPago = new ML.MetodoPago();
                venta.MetodoPago.IdMetodoPago = int.Parse(Console.ReadLine());

                ML.VentaProducto ventaProducto = new ML.VentaProducto();
                Console.WriteLine("Introduzca el id del producto a comprar ");
                ventaProducto.Producto = new ML.Producto();
                ventaProducto.Producto.IdProducto = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingresa la cantidad del producto: ");
                ventaProducto.Cantidad = int.Parse(Console.ReadLine());

                result.Objects.Add(ventaProducto);

                ML.Result resultProducto = BL.Producto.GetById(ventaProducto.Producto.IdProducto);

                decimal subTotal = ventaProducto.Cantidad * ((ML.Producto)resultProducto.Object).Precio;

                venta.Total += subTotal;

                Console.WriteLine("Desea agregar otro producto? Y/N: ");
                respuesta = Console.ReadLine();
            } 
            if (respuesta == "N")
            {
                result = BL.Venta.AddSP(venta, result.Objects);

                if (result.Correct)
                {
                    Console.WriteLine("Datos agregados exitosamente");
                }
                else
                {
                    Console.WriteLine("Ha ocurrido un error" + result.ErrorMessage);
                }
            }            
        }

        /* Metodo con Entity Framework */
        public static void AddEF()
        {
            ML.Venta venta = new ML.Venta();
            string respuesta;
            Console.WriteLine("Quieres realizar una compra? Y/N: ");
            respuesta = Console.ReadLine();
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();
            venta.Total = 0;
            while (respuesta == "Y")
            {
                Console.WriteLine("Lista de Productos: \n");
                PL.Producto.GetAllSP();

                Console.WriteLine("Escribe el id del Cliente: ");
                venta.Cliente = new ML.Cliente();
                venta.Cliente.IdCliente = int.Parse(Console.ReadLine());

                Console.WriteLine("Introduce el id del metodo de Pago ");
                venta.MetodoPago = new ML.MetodoPago();
                venta.MetodoPago.IdMetodoPago = int.Parse(Console.ReadLine());

                ML.VentaProducto ventaProducto = new ML.VentaProducto();
                Console.WriteLine("Introduzca el id del producto a comprar ");
                ventaProducto.Producto = new ML.Producto();
                ventaProducto.Producto.IdProducto = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingresa la cantidad del producto: ");
                ventaProducto.Cantidad = int.Parse(Console.ReadLine());

                result.Objects.Add(ventaProducto);

                ML.Result resultProducto = BL.Producto.GetByIdEF(ventaProducto.Producto);

                decimal subTotal = ventaProducto.Cantidad * ((ML.Producto)resultProducto.Object).Precio;

                venta.Total += subTotal;

                Console.WriteLine("Desea agregar otro producto? Y/N: ");
                respuesta = Console.ReadLine();
            }
            if (respuesta == "N")
            {
                result = BL.Venta.AddEF(venta, result.Objects);

                if (result.Correct)
                {
                    Console.WriteLine("Datos agregados exitosamente");
                }
                else
                {
                    Console.WriteLine("Ha ocurrido un error" + result.ErrorMessage);
                }
            }
        }
    }
}

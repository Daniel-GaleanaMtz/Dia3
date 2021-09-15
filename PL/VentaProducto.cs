using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    class VentaProducto
    {
        public static void AddSP()
        {
            ML.VentaProducto ventaproducto = new ML.VentaProducto();

            Console.WriteLine("Escriba el Id de la Venta: ");
            ventaproducto.Venta = new ML.Venta();
            ventaproducto.Venta.IdVenta = int.Parse(Console.ReadLine());

            Console.WriteLine("Introduce la cantidad de la venta: ");
            ventaproducto.Cantidad = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el id del producto ");
            ventaproducto.Producto = new ML.Producto();
            ventaproducto.Producto.IdProducto = int.Parse(Console.ReadLine());

            ML.Result result = BL.VentaProducto.AddPS(ventaproducto);

            if (result.Correct)
            {
                Console.WriteLine("Datos agregados exitosamente");
            }
            else
            {
                Console.WriteLine("Ha ocurrido un error" + result.ErrorMessage);
            }
        }

        /* Metodo utilizando Entity Framework */

        public static void AddEF()
        {
            ML.VentaProducto ventaproducto = new ML.VentaProducto();

            Console.WriteLine("Escriba el Id de la Venta: ");
            ventaproducto.Venta = new ML.Venta();
            ventaproducto.Venta.IdVenta = int.Parse(Console.ReadLine());

            Console.WriteLine("Introduce la cantidad de la venta: ");
            ventaproducto.Cantidad = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresa el id del producto ");
            ventaproducto.Producto = new ML.Producto();
            ventaproducto.Producto.IdProducto = int.Parse(Console.ReadLine());

            ML.Result result = BL.VentaProducto.AddEF(ventaproducto);

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

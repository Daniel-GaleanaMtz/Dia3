using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class VentaController : Controller
    {
        //
        // GET: /Venta/
        public ActionResult ProductoGetAll()
        {
            ML.Result result = BL.Producto.GetAllEF();
            ML.Producto producto = new ML.Producto();
            producto.Productos = result.Objects;
            return View(producto);
        }
        public ActionResult CarritoAdd(int? IdProducto)
        {
            ML.Result result = new ML.Result();
            if (Session["Carrito"] == null)
            {
                result.Objects = new List<object>();
                ML.VentaProducto ventaproducto = new ML.VentaProducto();
                ventaproducto.Producto = new ML.Producto();
                ventaproducto.Producto.IdProducto = IdProducto.GetValueOrDefault();
                ML.Result resultProducto = new ML.Result();
                resultProducto = BL.Producto.GetByIdEF(ventaproducto.Producto);
                if (resultProducto.Correct)
                {
                    ventaproducto.Cantidad = 1;
                    ventaproducto.Producto = ((ML.Producto)resultProducto.Object);
                    result.Objects.Add(ventaproducto);
                    ventaproducto.Producto.IdProducto = IdProducto.GetValueOrDefault();
                    Session["Carrito"] = result.Objects;
                }
                else
                {
                    resultProducto.ErrorMessage = "Ha ocurrido un error al traer la informacion";
                }

            }
            else
            {
                bool IsInList = false;
                result.Objects = ((List<object>)Session["Carrito"]);
                foreach (ML.VentaProducto ventaproducto in result.Objects)
                {
                    if (IdProducto == ventaproducto.Producto.IdProducto)
                    {
                        IsInList = true;
                    }
                }
                if (IsInList == true)
                {
                    foreach (ML.VentaProducto ventaproducto in result.Objects)
                    {
                        if (IdProducto == ventaproducto.Producto.IdProducto)
                        {
                            ventaproducto.Cantidad++;
                        }              
                    }
                }
                else
                {
                    ML.VentaProducto ventaproducto = new ML.VentaProducto();
                    ML.Result resultProducto = new ML.Result();
                    ventaproducto.Producto = new ML.Producto();
                    ventaproducto.Producto.IdProducto = IdProducto.GetValueOrDefault();
                    resultProducto = BL.Producto.GetByIdEF(ventaproducto.Producto);
                    ventaproducto.Cantidad = 1;                
                    ventaproducto.Producto = ((ML.Producto)resultProducto.Object);
                    result.Objects.Add(ventaproducto);
                    ventaproducto.Producto.IdProducto = IdProducto.GetValueOrDefault();
                    Session["Carrito"] = result.Objects;

                }
            }
            return RedirectToAction("Carrito");
        }

        public ActionResult Carrito()
        {
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();
            result.Objects = ((List<object>)Session["Carrito"]);
            return View(result);
        }

        public ActionResult Incrementar(int IdProducto)
        {
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();
            result.Objects = ((List<object>)Session["Carrito"]);
            foreach (ML.VentaProducto ventaproducto in result.Objects)
            {
                if (IdProducto == ventaproducto.Producto.IdProducto)
                {
                    if (ventaproducto.Cantidad < ventaproducto.Producto.Stock)
                    {
                        ventaproducto.Cantidad++;
                    }
                    else
                    {
                        TempData["msg"] = "<script>alert('No hay suficiente Stock para seguir agregando');</script>";
                        
                    }

                }               
            }
            return RedirectToAction("Carrito");
        }

        public ActionResult Decrementar(int IdProducto)
        {
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();
            result.Objects = ((List<object>)Session["Carrito"]);
            foreach (ML.VentaProducto ventaproducto in result.Objects)
            {
                if (IdProducto == ventaproducto.Producto.IdProducto)
                {
                    if (ventaproducto.Cantidad != 1)
                    {
                        ventaproducto.Cantidad--;
                    }
                    else
                    {
                        //TempData["msg"] = "<script>confirm('Deseas Eliminar el elemento');</script>";

                    }                  
                }
                
            }
            return RedirectToAction("Carrito");
        }

        public ActionResult Eliminar(int IdProducto)
        {
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();
            result.Objects = ((List<object>)Session["Carrito"]);
            int aux = 0;
            foreach (ML.VentaProducto ventaproducto in result.Objects)
            {
                if (IdProducto == ventaproducto.Producto.IdProducto)
                {
                    result.Objects.RemoveAt(aux);
                    break;
                }
                aux++;
            }
            return RedirectToAction("Carrito");
        }

        public ActionResult ProcesarCompra()
        {
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();
            result.Objects = ((List<object>)Session["Carrito"]);
            decimal total = 0;
            foreach (ML.VentaProducto ventaproducto in result.Objects)
            {
                var precio = ventaproducto.Producto.Precio;
                var cantidad = ventaproducto.Cantidad;
                var subtotal = precio * cantidad;
                total += subtotal;
                ventaproducto.Venta = new ML.Venta();
                ventaproducto.Venta.Cliente = new ML.Cliente();
                ventaproducto.Venta.MetodoPago = new ML.MetodoPago();
                ventaproducto.Venta.Total = total;
                ventaproducto.Venta.Cliente.IdCliente = 1;
                ventaproducto.Venta.MetodoPago.IdMetodoPago = 1;
                BL.Venta.AddEF(ventaproducto.Venta, result.Objects);
            }
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Carrito");     
        }
	}
}



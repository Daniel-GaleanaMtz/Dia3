using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;

namespace PL_MVC.Controllers
{
    public class ProductoController : Controller
    {
        //
        // GET: /Producto/
        public ActionResult GetAll()
        {
            //ML.Producto producto = new ML.Producto();
            //ML.Result result = new ML.Result();
            //ServiceReferenceProducto.ServiceProductoClient service = new ServiceReferenceProducto.ServiceProductoClient();
            //var SL_result = service.GetAll(producto);
            //result.Objects = SL_result.Objects;
            //producto.Productos = result.Objects;
            ML.Result resultProductooAPI = new ML.Result();
            resultProductooAPI.Objects = new List<Object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:17164/");

                var responseTask = client.GetAsync("api/producto");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Producto resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Producto>(resultItem.ToString());
                        resultProductooAPI.Objects.Add(resultItemList);
                    }
                }
            }

            ML.Producto producto = new ML.Producto();
            producto.Productos = resultProductooAPI.Objects;
            //resultProductooAPI = BL.Producto.GetAllEF();
            //producto.Productos = resultProductooAPI.Objects;
            return View(producto);
        }

        [HttpGet]
        public ActionResult Delete(int IdProducto)
        {
            //ML.Producto producto = new ML.Producto();
            //producto.IdProducto = IdProducto;
            //ServiceReferenceProducto.ServiceProductoClient service = new ServiceReferenceProducto.ServiceProductoClient();
            //service.Delete(producto);
            ML.Result resultProductoList = new ML.Result();
            using (var product = new HttpClient())
            {
                product.BaseAddress = new Uri("http://localhost:17164/");
                var postTask = product.DeleteAsync("api/producto/" + IdProducto);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetAll");
                }
            }
            return RedirectToAction("GetAll");
        }

        [HttpGet]//Mostrar el formulario
        public ActionResult Form(int? IdProducto) //Add , Update
        {
            ML.Producto producto = new ML.Producto();
            producto.IdProducto = IdProducto.GetValueOrDefault();

            ML.Result resultProveedor = BL.Proveedor.GetAllEF();
            producto.Proveedor = new ML.Proveedor();
            producto.Proveedor.Proveedors = resultProveedor.Objects; //Proveedor

            ML.Result resultAreas = BL.Area.GetAllEF();
            producto.Departamento = new ML.Departamento();
            producto.Departamento.Area = new ML.Area();
            producto.Departamento.Area.Areas = resultAreas.Objects; //Areas

            ML.Result resultDepartamentos = BL.Departamento.GetAllEF();
            producto.Departamento.Departamentos = resultDepartamentos.Objects;//Departamento



            if (IdProducto == null)//Add
            {
                return View(producto);
            }
            else //Update
            {
                //ML.Result result = BL.Producto.GetByIdEF(producto);
                ML.Result result = GetByIdAPI(IdProducto);

                if (result.Correct)
                {
                    //producto.Proveedor.Proveedors = resultProveedor.Objects;
                    //producto.Departamento.Area.Areas = resultAreas.Objects;
                    //producto.Departamento.Departamentos = resultDepartamentos.Objects;

                    producto.IdProducto = ((ML.Producto)result.Object).IdProducto;
                    producto.Nombre = ((ML.Producto)result.Object).Nombre;
                    producto.Precio = ((ML.Producto)result.Object).Precio;
                    producto.Stock = ((ML.Producto)result.Object).Stock;

                    producto.Proveedor.IdProveedor = ((ML.Producto)result.Object).Proveedor.IdProveedor;
                    producto.Proveedor.Nombre = ((ML.Producto)result.Object).Proveedor.Nombre;

                    producto.Departamento.Area.IdArea = ((ML.Producto)result.Object).Departamento.Area.IdArea;
                    producto.Departamento.Area.Nombre = ((ML.Producto)result.Object).Departamento.Area.Nombre;

                    producto.Departamento.IdDepartamento = ((ML.Producto)result.Object).Departamento.IdDepartamento;
                    producto.Departamento.Nombre = ((ML.Producto)result.Object).Departamento.Nombre;

                    producto.Descripcion = ((ML.Producto)result.Object).Descripcion;
                    producto.Imagen = ((ML.Producto)result.Object).Imagen;

                    return View(producto);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return PartialView("Modal");
                }
            }
        }
        public byte[] convertToByte(HttpPostedFileBase Imagen)
        {
            byte[] imageInput = null;
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Imagen.InputStream);
            imageInput = reader.ReadBytes((int)Imagen.ContentLength);
            return imageInput;
        }

        [HttpPost] //Recibir datos del formulario
        public ActionResult Form(ML.Producto producto)
        {
            var id = producto.IdProducto;
            ML.Result result = new ML.Result();
            HttpPostedFileBase file = Request.Files["ImagenInput"];
            if (file.ContentLength > 0)
            {
                producto.Imagen = convertToByte(file);
            }

            if (producto.IdProducto == 0)//Add
            {
                //ServiceReferenceProducto.ServiceProductoClient service = new ServiceReferenceProducto.ServiceProductoClient();
                //var result_SL = service.Add(producto);
                //result.Correct = result_SL.Correct;
                //result.ErrorMessage = result_SL.ErrorMessage;
                //result.Ex = result_SL.Ex;
                    //result = BL.Producto.AddEF(producto);
                using (var product = new HttpClient())
                {
                    product.BaseAddress = new Uri("http://localhost:17164/");

                    var postTask = product.PostAsJsonAsync<ML.Producto>("api/producto/", producto);
                    postTask.Wait();

                    var resultPost = postTask.Result;
                    if (resultPost.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "El producto se agregó correctamente ";
                        return PartialView("Modal");
                    }
                }
            }
            else //Update
            {
                //ServiceReferenceProducto.ServiceProductoClient service = new ServiceReferenceProducto.ServiceProductoClient();
                //var result_SL = service.Update(producto);
                //result.Correct = result_SL.Correct;
                //result.ErrorMessage = result_SL.ErrorMessage;
                //result.Ex = result_SL.Ex;
                    //result = BL.Producto.UpdateEF(producto); //BL.Materia.Update();
                using (var product = new HttpClient())
                {
                    product.BaseAddress = new Uri("http://localhost:17164/");

                    var postTask = product.PutAsJsonAsync<ML.Producto>("api/producto/" + id, producto);
                    postTask.Wait();

                    var resultPost = postTask.Result;
                    if (resultPost.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "El producto se actualizo correctamente ";
                        return PartialView("Modal");
                    }
                }
            }

            //if (!result.Correct)
            //{
            //    ViewBag.Message = "No se pudo agregar correctamente el producto " + result.ErrorMessage;
            //}

            return PartialView("Modal");
        }

        public JsonResult GetDepartamento(int IdArea)
        {
            var result = BL.Departamento.GetByIdArea(IdArea);
            List<SelectListItem> opciones = new List<SelectListItem>();

            opciones.Add(new SelectListItem { Text = "- Seleccione una opción -", Value = "0" });
            if (result.Objects != null)
            {
                foreach (ML.Departamento departamento in result.Objects)
                {
                    opciones.Add(new SelectListItem { Text = departamento.Nombre.ToString(), Value = departamento.IdDepartamento.ToString() });
                }
            }
            return Json(new SelectList(opciones, "Value", "Text", JsonRequestBehavior.AllowGet));
        }

        public static ML.Result GetByIdAPI(int? IdProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                string urlAPI = System.Configuration.ConfigurationManager.AppSettings["http://localhost:17164/"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:17164/");
                    var responseTask = client.GetAsync("api/producto/" + IdProducto);
                    responseTask.Wait();
                    var resultAPI = responseTask.Result;

                    if (resultAPI.IsSuccessStatusCode)
                    {
                        var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();
                        ML.Producto resultItemList = new ML.Producto();
                        resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Producto>(readTask.Result.Object.ToString());
                        result.Object = resultItemList;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla producto";
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
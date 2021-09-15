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
    public class DepartamentoController : Controller
    {
        //
        // GET: /Departamento/
        //public ActionResult GetAll()
        //{
        //    ML.Departamento departamento = new ML.Departamento();
        //    ML.Result result = new ML.Result();
        //    ServiceReferenceDepartamento.ServiceDepartamentoClient service = new ServiceReferenceDepartamento.ServiceDepartamentoClient();
        //    var SL_result = service.GetAll(departamento);
        //    result.Objects = SL_result.Objects;
        //    departamento.Departamentos = result.Objects;
        //    return View(departamento);
        //}
        public ActionResult GetAll()
        {
            ML.Result resultDepartamentoAPI = new ML.Result();
            resultDepartamentoAPI.Objects = new List<Object>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:17164/");

                var responseTask = client.GetAsync("api/departamento");
                responseTask.Wait();

                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Departamento resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Departamento>(resultItem.ToString());
                        resultDepartamentoAPI.Objects.Add(resultItemList);
                    }
                }
            }

            ML.Departamento departamento = new ML.Departamento();
            departamento.Departamentos = resultDepartamentoAPI.Objects;
            //resultDepartamentoAPI = BL.Departamento.GetAllEF();
            //departamento.Departamentos = resultDepartamentoAPI.Objects;

            return View(departamento);
        }

        [HttpGet]
        public ActionResult Delete(int IdDepartamento)
        {
            //ML.Departamento depto = new ML.Departamento();
            //depto.IdDepartamento = IdDepartamento;
            //ServiceReferenceDepartamento.ServiceDepartamentoClient service = new ServiceReferenceDepartamento.ServiceDepartamentoClient();
            //service.Delete(depto);
            ML.Result resultDepartmentList = new ML.Result();
            using (var depto = new HttpClient())
            {
                depto.BaseAddress = new Uri("http://localhost:17164/");
                var postTask = depto.DeleteAsync("api/departamento/" + IdDepartamento);
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
        public ActionResult Form(int? IdDepartamento) //Add , Update
        {
            ML.Departamento departamento = new ML.Departamento();
            departamento.IdDepartamento = IdDepartamento.GetValueOrDefault();

            ML.Result resultAreas = BL.Area.GetAllEF();
            departamento.Area = new ML.Area();
            departamento.Area.Areas = resultAreas.Objects;

            if (IdDepartamento == null)//Add
            {
                return View(departamento);
            }
            else //Update
            {
                ML.Result result = GetByIdAPI(IdDepartamento);
                //ML.Result result = BL.Departamento.GetByIdEF(departamento);

                if (result.Correct)
                {
                    departamento.Area.Areas = resultAreas.Objects;

                    departamento.IdDepartamento = ((ML.Departamento)result.Object).IdDepartamento;
                    departamento.Nombre = ((ML.Departamento)result.Object).Nombre;
                    departamento.Area.IdArea = ((ML.Departamento)result.Object).Area.IdArea;
                    departamento.Area.Nombre = ((ML.Departamento)result.Object).Area.Nombre;

                    return View(departamento);
                }
                else
                {
                    ViewBag.Message = result.ErrorMessage;
                    return PartialView("Modal");
                }
            }
        }

        [HttpPost] //Recibir datos del formulario
        public ActionResult Form(ML.Departamento departamento)
        {
            var id = departamento.IdDepartamento;
            //ML.Result result = new ML.Result();
            ML.Result result = new ML.Result();

            if (departamento.IdDepartamento == 0)//Add
            {
                //ServiceReferenceDepartamento.ServiceDepartamentoClient service = new ServiceReferenceDepartamento.ServiceDepartamentoClient();
                //var result_SL = service.Add(departamento);
                //result.Correct = result_SL.Correct;
                //result.ErrorMessage = result_SL.ErrorMessage;
                //result.Ex = result_SL.Ex;
                using (var depto = new HttpClient())
                {
                    depto.BaseAddress = new Uri("http://localhost:17164/");

                    var postTask = depto.PostAsJsonAsync<ML.Departamento>("api/departamento/" , departamento);
                    postTask.Wait();

                    var resultPost = postTask.Result;
                    if (resultPost.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "El departamento se agregó correctamente ";
                        return PartialView("Modal");
                    }
                }
                
            }
            else //Update
            {
                //ServiceReferenceDepartamento.ServiceDepartamentoClient service = new ServiceReferenceDepartamento.ServiceDepartamentoClient();
                //service.Update(departamento);
                //var result_SL = service.Add(departamento);
                //result.Correct = result_SL.Correct;
                //result.ErrorMessage = result_SL.ErrorMessage;
                //result.Ex = result_SL.Ex;
                //ViewBag.Message = "El departamento se actualizó correctamente ";
                using (var depto = new HttpClient())
                {
                    depto.BaseAddress = new Uri("http://localhost:17164/");

                    var postTask = depto.PutAsJsonAsync<ML.Departamento>("api/departamento/" + id , departamento);
                    postTask.Wait();

                    var resultPost = postTask.Result;
                    if (resultPost.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "El departamento se actualizó correctamente ";
                        return PartialView("Modal");                      
                    }
                }
                
            }

            //if (!result.Correct)
            //{
            //    ViewBag.Message = "No se pudo agregar correctamente el departamento " + result.ErrorMessage;
            //}

            return PartialView("Modal");         
        }

        public static ML.Result GetByIdAPI(int? IdDepartamento)
        {
            ML.Result result = new ML.Result();
            try
            {
                string urlAPI = System.Configuration.ConfigurationManager.AppSettings["http://localhost:17164/"];
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:17164/");
                    var responseTask = client.GetAsync("api/departamento/" + IdDepartamento);
                    responseTask.Wait();
                    var resultAPI = responseTask.Result;

                    if (resultAPI.IsSuccessStatusCode)
                    {
                        var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();
                        ML.Departamento resultItemList = new ML.Departamento();
                        resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Departamento>(readTask.Result.Object.ToString());
                        result.Object = resultItemList;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla Departamento";
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
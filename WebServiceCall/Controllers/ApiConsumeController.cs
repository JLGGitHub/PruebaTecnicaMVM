
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using WebServiceCall.Models;

namespace WebServiceCall.Controllers
{
    public class ApiConsumeController : Controller
    {
        // GET: ApiConsume
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Metodo que realiza una peticion a una API
        /// </summary>
        /// <param name="sigla"> Codigo de 3 digitos </param>
        /// <returns>Informacion de la API</returns>
        [HttpGet]
        public JsonResult GetApi(string sigla)
        {
            var url = "https://restcountries.eu/rest/v2/alpha/" + sigla;

            using (var webClient = new WebClient())
            {
               
                webClient.Encoding = Encoding.UTF8;

                try
                {
                    var json = webClient.DownloadString(url);
                    var deserializadorJson = JsonConvert.DeserializeObject<ApiConsumeVM>(json);
                    return Json(new { Data = deserializadorJson}, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    return Json("Error", JsonRequestBehavior.AllowGet);
                }

            }
        }

    }
}
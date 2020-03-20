using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.Extensions.Logging;
using Nancy.Json;
using Newtonsoft.Json;
using web.Funciones;
using web.Models;
using web.Models.BBDD;


namespace web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public object Listado { get; private set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public String getJson2()
        {
            Persona p = new Persona()
            {
                Nombre = "Perico",
                Apellido = "dasdas",
                Dni = "23"
            };
            String json2 = "{\"Dni\":\"23\",\"Nombre\":\"Perico\",\"Apellido\":\"dasdas\"}";
            Persona aaa = JsonConvert.DeserializeObject<Persona>(json2);
            var json = new JavaScriptSerializer().Serialize(p);
            return json;
        }

        public ActionResult readJson()
        {

            Fichero_Configuracion j = new Fichero_Configuracion();
            j.read();
            return View();
        }


        public ActionResult getValor()
        {

            BBDDCAtegories categories = new BBDDCAtegories();
            DataTable dt = categories.getCategories("select * from Categories", Connection.conexion());


            IEnumerable<DataRow> query =
            from info in dt.AsEnumerable()
            where info.Field<int>("CategoryId") > 3
            orderby info.Field<int>("CategoryId") descending
            select info;


            IEnumerable<DataRow> query2 =
            from info in dt.AsEnumerable()
            where info.Field<int>("CategoryId") > 3
            select info;


            var query3 =
             from info in dt.AsEnumerable()
             where info.Field<int>("CategoryId") > 3
             orderby info.Field<int>("CategoryId") descending
             select new
             {
                 val = info.Field<int>("CategoryId"),
                 val2 = info.Field<string>("Description")
             };

            foreach (var  item in query3)
            {
                Debug.Print( item.val.ToString() );
                Debug.Print(item.val2.ToString());
            }
            return View();
        }


        [HttpPost]
        public ActionResult sendPersona(Persona p)
        {

            return View();
        }

        [HttpGet]
        public ActionResult sendPersona()
        {

            return View();
        }

        public ActionResult Test()
        {
            Persona p = new Persona()
            {
                Nombre = "dsasa",
                Apellido = "asda",
                Dni = "23"
            };


            Persona p2 = new Persona()
            {
                Nombre = "Sergi",
                Apellido = "Sacristan",
                Dni = "2"
            };


            ArrayList valors = new ArrayList();
            valors.Add(p2);
            valors.Add(p);
            ViewData["valor"] = valors;
            return View(valors);
        }


        public JsonResult getJson()
        {
            Persona p1 = new Persona() { Nombre = "aa", Apellido = "das", Dni = "2" };
            Persona p = new Persona()
            {
                Nombre = "Perico",
                Apellido = "dasdas",
                Dni = "2"
            };

            return Json(p);
        }
    }
}

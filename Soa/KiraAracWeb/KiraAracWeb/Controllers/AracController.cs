using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Mvc;
using static OtoKiralama.Models.Rezervasyon;

namespace KiraAracWeb.Controllers
{
    public class AracController : Controller
    {
        // GET: Arac
        public ActionResult RezervasyonYap(RezervasyonViewModel rezerv)
        {

            decimal toplam = (rezerv.Veris_Tarihi.Day - rezerv.Alis_Tarihi.Day) * rezerv.AlinanUcret;
            rezerv.AlinanUcret = toplam;
            // Create a HttpClient
            var client = new HttpClient();

            // Setup basics
            client.BaseAddress = new Uri("http://localhost:55393/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));



            // Serialize C# object to Json Object
            var serializedProduct = JsonConvert.SerializeObject(rezerv);
            // Json object to System.Net.Http content type
            var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
            // Post Request to the URI
            var result = client.PostAsync("api/Rezervasyon", content);
            // Check for result







            return RedirectToAction("ListAllCar", "Arac");

        }
        public ActionResult ArabaDetay(int id)
        {
            var client = new HttpClient();

            // Setup basics
            client.BaseAddress = new Uri("http://localhost:55393/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response;


            response = client.GetAsync("api/Arac/" + id).Result;

            var value = response.Content.ReadAsStringAsync().Result;
            List<OtoKiralama.Models.Arac> car = JsonConvert.DeserializeObject<ResponseContent<OtoKiralama.Models.Arac>>(value).Data;




            return View(car);
        }
        public ActionResult ListAllCar()
        {
            var client = new HttpClient();

            // Setup basics
            client.BaseAddress = new Uri("http://localhost:55393/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response;


            response = client.GetAsync("api/Arac").Result;

            var value = response.Content.ReadAsStringAsync().Result;
            List<OtoKiralama.Models.Arac> car = JsonConvert.DeserializeObject<ResponseContent<OtoKiralama.Models.Arac>>(value).Data;




            return View(car);






        }
    }
}
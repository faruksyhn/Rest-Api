using AracKiralamaWebApi.Models;
using AracKiralamaWebApi.Result;
using OtoKiralama.BusinesLogic;
using OtoKiralama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AracKiralamaWebApi.Controllers
{
    public class RezervasyonController : ApiController
    {
        public IHttpActionResult Put([FromBody]Rezervasyon rezerv)
        {
            var content = new ResponseContent<Rezervasyon>(null);

            if (rezerv != null)
            {
                var rezervBusiness = new RezervasyonBusiness();

                content.Result = rezervBusiness.UpdateCar(rezerv) ? "1" : "0";

                return new StandartResult<Rezervasyon>(content, Request);

            }

            content.Result = "0";

            return new StandartResult<Rezervasyon>(content, Request);
        }
        public IHttpActionResult Delete(int id)
        {
            var content = new ResponseContent<Rezervasyon>(null);

            var rezervasyonBusiness = new RezervasyonBusiness();
            
                content.Result = rezervasyonBusiness.DeleteCarById(id) ? "1" : "0";

                return new StandartResult<Rezervasyon>(content, Request);
            
        }
       

        public IHttpActionResult Post([FromBody]Rezervasyon.RezervasyonViewModel rezerv)
        {
            var content = new ResponseContent<Rezervasyon.RezervasyonViewModel>(null);
            if (rezerv != null)
            {
                var rezervBusiness = new RezervasyonBusiness();

                content.Result = rezervBusiness.InsertRezerv(rezerv) ? "1" : "0";

                return new StandartResult<Rezervasyon.RezervasyonViewModel>(content, Request);

            }

            content.Result = "0";

            return new StandartResult<Rezervasyon.RezervasyonViewModel>(content, Request);
        }
    }
}

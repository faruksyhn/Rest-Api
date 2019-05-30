using OtoKiralama.BusinesLogic;
using OtoKiralama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Ajax.Utilities;
using AracKiralamaWebApi.Models;
using AracKiralamaWebApi.Result;

namespace AracKiralamaWebApi.Controllers
{
    public class AracController : ApiController
    {
        public IHttpActionResult Get(int sirketId,bool durum)
        {
            var rezervasyonBusiness = new RezervasyonBusiness();
            
                List<Rezervasyon.RezervasyonViewModel> rezerv = rezervasyonBusiness.SelectAllCar(sirketId,durum);
                var content = new ResponseContent<Rezervasyon.RezervasyonViewModel>(rezerv);
                return new StandartResult<Rezervasyon.RezervasyonViewModel>(content, Request);
            
        }
        public IHttpActionResult Get()
        {
            var aracBusiness = new AracBusiness();

            List<Arac> arac = aracBusiness.SelectAllCar();
            var content = new ResponseContent<Arac>(arac);
            return new StandartResult<Arac>(content, Request);

        }


        public IHttpActionResult Get(int id)
        {
            ResponseContent<Arac> content;

            var aracBusiness = new AracBusiness();
            
                // Get customer from business layer (Core App)
                List<Arac> arac = null;
                try
                {
                    var c = aracBusiness.SelectCarById(id);
                    if (c != null)
                    {
                        arac = new List<Arac>();
                        arac.Add(c);
                    }

                    // Prepare a content
                    content = new ResponseContent<Arac>(arac);

                    // Return content as a json and proper http response
                    return new StandartResult<Arac>(content, Request);
                }
                catch (Exception)
                {
                    // Prepare a content
                    content = new ResponseContent<Arac>(null);
                    return new XmlResult<Arac>(content, Request);
                }
            }

      /*
        public IHttpActionResult Post([FromBody]Arac arac)
        {
            var content = new ResponseContent<Arac>(null);
            if (arac != null)
            {
                var customerBusiness = new AracBusiness();
                
                    content.Result = customerBusiness.InsertCar(arac) ? "1" : "0";

                    return new StandartResult<Arac>(content, Request);
                
            }

            content.Result = "0";

            return new StandartResult<Arac>(content, Request);
        }
        */
        // PUT api/<controller>/5
       
       
        
        public IHttpActionResult Put([FromBody]Arac arac)
        {
            var content = new ResponseContent<Arac>(null);

            if (arac != null)
            {
                var aracBusiness = new AracBusiness();

                content.Result = aracBusiness.UpdateCar(arac) ? "1" : "0";

                return new StandartResult<Arac>(content, Request);

            }

            content.Result = "0";

            return new StandartResult<Arac>(content, Request);
        }
        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            var content = new ResponseContent<Arac>(null);

            var aracBusiness = new AracBusiness();
            
                content.Result = aracBusiness.DeleteCarById(id) ? "1" : "0";

                return new StandartResult<Arac>(content, Request);
            
        }
    }
}

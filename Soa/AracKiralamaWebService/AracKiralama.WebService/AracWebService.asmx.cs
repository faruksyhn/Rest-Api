using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using OtoKiralama.BusinesLogic;
using OtoKiralama.Models;


namespace AracKiralama.WebService
{
    /// <summary>
    /// Summary description for AracWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AracWebService : System.Web.Services.WebService
    {
        [WebMethod]
        public bool InsertCar(Arac entity)
        {
            try
            {
                using (var business = new AracBusiness())
                {
                    business.InsertCar(entity);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
       
       
        [WebMethod]
        public bool UpdateCar(Arac entity)
        {
            try
            {
                using (var business = new AracBusiness())
                {
                    business.UpdateCar(entity);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [WebMethod]
        public bool DeleteCar(int id)
        {
            try
            {
                using (var business = new AracBusiness())
                {
                    business.DeleteCarById(id);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        [WebMethod]
        public void RezervYap(Rezervasyon.RezervasyonViewModel rezerv)
        {
            var business = new RezervasyonBusiness();

           business.InsertRezerv(rezerv);


        }
        [WebMethod]
        public List<Arac> SelectAllCars()
        {
            var business = new AracBusiness();
               
                    return business.SelectAllCar();
               
           
        }

        [WebMethod]
        public List<Rezervasyon.RezervasyonViewModel> SelectAllRezerv(int sirketId)
        {
            var business = new RezervasyonBusiness();
            return business.SelectAllCar(sirketId,false);
             
           
           
        }

        [WebMethod]
        public Arac SelectCarById(int id)
        {
            var business = new AracBusiness();
                
                    return business.SelectCarById(id);
               
           
          
        }
    }
}

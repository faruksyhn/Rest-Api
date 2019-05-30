using AracKiralamaWebSoap.AracWebService;
using OtoKiralama.Commons.Concretes.Helpers;
using OtoKiralama.Commons.Concretes.Loggers;
using OtoKiralama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AracKiralamaWebSoap.Controllers
{
    public class AracController : Controller
    {
        private void InsertCar(AracWebService.Arac arac)
        {
            try
            {
                using (var aracSoapClient = new AracWebServiceSoapClient())
                {
                     aracSoapClient.InsertCar(arac);
                 
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Customer doesn't exists.");
            }
        }

        private void UpdateCar(AracWebService.Arac arac)
        {
            try
            {

                using (var aracSoapClient = new AracWebServiceSoapClient())
                {
                    aracSoapClient.UpdateCar(arac);
                    
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Customer doesn't exists.");
            }
        }
        public ActionResult RezervasyonYap(RezervasyonViewModel rezerv)
        {
            decimal toplam = (rezerv.Veris_Tarihi.Day - rezerv.Alis_Tarihi.Day) * rezerv.AlinanUcret;
            var aracSoapClient = new AracWebServiceSoapClient();
            rezerv.AlinanUcret = toplam;
            aracSoapClient.RezervYap(rezerv);
            return RedirectToAction( "ListAllCar","Arac");
            
        }
        public ActionResult ArabaDetay(int id)
        {
            var aracSoapClient = new AracWebServiceSoapClient();

            AracWebService.Arac cars = new AracWebService.Arac();
            cars = aracSoapClient.SelectCarById(id);
            return View(cars);
        }
        private void DeleteCustomer(int ID)
        {
            try
            {
                using (var aracSoapClient = new AracWebServiceSoapClient())
                {
                     aracSoapClient.DeleteCar(ID);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Customer doesn't exists.");
            }
        }

        public ActionResult ListAllCar()
        {
            var aracSoapClient = new AracWebServiceSoapClient();
                
                    List<AracWebService.Arac> cars = new List<AracWebService.Arac>();
                   cars=aracSoapClient.SelectAllCars().ToList();
                   return View(cars);
               
                    
                
           
           
        }

        private AracWebService.Arac SelectCustomerByID(int ID)
        {
            try
            {
                using (var aracSoapClient = new AracWebServiceSoapClient())
                {
                   
                    AracWebService.Arac responsedCar = aracSoapClient.SelectCarById(ID);
                   

                    return responsedCar;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Customer doesn't exists.");
            }
        }


    }
}

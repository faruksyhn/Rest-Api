using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OtoKiralama.Models;
using OtoKiralama.BusinesLogic;

namespace AracKiralamaWeb.Controllers
{
    public class AracController : Controller
    {

        // GET: Arac
        public ActionResult Index()
        {
            return View();
        }

        // GET: Arac/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Arac/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Arac/Create
        [HttpPost]
        public ActionResult Create(Arac arac)
        {
            try
            {
                bool success;
                using (var aracBusiness = new AracBusiness())
                {
                    success = aracBusiness.InsertCar(new Arac()
                    {
                        AracAdi = "dsada",
                        SirketId = 2,
                        Airbag = false,
                        BagajHacmi = 1,
                        GunlukSinirKM = 2,
                        KoltukSayisi = 1,
                        MinYasSiniri = 2,
                        EhliyetYasi = 1,
                        GunlukKiralikFiyat = 1,
                        KendiAnlikKM = 1,
                        Model = "sasa"
                    });
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    /*    public ActionResult RezervasyonYap(Rezervasyon rezerv)

        {

        }
        */
        // GET: Arac/Edit/5
        public ActionResult Edit(int id)
        {

            return View();
        }

        // POST: Arac/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Arac arac)
        {
            try
            {
                using (var business = new AracBusiness())
                {
                    business.UpdateCar(arac);
                }
               
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Arac/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Arac/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

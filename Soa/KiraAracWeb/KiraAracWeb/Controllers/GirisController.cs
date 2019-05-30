using OtoKiralama.BusinesLogic;
using OtoKiralama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KiraAracWeb.Controllers
{
    public class GirisController : Controller
    {
        [HttpGet]
        // GET: Giris
        public ActionResult Login()
        {
            return View();
        }
        public static string Sifrele(string data)
        {
            byte[] tempDizi = System.Text.ASCIIEncoding.ASCII.GetBytes(data);// şifrelenecek veri byte dizisine çevrilir
            string finalData = System.Convert.ToBase64String(tempDizi);//Base64 ile şifrelenir
            return finalData;
        }
        [HttpPost]
        public ActionResult Login(Kullanici k )
        {
            k.Sifre = Sifrele(k.Sifre);
            var kullaniciBusiness = new KullaniciBusiness();
            FormsAuthentication.SetAuthCookie(k.Ad, true);
            Kullanici kullanıcı = kullaniciBusiness.kullaniciKontrol(k);
            if (kullanıcı.RolId == 1)
                return RedirectToAction("ListAllCar", "Arac");
            else
                return RedirectToAction("Login", "Giris");
                
            
        }
    }
}
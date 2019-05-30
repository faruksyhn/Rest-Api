using OtoKiralama.Commons.Concretes.Helpers;
using OtoKiralama.Commons.Concretes.Loggers;
using OtoKiralama.DataAccess.Concretes;
using OtoKiralama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoKiralama.BusinesLogic
{
    public class KullaniciBusiness : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }
        public Kullanici kullaniciKontrol(Kullanici k)
        {
            Kullanici kullanici=null;
            var repo = new KullaniciRepository();
            kullanici = repo.kullaniciKontrol(k);
               
                return kullanici;
           
           
        }
    }
}

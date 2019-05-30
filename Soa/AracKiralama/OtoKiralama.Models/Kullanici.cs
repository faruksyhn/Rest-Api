using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoKiralama.Models
{
    public class Kullanici:IDisposable
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public int Yas { get; set; }
        public string Email { get; set; }
        public DateTime EhliyetAlimTarihi { get; set; }
        public string Sifre { get; set; }
        public int SirketId { get; set; }
        public int RolId { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public Kullanici()
        {
        }

    }
}

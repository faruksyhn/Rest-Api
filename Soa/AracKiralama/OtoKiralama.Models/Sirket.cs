using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoKiralama.Models
{
    public class Sirket:IDisposable
    {
        public string SirketAdi { get; set; }
        public string Sehir { get; set; }
        public string Adres { get; set; }
        public int AracSayisi { get; set; }
        public int SirketPuani { get; set; }
        public List<Arac> AracListe { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        public Sirket()
        {
            AracListe = new List<Arac>();
        }
    }
}

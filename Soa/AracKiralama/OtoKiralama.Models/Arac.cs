using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoKiralama.Models
{
    public class Arac:IDisposable
    {
        public int AracId { get; set; }
        public string AracAdi { get; set; }
        public string Model { get; set; }
        public int EhliyetYasi { get; set; }
        public int MinYasSiniri { get; set; }
        public int GunlukSinirKM { get; set; }
        public int KendiAnlikKM { get; set; }
        public bool Airbag { get; set; }
        public int BagajHacmi { get; set; }
        public int KoltukSayisi { get; set; }
        public decimal GunlukKiralikFiyat { get; set; }
        public int SirketId { get; set; }
        public string SirketAdi { get; set; }
        public bool RezerveDurumu { get; set; }
        public string Resim { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}

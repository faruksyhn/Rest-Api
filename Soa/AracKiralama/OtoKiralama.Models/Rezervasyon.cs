using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtoKiralama.Models
{
    public class Rezervasyon
    {
        public int KiralikId { get; set; }
        public int AracId { get; set; }
        public int MusteriId { get; set; }
        public DateTime Alis_Tarihi { get; set; }
        public DateTime Veris_Tarihi { get; set; }
        public int VerilisKm { get; set; }
        public decimal AlinanUcret { get; set; }
        public bool Iade { get; set; }
        public bool KabulDurumu { get; set; }
        public class RezervasyonViewModel2
        {
            public int AracId { get; set; }
            public string MusteriAdSoyad { get; set; }
            public int EhliyetYasi { get; set; }
            public string Email { get; set; }
           
            public DateTime Alis_Tarihi { get; set; }
            public DateTime Veris_Tarihi { get; set; }
            public int VerilisKm { get; set; }
            public decimal AlinanUcret { get; set; }
            public bool Iade { get; set; }
            public bool KabulDurumu { get; set; }

        }
        public class RezervasyonViewModel
        {
            public int KiralikId { get; set; }
            public int AracId { get; set; }
            public string MusteriAdSoyad { get; set; }
            public int EhliyetYasi { get; set; }
            public string Email { get; set; }
            public string AracAdi { get; set; }
            public string Model { get; set; }
           
            public DateTime Alis_Tarihi { get; set; }
            public DateTime Veris_Tarihi { get; set; }
            public int VerilisKm { get; set; }
            public decimal AlinanUcret { get; set; }
            public bool Iade { get; set; }
            public bool KabulDurumu { get; set; }
        }
    }
}

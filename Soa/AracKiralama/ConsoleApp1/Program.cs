using OtoKiralama.DataAccess.Concretes;
using OtoKiralama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            AracRepository rep = new AracRepository();
            Arac a = new Arac();
            a.AracAdi = "das";
            a.Model = "dswq";
            a.EhliyetYasi = 18;
            a.MinYasSiniri = 21;
            a.GunlukSinirKM = 12;
            a.KendiAnlikKM = 20;
            a.KoltukSayisi = 4;
            a.BagajHacmi = 20;
            a.Airbag = "true";
            a.SirketId = 2;
            a.GunlukKiralikFiyat = 20;
            rep.Insert(a);

                }
    }
}

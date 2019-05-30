using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OtoKiralama.Models;
using OtoKiralama.DataAccess.Concretes;
using OtoKiralama.BusinesLogic;

namespace AracKiralamaForm
{
    public partial class KullaniciUI : Form
    {
        public KullaniciUI()
        {
            InitializeComponent();
        }
        public static string Sifrele(string data)
        {
            byte[] tempDizi = System.Text.ASCIIEncoding.ASCII.GetBytes(data);// şifrelenecek veri byte dizisine çevrilir
            string finalData = System.Convert.ToBase64String(tempDizi);//Base64 ile şifrelenir
            return finalData;
        }
        public static string SifreCoz(string data)
        {
            byte[] tempDizi = System.Convert.FromBase64String(data);
            string finalData = System.Text.ASCIIEncoding.ASCII.GetString(tempDizi);
            return finalData;
        }
        public static Kullanici kullaniciKontrol;
        private void btnGiris_Click(object sender, EventArgs e)
        {
            var kullaniciBusinies = new KullaniciBusiness();
            kullaniciKontrol = new Kullanici();
           

            kullaniciKontrol = kullaniciBusinies.kullaniciKontrol(new Kullanici()
            {
                Email = txtEmail.Text,
                Sifre = Sifrele(txtSifre.Text)
            });
            if (kullaniciKontrol!=null)
            {
                Form1 form = new Form1();
               
                form.Show();
            }
               
     }

        private void KullaniciUI_Load(object sender, EventArgs e)
        {

        }
    }
}

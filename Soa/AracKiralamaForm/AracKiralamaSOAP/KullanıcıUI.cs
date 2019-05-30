using OtoKiralama.BusinesLogic;
using OtoKiralama.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AracKiralamaSOAP
{
    public partial class KullanıcıUI : Form
    {
        public KullanıcıUI()
        {
            InitializeComponent();
        }
        public static Kullanici kullaniciKontrol;
        private void KullanıcıUI_Load(object sender, EventArgs e)
        {

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {

            var kullaniciBusinies = new KullaniciBusiness();
            kullaniciKontrol = new Kullanici();

            kullaniciKontrol = kullaniciBusinies.kullaniciKontrol(new Kullanici()
            {
                Email = txtEmail.Text,
                Sifre = txtSifre.Text
            });
            if (kullaniciKontrol != null)
            {
                Form1 form = new Form1();

                form.Show();
            }
        }
    }
}

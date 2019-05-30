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
using AracKiralamaSOAP.RezervWebService;

namespace AracKiralamaSOAP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<RezervWebService.RezervasyonViewModel> rezervasyon = new List<RezervWebService.RezervasyonViewModel>();
            var aracSoapClient = new AracWebServiceSoapClient();
            
                bool success;
                
                    rezervasyon = aracSoapClient.SelectAllRezerv(KullanıcıUI.kullaniciKontrol.SirketId).ToList();
                    success = true;
                
                dataGridRezerv.DataSource = rezervasyon;
                var message = success ? "done" : "failed";

                MessageBox.Show("Operation " + message);
            
            
        }

        private void dataGridRezerv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

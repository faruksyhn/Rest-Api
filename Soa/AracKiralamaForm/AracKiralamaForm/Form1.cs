using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using OtoKiralama.BusinesLogic;
using OtoKiralama.Commons.Concretes.Helpers;
using OtoKiralama.Commons.Concretes.Loggers;
using OtoKiralama.Models;


using Arac = OtoKiralama.Models.Arac;

namespace AracKiralamaForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

           
                // Create a HttpClient
                var client = new HttpClient();
                
                    // Setup basics
                    client.BaseAddress = new Uri("http://localhost:55393/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage response,response2;
            // Get Request from the URI

            response = client.GetAsync("api/Arac/" + KullaniciUI.kullaniciKontrol.SirketId + "/" + true).Result;
            response2 = client.GetAsync("api/Arac/" + KullaniciUI.kullaniciKontrol.SirketId+"/"+ false).Result;
                    // Check the Result
                    if (response.IsSuccessStatusCode)
                        {
                            // Take the Result as a json string
                            var value = response.Content.ReadAsStringAsync().Result;

                            // Deserialize the string with a Json Converter to ResponseContent object and fill the datagrid
                            dataGridKabul.DataSource =
                                JsonConvert.DeserializeObject<ResponseContent<Rezervasyon.RezervasyonViewModel>>(value).Data.ToList();
                        }
                    // Check the Result
                    if (response2.IsSuccessStatusCode)
                    {
                        // Take the Result as a json string
                        var value = response2.Content.ReadAsStringAsync().Result;

                        // Deserialize the string with a Json Converter to ResponseContent object and fill the datagrid
                        dataGridRezerve.DataSource =
                            JsonConvert.DeserializeObject<ResponseContent<Rezervasyon>>(value).Data.ToList();
                    }

                
            
          



         /*  List<Rezervasyon.RezervasyonViewModel> rezervasyon1,rezervasyon2 = new List<Rezervasyon.RezervasyonViewModel>();
            
            
            bool success;
            var rezervBusiness = new RezervasyonBusiness();
            
                success = true;
                rezervasyon1 = rezervBusiness.SelectAllCar(KullaniciUI.kullaniciKontrol.SirketId,true);
            rezervasyon2 = rezervBusiness.SelectAllCar(KullaniciUI.kullaniciKontrol.SirketId, false);

            dataGridKabul.DataSource = rezervasyon1;
            dataGridRezerve.DataSource = rezervasyon2;
        
            
            var message = success ? "done" : "failed";

            MessageBox.Show("Operation " + message);
         */ 
        }
            private void button1_Click(object sender, EventArgs e)
            {
                using (var aracBusiness = new AracBusiness())
                {
                    aracBusiness.DeleteCarById(16);
                }
            }

        private void dataGridRezerve_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnKabul_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
 client.BaseAddress = new Uri("http://localhost:55393/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            foreach (DataGridViewRow drow in dataGridRezerve.SelectedRows)
            {
               
               

                // Setup basics
               
                // Get Request from the URI

                Rezervasyon rezerv = new Rezervasyon()
                {
                    KiralikId = Convert.ToInt32(drow.Cells[0].Value),
                    Iade = false,
                    KabulDurumu = true
                };
                var serializedProduct = JsonConvert.SerializeObject(rezerv);
                // Json object to System.Net.Http content type
                var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                // Post Request to the URI
                var result= client.PutAsync("api/Rezervasyon",content);
               
             
                Arac arac = new Arac()
                {
                    AracId = Convert.ToInt32(drow.Cells[1].Value),
                    RezerveDurumu = true

                };
                var serializedProduct1 = JsonConvert.SerializeObject(arac);
                // Json object to System.Net.Http content type
                var content1 = new StringContent(serializedProduct1, Encoding.UTF8, "application/json");
                // Post Request to the URI
                var result1 = client.PutAsync("api/Arac", content1);
               
               
            }
           

        }

        private void btnİade_Click(object sender, EventArgs e)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:55393/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            foreach (DataGridViewRow drow in dataGridKabul.SelectedRows)
            {
                HttpResponseMessage response, response2;

                response = client.DeleteAsync("api/Rezervasyon/" + drow.Cells[0].Value).Result;
                

                
                Arac arac = new Arac()
                {
                    AracId = Convert.ToInt32(drow.Cells[1].Value),
                    RezerveDurumu = false

                };
                var serializedProduct1 = JsonConvert.SerializeObject(arac);
                // Json object to System.Net.Http content type
                var content1 = new StringContent(serializedProduct1, Encoding.UTF8, "application/json");
                // Post Request to the URI
                var result1 = client.PutAsync("api/Arac", content1);

                List<Rezervasyon.RezervasyonViewModel> rezervasyon1, rezervasyon2 = new List<Rezervasyon.RezervasyonViewModel>();


               /* bool success;
                var rezervBusiness1 = new RezervasyonBusiness();

                success = true;
                rezervasyon1 = rezervBusiness1.SelectAllCar(KullaniciUI.kullaniciKontrol.SirketId, false);
                rezervasyon2 = rezervBusiness1.SelectAllCar(KullaniciUI.kullaniciKontrol.SirketId, true);
                dataGridRezerve.DataSource = rezervasyon1;
                dataGridKabul.DataSource = rezervasyon2;
                var message = success ? "done" : "failed";

                MessageBox.Show("Operation " + message);*/
            }
            }

        private void btnRed_Click(object sender, EventArgs e)
        {
            var rezervBusiness = new RezervasyonBusiness();
            foreach (DataGridViewRow drow in dataGridRezerve.SelectedRows)
            {
                rezervBusiness.DeleteCarById(Convert.ToInt32(drow.Cells[0].Value));
            }
            List<Rezervasyon.RezervasyonViewModel> rezervasyon1, rezervasyon2 = new List<Rezervasyon.RezervasyonViewModel>();


            bool success;
            var rezervBusiness1 = new RezervasyonBusiness();

            success = true;
            rezervasyon1 = rezervBusiness1.SelectAllCar(KullaniciUI.kullaniciKontrol.SirketId, false);
            rezervasyon2 = rezervBusiness1.SelectAllCar(KullaniciUI.kullaniciKontrol.SirketId, true);
            dataGridRezerve.DataSource = rezervasyon1;
            dataGridKabul.DataSource = rezervasyon2;
            var message = success ? "done" : "failed";

            MessageBox.Show("Operation " + message);
        }
    }
    } 

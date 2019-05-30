using KiraAracWeb.Models;
using OtoKiralama.BusinesLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace KiraAracWeb.Controllers
{
    public class DashBoardController : Controller
    {
        public ActionResult Index()
        {
            DashboardViewModel dashboard = new DashboardViewModel();
            RezervasyonBusiness rezervasyon = new RezervasyonBusiness();
            dashboard.kazanç = rezervasyon.Kazanc();
            dashboard.kiralan = rezervasyon.kiralanan();
            dashboard.km = rezervasyon.kiralanan();
            return View(dashboard);
        }
        public ActionResult Kazanc()
        {
            RezervasyonBusiness rezervasyon = new RezervasyonBusiness();
            List<decimal> kazanç = new List<decimal>();
            kazanç.Add(rezervasyon.Kazanc());

            Chart chart = new Chart(500, 400);
            chart.AddTitle("Kazanc");
            chart.AddLegend("Kazanç");
            // chart.DataBindTable(dataSource: ziyaretci, xField: "ZiyaretTarihi");
            chart.DataBindCrossTable(dataSource: kazanç, groupByField: "kazanç", xField: "kazanç", yFields: "ToplamKazanç");
            return View(chart);
        }
        public ActionResult GünlükKiralananOrtalama()
        {
            RezervasyonBusiness rezervasyon = new RezervasyonBusiness();
            int kiralan = rezervasyon.kiralanan();
            float kiralama = kiralan / 30f;
            List<float> ortalama = new List<float>();
            ortalama.Add(kiralama);

            Chart chart = new Chart(500, 400);
            chart.AddTitle("OrtalamaKiralanan");
            chart.AddLegend("Kiralanan");
            // chart.DataBindTable(dataSource: ziyaretci, xField: "ZiyaretTarihi");
            chart.DataBindCrossTable(dataSource: ortalama, groupByField: "kiralanan", xField: "kiralanan", yFields: "kiralanan");
            return View(chart);
        }
        public ActionResult km()
        {
            RezervasyonBusiness rezervasyon = new RezervasyonBusiness();
            List<int> km = new List<int>();
            km.Add(rezervasyon.günlükKm());

            Chart chart = new Chart(500, 400);
            chart.AddTitle("Kilometre");
            chart.AddLegend("Kilometre");
            // chart.DataBindTable(dataSource: ziyaretci, xField: "ZiyaretTarihi");
            chart.DataBindCrossTable(dataSource: km, groupByField: "km", xField: "Kilometre", yFields: "Kilometre");
            return View(chart);
        }
    }
}
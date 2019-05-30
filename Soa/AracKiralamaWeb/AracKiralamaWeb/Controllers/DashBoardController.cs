using OtoKiralama.BusinesLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace AracKiralamaWeb.Controllers
{
    public class DashBoardController : Controller
    {
        // GET: DashBoard
        public ActionResult Index()
        {
            return View();
        }
            public ActionResult Kazanc()
            {
                RezervasyonBusiness rezervasyon = new RezervasyonBusiness();
                List<decimal> kazanç = new List<decimal>();
                kazanç.Add(rezervasyon.Kazanc());
    
                Chart chart = new Chart(500, 400);
                chart.AddTitle("Kazanc");
                chart.AddLegend("Ziyaretçiler");
                // chart.DataBindTable(dataSource: ziyaretci, xField: "ZiyaretTarihi");
                chart.DataBindCrossTable(dataSource: kazanç, groupByField: "hafta", xField: "hafta", yFields: "HaftaZiyaretci");
                return View(chart);
            }
        public ActionResult gunlukKm()
        {
            RezervasyonBusiness rezervasyon = new RezervasyonBusiness();
            List<int> km = new List<int>();
            km.Add(rezervasyon.günlükKm());

            Chart chart = new Chart(500, 400);
            chart.AddTitle("Kazanc");
            chart.AddLegend("Ziyaretçiler");
            // chart.DataBindTable(dataSource: ziyaretci, xField: "ZiyaretTarihi");
            chart.DataBindCrossTable(dataSource: km, groupByField: "hafta", xField: "hafta", yFields: "HaftaZiyaretci");
            return View(chart);
        }
    }
}
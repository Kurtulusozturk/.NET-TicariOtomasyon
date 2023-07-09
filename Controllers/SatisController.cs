using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using MVCOnlineTicariOtomasyon.Models.Siniflar;

namespace MVCOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        Context c = new Context();
        // GET: Satis
        public ActionResult Index()
        {
            var degerler = c.SatisHarakets.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> urunDeger = (from x in c.Uruns.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.UrunAd,
                                                Value = x.UrunID.ToString()
                                            }).ToList();
            ViewBag.urunDeger = urunDeger;
            List<SelectListItem> cariDeger = (from x in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CariAd + " " + x.CariSoyad,
                                               Value = x.CariID.ToString()
                                           }).ToList();
            ViewBag.cariDeger = cariDeger;
            List<SelectListItem> personelDeger = (from x in c.Personels.ToList()
                                              select new SelectListItem
                                              {
                                                  Text = x.PersonelAd + " " + x.PersonelSoyad,
                                                  Value = x.PersonelID.ToString()
                                              }).ToList();
            ViewBag.personelDeger = personelDeger;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis(SatisHaraket s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarakets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
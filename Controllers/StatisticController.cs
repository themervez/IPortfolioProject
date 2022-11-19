using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DemoUpSchoolProject.Models.Entities;
namespace DemoUpSchoolProject.Controllers
{
    public class StatisticController : Controller
    {
        UpSchoolDbPortfolioEntities db = new UpSchoolDbPortfolioEntities();
        public ActionResult Index()
        {   //Toplam referans veri sayısı
            ViewBag.v1 = db.TblTestimonial.Count();
            //Şehir bilgisi İstanbul olan referans sayısı
            ViewBag.v2 = db.TblTestimonial.Where(x => x.City == "İstanbul").Count();
            //Android Developer haricindeki kişi sayısı
            ViewBag.v3 = db.TblTestimonial.Where(x => x.Profession != "Android Developer").Count();
            //Şehri Mersin olan kişinin ismi
            ViewBag.v4 = db.TblTestimonial.Where(x => x.City == "Mersin").Select(y => y.NameSurname).FirstOrDefault();
            //Referansların ortalama maaşı
            ViewBag.v5 = db.TblTestimonial.Average(x => x.Salary);
            return View();
        }
    }
}
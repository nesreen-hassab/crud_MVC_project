using IT_Fusion_Task.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IT_Fusion_Task.Controllers
{
    public class ITFusionController : Controller
    {
        ITFusionEntities db = new ITFusionEntities();
     
        // GET: ITFusion
        public ActionResult Index()
        {

            ViewBag.expenses = db.IT_Expenses_Revenues.AsNoTracking().Where(e => e.Eexp_Rev_type.ex_re_type == "expenses").Select(e => e.Fees).Sum();
            ViewBag.revenues = db.IT_Expenses_Revenues.AsNoTracking().Where(e => e.Eexp_Rev_type.ex_re_type == "revenues").Select(e => e.Fees).Sum();
            ViewBag.total = db.IT_Expenses_Revenues.AsNoTracking().Select(e => e.Fees).Sum();

            return View(db.IT_Expenses_Revenues.AsNoTracking().ToList());
        }

        public ActionResult Getitems()
        {
            var products =new ITFusionEntities();
            List<product> pro = (from obj in products.IT_Expenses_Revenues
                                select new product
                                {   ID = obj.ID,
                                    Exp_Rev_Name = obj.Exp_Rev_Name,
                                    Entry_Date=obj.Entry_Date,
                                    Fees=obj.Fees,
                                    Note=obj.Note,
                                    Exp_Rev_type=obj.Eexp_Rev_type.ex_re_type,
                                }).ToList();
            return Json(pro,JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.type = new SelectList(db.Eexp_Rev_type, "id_ex_re", "ex_re_type");
            return View();
        }
        [HttpPost]
        public ActionResult Create(IT_Expenses_Revenues i)
        {
            if (ModelState.IsValid)
            {
                db.IT_Expenses_Revenues.Add(i);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.type = new SelectList(db.Eexp_Rev_type, "id_ex_re", "ex_re_type");
                return View(i);
            }
        }

        [HttpGet]
        public ActionResult Update(int? ID)
        {
            if (ID == null)
            {
                return HttpNotFound("This ID Not Found");
            }
            else
            {
                var data = db.IT_Expenses_Revenues.Find(ID);
                ViewBag.type = new SelectList(db.Eexp_Rev_type, "id_ex_re", "ex_re_type", data.id_ex_re);
                return View(data);
            }
        }
        [HttpPost]
        public ActionResult Update(IT_Expenses_Revenues item)
        {
            if (ModelState.IsValid)
            {
                //old way 
                //var olddata= db.IT_Expenses_Revenues.Find(item.ID);
                //olddata.Exp_Rev_Name = item.Exp_Rev_Name;
                //olddata.Entry_Date = item.Entry_Date;
                //olddata.Fees = item.Fees;
                //olddata.Note = item.Note;
                //olddata.id_ex_re = item.id_ex_re;

                //new way 
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.type = new SelectList(db.Eexp_Rev_type, "id_ex_re", "ex_re_type", item.id_ex_re);
                return View(item);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return HttpNotFound("This ID Not Found");
            }
            else
            {
                IT_Expenses_Revenues item = db.IT_Expenses_Revenues.Where(e => e.ID == ID).SingleOrDefault();
                db.IT_Expenses_Revenues.Remove(item);
                db.SaveChanges();
                return RedirectToAction("index");
            }
        }
    }
}
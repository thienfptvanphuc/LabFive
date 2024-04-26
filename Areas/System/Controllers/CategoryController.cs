using LabFive.Models;
using Microsoft.AspNetCore.Mvc;

namespace LabFive.Areas.System.Controllers
{
    [Area("System")]
    [Route("System/Category")]
    public class CategoryController : Controller
    {
        private readonly ShopContext db;

        public CategoryController(ShopContext context)
        {
            db = context;
        }
        [Route("Index")]
        public IActionResult Index()
        {
            var list = db.Categories.ToList();
            return View(list);
        }
        [Route("Add")]
        public IActionResult Add()
        {
            return View();
        }

        [Route("Add")]
        [HttpPost]
        public IActionResult Add(Category ViewData)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(ViewData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ViewData);
        }
        [Route("Edit")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var list = db.Categories.Find(id);
            if (list == null)
            {
                return RedirectToAction("Index");
            }
            return View(list);
        }
        [Route("Edit")]
        [HttpPost]
        public IActionResult Edit(int? id, Category ViewData)
        {
            if (id == ViewData.Id)
            {
                if (ModelState.IsValid)
                {
                    db.Categories.Update(ViewData);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(ViewData);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            var list = db.Categories.Find(id);
            if (list != null)
            {
                db.Categories.Remove(list);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}

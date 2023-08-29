using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objData = _db.Categories.ToList();
            return View(objData);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category Obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Add(Obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            
            Category? dataForEdit = _db.Categories.Find(Id);

            if (dataForEdit == null)
            {
                return NotFound();
            }
            return View(dataForEdit);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

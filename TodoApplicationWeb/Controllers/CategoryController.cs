using Microsoft.AspNetCore.Mvc;
using TodoApplicationWeb.Data;
using TodoApplicationWeb.Models;

namespace TodoApplicationWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db= db;
        }
        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.TodoTasks.ToList();
            return View(objCategoryList);
        }
        //get action method
        public IActionResult Create()
        {
            return View();
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.Task == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Custom Error", "THe Display Order cannot match the Task.");
            }
            if (ModelState.IsValid)
            


                _db.TodoTasks.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            
        }



        //get action method
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryfromDb = _db.TodoTasks.Find(id);
           // var categoryfromDbFirst = _db.TodoTasks.FirstOrDefault(u=> u.Id == id);
           // var categoryfromDbFirst = _db.TodoTasks.SingleOrDefault(u=>u.Id == id); 

            if (categoryfromDb == null) {
                return NotFound();
            }
            return View(categoryfromDb);
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.Task == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Custom Error", "THe Display Order cannot match the Task.");
            }
            if (ModelState.IsValid)
            {
                _db.TodoTasks.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
            
        }
        //get action method
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryfromDb = _db.TodoTasks.Find(id);
            // var categoryfromDbFirst = _db.TodoTasks.FirstOrDefault(u=> u.Id == id);
            // var categoryfromDbFirst = _db.TodoTasks.SingleOrDefault(u=>u.Id == id); 

            if (categoryfromDb == null)
            {
                return NotFound();
            }
            return View(categoryfromDb);
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj  = _db.TodoTasks.Find(id);
            if (obj == null) {
                return NotFound();
                    }

                _db.TodoTasks.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}

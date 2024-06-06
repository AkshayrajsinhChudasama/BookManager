using BookManagement.Data;
using BookManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
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
                List<Category> objCategoryList = _db.Categories.ToList();
                return View(objCategoryList);
            }

            public IActionResult Create()
            {
                return View();  
            }
        [HttpPost]
        public IActionResult Create(Category obj)
        {

            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("name", "The DisplayOrder cannot be same as the name ");
            //}
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category Created Successfully";
                return RedirectToAction("Index");

            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }


            Category categoryFromDb = _db.Categories.Find(id);
            //Category categoryFromDb = _db.Categories.FirstOrDefault(u=>id.id==id);
            //Category categoryFromDb = _db.Categories.Where();

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }


        [HttpPost]
        public IActionResult Edit(Category obj)
        {

            
            if (ModelState.IsValid) 
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["Success"] = "Category Updated Successfully";
                return RedirectToAction("Index");

            }
            return View();
        }


        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }


            Category categoryFromDb = _db.Categories.Find(id);
            //Category categoryFromDb = _db.Categories.FirstOrDefault(u=>id.id==id);
            //Category categoryFromDb = _db.Categories.Where();

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(obj);

            _db.Categories.Update(obj);
            _db.SaveChanges();
            TempData["Success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");

        }


    }
}        
 


using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBook.Controllers
{
    public class CategoryController : Controller
    {

        private readonly ApplicationDBContext _dbContext;

        public CategoryController(ApplicationDBContext db)
        {
                _dbContext = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _dbContext.categories;
            return View(objCategoryList);
        }

        //GET 
        public IActionResult Create()
        {
           
            return View();
        }


        //POST 
        [HttpPost]
        [ValidateAntiForgeryToken]
		public IActionResult Create(Category obj)
		{
            if(obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name","The Name can't exactly match the DisplayOrder. ");
            }

            if (ModelState.IsValid)
            {
                _dbContext.categories.Add(obj);
                _dbContext.SaveChanges();
                TempData["Success"] = "Category Created Successfully";

                return RedirectToAction("Index");
            }
            return View();
		}



		//GET 
		public IActionResult Edit(int? id)
		{
            if(id == null || id ==0)
            {
                return NotFound();
            }

            var category = _dbContext.categories.FirstOrDefault(c => c.Id == id);

            if (category == null)
            {
                return NotFound();
            }

			return View(category);
		}


		//POST 
		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(Category obj)
		{
			if (obj.Name == obj.DisplayOrder.ToString())
			{
				ModelState.AddModelError("name", "The Name can't exactly match the DisplayOrder. ");
			}

			if (ModelState.IsValid)
			{
				_dbContext.categories.Update(obj);
				_dbContext.SaveChanges();
                TempData["Success"] = "Category Updated Successfully";


                return RedirectToAction("Index");
			}
			return View();
		}


        //GET 
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var category = _dbContext.categories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }


        //POST 
        [HttpPost , ActionName("Delete")]        
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _dbContext.categories.Find(id);

            if (obj == null)
            {
                return NotFound();
            }

            _dbContext.categories.Remove(obj);
            _dbContext.SaveChanges();
            TempData["Success"] = "Category Deleted Successfully";


            return RedirectToAction("Index");
            
            return View();
        }
    }
}

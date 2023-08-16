using crudEFDBfirst.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace crudEFDBfirst.Controllers
{
    public class StudentsController : Controller
    {

        CollegeContext _Dbcontext;

        public StudentsController(CollegeContext dbcontext)
        {
            _Dbcontext = dbcontext;
        }

        public IActionResult Index()
        {
            return View(_Dbcontext.Students.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Student std)
        {
            if (ModelState.IsValid)
            {
                _Dbcontext.Students.Add(std);
                _Dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
           var s1= _Dbcontext.Students.Find(Id);
            return View(s1);

        }

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit(Student std)
        {
            if (ModelState.IsValid)
            {
                _Dbcontext.Students.Update(std);
                _Dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();

        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Delete(Student std)
        {
            if (ModelState.IsValid)
            {
                _Dbcontext.Students.Remove(std);
                _Dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}

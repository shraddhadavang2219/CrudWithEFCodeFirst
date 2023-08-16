using Microsoft.AspNetCore.Mvc;
using PracticeDBfirstEF.Models;

namespace PracticeDBfirstEF.Controllers
{
    public class EmployeController : Controller
    {
        DbfirstpracticeContext _Dbprac;

        public EmployeController(DbfirstpracticeContext dbprac)
        {
            _Dbprac = dbprac;
        }

        public IActionResult Index()
        {
            return View(_Dbprac.Employes.ToList());
        }

    }  
    
        
}

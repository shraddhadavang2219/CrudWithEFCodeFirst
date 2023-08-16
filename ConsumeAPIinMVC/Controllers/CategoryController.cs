using ConsumeAPIinMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ConsumeAPIinMVC.Controllers
{
    public class CategoryController : Controller
    {
        HttpClient client;
        string baseaddress;


        public CategoryController(IConfiguration cong)
        {
            this. client=new HttpClient();
            this.baseaddress = cong["Apiaddress"];
            client.BaseAddress = new Uri(baseaddress);
        }
        public IActionResult Index()
        {
            string Result = client.GetStringAsync(baseaddress + "").Result;
            List<CategoryModel>list=JsonSerializer.Deserialize<List<CategoryModel>>(Result).ToList();
            var Category = list.AsQueryable();
                
            return View(Category.ToList());
        }
    }
}

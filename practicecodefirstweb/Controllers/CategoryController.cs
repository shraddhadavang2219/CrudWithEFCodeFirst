using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using practicecodefirstweb.Model;
using System.Linq.Expressions;

namespace practicecodefirstweb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        IConfiguration _config;
        FlipkartContext _contex;

        public CategoryController(IConfiguration config, FlipkartContext contex)
        {
            _config = config;
            _contex = contex;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var products = _contex.CategoryModel.ToList();
                if (products.Count == 0)
                {
                    return NotFound("products not found");
                }
                return Ok(products);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {

                var products = _contex.CategoryModel.Find(id);
                if (products == null)
                {
                    return NotFound("product not found with id");

                }
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


         

            


        


            
    }
}

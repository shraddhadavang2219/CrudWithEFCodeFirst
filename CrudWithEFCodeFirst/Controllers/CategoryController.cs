using CrudWithEFCodeFirst.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace CrudWithEFCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        flipkartContext _Context;

        public CategoryController(flipkartContext context)
        {
            _Context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var result = _Context.Category.ToList();
                if (result.Count == 0)
                {
                    return NotFound("categories not found");
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = _Context.Category.Find(id);
                if(result== null)
                {
                    return NotFound($"product with id {id} not found");
                }
               return Ok(result);   
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult post(CategoryModel model)
        {
            try
            {

                if (model == null)
                {
                    return NotFound("model not found");
                }
                _Context.Category.Add(model);
                _Context.SaveChanges();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPut]
        public IActionResult put(CategoryModel model)
        {
            try
            {
                if(model == null)
                {
                    return NotFound("model not found");
                }
                var result = _Context.Category.Find(model.Id);

                if (result == null)
                {
                    return NotFound("result not found");
                }

                result.Name = model.Name;
                result.Description = model.Description;

                _Context.SaveChanges();

                return Ok(result);
                    
            }

            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult delete(int id)
        {
            try
            {
                var result = _Context.Category.Find(id);
                if (result == null)
                {
                    return NotFound($"product with id {id} not found");
                }
                _Context.Category.Remove(result);
                _Context.SaveChanges();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

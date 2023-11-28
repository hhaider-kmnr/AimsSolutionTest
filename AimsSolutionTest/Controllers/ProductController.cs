using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AimsSolutionTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepo product;

        public ProductController(IProductRepo product)
        {
            this.product = product;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<ProductVM> Get()
        {
            return product.GetAll();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ProductVM Get(int id)
        {
            return product.Get(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public ProductVM Post([FromBody] ProductVM value)
        {
            return product.Create(value);
        }

        // PUT api/<ProductController>/5
        [HttpPut]
        public ProductVM Put([FromBody] ProductVM value)
        {
            return product.Update(value);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return product.Delete(id);
        }
    }
}

using docker_backend.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace docker_backend.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ProductService _productservice;
        public ProductController(ProductService productservice, IConfiguration config)
        {
            _productservice = productservice;
            _config = config;
        }

        [HttpGet]
        [Route("get-products")]
        public IActionResult GetAll()
        {
            var products = _productservice.GetAllProducts();
            return Ok(new { products = products, message = "HELLO GITHUB ACTIONS" });
        }

        [HttpGet]
        [Route("get-product-byid")]
        public IActionResult GetProduct(int id)
        {
            var products = _productservice.GetProduct(id);
            return Ok(products);
        }

        [HttpGet]
        [Route("get-appsettings-value")]
        public IActionResult GetAppsettings()
        {
            return Ok(_config.GetValue<string>("TestingString"));
        }
    }
}

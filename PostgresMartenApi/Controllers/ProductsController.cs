using Marten;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostgresMartenApi.Models;

namespace PostgresMartenApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IDocumentSession _session;

        public ProductsController(IDocumentSession session)
        {
            _session = session;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> Get()
        {
            var products = await _session.Query<Product>().ToListAsync();
            return Ok(products);
        }

        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            _session.Store(product);
            _session.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }
    }
}

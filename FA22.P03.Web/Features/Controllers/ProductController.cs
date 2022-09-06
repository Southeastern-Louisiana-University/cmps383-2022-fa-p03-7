using Microsoft.AspNetCore.Mvc;
// using System.Web.Http;
using FA22.P03.Web.Features.Products;
using FA22.P02.Web.Features;
using Database;
using System.Linq;

[ApiController]
[Route("[controller]")]
public class ProductController : Controller
{
    private readonly DataContext _dataContext;


    public ProductController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    //Todo GET /api/products
    // returns list of all products 200

    [HttpGet("/api/products/")]
    public IActionResult GetAllProducts()
    {
        IList<ProductDto> products = _dataContext.Products.Distinct().Select<Product, ProductDto>((product) => new ProductDto { Id = product.Id, Name = product.Name, Description = product.Description }).ToList();
        return Ok(products);
    }



    //Todo Get /api/products/{id}
    // find product by its unique id and return the details 200/404
    [HttpGet("/api/products/{id}")]
    public IActionResult GetProductById(int id)
    {

        var result = _dataContext.Products.FirstOrDefault(x => x.Id == id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);

    }

    //Todo GET /api/products/{id}/listings
    // returns all current listings for the given product id 200
    //! No listings in db to check
    [HttpGet("/api/products/{id}/listings")]
    public IActionResult GetProductListing(int id)
    {
        var result = _dataContext.Listings.Where(x => x.Id == id);

        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);

    }
    //Todo Post /api/products
    // name must be provided, no longer than 120 / must have description/ return created dto and location
    [HttpPost("/api/products/")]
    public IActionResult AddNewProduct(string name, string description)
    {

        var newProduct = new ProductDto
        {
            Name = name,
            Description = description
        };





    }
    //Todo PUT /api/products/{id}
    // must have name 120 char max and description  return updated dto
    //Todo DELETE /api/products/{id}
    //retrun 200 or 404
}


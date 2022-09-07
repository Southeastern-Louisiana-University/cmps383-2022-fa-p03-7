using Microsoft.AspNetCore.Mvc;
using FA22.P03.Web.Features.Products;
using FA22.P02.Web.Features;
using Database;
public class ItemController : Controller
{
    private readonly DataContext _dataContext;
    public ItemController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    [HttpGet("/api/items/{id}")]
    public IActionResult GeItembyId(int id)
    {
        var result = _dataContext.Items.FirstOrDefault(x => x.Id == id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    [HttpPost("/api/items/")]
    public IActionResult AddNewItem(string condition, int productId)
    {
        //check for existing product by id and for condition string
        var result = _dataContext.Items.FirstOrDefault(x => x.Id == productId);
        if (result == null)
        {
            return NotFound();
        }
        if (condition == null)
        {
            return BadRequest("invalid data");
        }
        var newItem = new ItemDto
        {
            Condition = condition,
            ProductId = productId,
        };
        _dataContext.Items.Add(new Item
        {
            Condition = condition,

        });
        _dataContext.SaveChanges();

        return CreatedAtAction("AddNewItem", "/api/items", newItem);
    }
    [HttpPut("/api/items/{id}")]
    public IActionResult UpdateItem(int productId, string name, string condition)
    {
        var id = String.IsNullOrEmpty(productId.ToString());
        if (condition == null || id == false)
        {
            return BadRequest("invalid data");
        }
        var current = _dataContext.Items.FirstOrDefault(x => x.Id == productId);
        if (current == null)
        {
            return NotFound();
        }



        current.Condition = condition;

        _dataContext.SaveChanges();

        return CreatedAtAction("AddNewProduct", "/api/products", current);
    }



    [HttpDelete("/api/items/{id}")]
    public IActionResult DeleteItem(int id)
    {
        var current = _dataContext.Items.FirstOrDefault(x => x.Id == id);
        if (current == null)
        {
            return NotFound();
        }
        _dataContext.Remove(current);
        _dataContext.SaveChanges();
        return Ok();
    }

}
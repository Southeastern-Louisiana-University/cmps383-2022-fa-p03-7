using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;


public class ProductController : Controller
{
    // 
    // GET: /HelloWorld/

    public string Index()
    {
        return "This is my default action...";
    }

    // 
    // GET: /HelloWorld/Welcome/ 

    public string GetAllProducts()
    {
        return "This is the Welcome action method...";
    }
}


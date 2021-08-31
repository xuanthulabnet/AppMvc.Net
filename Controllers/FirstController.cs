using System;
using System.IO;
using System.Linq;
using App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly ProductService _productService;
        public FirstController(ILogger<FirstController> logger, ProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public string Index()
        {
            // this.HttpContext
            // this.Request
            // this.Response
            // this.RouteData

            // this.User
            // this.ModelState
            // this.ViewData
            // this.ViewBag
            // this.Url
            // this.TempData

            // _logger.Log(LogLevel.Warning, "Thong bao abc");

            _logger.LogWarning("Thong bao");
            _logger.LogError("Thong bao");
            _logger.LogDebug("Thong bao");
            _logger.LogCritical("Thong bao");
            _logger.LogInformation("Index Action");
            // Serilog 
            

            return "Toi la Index cua First";
        }


        public void Nothing()
        {
            _logger.LogInformation("Nothing Action");
            Response.Headers.Add("hi", "xin chao cac ban");
        }

        public object Anything() => new int[] { 1, 2, 3};

        public IActionResult Readme()
        {
            var content = @"
            Xin chao cac ban,
            cac ban dang hoc ve ASP.NET MVC




            XUANTHULAB.NET
            ";
            return Content(content, "text/plain");
        }

        public IActionResult Bird()
        {
            // Startup.ContentRootPath
            string filePath = Path.Combine(Startup.ContentRootPath, "Files", "Birds.jpg");
            var bytes = System.IO.File.ReadAllBytes(filePath);

            return File(bytes, "image/jpg");
        }
        
        public IActionResult IphonePrice()
        {
            return Json(
              new {
                  productName = "Iphone X",
                  Price = 1000
              }
            );
        } 

        public IActionResult Privacy()
        {
            var url = Url.Action("Privacy", "Home");
            _logger.LogInformation("Chuyen huong den " + url);
            return LocalRedirect(url); // local ~ host 
        }
        public IActionResult Google()
        {
            var url = "https://google.com";
            _logger.LogInformation("Chuyen huong den " + url);
            return Redirect(url); // local ~ host 
        }

      
        // ViewResult | View()
        public IActionResult HelloView(string username)
        {
            if (string.IsNullOrEmpty(username))
              username = "Khách";


            // View()  -> Razor Engine, doc .cshtml (template)
            //------------------------------------------------
            // View(template) - template đường dẫn tuyệt đối tới .cshtml
            // View(template, model) 
            // return View("/MyView/xinchao1.cshtml", username);

            // xinchao2.cshtml -> /View/First/xinchao2.cshtml
            // return View("xinchao2", username);

            // HelloView.cshtml -> /View/First/HelloView.cshtml
            // /View/Controller/Action.cshtml
            // return View((object)username);

            return View("xinchao3", username);

            // View();
            // View(Model);
            
        }

        [TempData]
        public string StatusMessage { get; set; }

        [AcceptVerbs("POST", "GET")]
        public IActionResult ViewProduct(int? id)
        {
            var product = _productService.Where(p => p.Id == id).FirstOrDefault();
            if (product == null)
            {
                // TempData["StatusMessage"] = "San pham ban yeu cau khong co";
                StatusMessage = "Sản phẩm bạn yêu cầu không có";
                return Redirect(Url.Action("Index", "Home"));
            }
              

            // /View/First/ViewProduct.cshtml
            // /MyView/First/ViewProduct.cshtml

            // Model
            // return View(product);

            // ViewData
            // this.ViewData["product"] = product;
            // ViewData["Title"] = product.Name;
            // return View("ViewProduct2");

            


            ViewBag.product = product;
            return View("ViewProduct3");

        }
        


    }
}
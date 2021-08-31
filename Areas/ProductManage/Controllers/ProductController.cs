using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace App.Controllers
{
    [Area("ProductManage")]
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        [Route("/cac-san-pham/{id?}")]
        public IActionResult Index()
        {
            // /Areas/AreaName/Views/ControllerName/Action.cshtml

            var products = _productService.OrderBy(p => p.Name).ToList();
            return View(products); // Areas/ProductManage/Views/Product/Index.cshtml

        }
    }
}
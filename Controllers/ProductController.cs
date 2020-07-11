using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNetCoreDynamicForm.Models;
using AspNetCoreDynamicForm.Models.Services.Application;
using AspNetCoreDynamicForm.Models.InputModels;

namespace AspNetCoreDynamicForm.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Edit), new { id = 1 });
        }

        public IActionResult Edit([FromServices] IProductService productService, int id)
        {
            ProductConfigurationEditModel product = productService.GetProductForEditing(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit([FromServices] IProductService productService, ProductConfigurationEditModel editModel, int id)
        {
            productService.EditProduct(id, editModel);
            TempData["Message"] = "Product was saved successfully";
            return RedirectToAction(nameof(Edit), new { id = id });
        }
    }
}

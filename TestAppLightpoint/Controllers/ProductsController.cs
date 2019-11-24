using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestAppLightpoint.BLL.DTO;
using TestAppLightpoint.BLL.Interfaces;
using TestAppLightpoint.DAL.EF;
using TestAppLightpoint.Web.Models;

namespace TestAppLightpoint.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _productService;
        private readonly IStoreService _storeService;

        public ProductsController(IProductService productService, IStoreService storeService)
        {
            _productService = productService;
            _storeService = storeService;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var listProductsDTO = await _productService.GetAllProductAsync();
            IEnumerable<ProductViewModel> view = listProductsDTO.ToList().ConvertAll(t => new ProductViewModel
            {
                Id = t.Id,
                Name = t.Name,
                Description = t.Description,
                StoreId = t.StoreId,
            });

            return View(view);
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.GetSingleProductAsync((int)id);

            ProductViewModel productView = new ProductViewModel()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                StoreId = product.StoreId
            };
            if (product == null)
            {
                return NotFound();
            }

            return View(productView);
        }

        // GET: Products/Create
        public IActionResult Create(int storeId)
        {
            var id = new ProductViewModel()
            {
                StoreId = storeId
            };
            return View(id);
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int storeId, ProductViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                ProductDTO productDTO = new ProductDTO
                {
                    Name = viewModel.Name,
                    Description = viewModel.Description,
                    StoreId = storeId,
                };
                await _productService.CreateProductAsync(productDTO);
                return RedirectToAction("Index", "Stores");
            }
            else return View();
        }


        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.GetSingleProductAsync((int)id);
            var viewProduct = new ProductViewModel()
            {
                Name = product.Name,
                Description = product.Description,
                StoreId = product.StoreId,

            };
            if (product == null)
            {
                return NotFound();
            }
            return View(viewProduct);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductViewModel product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ProductDTO productUpdate = new ProductDTO()
                    {
                        Id = product.Id,
                        Name = product.Name,
                        Description = product.Description,
                        StoreId = product.StoreId
                    };
                    await _productService.UpdateProduct(productUpdate);
                }
                catch (DbUpdateConcurrencyException)
                {

                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productService.GetSingleProductAsync((int)id);
            var viewProduct = new ProductViewModel()
            {
                Name = product.Name,
                Description = product.Description,
                StoreId = product.StoreId,

            };
            if (product == null)
            {
                return NotFound();
            }

            return View(viewProduct);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {

            await _productService.DeleteProductAsync(id);
            return RedirectToAction(nameof(Index));
        }


    }
}

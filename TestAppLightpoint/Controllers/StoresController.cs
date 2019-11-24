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
    public class StoresController : Controller
    {
        private readonly IProductService _productService;
        private readonly IStoreService _storeService;


        public StoresController(IProductService productService, IStoreService storeService)
        {
            _productService = productService;
            _storeService = storeService;
 
        }

        // GET: Stores
        public async Task<IActionResult> Index()
        {
           var listDTO = await _storeService.GetAllStoreAsync();
            IEnumerable<StoreViewModel> lisViewModel = listDTO.ToList().ConvertAll(t => new StoreViewModel
            {
                Id = t.Id,
                Name = t.Name,
                Address = t.Address,
                OpeningTimes = t.OpeningTimes,
            });
            return View(lisViewModel);
        }

        // GET: Stores/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id != 0)
            {
                var productDTOs = await _productService.GetAllProductsOfStore(id);
                var store = await _storeService.GetSingleStoreAsync(id);
                IEnumerable<ProductViewModel> view = productDTOs.ToList().ConvertAll(t => new ProductViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Description = t.Description,
                    StoreId = t.StoreId,
                }) ;

                ProductListViewModel viewList = new ProductListViewModel
                {
                    ListProduct = view,
                    Store = store
                };

                if (productDTOs == null)
                {
                    return NotFound();
                }

                return View(viewList);
            }
            return NotFound();
        }

        // GET: Stores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Stores/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StoreViewModel store)
        {
            if (ModelState.IsValid)
            {
                StoreDTO storeDTO = new StoreDTO()
                {
                    Id = store.Id,
                    Address = store.Address,
                    Name = store.Name,
                    OpeningTimes = store.OpeningTimes
                };
                await _storeService.CreateStoreAsync(storeDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(store);
        }



        // GET: Stores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var store = await _storeService.GetSingleStoreAsync((int)id);
            StoreViewModel storeViewModel = new StoreViewModel()
            {
                Id = store.Id,
                Name = store.Name,
                OpeningTimes = store.OpeningTimes,
                Address = store.Address
            };
            if (store == null)
            {
                return NotFound();
            }
            return View(storeViewModel);
        }

        // POST: Stores/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, StoreViewModel store)
        {
            if (id != store.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    StoreDTO storeDTO = new StoreDTO()
                    {
                        Id = store.Id,
                        Name = store.Name,
                        Address = store.Address,
                        OpeningTimes = store.OpeningTimes
                    };
                    await _storeService.UpdateStore(storeDTO);
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!StoreExists(store.Id))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction(nameof(Index));
            }
            return View(store);
        }

        // GET: Stores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var store = await _storeService.GetSingleStoreAsync((int)id);

            StoreViewModel storeViewModel = new StoreViewModel()
            {
                Id = store.Id,
                Name = store.Name,
                OpeningTimes = store.OpeningTimes,
                Address = store.Address
            };
            if (store == null)
            {
                return NotFound();
            }

            return View(storeViewModel);
        }

        // POST: Stores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _storeService.DeleteStoreAsync(id);
            return RedirectToAction(nameof(Index));
        }


    }
}

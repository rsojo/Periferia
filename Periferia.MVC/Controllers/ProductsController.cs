using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Periferia.MVC.Models;
using Periferia.MVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Periferia.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }
        public async Task<ActionResult> Index()
        {
            var response = await _service.GetItems("");
            if (response.Error)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(response.Lst);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            var item = new Product();
            item.Id = 0;
            item.Name = collection["Name"];
            item.UnitValue = int.Parse(collection["UnitValue"]);
            var response = await _service.SetItem(item);
            if (response.Error)
            {
                return RedirectToAction("Error", "Home");
            }
            ViewData["Message"] = "Guardado finalizado";
            return View(response.UnitResp);
        }

        // GET: ProductsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var response = await _service.GetItem(id);
            if (response.Error)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(response.UnitResp);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            var item = new Product();
            item.Id = id;
            item.Name = collection["Name"];
            item.UnitValue = int.Parse( collection["UnitValue"]);
            var response = await _service.SetItem(item);
            if (response.Error)
            {
                return RedirectToAction("Error", "Home");
            }
            ViewData["Message"] = "Guardado finalizado";
            return View(response.UnitResp);
        }

        // GET: ProductsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _service.GetItem(id);
            if (response.Error)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(response.UnitResp);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            var response = await _service.Delete(id);
            if (response.Error)
            {
                return RedirectToAction("Error", "Home");
            }
            ViewData["Message"] = "Eliminado finalizado";
            return View(new Product());
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Periferia.MVC.Models;
using Periferia.MVC.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Periferia.MVC.Controllers
{
    public class SimpleSalesController : Controller
    {
        private ISimpleSaleService _service;
        private IProductService _productService;
        private IClientService _clientService;

        public SimpleSalesController(ISimpleSaleService service, IProductService productService, IClientService clientService)
        {
            _service = service;
            _productService = productService;
            _clientService = clientService;
        }
        public async Task<ActionResult> Index()
        {
            var response = await _service.GetItems("");
            var responseC = await _clientService.GetItems("");
            var responseP = await _productService.GetItems("");
            if (response.Error || responseC.Error || responseP.Error)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(response.Lst);
        }

        // GET: SimpleSalesController/Create
        public async Task<ActionResult> Create()
        {

            var responseC = await _clientService.GetItems("");
            var responseP = await _productService.GetItems("");
            if (responseC.Error || responseP.Error)
            {
                return RedirectToAction("Error", "Home");
            }
            var lstProd = new List<SelectListItem>();
            foreach (var item in responseP.Lst)
            {
                lstProd.Add(new SelectListItem() { Text = item.Name, Value = item.Id.ToString() });
            }
            var lstCli = new List<SelectListItem>();
            foreach (var item in responseC.Lst)
            {
                lstCli.Add(new SelectListItem() { Text = item.FirstName + " " + item.LastName, Value = item.Id.ToString() });
            }

            ViewBag.lstCli = lstCli;
            ViewBag.lstProd = lstProd;
            return View();
        }

        // POST: SimpleSalesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            var item = new SimpleSale();
            item.Id = 0;
            item.Count = int.Parse(collection["Count"]);
            item.ProductId = int.Parse(collection["ProductId"][0]);
            item.ClientId = int.Parse(collection["ClientId"][0]);
            var response = await _service.SetItem(item);
            if (response.Error)
            {
                return RedirectToAction("Error", "Home");
            }
            ViewData["Message"] = "Guardado finalizado";

            ViewBag.lstCli = new List<SelectListItem>();
            ViewBag.lstProd = new List<SelectListItem>();
            return View(response.UnitResp);
        }
    }
}

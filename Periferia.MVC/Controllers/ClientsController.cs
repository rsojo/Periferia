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
    public class ClientsController : Controller
    {
        private IClientService _service;

        public ClientsController(IClientService service)
        {
            _service = service;
        }
        // GET: ClientsController
        public async Task<ActionResult> Index()
        {
            var response = await _service.GetItems("");
            if (response.Error)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(response.Lst);
        }

        // GET: ClientsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            var item = new Client();
            item.Id = 0;
            item.FirstName = collection["FirstName"];
            item.LastName = collection["LastName"];
            item.Phone = collection["Phone"];
            item.DocNumber = collection["DocNumber"];
            var response = await _service.SetItem(item);
            if (response.Error)
            {
                return RedirectToAction("Error", "Home");
            }
            ViewData["Message"] = "Guardado finalizado";
            return View(response.UnitResp);
        }

        // GET: ClientsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var response = await _service.GetItem(id);
            if (response.Error)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(response.UnitResp);
        }

        // POST: ClientsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            var item = new Client();
            item.Id = id;
            item.FirstName = collection["FirstName"];
            item.LastName = collection["LastName"];
            item.Phone = collection["Phone"];
            item.DocNumber = collection["DocNumber"];
            var response = await _service.SetItem(item);
            if (response.Error)
            {
                return RedirectToAction("Error", "Home");
            }
            ViewData["Message"] = "Guardado finalizado";
            return View(response.UnitResp);
        }

        // GET: ClientsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _service.GetItem(id);
            if (response.Error)
            {
                return RedirectToAction("Error", "Home");
            }
            return View(response.UnitResp);
        }

        // POST: ClientsController/Delete/5
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
            return View(new Client());
        }
    }
}

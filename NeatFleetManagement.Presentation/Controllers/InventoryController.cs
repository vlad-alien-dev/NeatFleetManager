using AutoMapper;
using NeatFleetManager.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NeatFleetManager.Web.Controllers
{
    public class InventoryController : Controller
    {
        private readonly ICarService carService;
        private readonly IMapper mapper;

        public InventoryController(ICarService carService, IMapper mapper)
        {
            this.carService = carService;
            this.mapper = mapper;
        }
        // GET: Inventory
        public ActionResult Index()
        {
            IEnumerable<CarServiceModel> servModels = this.carService.GetAllCars();
            var viewModels = this.mapper.Map<List<CarViewModel>>(servModels);

            return View(viewModels);
        }

        // GET: Inventory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Inventory/Create
        [ChildActionOnly]
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Inventory/Create
        [HttpPost]
        public ActionResult Create(CarViewModel car)
        {
            try
            {
                var serviceModel = this.mapper.Map<CarServiceModel>(car);
                this.carService.CreateCar(serviceModel);
                this.carService.Save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: Inventory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Inventory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Inventory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Inventory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [ChildActionOnly]
        public ActionResult AveragePrice()
        {
            var averagePrice = this.carService.AveragePrice();
            return PartialView("_AveragePrice", averagePrice);
        }
        [ChildActionOnly]
        public ActionResult ColorsProportion()
        {
            var colorsProportion = this.carService.ColorsProportion();
            return PartialView("_ColorsPieChart", colorsProportion);
        }
        [ChildActionOnly]
        public ActionResult NewCarsProportion()
        {
            var newCarsProportion = this.carService.NewCarsProportion();
            return PartialView("_NewCarsProportion", newCarsProportion);
        }

    }
}

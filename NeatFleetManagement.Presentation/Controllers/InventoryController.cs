using AutoMapper;
using Microsoft.AspNet.Identity;
using NeatFleetManagement.Presentation.Models;
using NeatFleetManagement.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NeatFleetManagement.Web.Controllers
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
            var userId = User.Identity.GetUserId();

            IEnumerable<CarServiceModel> servModels = this.carService.GetCarsByUserId(userId);
            var viewModels = this.mapper.Map<List<CarViewModel>>(servModels);

            return View(viewModels);
        }
        public ActionResult ReadyToGoDemo()
        {
            IEnumerable<CarServiceModel> servModels = this.carService.GetAllCars();
            var viewModels = this.mapper.Map<List<CarViewModel>>(servModels);

            return View("Index",viewModels);
        }

        // GET: Inventory/Create
        [ChildActionOnly]
        public ActionResult Create()
        {
            return PartialView();
        }

        // POST: Inventory/Create
        [HttpPost]
        public ActionResult Create(CarFormViewModel car)
        {
            try
            {
                var callingActionName = (Request.UrlReferrer.Segments.Skip(2).Take(1).SingleOrDefault() ?? "ReadyToGoDemo").Trim('/');
                var userId = User.Identity.GetUserId();

                var serviceModel = this.mapper.Map<CarServiceModel>(car);
                serviceModel.OwnerId = userId;
                this.carService.CreateCar(serviceModel);
                this.carService.Save();
                return RedirectToAction(callingActionName);
            }
            catch(Exception ex)
            {
                return View("~/Views/Shared/Error.cshtml", new HandleErrorInfo(ex, "Inventory", "Create"));
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

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjectDomnet.Repository.Repository.IRepository;
using ProjectDomnet.Models;
using ProjectDomnet.Service.Service.IService;
using ProjectDomnet.WebAPI.ProjectDtos.VehicleModelDto;
using ProjectDomnet.Common;

namespace ProjectDomnet.WebAPI.Controllers
{
    public class VehicleModelController : Controller
    {
        private readonly IMapper _mapper;

        public readonly IVehicleModelService _vehicleModelService;

        public VehicleModelController(IVehicleModelService vehicleModelService, IMapper mapper)
        {
            _vehicleModelService = vehicleModelService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Detail(int id)
        {
            VehicleModel vehicleModel = await _vehicleModelService.GetModelByIdAsync(id);
            return View("~/Views/VehicleModel/Detail.cshtml", vehicleModel);
        }


        //GET
        public IActionResult Create()
        {

            return View("~/Views/VehicleModel/Create.cshtml");
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateVehicleModel createVehicleModel)
        {
            if (!ModelState.IsValid)
            {

                return View("~/Views/VehicleModel/Create.cshtml", createVehicleModel);
            }

            var vehicle = _mapper.Map<VehicleModel>(createVehicleModel);

            await _vehicleModelService.CreateModelAsync(vehicle);
            return RedirectToAction("VehicleModelPage", "VehicleModel");
        }

        //GET
        public async Task<IActionResult> Edit(int id)
        {
            var vehicleModel = await _vehicleModelService.GetModelByIdAsync(id);
            if (vehicleModel == null)
            {
                return View("Error");
            }

            var vehicleMap = _mapper.Map<EditVehicleModel>(vehicleModel);

            return View("~/Views/VehicleModel/Edit.cshtml", vehicleMap);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditVehicleModel editVehicleModel)
        {
            if (!ModelState.IsValid)
            {

                return View("~/Views/VehicleModel/Edit.cshtml", editVehicleModel);
            }

            var vehicleModel = _mapper.Map<VehicleModel>(editVehicleModel);
            await _vehicleModelService.EditModelAsync(vehicleModel);
            return RedirectToAction("VehicleModelPage", "VehicleModel");
        }

        //GET
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var vehicleModel = await _vehicleModelService.GetModelByIdAsync(id);

            if (vehicleModel == null)
            {
                return NotFound();
            }
            return View("~/Views/VehicleModel/Delete.cshtml", vehicleModel);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePOST(int id)
        {
            var vehicleModel = await _vehicleModelService.GetModelByIdAsync(id);
            if (vehicleModel == null)
            {
                return NotFound();
            }

            await _vehicleModelService.DeleteModelAsync(vehicleModel);
            return RedirectToAction("VehicleModelPage", "VehicleModel");
        }

        public async Task<IActionResult> VehicleModelPage(string sortOrder, string currentFilter, string searchString, int? pgNumber)
        {
            ViewData["Sort"] = sortOrder;
            ViewData["NameSort"] = "name";
            ViewData["AbrvSort"] = "abrv";

            if (pgNumber == null && searchString != null)
                pgNumber = 0;
            else if (currentFilter != null)
                searchString = currentFilter;
            else
                searchString = "";

            (var vehicleModels, int totalPages) = await _vehicleModelService.GetAllAsync(new Page()
            {
                PgIndex = pgNumber ?? 0,
                PgFilter = searchString,
                SortOrder = sortOrder,
                PgSize=4
            });

            ViewData["Filter"] = searchString;

            var model = new VehicleModelPagingSorting()
            {
                VehicleModelsModel = vehicleModels,
                page = new Page()
                {
                    PgIndex = pgNumber ?? 0,
                    NumPages = totalPages
                },
            };

            return View("~/Views/VehicleModel/VehicleModel.cshtml", model);
        }
    }
}

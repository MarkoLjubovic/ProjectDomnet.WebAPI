using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ProjectDomnet.Common;
using ProjectDomnet.Repository.Repository.IRepository;
using ProjectDomnet.Models;
using ProjectDomnet.Service.Service.IService;
using ProjectDomnet.WebAPI.ProjectDtos.VehicleMakeDto;

namespace ProjectDomnet.WebAPI.Controllers
{
    public class VehicleMakeController : Controller
    {
        private readonly IMapper _mapper;
        public readonly IVehicleMakeService _vehicleMakeService;

        public VehicleMakeController(IVehicleMakeService vehicleMakeService, IMapper mapper)
        {
            _vehicleMakeService = vehicleMakeService;
            _mapper = mapper;
        }

        //GET
        public IActionResult Create()
        {
            return View("~/Views/VehicleMake/Create.cshtml");
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateVehicleMake createVehicleMake)
        {
            if (!ModelState.IsValid)
            {

                return View("~/Views/VehicleMake/Create.cshtml", createVehicleMake);
            }

            var vehicleMake = _mapper.Map<VehicleMake>(createVehicleMake);

            await _vehicleMakeService.CreateMakeAsync(vehicleMake);
            return RedirectToAction("VehicleMakePage", "VehicleMake");
        }

        //GET
        public async Task<IActionResult> Edit(int id)
        {
            var vehicleMake = await _vehicleMakeService.GetMakeByIdAsync(id);
            if (vehicleMake == null)
            {
                return View("Error");
            }

            return View("~/Views/VehicleMake/Edit.cshtml", vehicleMake);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditVehicleMake editVehicleMake)
        {
            if (!ModelState.IsValid)
            {

                return View("~/Views/VehicleMake/Edit.cshtml", editVehicleMake);
            }

            var vehicleMake = _mapper.Map<VehicleMake>(editVehicleMake);
            await _vehicleMakeService.EditMakeAsync(vehicleMake);
            return RedirectToAction("VehicleMakePage", "VehicleMake");
        }

        //GET
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var vehicleMake = await _vehicleMakeService.GetMakeByIdAsync(id);

            if (vehicleMake == null)
            {
                return NotFound();
            }
            return View("~/Views/VehicleMake/Delete.cshtml", vehicleMake);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletePOST(int id)
        {
            var vehicleMake = await _vehicleMakeService.GetMakeByIdAsync(id);
            if (vehicleMake == null)
            {
                return NotFound();
            }

            await _vehicleMakeService.DeleteMakeAsync(vehicleMake);
            return RedirectToAction("VehicleMakePage", "VehicleMake");
        }

        public async Task<IActionResult> VehicleMakePage(string sortOrder, string currentFilter, string searchString, int? pgNumber)
        {
            ViewData["Sort"]=sortOrder;
            ViewData["NameSort"] = "name";
            ViewData["AbrvSort"] = "abrv";

            if (pgNumber == null && searchString != null)
                pgNumber = 0;
            else if (currentFilter != null)
                searchString = currentFilter;
            else
                searchString = "";

            Paging paging = new();
            Filtering filtering = new();
            Sorting sorting = new();

            paging.PgIndex = pgNumber ?? 0;
            filtering.PgFilter = searchString;
            sorting.SortOrder = sortOrder;

            (var vehicleMakes, int totalPages) = await _vehicleMakeService.GetAllAsync(sorting, paging, filtering);

            ViewData["Filter"] = searchString;

            var model = new VehicleMakePage()
            {
                VehicleMakesModel = vehicleMakes,
                paging = new Paging()
                {
                    PgIndex= pgNumber ?? 0,
                    NumOfPages= totalPages
                },
            };

            return View("~/Views/VehicleMake/VehicleMake.cshtml", model);
        }
    }
}

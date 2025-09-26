using Application.Dtos.CountryDto;
using Application.Services.CountryService;
using Application.ViewModels.Country;
using Microsoft.AspNetCore.Mvc;
using Persistence.Contexts;

namespace HorizonFutureVestWepApp.Controllers
{
    public class CountryController(AppContextDB contextDB) : Controller
    {

        private readonly ReedCountryService _reedcountryService = new (contextDB);
        private readonly CreateCountryService _createcountryService = new (contextDB);
        private readonly UpdateCountryService _updatecountryService = new (contextDB);
        private readonly DeleteCountryService _deletecountryService = new (contextDB);


        public async Task<IActionResult> Index()
        {
            var dtos = await _reedcountryService.GetAllWithInclude();

            var entityListVms = dtos.Select(c =>
            new ReedCountryViewModel()
            {
                Id = c.Id,
                Name = c.Name,
                ISOCode = c.ISOCode,
                IndicatorQuantity = c.IndicatorQuantity,

            }).ToList();
            return View(entityListVms);
        }

        // create

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create", new CreateCountryViewModel() { Name = "", ISOCode = "" });
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCountryViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", vm);
            }

            CreateCountryDto dto = new()
            {
                Name = vm.Name,
                ISOCode = vm.ISOCode,
            };
            await _createcountryService.AddAsync(dto);
            return RedirectToRoute(new { Controller = "Country", Action = "Index" });

        }


        // Delete

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            var dto = await _deletecountryService.GetById(id);
            if (dto != null)
            {
                DeleteCountryViewModel vm = new() { Id = dto.Id, Name = dto.Name };
                return View(vm);
            }

            return RedirectToRoute( new {Controller = "Country", action = "Index" });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteCountryViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            await _deletecountryService.DeleteAsync(vm.Id);
            return RedirectToRoute(new { Controller = "Country", action = "Index" });
            
        }

        // editar
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.EditMode = true;
            var dto = await _deletecountryService.GetById(id);
            if(dto != null)
            {
                UpdateCountryViewModel vm = new () { Id = dto.Id, Name = dto.Name, ISOCode = dto.ISOCode };
                return View("Update", vm);
            }

            return RedirectToRoute(new { Controller = "Country", action = "Index" });
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCountryViewModel vm)
        {
            
            
            if (!ModelState.IsValid)
            {
                ViewBag.EditMode = true;
                return View("Update", vm);
            }
           
            UpdateCountryDto dto = new() { Id = vm.Id, Name = vm.Name, ISOCode = vm.ISOCode };
            await _updatecountryService.UpdateAsync(dto);
            return RedirectToRoute(new { Controller = "Country", action = "Index" });
        }



    }
}

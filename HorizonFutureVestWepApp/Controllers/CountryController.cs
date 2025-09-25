using Application.DTOs;
using Application.Services;
using Application.ViewModels.Country;
using Microsoft.AspNetCore.Mvc;
using Persistence.Contexts;
using System.Threading.Tasks;
namespace HorizonFutureVestWepApp.Controllers
{
    public class CountryController(AppContextDB contextDB) : Controller
    {

        private readonly CountryService _countryService = new CountryService(contextDB);

        public async Task<IActionResult> Index()
        {
            var dtos = await _countryService.GetAllWithInclude();

            var entityListVms = dtos.Select(c =>
            new CountryViewModel()
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
            return View("Save", new SaveCountryViewModel() { Name = "", ISOCode = "" });
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveCountryViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Save", vm);
            }

            CountryDto dto = new()
            {

                Id = vm.Id,
                Name = vm.Name,
                ISOCode = vm.ISOCode,
            };
            await _countryService.AddAsync(dto);
            return RedirectToRoute(new { Controller = "Country", Action = "Index" });

        }


        // Delete

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            var dto = await _countryService.GetById(id);
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

            await _countryService.DeleteAsync(vm.Id);
            return RedirectToRoute(new { Controller = "Country", action = "Index" });
            
        }

        // editar
        public async Task<IActionResult> Edit(int id)
        {
            ViewBag.EditMode = true;
            var dto = await _countryService.GetById(id);
            if(dto != null)
            {
                SaveCountryViewModel vm = new () { Id = dto.Id, Name = dto.Name, ISOCode = dto.ISOCode };
                return View("Save", vm);
            }

            return RedirectToRoute(new { Controller = "Country", action = "Index" });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveCountryViewModel vm)
        {
            
            
            if (!ModelState.IsValid)
            {
                ViewBag.EditMode = true;
                return View("Save", vm);
            }
           
            CountryDto dto = new() { Id = vm.Id, Name = vm.Name, ISOCode = vm.ISOCode };
            await _countryService.UpdateAsync(dto);
            return RedirectToRoute(new { Controller = "Country", action = "Index" });
        }



    }
}

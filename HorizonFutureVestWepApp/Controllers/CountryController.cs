using Application.Dtos.CountryDto;
using Application.ViewModels.Country;
using Microsoft.AspNetCore.Mvc;
using Application.Services.Interface;


namespace HorizonFutureVestWepApp.Controllers
{
    public class CountryController(ICountryService countrySevice) : Controller
    {

        private readonly ICountryService _countryService = countrySevice;
        


        public async Task<IActionResult> Index()
        {
            var dtos = await _countryService.GetAllWithIncludeAsync();

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
            await _countryService.CreateAsync(dto);
            return RedirectToRoute(new { Controller = "Country", Action = "Index" });

        }


        // Delete

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            var dto = await _countryService.GetByIdAsync(id);
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
        public async Task<IActionResult> Update(int id)
        {
            
            var dto = await _countryService.GetByIdAsync(id);
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
                
                return View("Update", vm);
            }
           
            UpdateCountryDto dto = new() { Id = vm.Id, Name = vm.Name, ISOCode = vm.ISOCode };
            await _countryService.UpdateAsync(dto);
            return RedirectToRoute(new { Controller = "Country", action = "Index" });
        }



    }
}

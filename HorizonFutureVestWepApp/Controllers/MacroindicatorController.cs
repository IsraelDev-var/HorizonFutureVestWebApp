
using Application.Dtos.MacroindicatorDto;
using Application.Services.Interface;
using Application.ViewModels.Macroindicator;
using Microsoft.AspNetCore.Mvc;
using Persistence.Contexts;


namespace HorizonFutureVestWepApp.Controllers
{
    public class MacroindicatorController(IMacroindicatorService macroindicatorService) : Controller
    {
        private readonly IMacroindicatorService _createMacroindicatorService = macroindicatorService;
        





        public async Task<IActionResult> Index()
        {

            var dto = await _createMacroindicatorService.GetAllWithIncludeAsync();

            var entitiesList = dto.Select(x => new ReedMacroindicatorViewModel
            { 
                Id = x.Id,
                Name = x.Name,
                Weight = x.Weight,
                HigherIsBetter = x.HigherIsBetter,
            
            }).ToList();

            return View(entitiesList);
        }


        // crete 

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create", new CreateMacroindicatorViewModel { Name = "", Weight = 0, HigherIsBetter = false});
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMacroindicatorViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", vm);
            }


            CreateMacroindicatorDto dto = new()
            {
                Name = vm.Name,
                Weight = vm.Weight,
                HigherIsBetter = vm.HigherIsBetter,
            };



            var ok = await _createMacroindicatorService.CreateAsync(dto);
            if (!ok)
            {
                // La suma de pesos superó 1 (o el servicio devolvió false)
                ModelState.AddModelError(nameof(vm.Weight), "La suma de los pesos no puede superar 1.");
                return View(vm);
            }
            TempData["Success"] = "Macroindicador creado correctamente.";
            return RedirectToAction("Index", "Macroindicator"); 
        }




        
        public async Task<IActionResult> Update(int id)
        {

            var dto = await _createMacroindicatorService.GetByIdAsync(id);

            if (dto != null)
            {
                UpdateMacroindicatorViewModel vm = new() { Id = dto.Id, Name = dto.Name, HigherIsBetter = dto.HigherIsBetter, Weight = dto.Weight };
                return View("Update", vm);
            }
            return RedirectToAction("Index", "Macroindicator"); // éxito => PRG


        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateMacroindicatorViewModel vm)
        {


            if (!ModelState.IsValid)
            {

                return View("Update", vm);
            }

            
            UpdateMacroindicatorDto dto = new()
            {
                Id = vm.Id,
                Name = vm.Name,
                Weight = vm.Weight,
                HigherIsBetter = vm.HigherIsBetter,
            };

            var ok = await _createMacroindicatorService.UpdateAsync(dto);
            if (!ok)
            {
                // La suma de pesos superó 1 (o el servicio devolvió false)
                ModelState.AddModelError(nameof(vm.Weight), "La suma de los pesos no puede superar 1.");
                return View(vm);
            }

            return RedirectToAction("Index", "Macroindicator"); // éxito => PRG


        }



    }
}

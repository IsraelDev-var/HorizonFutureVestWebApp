using Application.Dtos.MacroindicatorDto;
using Persistence.Contexts;
using Persistence.Entities;
using Persistence.Repositpries;

namespace Application.Services.MacroindicatorService
{
    public class CreateMacroindicatorService(AppContextDB appContextDB)
    {
        private readonly MacroindicatorRepository _macroindicatorRepository = new(appContextDB);

        // validación y es que si la suma actual de los pesos
        // de los macroindicadores creados es igual 1 ya no se pueden
        //crear más macroindicadores

        public async Task<bool>  AddAsync(CreateMacroindicatorDto dto)
        {
            try
            {
                // hacer la ppContextDB sumatoria
                var sumatoria = (await _macroindicatorRepository.GetAllList()).Sum(x => x.Weight);

                // validar la suma lleho a 1
                if (sumatoria >= 0)
                {
                    return false;
                }

                Macroindicator entity = new ()
                {
                    Id = 0,
                    Name = dto.Name,
                    Weight = dto.Weight,
                    HigherIsBetter = false,

                };


                if (sumatoria + entity.Weight > 1)
                {
                    return false;
                }

                var created = await _macroindicatorRepository.AddAsync(entity);
                return created != null;



            }
            catch (Exception)
            {

                return false;

            }
        }


    }
}

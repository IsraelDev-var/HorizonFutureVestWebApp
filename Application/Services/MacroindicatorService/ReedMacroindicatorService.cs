using Application.Dtos.MacroindicatorDto;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Repositpries;

namespace Application.Services.MacroindicatorService
{
    public class ReedMacroindicatorService(AppContextDB appContextDB)
    {
        private readonly MacroindicatorRepository _macroindicatorRepository = new(appContextDB);


        public async Task<List<ReedMacroindicatorDto>> GetAllList()
        {
            try
            {
                var entitiesList = await _macroindicatorRepository.GetAllList();

                var entityListDto = entitiesList.Select(c =>
                new ReedMacroindicatorDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Weight = c.Weight,
                    HigherIsBetter = false,
                }).ToList();

                return entityListDto;
            }
            catch (Exception)
            {
                return [];
            }
        }

        public async Task<List<ReedMacroindicatorDto>> GetAllWithInclude()
        {
            try
            {
                var entitiesQuery = _macroindicatorRepository.GetAllQuery();

                var entitiesList = await entitiesQuery.Include(c => c.Indicators).ToListAsync();

                var entityListDto = entitiesList.Select(c =>
                new ReedMacroindicatorDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Weight = c.Weight,
                    HigherIsBetter = false,
                }).ToList();
                return entityListDto;
            }
            catch (Exception)
            {
                return [];
            }
        }



    }
}

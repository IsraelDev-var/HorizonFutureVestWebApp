
using Persistence.Repositpries.Interface;
using Application.Validations.Inteface;
using System.ComponentModel.DataAnnotations;
namespace Application.Validations
{
    public class TotalWeightValidation(IMacroindicatorRepository macroindicatorRepository) : ValidationAttribute, IWeightValidation
    {
        private readonly IMacroindicatorRepository _macroindicatorRepository = macroindicatorRepository;
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value is decimal newWeight)
            {
               
                    var excedido = IsSumExceededAsync(newWeight).GetAwaiter().GetResult();
                    if (excedido)
                        return new ValidationResult(ErrorMessage ?? "La suma de los pesos no puede superar 1");
                
            }


            return base.IsValid(value, validationContext);
        }


        // obtener toda la sumatoria de los pesos
        public async Task<decimal> GetSum()
        {
            // hacer la ppContextDB sumatoria
            var sum = (await _macroindicatorRepository.GetAllList()).Sum(x => x.Weight);


            return sum;
        }

        // validar que la sumatoria no supere 1
        public async Task<bool> IsSumExceededAsync(decimal newWeight)
        {
            var sum = (await _macroindicatorRepository.GetAllList()).Sum(x => x.Weight);
            sum -= newWeight;

            return (sum + newWeight) > 1;

        }

    }
}

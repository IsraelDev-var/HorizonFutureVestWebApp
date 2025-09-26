
namespace Application.Validations.Inteface
{
    public interface IWeightValidation
    {
        Task<bool> IsSumExceededAsync(decimal newWeight);
    }
}

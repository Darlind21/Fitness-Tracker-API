using Fitness_Tracker_API.DataLayer.Models;

namespace Fitness_Tracker_API.BusinessLayer.Infrastructure
{
    public interface IFoodService
    {
        public Food CreateFood
            (string name,
            string? brand = null,
            string? notes = null,
            int? servingPortionInGrams = null,
            float? calories = null,
            float? proteinInGrams = null,
            float? carbsGrams = null,
            float? sugarGrams = null,
            float? fatGrams = null,
            float? fiberGrams = null);
        public void EditFood
            (int id,
            string? name = null,
            string? brand = null,
            string? notes = null,
            int? servingPortionInGrams = null,
            float? calories = null,
            float? proteinInGrams = null,
            float? carbsGrams = null,
            float? sugarGrams = null,
            float? fatGrams = null,
            float? fiberGrams = null);
        public Food GetFoodByName(string name);
        public List<Food> GetFoodByBrand(string brand);
        public void DeleteFood();
    }
}

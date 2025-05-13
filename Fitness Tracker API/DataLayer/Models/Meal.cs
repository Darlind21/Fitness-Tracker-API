using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fitness_Tracker_API.DataLayer.Models
{
    public class Meal
    {
        [Key]
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
        public string? Name { get; set; }
        public string? Notes { get; set; }
        public MealType MealType { get; set; }


        public List<ConsumedFood> ConsumedFood { get; set; } = new List<ConsumedFood>();
        public required DailyNutritionLog DailyNutritionLog { get; set; }

        [ForeignKey(nameof(DailyNutritionLog))]
        public int DailyNutritionLogId { get; set; }

    }

    public enum MealType
    {
        Breakfast,
        Brunch,
        Lunch,
        Dinner,
        Dessert,
        Snack
    }
}

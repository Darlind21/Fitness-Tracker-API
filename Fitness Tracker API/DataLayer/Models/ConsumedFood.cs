using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fitness_Tracker_API.DataLayer.Models
{
    public class ConsumedFood
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey(nameof(Meal))]
        public int MealId { get; set; }
        public required Meal Meal { get; set; }

        [ForeignKey(nameof(Food))]
        public int FoodId { get; set; }
        public required Food Food { get; set; }


        //serving portion is how much the user ate 
        public byte ServingPortionInGrams { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fitness_Tracker_API.DataLayer.Models
{
    public class DailyNutritionLog
    {
        [Key]
        public int Id { get; set; }
        public DateOnly Date { get; set; }

        public List<Meal> Meals { get; set; } = new List<Meal>();
        public required User User { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
    }
}

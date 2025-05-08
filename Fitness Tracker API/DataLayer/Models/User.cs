using System.ComponentModel.DataAnnotations;

namespace Fitness_Tracker_API.DataLayer.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(30)]
        [MinLength(3)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(30)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(10)]
        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }


        //Navigation properties
        public ICollection<Workout>? Workouts { get; set; }
        public ICollection<DailyNutritionLog>? DailyNutritionLogs { get; set; } 
        public ICollection<FitnessGoal>? FitnessGoals { get; set; }
        public ICollection<BodyMeasurement>? BodyMeasurements { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fitness_Tracker_API.DataLayer.Models
{
    public class Excercise
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }
        public string? Description { get; set; }

        //nullable since User might not know what muscles are targeted
        public List<TargetedMuscleGroup>? TargetedMuscleGroups { get; set; }
        public ExcerciseType? TypeOfExcercise { get; set; }
        public EquipmentType? TypeOfEquipment { get; set; }



        public List<WorkoutExcercise> WorkoutExcercises { get; set; } = new List<WorkoutExcercise>();

    }


        public enum ExcerciseType
        {
            Cardio,
            Strength,
            Functional
        }
        public enum EquipmentType
        {
            Cables,
            Machine,
            FreeWeights
        }
}

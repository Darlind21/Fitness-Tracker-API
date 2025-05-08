using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fitness_Tracker_API.DataLayer.Models
{
    public class Excercise
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }

        //nullable since the excercise could be cardio which does not involve sets
        public List<WorkoutSet>? WorkoutSets { get; set; }
        
        //nullable since User might not know what muscles are targeted
        public List<TargetedMuscleGroup>? TargetedMuscleGroups { get; set; }
        public ExcerciseType? TypeOfExcercise { get; set; }
        public EquipmentType? TypeOfEquipment { get; set; }


        [ForeignKey(nameof(Workout))]
        public int WorkoutId { get; set; }
        public Workout Workout { get; set; }


        //Static factory method
        private Excercise() { }
        public static Excercise CreateExcercise 
            (Workout workout,
            string name,
            string? description,
            ExcerciseType? typeOfExcercise = null,
            EquipmentType? typeOfEquipment = null)
        {
            var excercise = new Excercise();
            excercise.Workout = workout;
            excercise.WorkoutId = workout.Id;

            excercise.Name = name;

            if (description != null)
            {
                excercise.Description = description;
            }

            if (typeOfExcercise != null)
            {
                excercise.TypeOfExcercise = typeOfExcercise;
            }

            if (typeOfEquipment != null)
            {
                excercise.TypeOfEquipment = typeOfEquipment;
            }
            return excercise;
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
        public enum TargetedMuscleGroup
        {
            Chest,
            Back,
            Deltoids,
            Biceps,
            Triceps,
            Forearms,
            Quadricep,
            Hamstrings,
            Calves
        }
    }
}

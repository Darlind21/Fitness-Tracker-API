using System.ComponentModel.DataAnnotations;

namespace Fitness_Tracker_API.DataLayer.Models
{
    public class TargetedMuscleGroup
    {
        [Key]
        public int Id { get; set; }
        public required MuscleName Name { get; set; }
        public List<Excercise> Excercises { get; set; } = new List<Excercise>();
    }
        public enum MuscleName
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

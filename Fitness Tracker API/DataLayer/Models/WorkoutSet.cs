using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fitness_Tracker_API.DataLayer.Models
{
    public class WorkoutSet
    {
        [Key]
        public int Id { get; set; }
        public bool? IsWarmUpSet { get; set; }
        public byte? Reps { get; set; } //Repetitions => how many times the movement needed to execute the excercise is performed
        public byte? WeightInKg { get; set; }
        public byte? DurationInMinutes { get; set; } // Duration property used for cardio or functional type excercises
        public byte? IntensityOutOfTen { get; set; }
        public byte? RepsInReserve { get; set; }
        //RIR (Reps in Reserve is a common type of measurement in strength training
        //The number means how many more reps you can do until failure for an excercise

        public Excercise Excercise { get; set; }

        [ForeignKey(nameof(Excercise))]
        public int ExcerciseId { get; set; }
    }
}

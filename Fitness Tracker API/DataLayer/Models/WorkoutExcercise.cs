using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fitness_Tracker_API.DataLayer.Models
{
    public class WorkoutExcercise
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Workout))]
        public int WorkoutId { get; set; }
        public required Workout Workout { get; set; }


        [ForeignKey(nameof(Excercise))]
        public int ExcerciseId { get; set; }
        public required Excercise Excercise { get; set; }



        //nullable since the excercise could be cardio which does not involve sets
        public List<WorkoutSet>? WorkoutSets { get; set; }
    }
}

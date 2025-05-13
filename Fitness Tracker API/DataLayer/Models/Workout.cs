using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fitness_Tracker_API.DataLayer.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly? StartTime { get; set; }
        public TimeOnly? EndTime { get; set; }
        public string? Notes { get; set; }

        public WorkoutStatus? Status { get; set; }


        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public required User User { get; set; }
        public List<WorkoutExcercise> WorkoutExcercises { get; set; } = new List<WorkoutExcercise>();
    }


    public enum WorkoutStatus
    {
        InProgress,
        Planned,
        Finished,
        NotSpecified
    }        
}

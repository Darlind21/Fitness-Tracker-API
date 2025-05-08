using System.ComponentModel.DataAnnotations.Schema;

namespace Fitness_Tracker_API.DataLayer.Models
{
    public class Workout
    {
        public int Id { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public string? Notes { get; set; }

        public WorkoutStatus? Status { get; set; }


        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Excercise> Excercises { get; set; } = new List<Excercise>();



        //I have used a static factory method inside the model class to ensure/enforce model state is valid regardless of where it is created
        private Workout() { }
        public static Workout CreateWorkout
            (User user,
            DateTime? startTime = null,
            DateTime? endTime = null,
            string? notes = null,
            WorkoutStatus? workoutStatus = null
            )
        {
            var workout = new Workout();
            workout.User = user;
            workout.UserId = user.Id;

            if (startTime != null)
            {
                workout.StartTime = startTime;
            }
            if (endTime != null && startTime != null)
            {
                //EndTime for a workout cannot be earlier than the start time 
                //If thats the case we throw exception
                if (endTime < startTime)
                {
                    throw new ArgumentOutOfRangeException(nameof(endTime), "End Time cannot be earlier than the start time for a workout");
                }
                /*The workout EndTime must be on the same date or at most one date apart than the start time  (in case e.g. the workout started near midnight etc.)
                otherwise it does not make sense*/
                //If thats the case then the EndTime is set to null
                bool isAtMostOneDateApart = (endTime.Value.Date - startTime.Value.Date).Days <= 1 ? true : false;
                if (!isAtMostOneDateApart)
                {
                    throw new ArgumentOutOfRangeException(nameof(endTime), "End Time cannot be more than one day apart than Start Time");
                }
                workout.EndTime = endTime;
            }

            if (startTime < DateTime.Now && endTime < DateTime.Now)
            {
                workout.Status = WorkoutStatus.Finished;
            }
            //The rest of the WorkoutStatus logic will be handled in a service
            else
            {
                workout.Status = WorkoutStatus.NotSpecified;
            }

            if (notes != null)
            {
                workout.Notes = notes;
            }

            return workout;
        }


        public enum WorkoutStatus
            {
                InProgress,
                Planned,
                Finished,
                NotSpecified
            }        
    }
}

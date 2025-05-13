using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fitness_Tracker_API.DataLayer.Models
{
    public class BodyMeasurement
    {
        [Key]
        public int Id { get; set; }
        public double? Weight { get; set; }
        public DateOnly Date { get; set; }
        public double? ChestCm { get; set; }
        public double? WaistCm { get; set; }
        public double? HipsCm { get; set; }
        public double? BicepsCm { get; set; }
        public double? ThighsCm { get; set; }


        public required User User { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
    }
}

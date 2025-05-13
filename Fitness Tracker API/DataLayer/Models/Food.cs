using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fitness_Tracker_API.DataLayer.Models
{
    public class Food
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Brand { get; set; }
        public string? Notes { get; set; }
        
        public int? ServingInGrams { get; set; }

        //Calories and all the other meaasurements are per 100 grams since that is the standard 
        public float? Calories { get; set; }
        public float? ProteinGrams { get; set; }
        public float? CarbsGrams { get; set; }
        public float? SugarGrams { get; set; }
        public float? FatGrams { get; set; }
        public float? FiberGrams { get; set; }


        public List<ConsumedFood> ConsumedFood { get; set; } = new List<ConsumedFood>();
    }
}

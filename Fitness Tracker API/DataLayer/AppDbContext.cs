using Microsoft.EntityFrameworkCore;
using Fitness_Tracker_API.DataLayer.Models;

namespace Fitness_Tracker_API.DataLayer
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<Excercise> Excercises { get; set; }
        public DbSet<WorkoutSet> WorkoutSets { get; set; }
        public DbSet<BodyMeasurement> BodyMeasurements { get; set; }
        public DbSet<DailyNutritionLog> DailyNutritionLogs { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<TargetedMuscleGroup> TargetedMuscleGroups { get; set; }
        public DbSet<WorkoutExcercise> WorkoutExcercises { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("AppDb");

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.DailyNutritionLogs)
                .WithOne(dnl => dnl.User)
                .HasForeignKey(dnl => dnl.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.BodyMeasurements)
                .WithOne(bm => bm.User)
                .HasForeignKey(bm => bm.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Workouts)
                .WithOne(w => w.User)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade);







            modelBuilder.Entity<Workout>()
                .Property(w => w.Status)
                .HasConversion<string>();

            modelBuilder.Entity<Workout>()
                .HasMany(w => w.WorkoutExcercises)
                .WithOne(we => we.Workout)
                .HasForeignKey(we => we.WorkoutId)
                .OnDelete(DeleteBehavior.Cascade);







            modelBuilder.Entity<Excercise>()
                .HasMany(e => e.TargetedMuscleGroups)
                .WithMany(tms => tms.Excercises);

            modelBuilder.Entity<Excercise>()
                .Property(e => e.TypeOfExcercise)
                .HasConversion<string>();

            modelBuilder.Entity<Excercise>()
                .Property(e => e.TypeOfEquipment)
                .HasConversion<string>();

            modelBuilder.Entity<Excercise>()
                .HasMany(e => e.WorkoutExcercises)
                .WithOne(we => we.Excercise)
                .HasForeignKey(we => we.ExcerciseId)
                .OnDelete(DeleteBehavior.Cascade);








            modelBuilder.Entity<WorkoutExcercise>()
                .HasMany(we => we.WorkoutSets)
                .WithOne(ws => ws.WorkoutExcercise)
                .HasForeignKey(ws => ws.WorkoutExcerciseId)
                .OnDelete(DeleteBehavior.Cascade);








            modelBuilder.Entity<TargetedMuscleGroup>()
                .Property(tms => tms.Name)
                .HasConversion<string>();

            modelBuilder.Entity<TargetedMuscleGroup>()
                .HasMany(tms => tms.Excercises)
                .WithMany(e => e.TargetedMuscleGroups);






            modelBuilder.Entity<DailyNutritionLog>()
                .HasMany(dnl => dnl.Meals)
                .WithOne(m => m.DailyNutritionLog)
                .HasForeignKey(m => m.DailyNutritionLogId)
                .OnDelete(DeleteBehavior.Cascade);







            modelBuilder.Entity<Meal>()
                .HasMany(m => m.ConsumedFood)
                .WithOne(cf => cf.Meal)
                .HasForeignKey(cf => cf.MealId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Meal>()
                .Property(m => m.MealType)
                .HasConversion<string>();







            modelBuilder.Entity<Food>()
                .HasMany(f => f.ConsumedFood)
                .WithOne(cf => cf.Food)
                .HasForeignKey(cf => cf.FoodId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET.Domain
{
    public class WorkoutDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Points { get; set; }
        public string? Level { get; set; }
        public ICollection<ExerciseDTO>? Exercises { get; set; }
    }

    public class CreateWorkoutDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Points { get; set; }
        public string? Level { get; set; }
        public ICollection<int>? Exercise { get; set; }
    }

    public class UpdateWorkoutDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? Points { get; set; }
        public string? Level { get; set; }
        public ICollection<int>? Exercise { get; set; }
    }
}
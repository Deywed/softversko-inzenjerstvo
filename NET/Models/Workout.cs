using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET.Models
{

    public enum Level
    {
        Beginner,
        Intermediate,
        Advanced
    }
    public class Workout
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Points { get; set; }
        public Level Level { get; set; }
        public ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
    }
}
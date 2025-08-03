using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET.Models
{
    public class Exercise
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? URL { get; set; }
        public string? Description { get; set; }
        public ICollection<Workout> Workouts { get; set; } = new List<Workout>();
    }
}
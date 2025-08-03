using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.entities;

namespace NET.Models
{
    public class PR
    {
        public int Id { get; set; }
        public int ExerciseId { get; set; }
        public Exercise? Exercise { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
        public double Weight { get; set; }
        public DateTime Date { get; set; }
    }
}
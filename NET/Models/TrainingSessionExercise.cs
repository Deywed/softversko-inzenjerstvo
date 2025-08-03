using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET.Models
{
    public class TrainingSessionExercise
    {
        public int Id { get; set; }
        public int TrainingSessionId { get; set; }
        public int ExerciseId { get; set; }
        public  Exercise? Exercise { get; set; }
        public  TrainingSession? TrainingSession { get; set; }
    }
}
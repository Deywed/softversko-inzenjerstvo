using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET.Domain
{
    public class TrainingSessionExerciseDTO
    {
        public int Id { get; set; }
        public int TrainingSessionId { get; set; }
        public int ExerciseId { get; set; }
    }
    public class CreateTrainingSessionExerciseDTO
    {
        public int TrainingSessionId { get; set; }
        public int ExerciseId { get; set; }
    }
}
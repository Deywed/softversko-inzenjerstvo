using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Domain;
using NET.Models;

namespace NET.Mappers
{
    static class TrainingSessionExerciseMapper
    {
        public static TrainingSessionExerciseDTO ToDto(this TrainingSessionExercise trainingSessionExercise)
        {
            return new TrainingSessionExerciseDTO
            {
                Id = trainingSessionExercise.Id,
                TrainingSessionId = trainingSessionExercise.TrainingSessionId,
                ExerciseId = trainingSessionExercise.ExerciseId,

            };
        }
        public static TrainingSessionExercise ToEntity(this TrainingSessionExerciseDTO trainingSessionExerciseDto)
        {
            return new TrainingSessionExercise
            {
                Id = trainingSessionExerciseDto.Id,
                TrainingSessionId = trainingSessionExerciseDto.TrainingSessionId,
                ExerciseId = trainingSessionExerciseDto.ExerciseId,
            };
        }
    }
}
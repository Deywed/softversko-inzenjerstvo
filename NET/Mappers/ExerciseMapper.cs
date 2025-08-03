using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Domain;
using NET.Models;

namespace NET.Mappers
{
    static class ExerciseMapper
    {
        public static ExerciseDTO ToDto(this Exercise exercise)
        {
            return new ExerciseDTO
            {
                Id = exercise.Id,
                Name = exercise.Name,
                Description = exercise.Description,
                URL = exercise.URL
            };
        }

        public static Exercise ToEntity(this CreateExerciseDTO createExerciseDto)
        {
            return new Exercise
            {
                Name = createExerciseDto.Name,
                Description = createExerciseDto.Description,
                URL = createExerciseDto.URL
            };
        }

        public static Exercise UpdateEntity(this Exercise exercise, UpdateExerciseDTO updateExerciseDto)
        {
            exercise.Name = updateExerciseDto.Name ?? exercise.Name;
            exercise.Description = updateExerciseDto.Description ?? exercise.Description;
            exercise.URL = updateExerciseDto.URL ?? exercise.URL;
            return exercise;
        }
    }
}
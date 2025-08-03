using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Models;

namespace NET.Domain
{
    public class ExerciseDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? URL { get; set; }

    }
    public class CreateExerciseDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? URL { get; set; }
    }

    public class UpdateExerciseDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? URL { get; set; }
    }
}
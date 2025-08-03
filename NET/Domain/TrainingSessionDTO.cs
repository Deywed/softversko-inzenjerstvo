using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET.Domain
{
    public class TrainingSessionDTO
    {
        public int Id { get; set; }
        public int ClientAId { get; set; }
        public int? ClientBId { get; set; }
        public int GymId { get; set; }
        public DateTime Date { get; set; }
        public string? SessionStatus { get; set; }
        public string? RequestStatus { get; set; }
        public int? WorkoutId { get; set; }

    }

    public class CreateTrainingSessionDTO
    {
        public int ClientAId { get; set; }
        public int? ClientBId { get; set; }
        public int GymId { get; set; }
        public DateTime Date { get; set; }
        public string? SessionStatus { get; set; }
        public string? RequestStatus { get; set; }
        public int WorkoutId { get; set; }
    }

    public class UpdateTrainingSessionDTO
    {
        public int? ClientBId { get; set; }
        public DateTime? Date { get; set; }
        public string? SessionStatus { get; set; }
        public string? RequestStatus { get; set; }
        public int? WorkoutId { get; set; }
    }
}
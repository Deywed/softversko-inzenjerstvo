using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET.Domain
{
    public class PRDTO
    {
        public int Id { get; set; }
        public int ExerciseId { get; set; }
        public int UserId { get; set; }
        public double Weight { get; set; }
        public DateTime Date { get; set; }
    }

    public class CreatePRDTO
    {
        public int ExerciseId { get; set; }
        public int UserId { get; set; }
        public double Weight { get; set; }
        public DateTime Date { get; set; }
    }

    public class UpdatePRDTO
    {
        public double? Weight { get; set; }
        public DateTime? Date { get; set; }
    }
}
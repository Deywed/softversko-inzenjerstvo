using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.entities;

namespace NET.Models
{
    public class Statistics
    {
        public int Id { get; set; }
        public int CollectedPoints { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public ICollection<TrainingSession> TrainingSessions { get; set; } = new List<TrainingSession>();
        public ICollection<PR> PersonalRecords { get; set; } = new List<PR>();

    }
}
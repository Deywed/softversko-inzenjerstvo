using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.entities;

namespace NET.Models
{
    public enum SessionStatus
    {
        Upcoming,
        InProgress,
        Completed,
        Cancelled
    }

    public enum RequestStatus
    {
        Pending,
        Accepted,
        Rejected
    }
    public class TrainingSession
    {
        public int Id { get; set; }
        public  User? ClientA { get; set; }
        public  User? ClientB { get; set; }
        public int ClientAId { get; set; }
        public int? ClientBId { get; set; }
        public  Gym? Gym { get; set; }
        public int GymId { get; set; }
        public DateTime Date { get; set; }

        public SessionStatus SessionStatus { get; set; }
        public RequestStatus RequestStatus { get; set; }

        public Workout? Workout { get; set; }
        public int WorkoutId { get; set; }

    }
}
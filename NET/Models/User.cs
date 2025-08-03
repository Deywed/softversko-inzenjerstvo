using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.Models;

namespace NET.entities

{
    public enum Role
    {
        Admin,
        Client,
        Trainer
    }
    public class User
    {
        public int Id { get; set; }
        public string? FirebaseUID { get; set; }
        public string? Username { get; set; }
        public Role Role { get; set; }
        public int GymID { get; set; }
        public Gym? Gym { get; set; }
        public required Statistics Statistics { get; set; }
        
        public List<Workout> PersonalWorkouts { get; set; } = new List<Workout>();
        public List<JoinRequest> SentJoinRequests { get; set; } = new List<JoinRequest>();
        public List<JoinRequest> ReceivedJoinRequests { get; set; } = new List<JoinRequest>();
        public List<TrainingSession> CreatedSessions { get; set; } = new List<TrainingSession>();
        public List<TrainingSession> JoinedSessions { get; set; } = new List<TrainingSession>();

    }
}
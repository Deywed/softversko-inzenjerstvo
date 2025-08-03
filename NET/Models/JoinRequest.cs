using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.entities;

namespace NET.Models
{
    public enum JoinRequestStatus
    {
        Pending,
        Approved,
        Rejected
    }
    public class JoinRequest
    {
        public int Id { get; set; }
        public int UserAId { get; set; }
        public int UserBId { get; set; }
        public User? UserA { get; set; }
        public User? UserB { get; set; }
        public int TrainingSessionId { get; set; }
        public JoinRequestStatus Status { get; set; } = JoinRequestStatus.Pending;
        public TrainingSession? TrainingSession { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NET.entities;
using NET.Models;

namespace NET
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        public DbSet<JoinRequest> JoinRequests { get; set; }
        public DbSet<TrainingSession> TrainingSessions { get; set; }
        public DbSet<TrainingSessionExercise> TrainingSessionExercises { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Statistics> Statistics { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Gym> Gyms { get; set; }
        public DbSet<PR> PRs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1) UserA (pošiljalac) ↔ User.SentJoinRequests
            modelBuilder.Entity<JoinRequest>()
                .HasOne(j => j.UserA)
                .WithMany(u => u.SentJoinRequests)
                .HasForeignKey(j => j.UserAId)
                .OnDelete(DeleteBehavior.Restrict);

            // 2) UserB (primalac) ↔ User.ReceivedJoinRequests
            modelBuilder.Entity<JoinRequest>()
                .HasOne(j => j.UserB)
                .WithMany(u => u.ReceivedJoinRequests)
                .HasForeignKey(j => j.UserBId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<TrainingSession>()
                .HasOne(a => a.ClientA)
                .WithMany(u => u.CreatedSessions)
                .HasForeignKey(a => a.ClientAId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TrainingSession>()
                .HasOne(a => a.ClientB)
                .WithMany(u => u.JoinedSessions)
                .HasForeignKey(a => a.ClientBId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
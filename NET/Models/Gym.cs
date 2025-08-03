using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.entities;

namespace NET.Models
{
    public class Gym
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public City? City { get; set; }
        public int? CityId { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
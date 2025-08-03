using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NET.entities;

namespace NET.Models
{
    public class City
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public ICollection<Gym> Gyms { get; set; } = new List<Gym>();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET.Domain
{
    public class GymDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Location { get; set; }
        public int CityId { get; set; }
        public List<UserDTO>? Users { get; set; } // Assuming Users is a collection of UserDTOs
    }

    public class CreateGymDTO
    {
        public string? Name { get; set; }
        public string? Location { get; set; }
        public int CityId { get; set; }
    }
    public class UpdateGymDTO
    {
        public string? Name { get; set; }
        public string? Location { get; set; }
        public int? CityId { get; set; }
    }
}
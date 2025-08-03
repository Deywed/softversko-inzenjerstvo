using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET.Domain
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string? FirebaseUID { get; set; }
        public string? Username { get; set; }
        public string? Role { get; set; }
        public StatisticsDTO? Statistics { get; set; }

    }

    public class CreateUserDTO
    {
        public int GymID { get; set; }
        public string? FirebaseUID { get; set; }
        public string? Username { get; set; }
        public string? Role { get; set; }
    }

    public class UpdateUserDTO
    {
        public string? Username { get; set; }
        public int GymID { get; set; }
    }
}
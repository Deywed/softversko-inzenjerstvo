using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET.Domain
{
    public class CityDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
    }

    public class CreateCityDTO
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
    }

    public class UpdateCityDTO
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
    }
}
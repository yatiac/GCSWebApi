using System.Collections.Generic;

namespace GCSApi.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public string Maker { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string VIN { get; set; }
        public int Year { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
    }
    public class Owner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}

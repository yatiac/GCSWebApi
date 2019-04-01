using System;

namespace GCSApi.Models
{
    public class Work
    {
        public string Id { get; set; }
        public WorkOrder WorkOrder { get; set; }
        public Decimal Price { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }
    }
}

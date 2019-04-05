using System;

namespace GCSApi.Models
{
    public class Work
    {
        public string Id { get; set; }
        public int WorkOrderId { get; set; }
        public WorkOrder WorkOrder { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public string Comments { get; set; }
    }
}

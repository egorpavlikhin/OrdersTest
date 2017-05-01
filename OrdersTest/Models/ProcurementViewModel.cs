using System;
using System.ComponentModel.DataAnnotations;

namespace OrdersTest.Models
{
    public class ProcurementViewModel
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime Created  { get; set; }

        [Required]
        public decimal Total { get; set; }
    }
}
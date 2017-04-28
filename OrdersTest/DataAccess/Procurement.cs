using System;
using System.ComponentModel.DataAnnotations;

namespace OrdersTest.DataAccess
{
    public class Procurement
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime Created { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Total { get; set; }
    }
}
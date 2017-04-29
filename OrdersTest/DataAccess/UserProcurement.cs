using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdersTest.DataAccess
{
    public class UserProcurement
    {
        public UserProcurement()
        {
        }

        [Key, Column(Order = 0)]
        public string UserId { get; set; }

        [Key, Column(Order = 1), ForeignKey("Procurement")]
        public long ProcurementId { get; set; }

        public Procurement Procurement { get; set; }
    }
}
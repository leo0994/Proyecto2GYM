using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class CouponsDTO

    {
        public int Id { get; set; }
        public string CouponsName { get; set; }
        public int NumbersCoupons { get; set; }
        public DateTime ExpirationDate { get; set; }
        public decimal Percentaje { get; set; }

    }
}

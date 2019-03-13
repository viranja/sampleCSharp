using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class InvoiceHeader
    {
        public int InvoiceNo { get; set; }
        public int InvoiceDate { get; set; }
        public int CustomerNo { get; set; }
        public decimal TotalAmount { get; set; }
    }
}

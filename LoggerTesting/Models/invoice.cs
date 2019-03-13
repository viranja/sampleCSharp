using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonitorClient
{
    public class invoice:ISave,IInvoiceModle,IUpdate
    {
        public int InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }



        

        public void Save()
        {
            var i = InvoiceNo;
            var date = InvoiceDate;
        }

        public void Update()
        {
            var i = InvoiceNo;
            var date = InvoiceDate;
        }
    }

    public interface IInvoiceModle
    {
         int InvoiceNo { get; set; }
         DateTime InvoiceDate { get; set; }
    }
}

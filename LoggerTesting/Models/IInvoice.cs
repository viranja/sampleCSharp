using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MonitorClient
{
    public interface IInvoice
    {
        void Save(IInvoiceModle m);
        void Update(IInvoiceModle m);
    }

    public interface ISave
    {
        void Save();
    }

    public interface IUpdate
    {
        void Update();
    }
}


 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BackgrundProcess
{
    public delegate void GetCount(int i);

    public class ProcessOne
    {
        public event GetCount count;

        public void Calculation()
        {
            for (int i = 0; i < 1000; i++)
            {
                count(i);
                Thread.Sleep(300);
            }
        }
    }
}

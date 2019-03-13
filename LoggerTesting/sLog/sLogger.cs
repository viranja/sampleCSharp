using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sLog
{
    public static class sLogger
    {
        public static void Write(string log)
        {
            using (System.IO.StreamWriter sw = new System.IO.StreamWriter("./log.txt",true))
            {
                sw.WriteLine(log);
                sw.Write(" " + DateTime.Now.ToString("dd-MMM-yyyy"));
                
            }
        }

     
    }
}

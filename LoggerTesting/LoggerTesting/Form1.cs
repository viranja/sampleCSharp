using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoggerTesting
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sLog.sLogger.Write("start program");
            sLog.sLogger.Write("assing varibales");
            sLog.sLogger.Write("Excute");

            sLog.sLogger.Write("End");

            // customer object
            IDataService objdata = null;
            objdata.BeginTran();
            Customer objcust = new Customer(objdata);
            objcust.Save();
            objdata.Commit();
        }
    }
}

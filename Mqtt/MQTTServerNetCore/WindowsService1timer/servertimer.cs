using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsService1timer
{
    public partial class servertimer : ServiceBase
    {
        private Thread thdStart;

        private int numTimes;
        public servertimer()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            thdStart = new Thread(new ThreadStart(timer1.Start));
            thdStart.Start();
        }
        private void timer1_Elapsed(object sender, System.Timers.ElapsedEventArgs e)

        {

            this.timer1.Stop();

            numTimes++;

            string filePath = @"c:\ServiceTest.log";

            string strCont = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss") + "第" + numTimes + "次执行。";

            System.IO.File.AppendAllText(filePath, strCont);

            this.timer1.Start();

        }
        protected override void OnStop()
        {
        }
    }
}

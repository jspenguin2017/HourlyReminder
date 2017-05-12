using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hourly_Reminder
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Get Guid
            Assembly assembly = typeof(Program).Assembly;
            GuidAttribute attribute = (GuidAttribute)assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0];
            string appGuid = attribute.Value;
            //Check if multiple instances are running
            using (Mutex mutex = new Mutex(false, "Global\\" + appGuid))
            {
                if (mutex.WaitOne(0, false) || MessageBox.Show("There is already an instance running, do you want to start another one?", "Hourly Reminder", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //A new instance will start if this is the only instance or if the user wants multiple instances
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FormMain());
                }
            }
        }
    }
}

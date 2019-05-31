using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transformers.Bank.Data.Context;

namespace Transformers.Bank.App
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            IDataWorker worker = new DataWorker();
            Upgrader.AutoUpgrade();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(worker.Accounts.GetAll()));
        }
    }
}

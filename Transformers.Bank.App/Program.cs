using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Transformers.Bank.App
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static async Task Main()
        {
            ApiClient apiClient = new ApiClient();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(await apiClient.GetAccountsAsync()));
        }
    }
}

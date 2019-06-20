using System.Windows.Forms;

namespace Transformers.Bank.App
{
    public partial class MainForm : Form
    {
        public MainForm(object data)
        {
            InitializeComponent();
            gwData.AutoGenerateColumns = true;
            gwData.DataSource = data;
        }
    }
}

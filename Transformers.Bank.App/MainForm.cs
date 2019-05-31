using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

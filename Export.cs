using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Жеребьёвка
{
    public partial class Export : Form
    {
        public bool success = false;
        public List<string> Categories = new List<string>();
        public Export() => InitializeComponent();

        private void Continue_Click(object sender, EventArgs e)
        {
            success = true;
            Close();
        }

        private void Deny_Click(object sender, EventArgs e) => Close();

        private void Export_Load(object sender, EventArgs e) => listBox1.Items.AddRange(Categories.ToArray());
    }
}

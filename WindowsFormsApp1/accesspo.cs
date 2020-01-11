using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nader11ndeu
{
    public partial class accesspo : UserControl
    {
        public accesspo()
        {
            InitializeComponent();
        }

        private void get_tokens_button_Click(object sender, EventArgs e)
        {

            WindowsFormsApp1.main_form.get_tokens = true;
        }


    }
}

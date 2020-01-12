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
    public partial class authnew : UserControl
    {

       
        public authnew()
        {
            InitializeComponent();
        }

        private void authorization_button_Click(object sender, EventArgs e)
        {
            
            string scopes = string.Empty;
           
            if (comboBox1.selectedIndex == 0)
            WindowsFormsApp1.main_form.redirect_uri = "https://www.google.com";
            else if (comboBox1.selectedIndex == 1)
            WindowsFormsApp1.main_form.redirect_uri = "https://memoryhackers.org";

            WindowsFormsApp1.main_form.auth_token.client_id = client_id_textbox.Text;
            WindowsFormsApp1.main_form.auth_token.client_secret = client_sr_textbox.Text;
            
            foreach (int i in listBox1.SelectedIndices)
            {
                scopes += listBox1.Items[i] + "%20";
            }


            get_url_textbox.Text = "https://accounts.spotify.com/authorize/" + "?client_id=" + WindowsFormsApp1.main_form.auth_token.client_id + "&response_type=code&redirect_uri=" + WindowsFormsApp1.main_form.redirect_uri + "&state=ba09b65f&scope=" + scopes + "&show_dialog=False";


            WindowsFormsApp1.main_form.webbrowser_bool = true;
         
        }
    }
}

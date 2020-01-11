namespace nader11ndeu
{
    partial class authnew
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(authnew));
            this.auth_groupbox = new Bunifu.Framework.UI.BunifuCards();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new Bunifu.Framework.UI.BunifuDropdown();
            this.label5 = new System.Windows.Forms.Label();
            this.response_uri_textbox = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label4 = new System.Windows.Forms.Label();
            this.client_id_textbox = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.authorization_button = new Bunifu.Framework.UI.BunifuThinButton2();
            this.client_sr_textbox = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.get_url_textbox = new Bunifu.Framework.UI.BunifuMetroTextbox();
            this.label3 = new System.Windows.Forms.Label();
            this.auth_groupbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // auth_groupbox
            // 
            this.auth_groupbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.auth_groupbox.BorderRadius = 5;
            this.auth_groupbox.BottomSahddow = true;
            this.auth_groupbox.color = System.Drawing.Color.Lime;
            this.auth_groupbox.Controls.Add(this.label6);
            this.auth_groupbox.Controls.Add(this.comboBox1);
            this.auth_groupbox.Controls.Add(this.label5);
            this.auth_groupbox.Controls.Add(this.response_uri_textbox);
            this.auth_groupbox.Controls.Add(this.label4);
            this.auth_groupbox.Controls.Add(this.client_id_textbox);
            this.auth_groupbox.Controls.Add(this.authorization_button);
            this.auth_groupbox.Controls.Add(this.client_sr_textbox);
            this.auth_groupbox.Controls.Add(this.label1);
            this.auth_groupbox.Controls.Add(this.label2);
            this.auth_groupbox.Controls.Add(this.listBox1);
            this.auth_groupbox.Controls.Add(this.get_url_textbox);
            this.auth_groupbox.Controls.Add(this.label3);
            this.auth_groupbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.auth_groupbox.LeftSahddow = false;
            this.auth_groupbox.Location = new System.Drawing.Point(0, 0);
            this.auth_groupbox.Name = "auth_groupbox";
            this.auth_groupbox.RightSahddow = true;
            this.auth_groupbox.ShadowDepth = 20;
            this.auth_groupbox.Size = new System.Drawing.Size(649, 385);
            this.auth_groupbox.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label6.ForeColor = System.Drawing.Color.Silver;
            this.label6.Location = new System.Drawing.Point(5, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 17);
            this.label6.TabIndex = 44;
            this.label6.Text = "Redirect URIs:";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.Transparent;
            this.comboBox1.BorderRadius = 3;
            this.comboBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.comboBox1.DisabledColor = System.Drawing.Color.Gray;
            this.comboBox1.ForeColor = System.Drawing.Color.Silver;
            this.comboBox1.Items = new string[] {
        "https://www.google.com",
        "https://www.memoryhackers.org"};
            this.comboBox1.Location = new System.Drawing.Point(117, 80);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.NomalColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(54)))), ((int)(((byte)(54)))));
            this.comboBox1.onHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.comboBox1.selectedIndex = 0;
            this.comboBox1.Size = new System.Drawing.Size(241, 25);
            this.comboBox1.TabIndex = 43;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label5.ForeColor = System.Drawing.Color.Silver;
            this.label5.Location = new System.Drawing.Point(10, 281);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 17);
            this.label5.TabIndex = 36;
            this.label5.Text = "Response_Uri:";
            // 
            // response_uri_textbox
            // 
            this.response_uri_textbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.response_uri_textbox.BorderColorFocused = System.Drawing.Color.Green;
            this.response_uri_textbox.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.response_uri_textbox.BorderColorMouseHover = System.Drawing.Color.Green;
            this.response_uri_textbox.BorderThickness = 3;
            this.response_uri_textbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.response_uri_textbox.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.response_uri_textbox.ForeColor = System.Drawing.Color.Lime;
            this.response_uri_textbox.isPassword = false;
            this.response_uri_textbox.Location = new System.Drawing.Point(111, 278);
            this.response_uri_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.response_uri_textbox.Name = "response_uri_textbox";
            this.response_uri_textbox.Size = new System.Drawing.Size(495, 26);
            this.response_uri_textbox.TabIndex = 35;
            this.response_uri_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label4.ForeColor = System.Drawing.Color.Silver;
            this.label4.Location = new System.Drawing.Point(10, 237);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 17);
            this.label4.TabIndex = 32;
            this.label4.Text = "Get_Url:";
            // 
            // client_id_textbox
            // 
            this.client_id_textbox.BorderColorFocused = System.Drawing.Color.Green;
            this.client_id_textbox.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.client_id_textbox.BorderColorMouseHover = System.Drawing.Color.Green;
            this.client_id_textbox.BorderThickness = 1;
            this.client_id_textbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.client_id_textbox.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.client_id_textbox.ForeColor = System.Drawing.Color.Silver;
            this.client_id_textbox.isPassword = false;
            this.client_id_textbox.Location = new System.Drawing.Point(117, 13);
            this.client_id_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.client_id_textbox.Name = "client_id_textbox";
            this.client_id_textbox.Size = new System.Drawing.Size(495, 25);
            this.client_id_textbox.TabIndex = 30;
            this.client_id_textbox.Text = "35be1f197514464883f07682d52ffbef";
            this.client_id_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // authorization_button
            // 
            this.authorization_button.ActiveBorderThickness = 1;
            this.authorization_button.ActiveCornerRadius = 20;
            this.authorization_button.ActiveFillColor = System.Drawing.Color.Green;
            this.authorization_button.ActiveForecolor = System.Drawing.Color.White;
            this.authorization_button.ActiveLineColor = System.Drawing.Color.Green;
            this.authorization_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.authorization_button.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("authorization_button.BackgroundImage")));
            this.authorization_button.ButtonText = "Get Auth Link";
            this.authorization_button.Cursor = System.Windows.Forms.Cursors.Hand;
            this.authorization_button.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authorization_button.ForeColor = System.Drawing.Color.SeaGreen;
            this.authorization_button.IdleBorderThickness = 1;
            this.authorization_button.IdleCornerRadius = 20;
            this.authorization_button.IdleFillColor = System.Drawing.Color.White;
            this.authorization_button.IdleForecolor = System.Drawing.Color.Green;
            this.authorization_button.IdleLineColor = System.Drawing.Color.Green;
            this.authorization_button.Location = new System.Drawing.Point(13, 313);
            this.authorization_button.Margin = new System.Windows.Forms.Padding(5);
            this.authorization_button.Name = "authorization_button";
            this.authorization_button.Size = new System.Drawing.Size(604, 58);
            this.authorization_button.TabIndex = 17;
            this.authorization_button.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.authorization_button.Click += new System.EventHandler(this.authorization_button_Click);
            // 
            // client_sr_textbox
            // 
            this.client_sr_textbox.BorderColorFocused = System.Drawing.Color.Green;
            this.client_sr_textbox.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.client_sr_textbox.BorderColorMouseHover = System.Drawing.Color.Green;
            this.client_sr_textbox.BorderThickness = 1;
            this.client_sr_textbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.client_sr_textbox.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.client_sr_textbox.ForeColor = System.Drawing.Color.Silver;
            this.client_sr_textbox.isPassword = false;
            this.client_sr_textbox.Location = new System.Drawing.Point(117, 46);
            this.client_sr_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.client_sr_textbox.Name = "client_sr_textbox";
            this.client_sr_textbox.Size = new System.Drawing.Size(495, 25);
            this.client_sr_textbox.TabIndex = 31;
            this.client_sr_textbox.Text = "90697ab769a04d18bdc72c1d87124d7a";
            this.client_sr_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(5, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Auth_Client_id:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label2.ForeColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(5, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Auth_Client_sr:";
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.listBox1.ForeColor = System.Drawing.Color.Silver;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 17;
            this.listBox1.Items.AddRange(new object[] {
            "ugc-image-upload",
            "user-read-playback-state",
            "user-modify-playback-state",
            "user-read-currently-playing",
            "app-remote-control",
            "user-read-email",
            "user-read-private",
            "playlist-read-collaborative",
            "playlist-modify-public",
            "playlist-read-private",
            "playlist-modify-private",
            "user-library-modify",
            "user-library-read",
            "user-top-read",
            "user-read-recently-played",
            "user-follow-read",
            "user-follow-modify"});
            this.listBox1.Location = new System.Drawing.Point(111, 121);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(495, 104);
            this.listBox1.TabIndex = 10;
            // 
            // get_url_textbox
            // 
            this.get_url_textbox.BorderColorFocused = System.Drawing.Color.Green;
            this.get_url_textbox.BorderColorIdle = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.get_url_textbox.BorderColorMouseHover = System.Drawing.Color.Green;
            this.get_url_textbox.BorderThickness = 3;
            this.get_url_textbox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.get_url_textbox.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.get_url_textbox.ForeColor = System.Drawing.Color.Red;
            this.get_url_textbox.isPassword = false;
            this.get_url_textbox.Location = new System.Drawing.Point(111, 235);
            this.get_url_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.get_url_textbox.Name = "get_url_textbox";
            this.get_url_textbox.Size = new System.Drawing.Size(495, 26);
            this.get_url_textbox.TabIndex = 20;
            this.get_url_textbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(21, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Scopes:";
            // 
            // authnew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.auth_groupbox);
            this.Name = "authnew";
            this.Size = new System.Drawing.Size(649, 385);
            this.auth_groupbox.ResumeLayout(false);
            this.auth_groupbox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        public Bunifu.Framework.UI.BunifuDropdown comboBox1;
        public Bunifu.Framework.UI.BunifuMetroTextbox response_uri_textbox;
        public Bunifu.Framework.UI.BunifuMetroTextbox client_id_textbox;
        public Bunifu.Framework.UI.BunifuThinButton2 authorization_button;
        public Bunifu.Framework.UI.BunifuMetroTextbox client_sr_textbox;
        public System.Windows.Forms.ListBox listBox1;
        public Bunifu.Framework.UI.BunifuMetroTextbox get_url_textbox;
        public Bunifu.Framework.UI.BunifuCards auth_groupbox;

    }
}

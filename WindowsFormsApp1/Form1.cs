using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net;
using System.Collections.Specialized;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.Script.Serialization;
using Newtonsoft.Json.Linq;
using SpotifyAPI.Web;
using SpotifyAPI.Web.Enums;
using SpotifyAPI.Web.Models;
using System.Windows.Documents;
using System.IO.Ports;
using System.Globalization;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string[] port_names = SerialPort.GetPortNames();
        public Form1()
        {
            InitializeComponent();
        }


        public class SpotifyToken
        {
            public string Access_token { get; set; }
            public string Token_type { get; set; }
            public int Expires_in { get; set; }
        }
        SpotifyToken token = new SpotifyToken();

        private static SpotifyWebAPI _spotify;
        public class AuthInformations
        {
            public string client_id;
            public string client_secret;
            public string AuthorizationKey;
        }
        AuthInformations auth_token = new AuthInformations();


        public string GetAlbumInfo(string album_id, string activated_token, ref string textbox, ref string album_image_uri, ref int picture_height, ref int picture_width) //  by me xD
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.spotify.com/v1/albums/" + album_id);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.Accept = "application/json";
            request.Headers.Add("Authorization: Bearer " + activated_token);
            String json = "";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var my_string = reader.ReadToEnd();
                textbox = my_string;
                JObject my_object = JObject.Parse(my_string);
                album_image_uri = (string)my_object["images"][1]["url"];
                picture_height = (int)my_object["images"][1]["height"];
                picture_width = (int)my_object["images"][1]["width"];
                //Console.WriteLine(reader.ReadToEnd());
                return reader.ReadToEnd();
            }

        }


        public string GetTrackInfo(string activated_token, ref string textbox) // by me xD
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.spotify.com/v1/albums/");
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            request.Accept = "application/json";
            request.Headers.Add("Authorization: Bearer " + activated_token);
            String json = "";
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var my_string = reader.ReadToEnd();
                textbox = my_string;

                JObject my_object = JObject.Parse(my_string);
                // Console.WriteLine(reader.ReadToEnd());
                return reader.ReadToEnd();
            }

        }





        //}
        public string GetAccessToken(string code,string clientid,string clientsecret)
        {
            
            string url5 = "https://accounts.spotify.com/api/token";
            var encode_clientid_clientsecret = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", clientid, clientsecret)));

            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url5);

            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Accept = "application/json";
            webRequest.Headers.Add("Authorization: Basic " + encode_clientid_clientsecret);
    
            var request = ("grant_type=authorization_code&code="+code+"&redirect_uri="+ redirect_uri);
            byte[] req_bytes = Encoding.ASCII.GetBytes(request);
            webRequest.ContentLength = req_bytes.Length;

            Stream strm = webRequest.GetRequestStream();
            strm.Write(req_bytes, 0, req_bytes.Length);
            strm.Close();
       
            HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
            String json = "";
            using (Stream respStr = resp.GetResponseStream())
            {
                using (StreamReader rdr = new StreamReader(respStr, Encoding.UTF8))
                {
                    var deneme = rdr.ReadToEnd();

                    JObject my_object = JObject.Parse(deneme);
                    string access_token = (string)my_object["access_token"];
                    string refresh_token = (string)my_object["refresh_token"];
                    string token_type = (string)my_object["token_type"];
                    string expires_in = (string)my_object["expires_in"];
                    access_textbox.Text = access_token;
                    refresh_textbox.Text = refresh_token;
                    tokentype_textbox.Text = token_type;
                    expires_textbox.Text = expires_in;
                    richTextBox1.Text = deneme;
                    json = rdr.ReadToEnd();
                    rdr.Close();
                }
            }
            
            return token.Access_token;
        
        }
        bool just_once = false;
        string redirect_uri = string.Empty;
        private async void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                portdata = serialPort1.ReadLine();
                just_once = false;
              

            }
            catch (Exception)
            {

            }
        }
      
        private async void Form1_Load(object sender, EventArgs e)
        {
           
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Size = new Size(770, 900);
            listBox2.ScrollAlwaysVisible = true;

            try
            {
                foreach (string port in port_names)
                {
                    comboBox2.AddItem(port);

                }
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
                comboBox2.selectedIndex = 0;
           
            }
            catch (Exception)
            {
                MessageBox.Show("COM PORTLARI BAGLI DEGIL");
            }
         
            bunifuCards2.Visible = false;
            tabButton1.selected = true;

        }


        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
       
        private void btnMnu_Click(object sender, EventArgs e)
        {
            if (sidemenu.Width == 55)
            {
                sidemenu.Visible = false;
                sidemenu.Width = 252;
                PanelAnimator.ShowSync(sidemenu);
                logoAnimator.ShowSync(logo);
               
            }
            else
            {
                logoAnimator.Hide(logo);
                sidemenu.Visible = false;
                sidemenu.Width = 55;
                PanelAnimator.ShowSync(sidemenu);

            }
        }

        private void tabButton2_Click(object sender, EventArgs e)
        {
            if (tabButton2.selected != true) // multiclick block
            {
                this.Size = new Size(780, 650);
             
                webBrowser1.Visible = false;
                bunifuCards2.Size = new Size(681, 561);
                bunifuCards1.Visible = false;
                bunifuCards3.Visible = false;
                bunifuCards2.Location = new Point(18, 13);
                if (bunifuCards2.Visible == false)
                {
                    groupboxanimation.ShowSync(bunifuCards2);
                }
                else
                {
                    groupboxanimation.Hide(bunifuCards2);
                }
            }
        }
        private void tabButton1_Click(object sender, EventArgs e)
        {
            this.Size = new Size(770, 900);
            if (tabButton1.selected != true) // multi click block
            {
                webBrowser1.Visible = true;
                bunifuCards2.Visible = false;
                bunifuCards3.Visible = false;

                if (bunifuCards1.Visible == false)
                {

                    groupboxanimation1.ShowSync(bunifuCards1);
                }
                else
                {
                    groupboxanimation1.Hide(bunifuCards1);
                }
            }
        }
        private void tabButton3_Click(object sender, EventArgs e)
        {
            if (tabButton3.selected != true) // multi click block
            {
                this.Size = new Size(870,825);
              
                bunifuCards3.Size = new Size(777, 751);
                webBrowser1.Visible = false;
                bunifuCards1.Visible = false;
                bunifuCards2.Visible = false;
                bunifuCards3.Location = new Point(18, 13);
                if (bunifuCards3.Visible == false)
                {

                    groupboxanimation1.ShowSync(bunifuCards3);
                }
                else
                {
                    groupboxanimation1.Hide(bunifuCards3);
                }
            }

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            bunifuMetroTextbox1.Text = webBrowser1.Url.OriginalString;
            textBox4.Text = bunifuMetroTextbox1.Text;
        }


        

     
        private void get_tokens_button_Click(object sender, EventArgs e)
        {
            string oldone = string.Empty;

            oldone = textBox4.Text;
            int state_index = oldone.IndexOf("&state");

            oldone = oldone.Substring(0, state_index); ;
            oldone = oldone.Replace(redirect_uri + "/?code=", string.Empty);

            textBox5.Text = oldone;
            GetAccessToken(oldone,client_id_textbox.Text,client_sr_textbox.Text);
        }

        private void authorization_button_Click(object sender, EventArgs e)
        {
            string scopes = string.Empty;

            if (comboBox1.selectedIndex == 0)
                redirect_uri = "https://www.google.com";
            else if (comboBox1.selectedIndex == 1)
                redirect_uri = "https://memoryhackers.org";

            auth_token.client_id = client_id_textbox.Text;
            auth_token.client_secret = client_sr_textbox.Text;
            foreach (int i in listBox1.SelectedIndices)
            {
                scopes += listBox1.Items[i] + "%20";
            }
            textBox3.Text = "https://accounts.spotify.com/authorize/" + "?client_id=" + auth_token.client_id + "&response_type=code&redirect_uri=" + redirect_uri + "&state=ba09b65f&scope=" + scopes + "&show_dialog=False";
            webBrowser1.Navigate(textBox3.Text);
        }

       

        private void connect_api_Click(object sender, EventArgs e)
        {
            _spotify = new SpotifyWebAPI()
            {
                AccessToken = access_textbox.Text,
                TokenType = "Bearer"
            };

            timer1.Enabled = true;
                   
        }
        string my_albuminfo = string.Empty;
        string my_album_image_uri = string.Empty;
        string saved_uri_image = string.Empty;
        string saved_album_id = string.Empty;
        string saved_playlist_track_uri = string.Empty;
        int picture_height = 0, picture_width = 0 , progress_ms_setup = 0;
        bool justonce = true;
        bool play_fav_song = false;
     
        AvailabeDevices devices = new AvailabeDevices();
        PlaybackContext latest_song = new PlaybackContext();
        PlaybackContext context = new PlaybackContext();
        bool get_history = true;
        bool get_saved_track_list = true;
        bool get_featured_playlist = true;
        int saved_device_count = 0;
        int current_device_count = 0;
        List<string> list_devices;

        string featured_song_market = "TR";
        string saved_featured_song_market = string.Empty;
        private async void timer1_Tick(object sender, EventArgs e)
        {
 
            context = await _spotify.GetPlayingTrackAsync();
            devices = await _spotify.GetDevicesAsync();
            latest_song = await _spotify.GetPlaybackAsync();

            /////////////////////////// AYGITLARI ÇEKİP LİSTE YAZ ////////////////////////
            if (devices.Devices != null)
            {
              
                current_device_count = devices.Devices.Count; // kaç aygıt açık ?

                if (current_device_count != saved_device_count)
                { // bir kere ekle
                    connected_devices.Items.Clear();
                    devices_id.Items.Clear();                   
                    for (int i = 0; i < devices.Devices.Count; i++)
                    {
                     devices_id.Items.Add(devices.Devices[i].Id);
                     connected_devices.Items.Add(devices.Devices[i].Name);

                       //  listBox3.Items.Add(savedTracks.Items[i].Track.Uri);

                    }
                 list_devices = devices_id.Items.OfType<string>().ToList();
                }
                saved_device_count = current_device_count;

            }

            //////////////////////////////// AYGIT YAZMA END ////////////////////////////
            ///
            if (market_list_combobox.selectedIndex == -1) // keyboard fix xd
                return;

            if (saved_featured_song_market != market_list_combobox.selectedValue)        ////// Hit tavsiye edilen çalma listelerini çek !
            {
                featured_list_combobox.Clear();
                listBox5.Items.Clear();
                listBox6.Items.Clear();
                FeaturedPlaylists playlists = _spotify.GetFeaturedPlaylists("", market_list_combobox.selectedValue);
                if (playlists.Playlists == null)
                    return;

                for (int i = 0; i < playlists.Playlists.Items.Count; i++)
                {
                    featured_list_combobox.AddItem(playlists.Playlists.Items[i].Name);
                    listBox5.Items.Add(playlists.Playlists.Items[i].Name);
                    listBox6.Items.Add(playlists.Playlists.Items[i].Id);


                }

                label32.Text = listBox6.Items[0].ToString();
                saved_featured_song_market = market_list_combobox.selectedValue;

            }


            /////////////////////// LATEST_SONG HATA AYIKLAMA ////////////////////////////////
            if (latest_song.HasError())
            {
                Console.WriteLine($"latestsong_error_status: {latest_song.Error.Status}");
                Console.WriteLine($"latestsong_error_msg: {latest_song.Error.Message}");

            }

            //////////////////////////////////////////////////////////////////////////////////

            if (list_devices == null)
            {
                return;
            }
            else if (active_device_textbox.Text == string.Empty && list_devices[0].ToString() != string.Empty) // Eğer aktif aygıt yoksa bağlı aygıtlardan ilkini (0.indextekini) aktif aygıt olarak ata !
            {
                ErrorResponse error2 = _spotify.TransferPlayback(list_devices[0].ToString());
            }

            ///////////////////////////////////// LATEST SONG ITEM NULL DÖNÜYOSA RETURN AT /////////////////////////
            if (latest_song.Item == null)
                return;
            ///////////////////////////////////////////////////////////////////////////////////////////////////////
            

            ///////////////////////////////// LATEST_SONG AKTIF DEVICE, TYPE VS ÇEK ////////////////////////////////
            if (latest_song.Device != null)
            {
              
                active_device_textbox.Text = latest_song.Device.Name;
                isactive_textbox.Text = latest_song.Device.IsActive.ToString();
                device_type_textbox.Text = latest_song.Device.Type;
  
            }

            ///////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///

            if (get_saved_track_list) // get beğenilen şarkı listesi
            {
                listBox4.Items.Clear();
                Paging<SavedTrack> savedTracks = _spotify.GetSavedTracks(50);
             //   savedTracks.Items.ForEach(track => Console.WriteLine(track.Track.Name));

                for (int i = 0; i < savedTracks.Items.Count; i++)
                {
                    listBox4.Items.Add(savedTracks.Items[i].Track.Name);
                  //  listBox3.Items.Add(savedTracks.Items[i].Track.Uri);

                }
 
                get_saved_track_list = false;
            }
           
            if (latest_song.Context != null)
            {

                playback_type_textbox.Text = latest_song.Context.Type;

                if (latest_song.Context.Type == "playlist")
                {
                 
                playlist_uri_textbox.Text = latest_song.Context.Uri.Substring(latest_song.Context.Uri.IndexOf("play") + 9); //.Substring(17, latest_song.Context.Uri.Length - 17);
             
                    if (saved_playlist_track_uri != playlist_uri_textbox.Text)
                    {
                        listBox2.Items.Clear();
                        listBox3.Items.Clear();
                        FullPlaylist playlist = await _spotify.GetPlaylistAsync(playlist_uri_textbox.Text, "", "");
                   
                        for (int i = 0; i < playlist.Tracks.Total; i++)
                        {

                            listBox2.Items.Add(playlist.Tracks.Items[i].Track.Name);
                            listBox3.Items.Add(playlist.Tracks.Items[i].Track.Uri);
                            //Console.Write(playlist.Tracks.Next);
                        }

                       // label30.Text = playlist.Tracks.Total.ToString();
                       // playlist.Tracks.Items.ForEach(track => Console.WriteLine(track.Track.Name));
                    }
                    saved_playlist_track_uri = playlist_uri_textbox.Text; //1 kere döndür
                }

                if (latest_song.Context.Type == "album")
                {

                    if (saved_album_id != album_id_textbox.Text)
                    {
                        listBox2.Items.Clear();
                        listBox3.Items.Clear();
                        Paging<SimpleTrack> tracks = _spotify.GetAlbumTracks(album_id_textbox.Text);
                       // tracks.Items.ForEach(item => Console.WriteLine(item.Name)); //Display all fetched Track-Names (max 20)
                       //  Console.WriteLine(tracks.Total.ToString()); //Display total album track count

                        for (int i= 0; i < tracks.Items.Count; i++)
                        {

     
                            listBox2.Items.Add(tracks.Items[i].Name);
                            listBox3.Items.Add(tracks.Items[i].Uri);

                        }

                    }

                    saved_album_id = album_id_textbox.Text;
                     
                }

            }
            if (playback_type_textbox.Text != "album" && playback_type_textbox.Text != "playlist" && playback_type_textbox.Text != "Featured List" && get_history == true) // get users top track
            {
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                Paging<FullTrack> histories= _spotify.GetUsersTopTracks();
                //histories.Items.ForEach(item => Console.WriteLine(item.Track.Name));

                for (int i = 0; i < histories.Items.Count; i++)
                {
                    listBox2.Items.Add(histories.Items[i].Name);
                    listBox3.Items.Add(histories.Items[i].Uri);

                }
                listBox2.SelectedIndex = 0;
                get_history = false;
            }
            else if ((playback_type_textbox.Text == "album" || playback_type_textbox.Text == "playlist" || playback_type_textbox.Text == "Featured List") && get_history == false)
            {
                get_history = true;
            }

            if (latest_song.Item != null)
            {
            
                album_uri_textbox.Text = latest_song.Item.Album.Uri;
                album_id_textbox.Text = latest_song.Item.Album.Id;
                track_uri_textbox.Text = latest_song.Item.Uri;
               
            }
            else
            {
                album_uri_textbox.Text = "no album found!";
                track_uri_textbox.Text = "no track found.!";
            }

            if (latest_song.IsPlaying == true)
                device_status_text.Text = "Playing Song";
            else
                device_status_text.Text = "Not Playing";


            if (latest_song.IsPlaying == true)
            {
                pause_song_button.Visible = true;
                play_song_button.Visible = false;
            }
            else
            {
                pause_song_button.Visible = false;
                play_song_button.Visible = true;
            }


            ////////////////////// Get Album Infos and Photos //////////////////////

            GetAlbumInfo(album_id_textbox.Text, access_textbox.Text, ref my_albuminfo, ref my_album_image_uri, ref picture_height, ref picture_width);
          
            album_image_textbox.Text = my_album_image_uri;

            pictureBox2.Size = new Size(picture_width, picture_height);

            if (saved_uri_image != my_album_image_uri)
            {
                WebClient wc = new WebClient();
                byte[] bytes = wc.DownloadData(my_album_image_uri);
                MemoryStream ms = new MemoryStream(bytes);
                pictureBox2.Image = System.Drawing.Image.FromStream(ms);
            }

            saved_uri_image = my_album_image_uri;

            //////////////////////// Album Info End /////////////////////////



           // var context = await _spotify.GetPlayingTrackAsync();

            if (context.Item == null)
                return;

            if (context.Item != null)
            {

                volume_trackbar.Value = 100 - latest_song.Device.VolumePercent;
                label25.Text = latest_song.Device.VolumePercent.ToString(); // get device volume percent
                                                                          
                artistsname_textbox.Text = string.Empty;

                playingsong_textbox.Text = context.Item.Name; //Şarkı İsmi
                albumname_textbox.Text = context.Item.Album.Name; //Albüm ismi
                context.Item.Artists.ForEach(deneme => artistsname_textbox.Text = artistsname_textbox.Text + deneme.Name + ","); //şarkıcının isimlerini yazdır
                 
                artistsname_textbox.Text = artistsname_textbox.Text.Substring(0, artistsname_textbox.Text.Length-1);
                progress_ms_setup = context.ProgressMs;

                //denemetextbox.Text = context.Item.ExternUrls.Values.ToString();
            
                slider1.MaximumValue = context.Item.DurationMs;
                slider1.Value = context.ProgressMs;

                label28.Text = (((context.Item.DurationMs * 0.001) - ((context.Item.DurationMs * 0.001) % 60))/60 + ":" + Math.Round((context.Item.DurationMs * 0.001) % 60)).ToString(); 
                label29.Text = (((context.ProgressMs * 0.001) - ((context.ProgressMs * 0.001) % 60)) / 60 + ":" + Math.Round((context.ProgressMs * 0.001) % 60)).ToString();
                //    label27.Text = TimeSpan.FromMinutes(context.Item.DurationMs).Humanize(1);
                //duration_textbox.Text = time1.Add(time2).ToString();
                string current_song_uris = context.Item.Uri;
                //Console.WriteLine(current_song_uris); //Albüm ismi

               
            }
            else
            {
                Console.WriteLine("No Active Device Found!");
            }

        }



        public void DownloadData(string url)
        {
            try
            {
                WebRequest req = WebRequest.Create(url);
                WebResponse response = req.GetResponse();
                Stream stream = response.GetResponseStream();
                //...
            }
            catch (Exception)
            {
                MessageBox.Show("There was a problem downloading the file");
            }
        }

     
        private async void bunifuImageButton1_Click(object sender, EventArgs e)
        {
         
            var error = await _spotify.PausePlaybackAsync();
        }

    

        private async void slider1_ValueChanged(object sender, EventArgs e)
        {
            var error = await _spotify.SeekPlaybackAsync(slider1.Value);
        }
      
        private async void play_song_button_Click(object sender, EventArgs e)
        {
            List<string>  list_uris = listBox3.Items.OfType<string>().ToList();
            List<string>   list_song_names = listBox2.Items.OfType<string>().ToList();
            int  index = list_song_names.FindIndex(x => x.StartsWith(playingsong_textbox.Text));
            if (index != -1)
            listBox2.SelectedIndex = index;
            if (playback_type_textbox.Text != "playlist" && playback_type_textbox.Text != string.Empty && playback_type_textbox.Text != "album" && playback_type_textbox.Text != "Featured List") // album , playlist ya da history den çalmıyorsam
            {
                var error = await _spotify.ResumePlaybackAsync("", "", uris: new List<string> { track_uri_textbox.Text }, 0, slider1.Value);
            }
            else if ( playback_type_textbox.Text == string.Empty && index == -1) // historyden çalmıyorsam ama düz track oynatıyorsam ve listede yoksa başlatma bugu fix.
            {
                var error = await _spotify.ResumePlaybackAsync("", "", uris: new List<string> { track_uri_textbox.Text }, 0, slider1.Value);
            }
            else  // album, playlist ya da history den çalıyorsam.
            {
                var error = await _spotify.ResumePlaybackAsync("", "", uris: list_uris, index, slider1.Value);
            }  

        }

        private async void  next_song_button_Click(object sender, EventArgs e)
        {
            var error = _spotify.SkipPlaybackToNextAsync();
            
        }

        private async void previous_song_button_Click(object sender, EventArgs e)
        {
            var error = _spotify.SkipPlaybackToPreviousAsync();
        }

        bool fixcontrolfromtimer = true;

        private async void listBox2_DoubleClick(object sender, EventArgs e)
        {

            if (listBox2.SelectedItem.ToString() != string.Empty && fixcontrolfromtimer == true)
            {
                int selectedindex = listBox2.SelectedIndex;

                List<string> list_uris = listBox3.Items.OfType<string>().ToList();
                List<string> list_song_names = listBox2.Items.OfType<string>().ToList();
                int index = list_song_names.FindIndex(x => x.StartsWith(listBox2.SelectedItem.ToString()));
                //if (playback_type_textbox.Text == "playlist")
                //{
                var error = await _spotify.ResumePlaybackAsync("", "", uris: list_uris, index, 0);
                //}

                //Console.WriteLine(listBox3.SelectedIndex.ToString());

            }
        }

      
        string portdata = string.Empty;
        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
        }
       private  async Task ListenPortAsyncTask()
        {
            while (true)
            {
                if (serialPort1 != null && serialPort1.IsOpen)
                {
                    portdata = serialPort1.ReadLine(); 
           
                }
                
            }
        }
      

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1 != null && serialPort1.IsOpen) // port açıksa kapat
            {
                serialPort1.Close();
            }
            Application.Exit(); //uygulamayı tamamen kapat
        }


        string saved_one = string.Empty;
        

        private async void listcal_remote(int listnum,string kumandatusu)
        {
            try
            {
                if (portdata.Substring(0, 6).Equals(kumandatusu))
                {


                    listBox2.Items.Clear();
                    listBox3.Items.Clear();


                    FullPlaylist playlist = await _spotify.GetPlaylistAsync(listBox6.Items[listnum].ToString(), "", "");

                    for (int i = 0; i < playlist.Tracks.Items.Count; i++)
                    {

                        listBox2.Items.Add(playlist.Tracks.Items[i].Track.Name);
                        listBox3.Items.Add(playlist.Tracks.Items[i].Track.Uri);
                        //Console.Write(playlist.Tracks.Next);
                    }



                    // ErrorResponse error = _spotify.TransferPlayback("XXXX-XXXX-XXXX-XXXX");
                    playback_type_textbox.Text = "Featured List";
                    playlist_name_textbox.Text = listBox5.Items[listnum].ToString();
                    playlist_uri_textbox.Text = listBox6.Items[listnum].ToString();

                    List<string> list_uris = listBox3.Items.OfType<string>().ToList();
                    List<string> list_song_names = listBox2.Items.OfType<string>().ToList();
                    // album, playlist ya da history den çalıyorsam.

                    var error = await _spotify.ResumePlaybackAsync("", "", uris: list_uris, 0, 0);
                    listBox2.SelectedIndex = 0; //allahın belası bug fix (listbox drawının indexe bağlı liste tıklamadan çizilmeme bugu shit)
                    just_once = true;

                }
            }
            catch
            {

            }
        }

        private async Task ileri_geri_sar(string hotkey)
        {
            int ms = 0;
            just_once = true;
            List<string> list_uris = listBox3.Items.OfType<string>().ToList();
            List<string> list_song_names = listBox2.Items.OfType<string>().ToList();
            int index = list_song_names.FindIndex(x => x.StartsWith(playingsong_textbox.Text));
            if (hotkey == "ABCDEF")
            ms = 30000;
            else if (hotkey == "FEDCBA")
            ms = -30000;
            else if (hotkey == "FCDCBA")
            ms = -60000;
            else if (hotkey == "ACCDEF")
            ms = 60000;

            await _spotify.ResumePlaybackAsync("", "", uris: list_uris, index, slider1.Value + ms);
        }

        bool shuffle = false;

        bool set_shuffle_false_first_time = true;
        private async void remotecontrol_Tick(object sender, EventArgs e)
        {
            if (portdata.Length < 5) //Hotkey lenght kontrol... Yorma apiyi xd
                return;


            if (set_shuffle_false_first_time) // bug fix, gurur duymuyorum...
            {
                ErrorResponse error = _spotify.SetShuffle(false);
                set_shuffle_false_first_time = !set_shuffle_false_first_time;            
            }
            if (just_once == false)
            {
                if (portdata.Substring(0, 6).Equals("ABCDEF") || portdata.Substring(0, 6).Equals("FEDCBA") || portdata.Substring(0, 6).Equals("FCDCBA") || portdata.Substring(0, 6).Equals("ACCDEF")) // ileri sara basıldı
                {

                  await ileri_geri_sar(portdata.Substring(0, 6));
                   
         
                }

                if (portdata.Substring(0,6).Equals("FFFCCC")) // karışık çalma ayarı
                {
                    just_once = true;
                    shuffle =! shuffle;
                    ErrorResponse error = _spotify.SetShuffle(shuffle);

                }
             
                if (portdata.Substring(0, 6).Equals("FF906F")) // EQ tuşuna basılırsa featured list için marketler arası geçiş yap brom !
                {
                    just_once = true;
                    market_list_combobox.selectedIndex = market_list_combobox.selectedIndex + 1;
                }

                    if (portdata.Substring(0, 6).Equals("FF629D")) // ch basılırsa favori track listesi çal
                {
                    just_once = true;
                    listBox2.Items.Clear();
                    listBox3.Items.Clear();
                    Paging<SavedTrack> savedTracks = _spotify.GetSavedTracks(50);
        

                    for (int i = 0; i < savedTracks.Items.Count; i++)
                    {
                        listBox2.Items.Add(savedTracks.Items[i].Track.Name);
                        listBox3.Items.Add(savedTracks.Items[i].Track.Uri);
                        //  listBox3.Items.Add(savedTracks.Items[i].Track.Uri);

                    }

                    List<string> list_uris = listBox3.Items.OfType<string>().ToList();
                    List<string> list_song_names = listBox2.Items.OfType<string>().ToList();

                    playlist_name_textbox.Text = "Favorite List";

                    var error = await _spotify.ResumePlaybackAsync("", "", uris: list_uris, 0, 0);
                }

                if (portdata.Substring(0, 6).Equals("FFA25D")) // ch- basılırsa trackı saved listten sil
                {
                    ErrorResponse response = _spotify.RemoveSavedTracks(new List<string> { latest_song.Item.Id });
                    if (!response.HasError())
                        status_save.Text = "Deleted from Fav List";
                    else
                        status_save.Text = "Error";
                    just_once = true;
                    get_saved_track_list = true;

                }
                if (portdata.Substring(0, 6).Equals("FFE21D")) // ch+ basılırsa trackı saved liste kaydet
                {

                    ErrorResponse response = _spotify.SaveTrack(latest_song.Item.Id);
                    if (!response.HasError())
                        status_save.Text = "Added to Fav List";
                    else
                        status_save.Text = "Error";

                    get_saved_track_list = true;

                    just_once = true;

                }

                if (portdata.Substring(0, 6).Equals("FF02FD")) //sonraki şarkıya git
                {
                    var error = _spotify.SkipPlaybackToNextAsync();
                    just_once = true;

                }
                if (portdata.Substring(0, 6).Equals("FF22DD")) // önceki şarkıya dön
                {
                    var error = _spotify.SkipPlaybackToPreviousAsync();
                    just_once = true;

                }

                if (portdata.Substring(0, 6).Equals("FFC23D")) //müzik durdur & başlat
                {
                    just_once = true; // ne saçma şeysin sen böyle 
                    if (device_status_text.Text != "Playing Song") // Müzik durduysa işlemleri...
                    {

                        List<string> list_uris = listBox3.Items.OfType<string>().ToList();
                        List<string> list_song_names = listBox2.Items.OfType<string>().ToList();
                        int index = list_song_names.FindIndex(x => x.StartsWith(playingsong_textbox.Text));


                        var error = await _spotify.ResumePlaybackAsync("", "", uris: list_uris, index, slider1.Value);
       
                    }
                    else // Müziği durdur.
                    {
                        var error = await _spotify.PausePlaybackAsync();
                    }

                }
                int volume_integer = 0;
                Int32.TryParse(label25.Text, out volume_integer);
                if (portdata.Substring(0, 6).Equals("FFA857")) // volume scale up
                {


                    if (volume_integer + 20 >= 100)
                    {
                        ErrorResponse error = _spotify.SetVolume(100);
                    }
                    else
                    {
                        ErrorResponse error = _spotify.SetVolume(volume_integer + 20);

                    }

                    just_once = true;

                }
                if (portdata.Substring(0, 6).Equals("FFE01F")) // volume scale down
                {
                    if (volume_integer - 20 <= 0)
                    {
                        ErrorResponse error = _spotify.SetVolume(0);
                    }
                    else
                    {
                        ErrorResponse error = _spotify.SetVolume(volume_integer - 20);
                    }

                    just_once = true;

                }


                
                listcal_remote(0, "FF6897");
                listcal_remote(1, "FF30CF");
                listcal_remote(2, "FF18E7");
                listcal_remote(3, "FF7A85");
                listcal_remote(4, "FF10EF");
                listcal_remote(5, "FF38C7");
                listcal_remote(6, "FF5AA5");
                listcal_remote(7, "FF42BD");
                listcal_remote(8, "FF4AB5");
                listcal_remote(9, "FF52AD");
                just_once = true;

            }
        }
       
        /// ////////////// Remote Timer End /////////////////////
        


        private void port_connect_Click(object sender, EventArgs e)
        {
            serialPort1.BaudRate = 9600;

            if (comboBox2.selectedIndex == -1)
            {
                MessageBox.Show("Please select port");
                return;
            }
            if (!serialPort1.IsOpen) // port açıkken portname ayarlamasını engelle
            serialPort1.PortName = comboBox2.selectedValue;

            try
            {
                if (serialPort1 != null && serialPort1.IsOpen) // port açıksa kapat
                {
                    port_connect.ButtonText = "Connect to Port";
                    serialPort1.Close();
                }
                else
                {
                    serialPort1.Open();
                    port_connect.ButtonText = "Disconnect";

                }
            }
            catch (Exception)
            {
                throw;
            }
        
        }


        int savedlistboxitem = 0;
        int currentlistboxitem = 0;
        private void timer2_Tick(object sender, EventArgs e) // Çalan müziğin indexini listbox2 de bulup selected item olarak setle.
        {

            
            //////////////////////////// Çalan müziği listede display et. //////////////////
            List<string> list_song_names = listBox2.Items.OfType<string>().ToList();
                int index = list_song_names.FindIndex(x => x.StartsWith(playingsong_textbox.Text));

                currentlistboxitem = index;
                if (index != -1 && (savedlistboxitem != currentlistboxitem))
                {
                    listBox2.SelectedIndex = index;
                }
                savedlistboxitem = currentlistboxitem;
           
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            this.listBox2.Invalidate();
        }

        
        private void listBox2_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                //////////// copy paste //////////////
                int index = e.Index;
                Graphics g = e.Graphics;
                foreach (int selectedIndex in this.listBox2.SelectedIndices)
                {
                    if (index == selectedIndex)
                    {
                        // Draw the new background colour
                        e.DrawBackground();
                        g.FillRectangle(new SolidBrush(Color.FromArgb(40, 40, 40)), e.Bounds);
                    }
                }

                // Get the item details
                Font font = listBox2.Font;
                Color colour = listBox2.ForeColor;
                if (listBox2.SelectedIndex != -1)
                {
                    string text = listBox2.Items[index].ToString();
                    g.DrawString(text, font, new SolidBrush(Color.Silver), (float)e.Bounds.X, (float)e.Bounds.Y);
                    e.DrawFocusRectangle();
                }
                // Print the text
            }
            catch 
            {

            }
        }


        private void save_track_button_Click(object sender, EventArgs e)
        {
            ErrorResponse response = _spotify.SaveTrack(latest_song.Item.Id);
            if (!response.HasError())
               status_save.Text = "Added to Fav List";
            else
                status_save.Text = "Error";

            get_saved_track_list = true;
        }

        private void delete_saved_track_button_Click(object sender, EventArgs e)
        {
            ErrorResponse response = _spotify.RemoveSavedTracks(new List<string> { latest_song.Item.Id });
            if (!response.HasError())
                status_save.Text = "Deleted from Fav List";
            else
                status_save.Text = "Error";
            get_saved_track_list = true;
        }

        bool justonce2 = true;
        private async void play_fav_songs_Click(object sender, EventArgs e)
        {
            justonce2 = true;
            if (justonce2) // get beğenilen şarkı listesi
            {
                listBox2.Items.Clear();
                listBox3.Items.Clear();
                Paging<SavedTrack> savedTracks = _spotify.GetSavedTracks(50);
                //   savedTracks.Items.ForEach(track => Console.WriteLine(track.Track.Name));

                for (int i = 0; i < savedTracks.Items.Count; i++)
                {
                    listBox2.Items.Add(savedTracks.Items[i].Track.Name);
                    listBox3.Items.Add(savedTracks.Items[i].Track.Uri);
                    //  listBox3.Items.Add(savedTracks.Items[i].Track.Uri);

                }

                List<string> list_uris = listBox3.Items.OfType<string>().ToList();
                List<string> list_song_names = listBox2.Items.OfType<string>().ToList();
                // album, playlist ya da history den çalıyorsam.

                var error = await _spotify.ResumePlaybackAsync("", "", uris: list_uris, 0, 0);

                justonce2 = false;
            }

        }
        bool justonce3 = true;
        private async void play_featured_song_button_Click(object sender, EventArgs e) // Önce çıkanlar listesi çal
        {

            listBox2.Items.Clear();
            listBox3.Items.Clear();

            
            if (featured_list_combobox.selectedIndex == -1)
            {
                MessageBox.Show("Please select featured list");
                return;
            }
            FullPlaylist playlist = await _spotify.GetPlaylistAsync(listBox6.Items[featured_list_combobox.selectedIndex].ToString(), "", "");

                    for (int i = 0; i < playlist.Tracks.Total; i++)
                    {

                        listBox2.Items.Add(playlist.Tracks.Items[i].Track.Name);
                        listBox3.Items.Add(playlist.Tracks.Items[i].Track.Uri);
                        //Console.Write(playlist.Tracks.Next);
                    }


            playback_type_textbox.Text = "Featured List";
            playlist_name_textbox.Text = listBox5.Items[featured_list_combobox.selectedIndex].ToString();
            playlist_uri_textbox.Text = listBox6.Items[featured_list_combobox.selectedIndex].ToString();
               
                List<string> list_uris = listBox3.Items.OfType<string>().ToList();
                List<string> list_song_names = listBox2.Items.OfType<string>().ToList();
                // album, playlist ya da history den çalıyorsam.

                var error = await _spotify.ResumePlaybackAsync("", "", uris: list_uris, 0, 0);

           
          

        }

        private void retry_port_button_Click(object sender, EventArgs e) // Port infos retry
        {
            comboBox2.Clear();
            string[] new_port_names = SerialPort.GetPortNames();
            try
            {
                foreach (string port in new_port_names)
                {
                    comboBox2.AddItem(port);

                }
                serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
                comboBox2.selectedIndex = 0;

            }
            catch (Exception)
            {
                MessageBox.Show("COM PORTLARI BAGLI DEGIL");
            }

        }

        string saved_song_name = "asdas"; // ilk acilistaki bug fix
        string saved_artist_name = "asdasd";
        public string StringReplace(string text)
        {
            text = text.Replace("İ", "I");
            text = text.Replace("ı", "i");
            text = text.Replace("Ğ", "G");
            text = text.Replace("ğ", "g");
            text = text.Replace("Ö", "O");
            text = text.Replace("ö", "o");
            text = text.Replace("Ü", "U");
            text = text.Replace("ü", "u");
            text = text.Replace("Ş", "S");
            text = text.Replace("ş", "s");
            text = text.Replace("Ç", "C");
            text = text.Replace("ç", "c");
            //text = text.Replace(" ", "_");
            return text;
        }


        bool tek_sefer = false;
        bool saved_shuffle = false;
        private void info_gonder_Tick(object sender, EventArgs e)
        {
           
            if (serialPort1 != null && serialPort1.IsOpen) // port açıksa gonder bilgileri bebegim
            {

               if (shuffle && !tek_sefer)
                {
                    serialPort1.Write("shuffled$");
                    saved_shuffle = shuffle;
                    tek_sefer = true;
                }
               else if (!shuffle && tek_sefer)
                {
                    serialPort1.Write("notsf$");
                    saved_shuffle = shuffle;
                    tek_sefer = false;
                }
            
                 // şarkı ismi ve artist bilgileri varsa kontrolü                         // aynı anda shuffle ve song bilgilerini göndermesini engelle

                if (playingsong_textbox.Text != string.Empty && artistsname_textbox.Text != string.Empty && saved_shuffle == shuffle)
                {


                    string new_playingsong = playingsong_textbox.Text;
                    string new_singer_name = artistsname_textbox.Text;

                    if (new_singer_name.Length > 30) // string uzunluğu 30 dan büyükse son 3 charı ... yap, fazlası bug sebebi.
                        new_singer_name = new_singer_name.Substring(0, 27) + "...";
                    if (new_playingsong.Length > 30)
                        new_playingsong = new_playingsong.Substring(0, 27) + "...";
                  


                    if ((saved_song_name != playingsong_textbox.Text) || (saved_artist_name != artistsname_textbox.Text)) // sıkıntı yok yola devam
                    {
                        string yourString = new_playingsong + "\n" + new_singer_name + "$"; // arduinonun anlayacağı biçimde gönderelim.
                        yourString = StringReplace(yourString);
                        //  byte[] MyMessage = System.Text.Encoding.UTF8.GetBytes(yourString);
                        serialPort1.Write(yourString);
                        saved_song_name = playingsong_textbox.Text;
                        saved_artist_name = artistsname_textbox.Text;


                    }


                }
            }
        }

        private void form_minimize_button_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button_locals_Tick(object sender, EventArgs e)
        {
         
        }

        private void header_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void send_string_port_Click(object sender, EventArgs e)
        {

            string yourString = playingsong_textbox.Text + "\n" + artistsname_textbox.Text + "$";

 
 
                byte[] MyMessage = System.Text.Encoding.ASCII.GetBytes(yourString);
    
            if (serialPort1 != null && serialPort1.IsOpen) // port açıksa kapat
            {
                //  serialPort1.Write(MyMessage, 0, MyMessage.Length);
                serialPort1.Write(yourString);
            }

        }


        private void volume_trackbar_ValueChanged(object sender, EventArgs e)
        {
            ErrorResponse error = _spotify.SetVolume(100 - volume_trackbar.Value);

        }
    }
}
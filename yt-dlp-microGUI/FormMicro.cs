using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace yt_dlp_microGUI
{
    public partial class FormMicro : Form
    {
        private string paramPath = "";
        string ffmpeg_location = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\", @"\\");
        
        public FormMicro()
        {
            InitializeComponent();
            
            string paramDefaultFormat = "";
            string settings_filepath = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\", @"\\") + "\\yt-dlp-mg.properties";

            if (File.Exists(settings_filepath))
            {
                StreamReader sr = new StreamReader(settings_filepath);
                String line;
                try
                {
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        if (line.Contains("Path=")) { paramPath = line.Remove(0, 5); }
                        if (line.Contains("DefaultFormat=")) { paramDefaultFormat = line.Remove(0, 14); }
                        if (line.Contains("ffmpeg-location=")) { ffmpeg_location = line.Remove(0, 16); }
                        line = sr.ReadLine();
                    }                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error has been occurred. Couldn't read settings from file. ExceptionDetails: Source: " + ex.Source + "\nMessage: " + ex.Message + "\nStack" + ex.StackTrace);
                }
                finally
                {
                    sr.Close();
                }
            }
            if (paramDefaultFormat != "") 
            {
                if (paramDefaultFormat == "mp3") radioButtonMP3.Checked = true;
                else if (paramDefaultFormat == "mp4") radioButtonMP4.Checked = true;
            }

            this.ActiveControl = textBoxInputURL;

            ToolTip toolTip1 = new ToolTip();
            toolTip1.SetToolTip(this.pictureBoxAudio, "audio (.mp3)");
            toolTip1.SetToolTip(this.pictureBoxVideo, "video (.mp4)");
            toolTip1.SetToolTip(this.radioButtonMP3, "audio (.mp3)");
            toolTip1.SetToolTip(this.radioButtonMP4, "video (.mp4)");
            toolTip1.SetToolTip(this.buttonDownload, "LMB to start download,\nRMB to open destination folder");
            toolTip1.SetToolTip(this.checkBoxPlaylist, "Check this to download entire playlist instead of a current video from the pasted playlist");
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            Regex validateURLRegex = new Regex("^(https?:\\/\\/)?(?:www\\.)?[^.][-a-zA-Z0-9@:%._\\+~#=]{1,256}[^www]\\.[a-zA-Z0-9()]{2,6}\\b(?:[-a-zA-Z0-9()@:%_\\+.~#?&\\/=]*)$");
            Regex validateFilepathRegex = new Regex(@"file://[A-Z][:][\\]([A-Za-z0-9])*([\\][A-Za-z0-9])*([\\]|[.[A-Za-z0-9]{1})*");

            if (textBoxInputURL.Text == "" || textBoxInputURL.Text is null || !(validateURLRegex.IsMatch(textBoxInputURL.Text)||(validateFilepathRegex.IsMatch(textBoxInputURL.Text)))) 
            {
                MessageBox.Show("You must enter valid url");
                return; 
            }
            try
            {
                string executableFileName = "yt-dlp.exe";
                if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory.Replace(@"\", @"\\") + "\\" + executableFileName))
                {
                    MessageBox.Show("Original yt-dlp.exe was not found");
                    return;
                }
                if (!File.Exists(ffmpeg_location.Replace(@"\", @"\\").Replace("\"","")+"\\ffmpeg.exe"))
                {
                    MessageBox.Show("ffmpeg was not found");
                    return;
                }
                //string ffmpeg_location = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\", @"\\"); ;//"C:\\Users\\Caesar\\Desktop\\youtube-dl-gui-portable";
                string searchString = textBoxInputURL.Text;
                if (searchString.StartsWith(@"file://"))
                {
                    var searchListFile = File.ReadAllLines(searchString.Remove(0,7));
                    var searchList = new List<string>(searchListFile);
                    foreach(var name in searchList)
                    {
                        Download(String.Concat("\"ytsearch1:", name, "\""), executableFileName);
                    }
                }
                else
                {
                    Download(searchString, executableFileName);}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error has been occurred. ExceptionDetails: Source: " + ex.Source+"\nMessage: "+ex.Message+"\nStack"+ex.StackTrace);
            }
        }

        private void Download(string searchString, string executableFileName)
        {
            string url = searchString.Replace(@"/", @"//");
            ProcessStartInfo startInfo = new ProcessStartInfo(executableFileName);

            string argPath = "";
            if (paramPath != "") argPath = " -P " + paramPath.Replace(@"\", @"/");

            if (radioButtonMP3.Checked)
            {
                startInfo.Arguments = "--ffmpeg-location " + ffmpeg_location + " -x --audio-format mp3 " + url + " -o \"%(title)s.%(ext)s\"" + argPath + ((this.checkBoxPlaylist.Checked) ? "" : " --no-playlist");
            }
            else if (radioButtonMP4.Checked)
            {
                startInfo.Arguments = "--ffmpeg-location " + ffmpeg_location + " -S ext:mp4:m4a " + url + " -o \"%(title)s.%(ext)s\"" + argPath + ((this.checkBoxPlaylist.Checked) ? "" : " --no-playlist");
            }
            else
            {
                MessageBox.Show("You must choose an option \n(mp3 or mp4 button)");
                return;
            }
            Process.Start(startInfo).WaitForExit();
            /*            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = startInfo.FileName,
                    Arguments = startInfo.Arguments,
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                }
            };

            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();
                using (StreamWriter outputFile = File.AppendText(@"C:\1\log.txt"))
                {
                    outputFile.WriteLine(line);
                }
            }*/
        }
        private void buttonDownload_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                buttonDownload_Click(sender, e);
            }
            if (e.Button == MouseButtons.Right)
            {
                if (paramPath != "")
                    Process.Start(paramPath);
                else
                    Process.Start(AppDomain.CurrentDomain.BaseDirectory);
            }
        }

        private void textBox1_MouseLeave(object sender, EventArgs e)
        {
            textBoxInputURL.Width = textBoxInputURL.MinimumSize.Width;
            textBoxInputURL.Height = textBoxInputURL.MinimumSize.Height;
            this.Height = 90;
            this.Width = 236;
            //textBox1.ScrollBars = ScrollBars.None;
            textBoxInputURL.Height -= 25;
        }

        private void textBox1_MouseEnter(object sender, EventArgs e)
        {
            textBoxInputURL.Height += 25;
            this.Height = 90 + 25;
            textBox1_AutoSize();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1_AutoSize();
        }

        private void SetRadoButtonIcon(object sender, EventArgs e)
        {
            if (this.checkBoxPlaylist.Checked)
            { 
                pictureBoxAudio.Image = yt_dlp_microGUI.Properties.Resources.aPlaylist_20x20;
                pictureBoxVideo.Image = yt_dlp_microGUI.Properties.Resources.vPlaylist_20x20;
            }
            else
            {
                pictureBoxAudio.Image = yt_dlp_microGUI.Properties.Resources.music;
                pictureBoxVideo.Image = yt_dlp_microGUI.Properties.Resources.video;
            }
        }

        private void textBox1_AutoSize()
        {
            Size size = TextRenderer.MeasureText(textBoxInputURL.Text, textBoxInputURL.Font);
            /*   if (
                   (size.Width > textBoxInputURL.MinimumSize.Width)
                   && ((size.Width + 32) > 236)
                  )
               {
                   textBoxInputURL.Width = size.Width + 12;
                   this.Width = size.Width + 72;
               }
               else if (size.Width > textBoxInputURL.MinimumSize.Width)
               {
                   textBoxInputURL.Width = size.Width;
                   this.Width = 236;
               }
               else textBoxInputURL.Width = textBoxInputURL.MinimumSize.Width;
            */
            /*if (size.Width > textBoxInputURL.MinimumSize.Width-5)
            {
                if (size.Width + 12 < 228)
                {
                    textBoxInputURL.Width = size.Width + 12;
                    this.Width = 236;
                }
                else
                {
                    this.Width = size.Width + 42;
                    textBoxInputURL.Width = size.Width + 12;
                }
            }
            else 
            {
                textBoxInputURL.Width = textBoxInputURL.MinimumSize.Width;
                this.Width = 236; 
            }*/

            if (size.Width > textBoxInputURL.MinimumSize.Width - 5)
            {
                int resizeValue = size.Width - (textBoxInputURL.MinimumSize.Width - 5) + 25;
                if (resizeValue > 85) this.Width = 236 + resizeValue - 85;
                textBoxInputURL.Width = textBoxInputURL.MinimumSize.Width + resizeValue;
            }
            else
            {
                textBoxInputURL.Width = textBoxInputURL.MinimumSize.Width;
                this.Width = 236;
            }
        }

        private void textBoxInputURL_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter))
            {
                SendKeys.Send("{TAB}");
                e.SuppressKeyPress = true;
            }
        }
    }
}

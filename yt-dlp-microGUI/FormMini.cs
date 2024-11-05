using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace yt_dlp_microGUI
{
    public partial class FormMini : Form
    {
        private string paramPath = "";

        public FormMini()
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

            this.ActiveControl = textBox1;
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            try
            {
                string ExecutableFileName = "yt-dlp.exe";
                string ffmpeg_location = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\", @"\\"); ;//"C:\\Users\\Caesar\\Desktop\\youtube-dl-gui-portable";
                string url = textBox1.Text.Replace(@"\", @"\\");
                ProcessStartInfo startInfo = new ProcessStartInfo(ExecutableFileName);

                string argPath = "";
                if (paramPath != "") argPath = " -P " + paramPath.Replace(@"\", @"/");

                if (radioButtonMP3.Checked)
                {
                    startInfo.Arguments = "--ffmpeg-location " + ffmpeg_location + " -x --audio-format mp3 " + url + " -o \"%(title)s.%(ext)s\"" + argPath;
                }
                else if (radioButtonMP4.Checked)
                {
                    startInfo.Arguments = "--ffmpeg-location " + ffmpeg_location + " -S ext:mp4:m4a " + url + " -o \"%(title)s.%(ext)s\"" + argPath;
                }
                else
                {
                    MessageBox.Show("You must choose an option \n(mp3 or mp4 button)");
                    return;
                }
                Process.Start(startInfo).WaitForExit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error has been occurred. ExceptionDetails: Source: " + ex.Source+"\nMessage: "+ex.Message+"\nStack"+ex.StackTrace);
            }
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
    }
}

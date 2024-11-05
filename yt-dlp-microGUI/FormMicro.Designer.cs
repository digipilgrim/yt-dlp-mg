namespace yt_dlp_microGUI
{
    partial class FormMicro
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMicro));
            this.panel1 = new System.Windows.Forms.Panel();
            this.radioButtonMP4 = new System.Windows.Forms.RadioButton();
            this.radioButtonMP3 = new System.Windows.Forms.RadioButton();
            this.textBoxInputURL = new System.Windows.Forms.TextBox();
            this.labelURL = new System.Windows.Forms.Label();
            this.checkBoxPlaylist = new System.Windows.Forms.CheckBox();
            this.pictureBoxVideo = new System.Windows.Forms.PictureBox();
            this.pictureBoxAudio = new System.Windows.Forms.PictureBox();
            this.buttonDownload = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVideo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAudio)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.radioButtonMP4);
            this.panel1.Controls.Add(this.radioButtonMP3);
            this.panel1.Location = new System.Drawing.Point(127, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(25, 46);
            this.panel1.TabIndex = 2;
            // 
            // radioButtonMP4
            // 
            this.radioButtonMP4.AutoSize = true;
            this.radioButtonMP4.Location = new System.Drawing.Point(0, 22);
            this.radioButtonMP4.Name = "radioButtonMP4";
            this.radioButtonMP4.Size = new System.Drawing.Size(14, 13);
            this.radioButtonMP4.TabIndex = 5;
            this.radioButtonMP4.TabStop = true;
            this.radioButtonMP4.UseVisualStyleBackColor = true;
            // 
            // radioButtonMP3
            // 
            this.radioButtonMP3.AutoSize = true;
            this.radioButtonMP3.Location = new System.Drawing.Point(0, 0);
            this.radioButtonMP3.Name = "radioButtonMP3";
            this.radioButtonMP3.Size = new System.Drawing.Size(14, 13);
            this.radioButtonMP3.TabIndex = 4;
            this.radioButtonMP3.TabStop = true;
            this.radioButtonMP3.UseVisualStyleBackColor = true;
            // 
            // textBoxInputURL
            // 
            this.textBoxInputURL.Location = new System.Drawing.Point(12, 23);
            this.textBoxInputURL.MinimumSize = new System.Drawing.Size(109, 20);
            this.textBoxInputURL.Multiline = true;
            this.textBoxInputURL.Name = "textBoxInputURL";
            this.textBoxInputURL.Size = new System.Drawing.Size(109, 20);
            this.textBoxInputURL.TabIndex = 0;
            this.textBoxInputURL.WordWrap = false;
            this.textBoxInputURL.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBoxInputURL.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxInputURL_KeyDown);
            this.textBoxInputURL.MouseEnter += new System.EventHandler(this.textBox1_MouseEnter);
            this.textBoxInputURL.MouseLeave += new System.EventHandler(this.textBox1_MouseLeave);
            // 
            // labelURL
            // 
            this.labelURL.AutoSize = true;
            this.labelURL.Location = new System.Drawing.Point(12, 8);
            this.labelURL.Name = "labelURL";
            this.labelURL.Size = new System.Drawing.Size(32, 13);
            this.labelURL.TabIndex = 2;
            this.labelURL.Text = "URL:";
            // 
            // checkBoxPlaylist
            // 
            this.checkBoxPlaylist.AutoSize = true;
            this.checkBoxPlaylist.Location = new System.Drawing.Point(70, 7);
            this.checkBoxPlaylist.Name = "checkBoxPlaylist";
            this.checkBoxPlaylist.Size = new System.Drawing.Size(57, 17);
            this.checkBoxPlaylist.TabIndex = 3;
            this.checkBoxPlaylist.Text = "playlist";
            this.checkBoxPlaylist.UseVisualStyleBackColor = true;
            this.checkBoxPlaylist.CheckedChanged += new System.EventHandler(this.SetRadoButtonIcon);
            // 
            // pictureBoxVideo
            // 
            this.pictureBoxVideo.Image = global::yt_dlp_microGUI.Properties.Resources.video;
            this.pictureBoxVideo.Location = new System.Drawing.Point(143, 24);
            this.pictureBoxVideo.Name = "pictureBoxVideo";
            this.pictureBoxVideo.Size = new System.Drawing.Size(24, 34);
            this.pictureBoxVideo.TabIndex = 5;
            this.pictureBoxVideo.TabStop = false;
            // 
            // pictureBoxAudio
            // 
            this.pictureBoxAudio.Image = global::yt_dlp_microGUI.Properties.Resources.music;
            this.pictureBoxAudio.Location = new System.Drawing.Point(141, 2);
            this.pictureBoxAudio.Name = "pictureBoxAudio";
            this.pictureBoxAudio.Size = new System.Drawing.Size(24, 34);
            this.pictureBoxAudio.TabIndex = 4;
            this.pictureBoxAudio.TabStop = false;
            // 
            // buttonDownload
            // 
            this.buttonDownload.BackColor = System.Drawing.SystemColors.HotTrack;
            this.buttonDownload.Image = global::yt_dlp_microGUI.Properties.Resources.downloadWhite;
            this.buttonDownload.Location = new System.Drawing.Point(173, 3);
            this.buttonDownload.Name = "buttonDownload";
            this.buttonDownload.Size = new System.Drawing.Size(46, 46);
            this.buttonDownload.TabIndex = 1;
            this.buttonDownload.UseVisualStyleBackColor = false;
            this.buttonDownload.Click += new System.EventHandler(this.buttonDownload_Click);
            this.buttonDownload.MouseDown += new System.Windows.Forms.MouseEventHandler(this.buttonDownload_MouseDown);
            // 
            // FormMicro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 51);
            this.Controls.Add(this.textBoxInputURL);
            this.Controls.Add(this.checkBoxPlaylist);
            this.Controls.Add(this.pictureBoxVideo);
            this.Controls.Add(this.pictureBoxAudio);
            this.Controls.Add(this.labelURL);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonDownload);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMicro";
            this.Text = "yt-dlp-microGUI";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVideo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAudio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonDownload;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton radioButtonMP4;
        private System.Windows.Forms.RadioButton radioButtonMP3;
        private System.Windows.Forms.TextBox textBoxInputURL;
        private System.Windows.Forms.Label labelURL;
        private System.Windows.Forms.PictureBox pictureBoxAudio;
        private System.Windows.Forms.PictureBox pictureBoxVideo;
        private System.Windows.Forms.CheckBox checkBoxPlaylist;
    }
}


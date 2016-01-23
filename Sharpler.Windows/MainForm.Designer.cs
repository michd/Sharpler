namespace Sharpler.Windows
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.trackNameLabel = new System.Windows.Forms.Label();
            this.selectFileButton = new System.Windows.Forms.Button();
            this.playPauseButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.selectFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.currentTimeLabel = new System.Windows.Forms.Label();
            this.durationLabel = new System.Windows.Forms.Label();
            this.transportPanel = new System.Windows.Forms.Panel();
            this.nextButton = new System.Windows.Forms.Button();
            this.previousButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.mediaLibraryPlaceholderLabel = new System.Windows.Forms.Label();
            this.playlistDataGridView = new System.Windows.Forms.DataGridView();
            this.transportPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playlistDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // trackNameLabel
            // 
            this.trackNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackNameLabel.BackColor = System.Drawing.Color.Black;
            this.trackNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trackNameLabel.ForeColor = System.Drawing.Color.White;
            this.trackNameLabel.Location = new System.Drawing.Point(0, 0);
            this.trackNameLabel.Name = "trackNameLabel";
            this.trackNameLabel.Size = new System.Drawing.Size(724, 25);
            this.trackNameLabel.TabIndex = 0;
            this.trackNameLabel.Text = "Open a file to start playback.";
            this.trackNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // selectFileButton
            // 
            this.selectFileButton.Location = new System.Drawing.Point(11, 11);
            this.selectFileButton.Name = "selectFileButton";
            this.selectFileButton.Size = new System.Drawing.Size(75, 23);
            this.selectFileButton.TabIndex = 1;
            this.selectFileButton.Text = "Select File...";
            this.selectFileButton.UseVisualStyleBackColor = true;
            this.selectFileButton.Click += new System.EventHandler(this.SelectFileButton_Click);
            // 
            // playPauseButton
            // 
            this.playPauseButton.Location = new System.Drawing.Point(13, 81);
            this.playPauseButton.Name = "playPauseButton";
            this.playPauseButton.Size = new System.Drawing.Size(45, 23);
            this.playPauseButton.TabIndex = 2;
            this.playPauseButton.Text = "Play";
            this.playPauseButton.UseVisualStyleBackColor = true;
            this.playPauseButton.Click += new System.EventHandler(this.PlayPauseButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(114, 81);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(45, 23);
            this.stopButton.TabIndex = 3;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // selectFileDialog
            // 
            this.selectFileDialog.FileName = "openFileDialog1";
            this.selectFileDialog.Filter = "MP3 Files|*.mp3|Wave audio files|*.wav";
            this.selectFileDialog.Multiselect = true;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.progressBar.Location = new System.Drawing.Point(12, 38);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(701, 18);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 4;
            this.progressBar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ProgressBar_MouseClick);
            // 
            // currentTimeLabel
            // 
            this.currentTimeLabel.AutoSize = true;
            this.currentTimeLabel.Location = new System.Drawing.Point(10, 59);
            this.currentTimeLabel.Name = "currentTimeLabel";
            this.currentTimeLabel.Size = new System.Drawing.Size(28, 13);
            this.currentTimeLabel.TabIndex = 5;
            this.currentTimeLabel.Text = "0:00";
            // 
            // durationLabel
            // 
            this.durationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.durationLabel.AutoSize = true;
            this.durationLabel.Location = new System.Drawing.Point(685, 59);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(28, 13);
            this.durationLabel.TabIndex = 6;
            this.durationLabel.Text = "0:00";
            this.durationLabel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // transportPanel
            // 
            this.transportPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.transportPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.transportPanel.Controls.Add(this.nextButton);
            this.transportPanel.Controls.Add(this.previousButton);
            this.transportPanel.Controls.Add(this.trackNameLabel);
            this.transportPanel.Controls.Add(this.progressBar);
            this.transportPanel.Controls.Add(this.stopButton);
            this.transportPanel.Controls.Add(this.durationLabel);
            this.transportPanel.Controls.Add(this.playPauseButton);
            this.transportPanel.Controls.Add(this.currentTimeLabel);
            this.transportPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.transportPanel.Location = new System.Drawing.Point(0, 415);
            this.transportPanel.Margin = new System.Windows.Forms.Padding(0);
            this.transportPanel.Name = "transportPanel";
            this.transportPanel.Padding = new System.Windows.Forms.Padding(15, 15, 15, 10);
            this.transportPanel.Size = new System.Drawing.Size(725, 117);
            this.transportPanel.TabIndex = 7;
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(165, 81);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(45, 23);
            this.nextButton.TabIndex = 8;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // previousButton
            // 
            this.previousButton.Location = new System.Drawing.Point(64, 81);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(44, 23);
            this.previousButton.TabIndex = 7;
            this.previousButton.Text = "Prev";
            this.previousButton.UseVisualStyleBackColor = true;
            this.previousButton.Click += new System.EventHandler(this.PreviousButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.mediaLibraryPlaceholderLabel);
            this.splitContainer1.Panel1.Controls.Add(this.selectFileButton);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.playlistDataGridView);
            this.splitContainer1.Size = new System.Drawing.Size(725, 415);
            this.splitContainer1.SplitterDistance = 490;
            this.splitContainer1.TabIndex = 9;
            // 
            // mediaLibraryPlaceholderLabel
            // 
            this.mediaLibraryPlaceholderLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mediaLibraryPlaceholderLabel.AutoSize = true;
            this.mediaLibraryPlaceholderLabel.Location = new System.Drawing.Point(3, 393);
            this.mediaLibraryPlaceholderLabel.Name = "mediaLibraryPlaceholderLabel";
            this.mediaLibraryPlaceholderLabel.Size = new System.Drawing.Size(197, 13);
            this.mediaLibraryPlaceholderLabel.TabIndex = 2;
            this.mediaLibraryPlaceholderLabel.Text = "One day, the Media Library will live here.";
            this.mediaLibraryPlaceholderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playlistDataGridView
            // 
            this.playlistDataGridView.AllowUserToAddRows = false;
            this.playlistDataGridView.AllowUserToResizeRows = false;
            this.playlistDataGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.playlistDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.playlistDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.playlistDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.playlistDataGridView.ColumnHeadersVisible = false;
            this.playlistDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playlistDataGridView.Location = new System.Drawing.Point(0, 0);
            this.playlistDataGridView.MultiSelect = false;
            this.playlistDataGridView.Name = "playlistDataGridView";
            this.playlistDataGridView.ReadOnly = true;
            this.playlistDataGridView.RowHeadersVisible = false;
            this.playlistDataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.playlistDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.playlistDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.playlistDataGridView.Size = new System.Drawing.Size(231, 415);
            this.playlistDataGridView.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 532);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.transportPanel);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Sharpler";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.transportPanel.ResumeLayout(false);
            this.transportPanel.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.playlistDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label trackNameLabel;
        private System.Windows.Forms.Button selectFileButton;
        private System.Windows.Forms.Button playPauseButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.OpenFileDialog selectFileDialog;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label currentTimeLabel;
        private System.Windows.Forms.Label durationLabel;
        private System.Windows.Forms.Panel transportPanel;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label mediaLibraryPlaceholderLabel;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.DataGridView playlistDataGridView;
    }
}


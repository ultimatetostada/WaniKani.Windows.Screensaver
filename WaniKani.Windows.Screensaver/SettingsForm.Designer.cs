namespace WaniKani.Windows.Screensaver
{
    partial class SettingsForm
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
            this.lblAppName = new System.Windows.Forms.Label();
            this.lblApiKey = new System.Windows.Forms.Label();
            this.txtApiKey = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.lblMaxLeeches = new System.Windows.Forms.Label();
            this.txtMaxLeeches = new System.Windows.Forms.TextBox();
            this.txtScoreThreshold = new System.Windows.Forms.TextBox();
            this.lblScoreThreshold = new System.Windows.Forms.Label();
            this.txtDisplayInterval = new System.Windows.Forms.TextBox();
            this.lblDisplayInterval = new System.Windows.Forms.Label();
            this.lblCalculationType = new System.Windows.Forms.Label();
            this.lblScreensaverType = new System.Windows.Forms.Label();
            this.cboCalculationType = new System.Windows.Forms.ComboBox();
            this.cboScreensaverType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblAppName
            // 
            this.lblAppName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppName.Location = new System.Drawing.Point(13, 13);
            this.lblAppName.Name = "lblAppName";
            this.lblAppName.Size = new System.Drawing.Size(259, 23);
            this.lblAppName.TabIndex = 0;
            this.lblAppName.Text = "WaniKani Leeches Screensaver";
            this.lblAppName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblApiKey
            // 
            this.lblApiKey.AutoSize = true;
            this.lblApiKey.Location = new System.Drawing.Point(12, 65);
            this.lblApiKey.Name = "lblApiKey";
            this.lblApiKey.Size = new System.Drawing.Size(48, 13);
            this.lblApiKey.TabIndex = 1;
            this.lblApiKey.Text = "API Key:";
            // 
            // txtApiKey
            // 
            this.txtApiKey.Location = new System.Drawing.Point(12, 81);
            this.txtApiKey.Name = "txtApiKey";
            this.txtApiKey.Size = new System.Drawing.Size(260, 20);
            this.txtApiKey.TabIndex = 2;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(188, 265);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblMaxLeeches
            // 
            this.lblMaxLeeches.AutoSize = true;
            this.lblMaxLeeches.Location = new System.Drawing.Point(14, 174);
            this.lblMaxLeeches.Name = "lblMaxLeeches";
            this.lblMaxLeeches.Size = new System.Drawing.Size(74, 13);
            this.lblMaxLeeches.TabIndex = 5;
            this.lblMaxLeeches.Text = "Max Leeches:";
            // 
            // txtMaxLeeches
            // 
            this.txtMaxLeeches.Location = new System.Drawing.Point(142, 170);
            this.txtMaxLeeches.MaxLength = 3;
            this.txtMaxLeeches.Name = "txtMaxLeeches";
            this.txtMaxLeeches.Size = new System.Drawing.Size(49, 20);
            this.txtMaxLeeches.TabIndex = 6;
            // 
            // txtScoreThreshold
            // 
            this.txtScoreThreshold.Location = new System.Drawing.Point(142, 196);
            this.txtScoreThreshold.Name = "txtScoreThreshold";
            this.txtScoreThreshold.Size = new System.Drawing.Size(49, 20);
            this.txtScoreThreshold.TabIndex = 7;
            // 
            // lblScoreThreshold
            // 
            this.lblScoreThreshold.AutoSize = true;
            this.lblScoreThreshold.Location = new System.Drawing.Point(14, 200);
            this.lblScoreThreshold.Name = "lblScoreThreshold";
            this.lblScoreThreshold.Size = new System.Drawing.Size(88, 13);
            this.lblScoreThreshold.TabIndex = 8;
            this.lblScoreThreshold.Text = "Score Threshold:";
            // 
            // txtDisplayInterval
            // 
            this.txtDisplayInterval.Location = new System.Drawing.Point(142, 222);
            this.txtDisplayInterval.Name = "txtDisplayInterval";
            this.txtDisplayInterval.Size = new System.Drawing.Size(49, 20);
            this.txtDisplayInterval.TabIndex = 9;
            // 
            // lblDisplayInterval
            // 
            this.lblDisplayInterval.AutoSize = true;
            this.lblDisplayInterval.Location = new System.Drawing.Point(14, 226);
            this.lblDisplayInterval.Name = "lblDisplayInterval";
            this.lblDisplayInterval.Size = new System.Drawing.Size(82, 13);
            this.lblDisplayInterval.TabIndex = 10;
            this.lblDisplayInterval.Text = "Display Interval:";
            // 
            // lblCalculationType
            // 
            this.lblCalculationType.AutoSize = true;
            this.lblCalculationType.Location = new System.Drawing.Point(14, 147);
            this.lblCalculationType.Name = "lblCalculationType";
            this.lblCalculationType.Size = new System.Drawing.Size(89, 13);
            this.lblCalculationType.TabIndex = 11;
            this.lblCalculationType.Text = "Calculation Type:";
            // 
            // lblScreensaverType
            // 
            this.lblScreensaverType.AutoSize = true;
            this.lblScreensaverType.Location = new System.Drawing.Point(12, 120);
            this.lblScreensaverType.Name = "lblScreensaverType";
            this.lblScreensaverType.Size = new System.Drawing.Size(97, 13);
            this.lblScreensaverType.TabIndex = 12;
            this.lblScreensaverType.Text = "Screensaver Type:";
            // 
            // cboCalculationType
            // 
            this.cboCalculationType.FormattingEnabled = true;
            this.cboCalculationType.Location = new System.Drawing.Point(142, 143);
            this.cboCalculationType.Name = "cboCalculationType";
            this.cboCalculationType.Size = new System.Drawing.Size(121, 21);
            this.cboCalculationType.TabIndex = 13;
            // 
            // cboScreensaverType
            // 
            this.cboScreensaverType.FormattingEnabled = true;
            this.cboScreensaverType.Location = new System.Drawing.Point(142, 116);
            this.cboScreensaverType.Name = "cboScreensaverType";
            this.cboScreensaverType.Size = new System.Drawing.Size(121, 21);
            this.cboScreensaverType.TabIndex = 14;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 305);
            this.Controls.Add(this.cboScreensaverType);
            this.Controls.Add(this.cboCalculationType);
            this.Controls.Add(this.lblScreensaverType);
            this.Controls.Add(this.lblCalculationType);
            this.Controls.Add(this.lblDisplayInterval);
            this.Controls.Add(this.txtDisplayInterval);
            this.Controls.Add(this.lblScoreThreshold);
            this.Controls.Add(this.txtScoreThreshold);
            this.Controls.Add(this.txtMaxLeeches);
            this.Controls.Add(this.lblMaxLeeches);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtApiKey);
            this.Controls.Add(this.lblApiKey);
            this.Controls.Add(this.lblAppName);
            this.Name = "SettingsForm";
            this.Text = "SettingsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAppName;
        private System.Windows.Forms.Label lblApiKey;
        private System.Windows.Forms.TextBox txtApiKey;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label lblMaxLeeches;
        private System.Windows.Forms.TextBox txtMaxLeeches;
        private System.Windows.Forms.TextBox txtScoreThreshold;
        private System.Windows.Forms.Label lblScoreThreshold;
        private System.Windows.Forms.TextBox txtDisplayInterval;
        private System.Windows.Forms.Label lblDisplayInterval;
        private System.Windows.Forms.Label lblCalculationType;
        private System.Windows.Forms.Label lblScreensaverType;
        private System.Windows.Forms.ComboBox cboCalculationType;
        private System.Windows.Forms.ComboBox cboScreensaverType;
    }
}
namespace WaniKani.Windows.Screensaver
{
    partial class HitechbunnyScreenSaverForm
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
            this.lblCharacter = new System.Windows.Forms.Label();
            this.lblMeaning = new System.Windows.Forms.Label();
            this.lblReading = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCharacter
            // 
            this.lblCharacter.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharacter.ForeColor = System.Drawing.Color.White;
            this.lblCharacter.Location = new System.Drawing.Point(38, 326);
            this.lblCharacter.Name = "lblCharacter";
            this.lblCharacter.Size = new System.Drawing.Size(80, 70);
            this.lblCharacter.TabIndex = 1;
            this.lblCharacter.Text = "外れる";
            this.lblCharacter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCharacter.Visible = false;
            // 
            // lblMeaning
            // 
            this.lblMeaning.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeaning.ForeColor = System.Drawing.Color.White;
            this.lblMeaning.Location = new System.Drawing.Point(248, 366);
            this.lblMeaning.Name = "lblMeaning";
            this.lblMeaning.Size = new System.Drawing.Size(40, 35);
            this.lblMeaning.TabIndex = 3;
            this.lblMeaning.Text = "To be disconnected";
            this.lblMeaning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMeaning.Visible = false;
            // 
            // lblReading
            // 
            this.lblReading.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReading.ForeColor = System.Drawing.Color.White;
            this.lblReading.Location = new System.Drawing.Point(38, 286);
            this.lblReading.Name = "lblReading";
            this.lblReading.Size = new System.Drawing.Size(40, 35);
            this.lblReading.TabIndex = 2;
            this.lblReading.Text = "はずれる";
            this.lblReading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblReading.Visible = false;
            // 
            // HitechbunnyScreenSaverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.lblMeaning);
            this.Controls.Add(this.lblCharacter);
            this.Controls.Add(this.lblReading);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HitechbunnyScreenSaverForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "HitechbunnyScreenSaverForm";
            this.Load += new System.EventHandler(this.HitechbunnyScreenSaverForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HitechbunnyScreenSaverForm_KeyPress);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.HitechbunnyScreenSaverForm_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.HitechbunnyScreenSaverForm_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblCharacter;
        private System.Windows.Forms.Label lblMeaning;
        private System.Windows.Forms.Label lblReading;
    }
}
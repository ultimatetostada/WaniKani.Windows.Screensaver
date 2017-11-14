namespace WaniKani.Windows.Screensaver
{
    partial class ScreenSaverForm
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
            this.components = new System.ComponentModel.Container();
            this.lblText = new System.Windows.Forms.Label();
            this.moveTimer = new System.Windows.Forms.Timer(this.components);
            this.lblCharacter = new System.Windows.Forms.Label();
            this.lblReading = new System.Windows.Forms.Label();
            this.lblMeaning = new System.Windows.Forms.Label();
            this.pnlCharacter = new System.Windows.Forms.Panel();
            this.pnlCharacter.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.ForeColor = System.Drawing.Color.Red;
            this.lblText.Location = new System.Drawing.Point(12, 9);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(469, 37);
            this.lblText.TabIndex = 0;
            this.lblText.Text = "WaniKani Leeches Screensaver";
            // 
            // moveTimer
            // 
            this.moveTimer.Tick += new System.EventHandler(this.moveTimer_Tick);
            // 
            // lblCharacter
            // 
            this.lblCharacter.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharacter.ForeColor = System.Drawing.Color.White;
            this.lblCharacter.Location = new System.Drawing.Point(0, 0);
            this.lblCharacter.Name = "lblCharacter";
            this.lblCharacter.Size = new System.Drawing.Size(400, 80);
            this.lblCharacter.TabIndex = 1;
            this.lblCharacter.Text = "外れる";
            this.lblCharacter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCharacter.Visible = false;
            // 
            // lblReading
            // 
            this.lblReading.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReading.ForeColor = System.Drawing.Color.White;
            this.lblReading.Location = new System.Drawing.Point(0, 80);
            this.lblReading.Name = "lblReading";
            this.lblReading.Size = new System.Drawing.Size(400, 40);
            this.lblReading.TabIndex = 2;
            this.lblReading.Text = "はずれる";
            this.lblReading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblReading.Visible = false;
            // 
            // lblMeaning
            // 
            this.lblMeaning.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMeaning.ForeColor = System.Drawing.Color.White;
            this.lblMeaning.Location = new System.Drawing.Point(0, 120);
            this.lblMeaning.Name = "lblMeaning";
            this.lblMeaning.Size = new System.Drawing.Size(400, 40);
            this.lblMeaning.TabIndex = 3;
            this.lblMeaning.Text = "To be disconnected";
            this.lblMeaning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMeaning.Visible = false;
            // 
            // pnlCharacter
            // 
            this.pnlCharacter.Controls.Add(this.lblCharacter);
            this.pnlCharacter.Controls.Add(this.lblMeaning);
            this.pnlCharacter.Controls.Add(this.lblReading);
            this.pnlCharacter.Location = new System.Drawing.Point(198, 81);
            this.pnlCharacter.Name = "pnlCharacter";
            this.pnlCharacter.Size = new System.Drawing.Size(400, 160);
            this.pnlCharacter.TabIndex = 4;
            // 
            // ScreenSaverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.pnlCharacter);
            this.Controls.Add(this.lblText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ScreenSaverForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "WaniKani Leeches Screensaver";
            this.Load += new System.EventHandler(this.ScreenSaverForm_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ScreenSaverForm_KeyPress);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ScreenSaverForm_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ScreenSaverForm_MouseMove);
            this.pnlCharacter.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Timer moveTimer;
        private System.Windows.Forms.Label lblCharacter;
        private System.Windows.Forms.Label lblReading;
        private System.Windows.Forms.Label lblMeaning;
        private System.Windows.Forms.Panel pnlCharacter;
    }
}


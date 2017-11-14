using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WaniKani.Windows.Screensaver.Enum;
using WaniKani.Windows.Screensaver.Interface;
using WaniKani.Windows.Screensaver.Util;

namespace WaniKani.Windows.Screensaver
{
    public partial class ScreenSaverForm : Form, ICharacterManagerSubscriber
    {
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll")]
        static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        static extern bool GetClientRect(IntPtr hWnd, out Rectangle lpRect);

        private Point _mouseLocation;
        private Random _rand = new Random();
        private bool _previewMode = false;

        private bool _isParent;

        public ScreenSaverForm()
        {
            InitializeComponent();
        }

        public ScreenSaverForm(Rectangle Bounds, bool IsParent)
        {
            InitializeComponent();
            this.Bounds = Bounds;
            this._isParent = IsParent;
        }

        public ScreenSaverForm(IntPtr PreviewWndHandle)
        {
            InitializeComponent();

            // Set the preview window as the parent of this window
            SetParent(this.Handle, PreviewWndHandle);

            // Make this a child window so it will close when the parent dialog closes
            // GWL_STYLE = -16, WS_CHILD = 0x40000000
            SetWindowLong(this.Handle, -16, new IntPtr(GetWindowLong(this.Handle, -16) | 0x40000000));

            // Place our window inside the parent
            Rectangle ParentRect;
            GetClientRect(PreviewWndHandle, out ParentRect);
            Size = ParentRect.Size;
            Location = new Point(0, 0);
            
            lblCharacter.Font = new Font(lblCharacter.Font.Name, 10);
            lblReading.Font = new Font(lblReading.Font.Name, 8);
            lblMeaning.Font = new Font(lblMeaning.Font.Name, 8);

            int quarterScreen = (int)(Size.Height * .25f);

            pnlCharacter.Size = new Size(Size.Width, Size.Height - (quarterScreen * 2));
            pnlCharacter.Location = new Point(pnlCharacter.Location.X, quarterScreen);

            lblCharacter.Width = pnlCharacter.Width;
            lblReading.Width = pnlCharacter.Width;
            lblMeaning.Width = pnlCharacter.Width;

            int third = (int)(pnlCharacter.Height * .33f);

            lblCharacter.Height = third;
            lblReading.Height = third;
            lblMeaning.Height = third;

            lblReading.Location = new Point(lblCharacter.Location.X, lblCharacter.Location.Y + lblCharacter.Height);
            lblMeaning.Location = new Point(lblReading.Location.X, lblReading.Location.Y + lblReading.Height);

            lblCharacter.TextAlign = ContentAlignment.BottomCenter;
            lblReading.TextAlign = ContentAlignment.MiddleCenter;
            lblMeaning.TextAlign = ContentAlignment.TopCenter;

            _previewMode = true;
        }

        private void ScreenSaverForm_Load(object sender, System.EventArgs e)
        {
            Cursor.Hide();
            TopMost = true;
            
            CenterCharacter();
            CharacterManager.Subscribe(this, lblCharacter, lblMeaning, lblReading, false);

            UpdateErrors();
        }

        private void ScreenSaverForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_previewMode) return;

            Application.Exit();
        }

        private void ScreenSaverForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (_previewMode) return;

            Application.Exit();
        }

        private void ScreenSaverForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (_previewMode) return;

            if (!_mouseLocation.IsEmpty)
            {
                // Terminate if mouse is moved a significant distance
                if (Math.Abs(_mouseLocation.X - e.X) > 5 ||
                    Math.Abs(_mouseLocation.Y - e.Y) > 5)
                    Application.Exit();
            }

            // Update current mouse location
            _mouseLocation = e.Location;
        }

        private void moveTimer_Tick(object sender, EventArgs e)
        {
            // Move text to new location
            lblText.Left = _rand.Next(Math.Max(1, Bounds.Width - lblText.Width));
            lblText.Top = _rand.Next(Math.Max(1, Bounds.Height - lblText.Height));
        }
        
        private void CenterCharacter()
        {
            var x = (Bounds.Width / 2) - (pnlCharacter.Width / 2);
            var y = (Bounds.Height / 2) - (pnlCharacter.Height / 2);

            var loc = new Point(x, y);
            pnlCharacter.Location = loc;
        }
        
        public void PreCharacterChange()
        {
            BackColor = DataCache.CurrentLeech.CharacterType == CharacterTypeEnum.Kanji ? WaniKaniColors.Kanji : WaniKaniColors.Vocab;
        }

        private void UpdateErrors()
        {
            lblText.Text = string.Empty;

            foreach (var error in DataCache.Errors)
            {
                lblText.Text += error + "\n";
            }
        }
    }
}

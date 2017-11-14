using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using WaniKani.Windows.Screensaver.Interface;
using WaniKani.Windows.Screensaver.Util;

namespace WaniKani.Windows.Screensaver
{
    public partial class HitechbunnyScreenSaverForm : Form, ICharacterManagerSubscriber
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

        private int _minX;
        private int _maxX;

        private int _minY;
        private int _maxY;

        public HitechbunnyScreenSaverForm()
        {
            InitializeComponent();
        }

        public HitechbunnyScreenSaverForm(Rectangle Bounds, bool IsParent)
        {
            InitializeComponent();
            this.Bounds = Bounds;
            SetMinMaxBounds();
            _isParent = IsParent;
        }

        public HitechbunnyScreenSaverForm(IntPtr PreviewWndHandle)
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

            SetMinMaxBounds();

            lblCharacter.Font = new Font(lblCharacter.Font.Name, 10);
            lblReading.Font = new Font(lblReading.Font.Name, 8);
            lblMeaning.Font = new Font(lblMeaning.Font.Name, 8);
            
            _previewMode = true;
        }

        private void HitechbunnyScreenSaverForm_Load(object sender, EventArgs e)
        {
            BackColor = Color.Black;

            Cursor.Hide();
            TopMost = true;

            CharacterManager.Subscribe(this, lblCharacter, lblMeaning, lblReading);
        }

        private void HitechbunnyScreenSaverForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_previewMode) return;

            Application.Exit();
        }

        private void HitechbunnyScreenSaverForm_MouseClick(object sender, MouseEventArgs e)
        {
            if (_previewMode) return;

            Application.Exit();
        }

        private void HitechbunnyScreenSaverForm_MouseMove(object sender, MouseEventArgs e)
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
        
        private void NextLocation()
        {
            var x = _rand.Next(this._minX, this._maxX);
            var y = _rand.Next(this._minY, this._maxY);
            lblCharacter.Location = new Point(x, y);
        }

        public void PreCharacterChange()
        {
            NextLocation();
        }

        private void SetMinMaxBounds()
        {
            _minX = (int)(Size.Width * .05f);
            _maxX = Size.Width - (int)(Size.Width * .15f);
            _minY = (int)(Size.Height * .05f);
            _maxY = Size.Height - (int)(Size.Height * .10f);
        }
    }
}

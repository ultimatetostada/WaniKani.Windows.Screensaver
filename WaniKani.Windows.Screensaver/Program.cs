using System;
using System.Windows.Forms;
using WaniKani.Windows.Screensaver.Enum;
using WaniKani.Windows.Screensaver.Util;

namespace WaniKani.Windows.Screensaver
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DataCache.Initialize();

            if (args.Length > 0)
            {
                string firstArgument = args[0].ToLower().Trim();
                string secondArgument = null;

                // Handle cases where arguments are separated by colon.
                // Examples: /c:1234567 or /P:1234567
                if (firstArgument.Length > 2)
                {
                    secondArgument = firstArgument.Substring(3).Trim();
                    firstArgument = firstArgument.Substring(0, 2);
                }
                else if (args.Length > 1)
                    secondArgument = args[1];

                if (firstArgument == "/c")           // Configuration mode
                {
                    Application.Run(new SettingsForm());
                }
                else if (firstArgument == "/p")      // Preview mode
                {
                    if (secondArgument == null)
                    {
                        MessageBox.Show("Sorry, but the expected window handle was not provided.",
                            "ScreenSaver", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    IntPtr previewWndHandle = new IntPtr(long.Parse(secondArgument));

                    switch (DataCache.Config.ScreensaverType)
                    {
                        case ScreenSaverTypeEnum.Hitechbunny:
                            Application.Run(new HitechbunnyScreenSaverForm(previewWndHandle));
                            break;
                        case ScreenSaverTypeEnum.Ultimatetostada:
                        default:
                            Application.Run(new ScreenSaverForm(previewWndHandle));
                            break;
                    }

                    Application.Run(new ScreenSaverForm(previewWndHandle));
                }
                else if (firstArgument == "/s")      // Full-screen mode
                {
                    ShowScreenSaver();
                    Application.Run();
                }
                else    // Undefined argument
                {
                    MessageBox.Show("Sorry, but the command line argument \"" + firstArgument +
                        "\" is not valid.", "ScreenSaver",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else    // No arguments - treat like /c
            {
                Application.Run(new SettingsForm());
            }
        }

        private static void ShowScreenSaver()
        {
            var count = 0;
            foreach (Screen screen in Screen.AllScreens)
            {
                var isParent = (count == 0) ? true : false;

                switch(DataCache.Config.ScreensaverType)
                {
                    case ScreenSaverTypeEnum.Ultimatetostada:
                        ScreenSaverForm screensaver = new ScreenSaverForm(screen.Bounds, isParent);
                        screensaver.Show();
                        break;
                    case ScreenSaverTypeEnum.Hitechbunny:
                        HitechbunnyScreenSaverForm htbScreensaver = new HitechbunnyScreenSaverForm(screen.Bounds, isParent);
                        htbScreensaver.Show();
                        break;
                }
                
                count += 1;
            }
        }
    }
}

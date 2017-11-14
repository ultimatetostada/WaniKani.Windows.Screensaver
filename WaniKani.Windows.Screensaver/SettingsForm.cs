using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WaniKani.Windows.Screensaver.Enum;
using WaniKani.Windows.Screensaver.Util;

namespace WaniKani.Windows.Screensaver
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            LoadComboBoxes();
            LoadSettings();
        }

        private void SaveSettings()
        {
            //NEED TO VALIDATE FORM DATA
            var config = DataCache.Config;
            config.ApiKey = txtApiKey.Text;

            int maxLeeches = 15;
            int.TryParse(txtMaxLeeches.Text, out maxLeeches);
            config.MaxLeeches = maxLeeches;

            float scoreThreshold = .99f;
            float.TryParse(txtScoreThreshold.Text, out scoreThreshold);
            config.ScoreThreshold = scoreThreshold;

            int displayInterval = 4000;
            int.TryParse(txtDisplayInterval.Text, out displayInterval);
            config.DisplayInterval = displayInterval;

            int calcType = 0;
            int.TryParse(cboCalculationType.SelectedValue.ToString(), out calcType);
            config.LeechCalculationType = (LeechCalculationTypeEnum)calcType;

            int screensaverType = 0;
            int.TryParse(cboScreensaverType.SelectedValue.ToString(), out screensaverType);
            config.ScreensaverType = (ScreenSaverTypeEnum)screensaverType;

            DataCache.SaveConfig(config);
        }

        private void LoadSettings()
        {
            txtApiKey.Text = DataCache.Config.ApiKey;
            txtMaxLeeches.Text = DataCache.Config.MaxLeeches.ToString();
            txtScoreThreshold.Text = DataCache.Config.ScoreThreshold.ToString();
            txtDisplayInterval.Text = DataCache.Config.DisplayInterval.ToString();
            cboCalculationType.SelectedValue = (int)DataCache.Config.LeechCalculationType;
            cboScreensaverType.SelectedValue = (int)DataCache.Config.ScreensaverType;
        }

        public void LoadComboBoxes()
        {
            cboCalculationType.DataSource = new BindingSource(CalculationTypeItems, null);
            cboCalculationType.DisplayMember = "Value";
            cboCalculationType.ValueMember = "Key";

            cboScreensaverType.DataSource = new BindingSource(ScreensaverTypeItems, null);
            cboScreensaverType.DisplayMember = "Value";
            cboScreensaverType.ValueMember = "Key";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Close();
        }

        private Dictionary<int, string> ScreensaverTypeItems
        {
            get
            {
                var items = new Dictionary<int, string>();
                items.Add(0, "Ultimatetostada");
                items.Add(1, "Hitechbunny");
                return items;
            }
        }

        private Dictionary<int, string> CalculationTypeItems
        {
            get
            {
                var items = new Dictionary<int, string>();
                items.Add(0, "Leech Detector");
                items.Add(1, "Hitechbunny");
                return items;
            }
        }
    }
}

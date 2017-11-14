using System;
using WaniKani.Windows.Screensaver.Enum;

namespace WaniKani.Windows.Screensaver.DTO
{
    public class ConfigurationDTO
    {
        public string ApiKey { get; set; }
        public int MaxLeeches { get; set; }
        public float ScoreThreshold { get; set; }
        public int DisplayInterval { get; set; }
        public LeechCalculationTypeEnum LeechCalculationType { get; set; }
        public ScreenSaverTypeEnum ScreensaverType { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}

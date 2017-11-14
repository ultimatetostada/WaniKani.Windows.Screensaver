using WaniKani.Windows.Screensaver.Enum;

namespace WaniKani.Windows.Screensaver.DTO
{
    public class LeechScoreResultDTO
    {
        public string Character { get; set; }
        public string[] Readings { get; set; }
        public string[] Meanings { get; set; }
        public int Level { get; set; }
        public string Type { get; set; }
        public float Score { get; set; }
        public CharacterTypeEnum CharacterType { get; set; }
    }
}

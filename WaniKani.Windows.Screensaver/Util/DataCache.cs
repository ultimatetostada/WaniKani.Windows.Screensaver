using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WaniKani.Windows.Screensaver.DTO;
using WaniKani.Windows.Screensaver.Enum;

namespace WaniKani.Windows.Screensaver.Util
{
    public static class DataCache
    {
        public static ConfigurationDTO Config { get; private set; }
        public static List<LeechScoreResultDTO> Leeches { get; private set; }
        public static LeechScoreResultDTO CurrentLeech { get { return Leeches[CurrentLeechIndex]; } }
        public static List<string> Errors { get; private set; }

        private static int CurrentLeechIndex = 0;
        private static string AppPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "WaniKaniScreensaver");
        private static string ConfigFileName = "config.json";
        private static string LeechesFileName = "leeches.json";
        private static string ConfigFilePath = Path.Combine(AppPath, ConfigFileName);
        private static string LeechesFilePath = Path.Combine(AppPath, LeechesFileName);
        private static Random Rand = new Random();

        public static void Initialize()
        {
            //if the directory doesn't exist, create all dummy data
            if (!Directory.Exists(AppPath))
                InitializeAppData();

            Config = LoadConfig();
            Leeches = LoadLeechesFile();

            Errors = new List<string>();

            if (!string.IsNullOrWhiteSpace(Config.ApiKey))
            {
                var leechUpdate = GetLeechData(Config.ApiKey);
                SaveLeechesFile(leechUpdate);
            }

            Leeches.Shuffle(Rand);
        }

        private static void InitializeAppData()
        {
            Directory.CreateDirectory(AppPath);
            CreateConfig();
            CreateLeechesFile();
        }

        private static List<LeechScoreResultDTO> UniqueByScore(this List<LeechScoreResultDTO> leeches)
        {
            var final = new List<LeechScoreResultDTO>();
            foreach (var leech in leeches)
            {
                var existing = final.SingleOrDefault(o => o.Character == leech.Character);
                if (existing == null)
                    final.Add(leech);
                else if (leech.Score > existing.Score)
                    existing = leech;
            }
            return final;
        }

        private static ConfigurationDTO CreateConfig(bool overwrite = false)
        {
            //check if exists
            if (File.Exists(ConfigFilePath) && !overwrite) return LoadConfig();

            var config = new ConfigurationDTO()
            {
                ApiKey = string.Empty,
                MaxLeeches = 10,
                ScoreThreshold = 0.99f,
                DisplayInterval = 5000,
                LeechCalculationType = LeechCalculationTypeEnum.Hitechbunny,
                ScreensaverType = ScreenSaverTypeEnum.Hitechbunny,
                LastUpdated = DateTime.Now,
            };

            SaveConfig(config);

            return config;
        }

        private static ConfigurationDTO LoadConfig(bool overwrite = false)
        {
            if (!File.Exists(ConfigFilePath)) return CreateConfig();

            var json = File.ReadAllText(ConfigFilePath);
            var config = JsonConvert.DeserializeObject<ConfigurationDTO>(json);

            if (config == null || (string.IsNullOrWhiteSpace(config.ApiKey) && config.MaxLeeches == 0)) return CreateConfig(true);

            return config;
        }

        public static void SaveConfig(ConfigurationDTO config)
        {
            var json = JsonConvert.SerializeObject(config, Formatting.Indented);
            File.WriteAllText(ConfigFilePath, json);
        }

        private static List<LeechScoreResultDTO> CreateLeechesFile(bool overwrite = false)
        {
            if (File.Exists(LeechesFilePath) && !overwrite) return LoadLeechesFile();
            
            var leech = new LeechScoreResultDTO()
            {
                Character = "外れる",
                Readings = new string[] { "はずれる" },
                Meanings = new string[] { "to be disconnected", "to come off", "to be out", "to be off" },
                Level = 3,
                Type = "Reading",
                Score = 7,
                CharacterType = CharacterTypeEnum.Vocab
            };

            var leeches = new List<LeechScoreResultDTO>() { leech };

            SaveLeechesFile(leeches);

            return leeches;
        }

        private static List<LeechScoreResultDTO> LoadLeechesFile()
        {
            if (!File.Exists(LeechesFilePath)) return CreateLeechesFile();

            var json = File.ReadAllText(LeechesFilePath);
            var leeches = JsonConvert.DeserializeObject<List<LeechScoreResultDTO>>(json);

            //if they manually deleted the data, there may be nothing in the file...
            if (leeches == null || leeches.Count == 0) return CreateLeechesFile(true);

            return leeches;
        }

        private static void SaveLeechesFile(List<LeechScoreResultDTO> leeches)
        {
            //Don't overwrite their existing leech data if leeches is empty
            if (leeches.Count == 0) return;

            var json = JsonConvert.SerializeObject(leeches, Formatting.Indented);
            File.WriteAllText(LeechesFilePath, json);
        }

        private static List<LeechScoreResultDTO> GetLeechData(string apiKey)
        {
            var output = new List<LeechScoreResultDTO>();

            //load initial data
            try
            {
                var client = new WaniKaniApi.WaniKaniClient(apiKey);

                //get user current level
                var userInfo = client.GetUserInformation();
                var levels = new int[userInfo.Level];

                for (int i = 0; i < levels.Length; i++)
                {
                    levels[i] = i + 1;
                }

                var kanji = client.GetKanji(levels);
                var kScores = WaniKaniApiSharpExtensions.GenerateLeechScores(kanji)
                    .Where(o => o.Score > Config.ScoreThreshold)
                    .ToList()
                    .UniqueByScore();

                var vocab = client.GetVocabulary(levels);
                var vScores = WaniKaniApiSharpExtensions.GenerateLeechScores(vocab)
                    .Where(o => o.Score > Config.ScoreThreshold)
                    .ToList()
                    .UniqueByScore();

                var allLeech = kScores.Union(vScores).OrderByDescending(o => o.Score).Take(Config.MaxLeeches);

                output = allLeech.ToList();
            }
            catch
            {
                //build up list of errors to show as string
                //dont' want to overwrite any existing data if new data
                //can't be fetched.
                Errors.Add("ERROR: There was a problem updating your leech data.");
            }
            
            return output;
        }

        public static void NextLeech()
        {
            CurrentLeechIndex += 1;
            if (CurrentLeechIndex == Leeches.Count)
            {
                Leeches.Shuffle(Rand);
                CurrentLeechIndex = 0;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using WaniKani.Windows.Screensaver.DTO;
using WaniKani.Windows.Screensaver.Enum;
using WaniKaniApi.Models;

namespace WaniKani.Windows.Screensaver.Util
{
    public static class WaniKaniApiSharpExtensions
    {
        public static List<LeechScoreResultDTO> GenerateLeechScores<T>(List<T> data)
        {
            if (data is List<WaniKaniKanjiItem>)
            {
                return GenerateLeechScoresKanji(data as List<WaniKaniKanjiItem>);
            }
            else if (data is List<WaniKaniVocabularyItem>)
            {
                return GenerateLeechScoresVocabulary(data as List<WaniKaniVocabularyItem>);
            }

            return new List<LeechScoreResultDTO>();
        }

        public static List<LeechScoreResultDTO> GenerateLeechScoresKanji(List<WaniKaniKanjiItem> data)
        {
            var leeches = new List<LeechScoreResultDTO>();
            var temp = data.Where(d => d.UserInfo != null);

            foreach (var item in temp)
            {
                var name = item.Character;
                var details = item.UserInfo;

                var readings = new string[0];

                switch (item.ImportantReading)
                {
                    case WaniKaniReadingType.KunYomi:
                        readings = item.KunYomi;
                        break;
                    case WaniKaniReadingType.OnYomi:
                        readings = item.OnYomi;
                        break;
                    case WaniKaniReadingType.Nanori:
                        readings = item.Nanori;
                        break;
                }

                if (details.MeaningIncorrectAnswers > 0)
                {
                    var leech = new LeechScoreResultDTO();
                    leech.Character = item.Character;
                    leech.Readings = readings;
                    leech.Meanings = item.Meanings;
                    leech.Type = "Meaning";
                    leech.Score = GetMeaningScore(details);
                    leech.CharacterType = CharacterTypeEnum.Kanji;
                    leeches.Add(leech);
                }

                if (details.ReadingIncorrectAnswers > 0)
                {
                    var leech = new LeechScoreResultDTO();
                    leech.Character = item.Character;
                    leech.Readings = readings;
                    leech.Meanings = item.Meanings;
                    leech.Type = "Reading";
                    leech.Score = GetReadingScore(details);
                    leech.CharacterType = CharacterTypeEnum.Kanji;
                    leeches.Add(leech);
                }
            }

            return leeches;
        }

        public static List<LeechScoreResultDTO> GenerateLeechScoresVocabulary(List<WaniKaniVocabularyItem> data)
        {
            var leeches = new List<LeechScoreResultDTO>();
            var temp = data.Where(d => d.UserInfo != null);

            foreach (var item in temp)
            {
                var name = item.Character;
                var details = item.UserInfo;

                if (details.MeaningIncorrectAnswers > 0)
                {
                    var leech = new LeechScoreResultDTO();
                    leech.Character = item.Character;
                    leech.Readings = item.KanaReadings;
                    leech.Meanings = item.Meanings;
                    leech.Type = "Meaning";
                    leech.Score = GetMeaningScore(details);
                    leech.CharacterType = CharacterTypeEnum.Vocab;
                    leeches.Add(leech);
                }

                if (details.ReadingIncorrectAnswers > 0)
                {
                    var leech = new LeechScoreResultDTO();
                    leech.Character = item.Character;
                    leech.Readings = item.KanaReadings;
                    leech.Meanings = item.Meanings;
                    leech.Type = "Reading";
                    leech.Score = GetReadingScore(details);
                    leech.CharacterType = CharacterTypeEnum.Vocab;
                    leeches.Add(leech);
                }
            }

            return leeches;
        }

        private static float GetMeaningScore(WaniKaniItemUserInfo item)
        {
            float score = 0f;

            switch (DataCache.Config.LeechCalculationType)
            {
                case LeechCalculationTypeEnum.Hitechbunny:
                    score = (float)item.MeaningIncorrectAnswers / ((float)Math.Pow(item.MeaningCurrentStreak, 1.5f));
                    break;
                case LeechCalculationTypeEnum.LeechDetector:
                default:
                    score = (float)item.MeaningIncorrectAnswers / (float)item.MeaningCurrentStreak;
                    break;
            }

            return score;
        }

        private static float GetReadingScore(WaniKaniItemUserInfo item)
        {
            float score = 0f;

            switch (DataCache.Config.LeechCalculationType)
            {
                case LeechCalculationTypeEnum.Hitechbunny:
                    score = (float)item.ReadingIncorrectAnswers / ((float)Math.Pow(item.ReadingCurrentStreak ?? 0, 1.5f));
                    break;
                case LeechCalculationTypeEnum.LeechDetector:
                default:
                    score = (float)item.ReadingIncorrectAnswers / (float)item.ReadingCurrentStreak;
                    break;
            }

            return score;
        }
    }
}

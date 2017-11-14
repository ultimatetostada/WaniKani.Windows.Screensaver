using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WaniKani.Windows.Screensaver.Enum;
using WaniKani.Windows.Screensaver.Interface;

namespace WaniKani.Windows.Screensaver.Util
{
    public static class CharacterManager
    {
        private static Timer _characterTimer = new Timer();
        private static List<Label> _characters = new List<Label>();
        private static List<Label> _meanings = new List<Label>();
        private static List<Label> _readings = new List<Label>();
        private static List<ICharacterManagerSubscriber> _subscribers = new List<ICharacterManagerSubscriber>();

        private static CharacterTransitionStateEnum _characterTransitionState = CharacterTransitionStateEnum.Character;

        private static bool _isRunning = false;
        private static bool _hitechbunny = true;

        public static void Subscribe(ICharacterManagerSubscriber subscriber, Label character, Label meaning, Label reading, bool hitechbunny = true)
        {
            _subscribers.Add(subscriber);
            _characters.Add(character);
            _meanings.Add(meaning);
            _readings.Add(reading);
            _hitechbunny = hitechbunny;

            if(!_isRunning)
            {
                _characterTimer.Tick += _characterTimer_Tick;

                subscriber.PreCharacterChange();
                NextCharacter(true);

                _characterTimer.Interval = DataCache.Config.DisplayInterval;
                _characterTimer.Start();
                _isRunning = true;
            }
            else
            {
                //there HAS to be one other screen since the manager is running...
                subscriber.PreCharacterChange();
                SetupCharacter(character, meaning, reading, _characters[0].BackColor);

                switch(_characterTransitionState)
                {
                    case CharacterTransitionStateEnum.Reading:
                        TransitionToCharacter();
                        break;
                    case CharacterTransitionStateEnum.Meaning:
                        TransitionToCharacter();
                        TransitionToReading();
                        break;
                    case CharacterTransitionStateEnum.Blank:
                        break;
                }
            }
        }

        private static void NextCharacter(bool preventNextLeech = false)
        {
            //needed during initialization to prevent the first item in the list from being skipped.
            //This could possibly cause the item to be missing for nearly two cycles through the list.
            if(!preventNextLeech) DataCache.NextLeech();

            var backColor = DataCache.CurrentLeech.CharacterType == CharacterTypeEnum.Kanji ? WaniKaniColors.Kanji : WaniKaniColors.Vocab;

            for (int i = 0; i < _characters.Count; i++)
            {
                SetupCharacter(_characters[i], _meanings[i], _readings[i], backColor);
            }
            
            _characterTransitionState = CharacterTransitionStateEnum.Character;
            _characterTimer.Interval = 500;
        }

        private static void _characterTimer_Tick(object sender, EventArgs e)
        {
            switch (_characterTransitionState)
            {
                case CharacterTransitionStateEnum.Character:
                    TransitionToCharacter();
                    _characterTimer.Interval = DataCache.Config.DisplayInterval;
                    break;
                case CharacterTransitionStateEnum.Reading:
                    TransitionToReading();
                    break;
                case CharacterTransitionStateEnum.Meaning:
                    TransitionToMeaning();
                    break;
                case CharacterTransitionStateEnum.Blank:
                    TransitionToBlank();

                    PreCharacterChange();
                    NextCharacter();

                    _characterTransitionState = CharacterTransitionStateEnum.Character;
                    _characterTimer.Interval = 500;
                    break;
            }
        }

        private static void PreCharacterChange()
        {
            _subscribers.ForEach(o => o.PreCharacterChange());
        }

        private static void TransitionToCharacter()
        {
            _characters.ForEach(o => o.Visible = true);
            _characterTransitionState = CharacterTransitionStateEnum.Reading;
        }

        private static void TransitionToReading()
        {
            _readings.ForEach(o => o.Visible = true);
            _characterTransitionState = CharacterTransitionStateEnum.Meaning;
        }

        private static void TransitionToMeaning()
        {
            _meanings.ForEach(o => o.Visible = true);
            _characterTransitionState = CharacterTransitionStateEnum.Blank;
        }

        private static void TransitionToBlank()
        {
            _characters.ForEach(o => o.Visible = false);
            _readings.ForEach(o => o.Visible = false);
            _meanings.ForEach(o => o.Visible = false);
        }

        private static void SetupCharacter(Label character, Label meaning, Label reading, Color backColor)
        {
            character.Text = DataCache.CurrentLeech.Character;
            
            if (_hitechbunny)
            {
                character.BackColor = backColor;
                character.AutoSize = true;
            }
            
            reading.Text = DataCache.CurrentLeech.Readings[0];

            if(_hitechbunny)
            {
                reading.Location = new Point(character.Location.X, character.Location.Y - reading.Height);
                reading.Width = character.Width;
            }
            
            meaning.Text = DataCache.CurrentLeech.Meanings[0];

            if(_hitechbunny)
            {
                meaning.AutoSize = true;
                meaning.Location = new Point(character.Location.X + character.Width, character.Location.Y + (character.Height / 2) - (meaning.Height / 2));
            }
        }
    }
}

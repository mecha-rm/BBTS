

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BBTS
{
    public class SettingsMenu : MonoBehaviour
    {
        // the game settings object.
        public GameSettings gameSettings;

        // The title for the game.
        public TMPro.TMP_Text titleText;

        // The text for the back button.
        public TMPro.TMP_Text backButtonText;

        [Header("Volume")]

        // BGM
        // The bgm volume slider.
        public Slider bgmVolumeSlider;

        // The title text for the bgm slider.
        public TMPro.TMP_Text bgmLabelText;

        // SFX
        // The sound effect slider.
        public Slider sfxVolumeSlider;
        
        // The title for the sfx slider.
        public TMPro.TMP_Text sfxLabelText;

        // TTS
        // The tts volume slider.
        public Slider ttsVolumeSlider;

        // The title text for the tts slider.
        public TMPro.TMP_Text ttsLabelText;


        [Header("Misc")]
        // the toggle for the mute toggle.
        public Toggle muteToggle;

        // The text for the mute toggle.
        public TMPro.TMP_Text muteLabel;

        // the toggle for the text-to-speech toggle.
        public Toggle textToSpeechToggle;

        // The text for the text to speech toggle.
        public TMPro.TMP_Text textToSpeechLabel;

        // the tutorial toggle.
        public Toggle tutorialToggle;

        // The text for the text to speech toggle.
        public TMPro.TMP_Text tutorialLabel;

        // Start is called before the first frame update
        void Start()
        {
            // Save the instance.
            gameSettings = GameSettings.Instance;

            // Current bgm volume setting.
            bgmVolumeSlider.value = gameSettings.BgmVolume;

            // // Listener for the bgm slider.
            // bgmVolumeSlider.onValueChanged.AddListener(delegate
            // {
            //     OnBgmVolumeChange(bgmVolumeSlider);
            // });

            // Current sfx volume setting.
            sfxVolumeSlider.value = gameSettings.SfxVolume;

            // // Listener for the sfx slider.
            // sfxVolumeSlider.onValueChanged.AddListener(delegate
            // {
            //     OnSfxVolumeChange(sfxVolumeSlider);
            // });

            // Current tts volume setting.
            ttsVolumeSlider.value = gameSettings.TtsVolume;

            // Current muted setting.
            muteToggle.isOn = gameSettings.Mute;

            // Current text-to-speech tutorial.
            textToSpeechToggle.isOn = gameSettings.UseTextToSpeech;

            // // Listener for the text-to-speech.
            // textToSpeechToggle.onValueChanged.AddListener(delegate
            // {
            //     OnTextToSpeechChange(textToSpeechToggle);
            // });

            // Current tutorial toggle setting.
            tutorialToggle.isOn = gameSettings.UseTutorial;

            // // Listener for the tutorial toggle.
            // tutorialToggle.onValueChanged.AddListener(delegate
            // {
            //     OnTutorialChange(tutorialToggle);
            // });


            // No SDK, so disable these functions.
            ttsVolumeSlider.interactable = false;
            textToSpeechToggle.interactable = false;

            // Translate the dialogue - NO LONGER DOES ANYTHING.
            LanguageManager lm = LanguageManager.Instance;

            // Translate the dialogue.
            if (lm.TranslateAndLanguageSet())
            {
                titleText.text = lm.GetLanguageText("kwd_settings");
                bgmLabelText.text = lm.GetLanguageText("kwd_bgmVolume");
                sfxLabelText.text = lm.GetLanguageText("kwd_sfxVolume");
                ttsLabelText.text = lm.GetLanguageText("kwd_ttsVolume");

                muteLabel.text = lm.GetLanguageText("kwd_mute");
                textToSpeechLabel.text = lm.GetLanguageText("kwd_textToSpeech");
                tutorialLabel.text = lm.GetLanguageText("kwd_tutorial");
                backButtonText.text = lm.GetLanguageText("kwd_back");
            }
            else
            {
                lm.MarkText(titleText);
                lm.MarkText(bgmLabelText);
                lm.MarkText(sfxLabelText);
                lm.MarkText(ttsLabelText);

                lm.MarkText(muteLabel);
                lm.MarkText(textToSpeechLabel);
                lm.MarkText(tutorialLabel);
                lm.MarkText(backButtonText);
            }
        }

        // This function is called when the object becomes enabled and active
        private void OnEnable()
        {
            gameSettings = GameSettings.Instance;
        }

        public void OnTextSpeechChange()
        {
            OnTextToSpeechChange(textToSpeechToggle);
        }

        // On the mute changes.
        public void OnMuteChange(Toggle toggle)
        {
            gameSettings.Mute = toggle.isOn;
        }

        // On the text-to-speech changes.
        public void OnTextToSpeechChange(Toggle toggle)
        {
            gameSettings.UseTextToSpeech = toggle.isOn;

            // NO TTS
        }

        // On the tutorial changes.
        public void OnTutorialChange(Toggle toggle)
        {
            gameSettings.UseTutorial = toggle.isOn;
        }

        // On the bgm volume change.
        public void OnBgmVolumeChange(Slider slider)
        {
            gameSettings.BgmVolume = Mathf.InverseLerp(slider.minValue, slider.maxValue, slider.value);
        }

        // On the sfx volume change.
        public void OnSfxVolumeChange(Slider slider)
        {
            gameSettings.SfxVolume = Mathf.InverseLerp(slider.minValue, slider.maxValue, slider.value);
        }

        // On the tts volume change.
        public void OnTtsVolumeChange(Slider slider)
        {
            gameSettings.TtsVolume = Mathf.InverseLerp(slider.minValue, slider.maxValue, slider.value);
        }
    }
}
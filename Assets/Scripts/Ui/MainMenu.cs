using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : UiTextLines
{
    [SerializeField] GameObject _settingsPanel;
    [SerializeField] Slider _soundVolumeSlider;
    [SerializeField] Slider _musicVolumeSlider;
    [SerializeField] Text _settingsTitle;
    [SerializeField] Text _soundVolumeText;
    [SerializeField] Text _musicVolumeText;
    [SerializeField] Text _title;
    [SerializeField] Text _startGameText;
    [SerializeField] Text _gameSettingsText;
    [SerializeField] Text _exitGameText;

    // Start is called before the first frame update
    public override void Start()
    {
        _settingsTitle.text = GetTranslation("Ui_SettingsTitle");
        _soundVolumeText.text = GetTranslation("Ui_SoundVolumeText");
        _musicVolumeText.text = GetTranslation("Ui_MusicVolumeText");
        _title.text = GetTranslation("Ui_Title");
        _gameSettingsText.text = GetTranslation("Ui_GameSettings");
        _exitGameText.text = GetTranslation("Ui_ExitGame");
        if(Game.HasSaveFile())
        {
            _startGameText.text = GetTranslation("Ui_ContinueGame");
        }
        else
        {
            _startGameText.text = GetTranslation("Ui_NewGame");
        }
        _soundVolumeSlider.value = Game.Settings.SoundVolume;
        _musicVolumeSlider.value = Game.Settings.MusicVolume;
       // _menuPanel.SetActive(false);
        _settingsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnStartGameButton()
    {
        if (Game.HasSaveFile())
        {
            Game.LoadGame();
        }
        else
        {
            Game.StartGame();
        }
        SceneManager.LoadScene(1);
    }
    public void OnSettingButton()
    {
        _settingsPanel.SetActive(true);
    }
    public void OnConfirmSettingsButtom()
    {
        Game.Settings.SetMusicVolume(_musicVolumeSlider.value);
        Game.Settings.SetSoundVolume(_soundVolumeSlider.value);
        _settingsPanel.SetActive(false);
    }
    public void OnExitButton()
    {
        Application.Quit();
    }
}

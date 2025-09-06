using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    UI _ui;
    Player _player;
    Time _time;
    [SerializeField]UlpanData _ulpanData;
    //SaveData _saveData;
    [SerializeField] SaveLoad _saveLoad;



    [SerializeField]EffectsData _effectsData;
    [SerializeField]TranslationData _translationData;
    [SerializeField]AtributeData _atributeData;
    [SerializeField]ScheduleData _scheduleData;
    [SerializeField] DialogueData _dialogueData;
    [SerializeField] Settings _settings;
    GameCamera _camera;
    static Game _instance;
    string _saveFilePath;
    Ulpan _ulpan;
    List<MiniGame> _miniGames=new List<MiniGame>();
    List<Character> _characters=new List<Character>();
    List<DialogueTrigger> _dialogueTriggers=new List<DialogueTrigger>();
    Location _currentLocation;
    int _allowenceAmount;
    public Player Player { get => _player; set => _player = value; }
    public Time Time { get => _time; set => _time = value; }
    public UlpanData UlpanData { get => _ulpanData; set => _ulpanData = value; }
    //public SaveData SaveData { get => _saveData; set => _saveData = value; }
    public UI Ui { get => _ui; set => _ui = value; }
    //public Ulpan Ulpan { get => _ulpan; set => _ulpan = value; }
    public List<MiniGame> MiniGames { get => _miniGames; set => _miniGames = value; }
    public List<Character> Characters { get => _characters; set => _characters = value; }
    public TranslationData TranslationData { get => _translationData; set => _translationData = value; }
    public AtributeData AtributeData { get => _atributeData; set => _atributeData = value; }
    public ScheduleData ScheduleData { get => _scheduleData; set => _scheduleData = value; }
    public Location CurrentLocation { get => _currentLocation; set => _currentLocation = value; }
    public List<DialogueTrigger> DialogueTriggers { get => _dialogueTriggers; set => _dialogueTriggers = value; }
    public DialogueData DialogueData { get => _dialogueData; set => _dialogueData = value; }
    public static Game Instance { get => _instance; set => _instance = value; }
    public GameCamera Camera { get => _camera; set => _camera = value; }
    public Settings Settings { get => _settings; set => _settings = value; }


    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        _saveFilePath = Application.persistentDataPath + "/saves.MMD";
        _translationData.ParseTranslationsFromFile();
        _ulpanData.ParsefromFile();
        _effectsData.ParsefromFile();
        _scheduleData.ParseScheduleFromFile();
        _dialogueData.ParseFromFile();
        _player.Atributes = AtributeData.InitializeAtributes();
    }

/*    public Dialogue GetDialogueWithId(string id)
    {
        return _dialogueData.
    }*/
    private void Start()
    {
        Debug.Log(_saveFilePath);
        Time.OnChangingDayCallBack += NextDay;
    }
    public void Fading()
    {
        Ui.Fade();
    }
    public GameCamera GetCamera()
    {
        return _camera;
    }
    public MiniGame GetMinigameFromName(string name)
    {
        foreach(MiniGame game in MiniGames)
        {
            if(game.Name == name)
                return game;
        }
        return null;
    }

    public bool StartUlpanMinigame(Teacher teacher)
    {
        if (!_player.IsUlpanPassedToday)
        {
            _ui.ShowUlpanMinigame();
            GetMinigameFromName("Ulpan").StartGame("Ulpan");
            //_ulpan.SetTodaysWords("Ulpan");
            return true;
        }
        else
        {
            Debug.Log("Already Passed");
            teacher.SetAlreadyPassedState();
            return false;
        }
    }
    public bool StartHomeWorkMinigame(HomeWorkNotes homeWorkNotes)
    {
        if(!_player.IsHomeworkPassedToday)
        {
            if(_ulpanData.GetMistakes().Count > 4)
            {
                _ui.ShowUlpanMinigame();
                GetMinigameFromName("Ulpan").StartGame("HomeWork");
                //_ulpan.SetTodaysWords("HomeWork");
                return true;
            }
            else
            {
                homeWorkNotes.SetNotEnoughMistakesState();
                return false;
            }
        }
        else
        {
            homeWorkNotes.SetAlreadyPassedState();
            return false;
        }
    }

    public void LostAllHairs()
    {
        _player.IsUsingObject = true;
        _ui.GameOverScreens.ShowLostHairGameOver();
    }
    public void GameOver()
    {
        _player.IsUsingObject = true;
        if (_player.GetAtribute("UlpanScore").Value> UlpanData.Days*UlpanData.WordsPerDay*0.8f)
        { 
            _ui.GameOverScreens.ShowWinGameOver();
        }
        else
        {
            _ui.GameOverScreens.ShowLowScoreGameOver();
        }
    }
    public void ToTitle()
    {
        SceneManager.LoadScene(0);
    }
    public void DeleteSaveFile()
    {
        if(HasSaveFile())
        {
            File.Delete(_saveFilePath);
        }
    }
    public void GetAllowance()
    {
        _player.AddMoney(_allowenceAmount);
        _ui.UpdateUi();
    }
    public void NextDay()
    {
        //_time.NextDay();
        _player.OnDayStarted();
    }

    public Player GetPlayer()
    {
        return Player;
    }
    public void ApplyEffect(string effectName)
    {
        Dictionary<string,int> effect= _effectsData.GetEffect(effectName);
        if(effect!=null)
        {
            foreach (string atributeName in effect.Keys)
            {
                if (atributeName == "Time")
                {
                    _time.ChangeMinutesBy(effect[atributeName]);
                }
                else if (atributeName != "Money")
                {
                    //_player.GetAtribute(atributeName).ChangeValueBy(effect[atributeName]);//incorrect
                    _player.ChangeAtributeByValue(atributeName, effect[atributeName]);
                }
            }
            _ui.UpdateUi();
        }
    }
    public int GetCostForEffect(string effectName)
    {
        Dictionary<string, int> effect = _effectsData.GetEffect(effectName);
        if (effect != null)
        {
            foreach (string atributeName in effect.Keys)
            {
                if (atributeName == "Money")
                {
                    return effect[atributeName];
                }
            }
        }
        return 0;
    }
    public bool HasSaveFile()
    {

        return File.Exists(_saveFilePath);
    }
    public void StartGame()
    {
        _allowenceAmount = _player.GetAtribute("Money").Value;
        _time.SetInitialTime();
        //_ui.UpdateUi();
    }
    public void LoadGame()
    {
        Debug.Log("Load");
        SaveData data = _saveLoad.LoadData(this);
        Time.LoadTime(data.Day, data.Hour, data.Minute);
        _player.LoadAtributes(data.UlpanScore, data.HairAmount, data.EnergyLevel, data.StressLevel, data.Money,data.IsHomeWorkPasedToday,data.IsUlpanPasedToday, data.Mistakes,data.SeenDiaogues);
        UlpanData.LoadMistakes();
    }
    public void SaveGame()
    {
        UlpanData.SaveMistakes();
        _saveLoad.SaveData(this);
    }
    public string GetSaveFilePath()
    {
        return _saveFilePath;
    }
}

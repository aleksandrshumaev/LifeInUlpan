using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ulpan : MiniGame
{
    int _stressForWrongAnswer;
    List<Word> _originals=new List<Word>();
    List<Word> _translations = new List<Word>();
    List<Word> _answerPair=new List<Word>();
    //Word[] _answerPair = new Word[2];
    List<Word> _mistakes = new List<Word>();
    [SerializeField] GameObject _ulpanPanel;
    UlpanUI _ui;
    int _correctAnswers;
    bool _isHomeWork;

    private void Awake()
    {
        _ui = _ulpanPanel.GetComponent<UlpanUI>();
    }
    public override void StartGame(string name="")
    {
       
        _ulpanPanel.SetActive(true);
        base.StartGame();
        SetTodaysWords(name);
    }
    /*    private void OnEnable()
        {
            InitializeGame();
        }*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void InitializeGame()
    {
        base.InitializeGame();
        if(Game==null)
        {
            Debug.Log("game");
        }
        else if (Game.MiniGames == null)
        {
            Debug.Log("miniGames");
        }

        Game.MiniGames.Add(this);
    }
/*    protected override void OnDestroy()
    {
        Game.Ulpan = null;
    }*/
    public void SetTodaysWords(string type)
    {
        _correctAnswers=0;
        _originals.Clear();
        _translations.Clear();
        if(type=="Ulpan")
        {
            _originals = Game.UlpanData.GetOriginalsForDay(Game.Time.Day);
            _translations = Game.UlpanData.GetTranslationsForDay(Game.Time.Day);
            _isHomeWork = false;
        }
        else if(type=="HomeWork")
        {
            _originals = Game.UlpanData.GetRandomMistakes();
            _translations= Game.UlpanData.GetShuffledWordsAliases(_originals);
            _isHomeWork = true;
        }
        foreach(Word word in _originals)
        {
            word.Ulpan = this;
        }
        foreach(Word word in _translations)
        {
            word.Ulpan = this;
        }
        _ui.SetWordSlots(_originals, _translations);
    }
    public bool AddToAnswer(Word word)
    {
        if(_answerPair.Count==0)
        {
            _answerPair.Add(word);
            word.Slot.SetAsSelected();
            return true;
        }
        else if(_answerPair.Count==1)
        {
            if(_answerPair[0].Type!=word.Type)
            {
                _answerPair.Add(word);
                if(IsAnswerCorrect())
                {
                    SetAnswerAsCorrect();
                    return false;
                }
                else
                {
                    SetAnswerAsWrong();
                    return false;
                }

            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }

    }
    public bool RemoveFromAnswer(Word word)
    {
        if(_answerPair.Contains(word))
        {
            _answerPair.Remove(word);
            word.Slot.SetAsUnSelected();
            return true;
        }
        else
        {
            return false;
        }
    }
    bool IsAnswerCorrect()
    {
        if(_answerPair.Count==2)
        {
            if (_answerPair[0].Allias.Name == _answerPair[1].Allias.Name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
    void SetAnswerAsCorrect()
    {
        int originId=GetChosedOriginalId();
        int translationId=GetChosedTranslationId();
        ClearAnswerPair();
        Game.Player.ChangeUlpanScoreBy(1);
        //Game.UlpanData.RemoveFromMistakes(_originals[originId]);
        _ui.SetAsCorrectPair(originId,translationId);
        //_answerPair.Clear();
        if(_isHomeWork)
        {
            Game.UlpanData.RemoveFromMistakes(_originals[originId]);
        }
        if(_correctAnswers==_originals.Count-1)
        {
            GameFinished();
        }
        else
        {
            _correctAnswers++;
            Debug.Log(_correctAnswers+"___"+_originals.Count);
        }
    }
    void GameFinished()
    {
        _ui.ShowGameFinishPanel();
        if(_isHomeWork)
        {
            Game.Player.IsHomeworkPassedToday = true;
        }
        else
        {
            Game.Player.IsUlpanPassedToday = true;
        }
        Game.ApplyEffect("UlanEffect");
        _ulpanPanel.SetActive(false);
        Debug.Log("finished");
    }
    void SetAnswerAsWrong()
    {
        int originId = GetChosedOriginalId();
        int translationId = GetChosedTranslationId();
        ClearAnswerPair();
        Game.Player.ChangeUlpanScoreBy(-1);
        Game.Player.ChangeStressLevelBy(-_stressForWrongAnswer);
        Game.UlpanData.AddToMistakes(_originals[originId]);
        _ui.SetAsMistakePair(originId, translationId);
        Game.ApplyEffect("MistakeEffect");
    }
    void ClearAnswerPair()
    {
        int length=_answerPair.Count;
        for(int i=length-1;i>-1;i--)
        {
            _answerPair[i].UnChose();
        }
    }
    int GetChosedOriginalId()
    {
        foreach (Word word in _answerPair)
            if (word.Type == "original")
            {
                int id=_originals.IndexOf(word);
                return id;
            }
        return -1;
    }
    int GetChosedTranslationId()
    {
        foreach (Word word in _answerPair)
            if (word.Type == "translation")
            {
                int id = _translations.IndexOf(word);
                return id;
            }
        return -1;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UlpanUI : UiTextLines
{
    //Game _game;
    [SerializeField] List<WordSlot> _originalSlots = new List<WordSlot>();
    [SerializeField] List<WordSlot> _translationSlots = new List<WordSlot>();
    [SerializeField] Text _finalScoreText;
    [SerializeField]Text _score;
    [SerializeField]Text _finalScore;
    [SerializeField] GameObject _gameFinishedPanel;
    Text _lifes;
    [SerializeField]Ulpan _ulpan;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        _finalScoreText.text = GetTranslation("Ui_FinalScoreUlpanMinigame");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetWordSlots(List<Word> originals,List<Word> translations)
    {
        SetScore();
        SetOriginalSlots(originals);
        SetTranslationSlots(translations);
    }
    void SetOriginalSlots(List<Word> originals)
    {
        for(int i = 0; i < _originalSlots.Count; i++)
        {
            Debug.Log("original_" + originals[i].Name);
            //_originalSlots[i].Word=originals[i];
            _originalSlots[i].SetUp(originals[i]);
            Debug.Log("original_new_" + _originalSlots[i].Word.Name);
        }
    }
    void SetTranslationSlots(List<Word> translations)
    {
        for (int i = 0; i < _translationSlots.Count; i++)
        {
            Debug.Log("translation_" + translations[i].Name);
            _translationSlots[i].SetUp(translations[i]);
            Debug.Log("translation_new_" + _translationSlots[i].Word.Name);
        }
    }
    public void SetAsMistakePair(int originalId,int translationId)
    {
        _originalSlots[originalId].SetAsWrong();
        _translationSlots[translationId].SetAsWrong();
        SetScore();
    }
    public void SetAsCorrectPair(int originalId,int translationId)
    {
        _originalSlots[originalId].SetAsCorrect();
        _translationSlots[translationId].SetAsCorrect();
        SetScore();
    }   
    void SetScore()
    {
        _score.text = _ulpan.Game.Player.GetAtribute("UlpanScore").Value.ToString();
    }
    public void ShowGameFinishPanel()
    {
        _finalScore.text=_ulpan.Game.Player.GetAtribute("UlpanScore").Value.ToString();
        _gameFinishedPanel.SetActive(true);
    }
    public void OnConfirmGameFinishButton()
    {
        _ulpan.Game.GetPlayer().IsUsingObject = false;
        _gameFinishedPanel.SetActive(false);
        this.gameObject.SetActive(false);
    }
    void SetLifes()
    {

    }
}

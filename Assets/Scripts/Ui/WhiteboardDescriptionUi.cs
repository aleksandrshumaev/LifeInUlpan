using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhiteboardDescriptionUi : UiTextLines
{
    //[SerializeField] GameObject _wiskyDescriptionPanel;
    //[SerializeField] GameObject _bedCantUseDescriptionPanel;
    [SerializeField] GameObject _whiteboardLearningPanel;
    //[SerializeField] Text _takingFoodDescription;
    //[SerializeField] Text _bedCantUseDescription;
    [SerializeField] List<Text> _whiteboardOriginals=new List<Text>();
    [SerializeField] List<Text> _whiteboardTranslations = new List<Text>();
    Whiteboard _whiteboard;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();  
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void ShowWhiteboardPanel(Whiteboard whiteboard, string whiteboardDescription)
    {

        _whiteboard = whiteboard;
        SetTodaysWords();
        _whiteboardLearningPanel.SetActive(true);
        //_whiteboardConsumedDescription.text = GetTranslation(whiteboardDescription);
    }
    public void SetTodaysWords()
    {
        List<Word> words = _whiteboard.Game.UlpanData.GetOriginalsForDay(_whiteboard.Game.Time.GetCurrentTime().Day);
        for(int i=0; i < _whiteboardOriginals.Count; i++)
        {
            _whiteboardOriginals[i].text =GetTranslation(words[i].Name);
            _whiteboardTranslations[i].text = GetTranslation(words[i].Allias.Name);
        }
    }
    public void OnWhiteboardConfirmButton()
    {
        _whiteboardLearningPanel.SetActive(false);
        _whiteboard.OnWiskyConsumed(_whiteboard.Game.GetPlayer());
        _whiteboard = null;
    }


}

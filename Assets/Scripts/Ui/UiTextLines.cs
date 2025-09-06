using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiTextLines : MonoBehaviour
{
    Game _game;
    TranslationData _translationData;
    [SerializeField] List<Text> _confirmButtonsDescriptions=new List<Text>();
    [SerializeField] List<Text> _cancleButtonsDescriptions=new List<Text>();

    public Game Game { get => _game; set => _game = value; }

    // Start is called before the first frame update
    public virtual void Awake()
    {
        _game = GameObject.FindGameObjectWithTag("Game").GetComponent<Game>();
        _translationData = _game.TranslationData;

    }
    public virtual void Start()
    {
        foreach(Text confirmLine in _confirmButtonsDescriptions)
        {
            confirmLine.text = GetTranslation("Ui_ConfirmButton");
        }
        foreach (Text cancleLine in _cancleButtonsDescriptions)
        {
            cancleLine.text = GetTranslation("Ui_CancleButton");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public string GetTranslation(string textToTranslate)
    {
        return _translationData.GetTranslatedText(textToTranslate);
    }
}

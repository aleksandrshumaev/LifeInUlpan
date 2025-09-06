using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationData : MonoBehaviour
{
    enum Languages
    {
        English,
        Russian
    }
    Dictionary<string,string> _translations = new Dictionary<string,string>();
    string _translationDataCsvFilePath="/Data/TranslationData.csv";
    Languages _gameLanguage=Languages.English;
    Game _game;
    private void Awake()
    {
        _game=GetComponent<Game>();
        _game.TranslationData = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ParseTranslationsFromFile()
    {
        string[] lines = System.IO.File.ReadAllLines(Application.dataPath + _translationDataCsvFilePath);
        foreach(string line in lines)
        {
            Debug.Log(line); 
            string[] locales = line.Split('/');
            _translations.Add(locales[0], locales[(int)_gameLanguage+1]);
        }
    }
    void ChangeGameLanguage(Languages language)
    {
        _gameLanguage = language;
        ParseTranslationsFromFile();
    }
    public string GetTranslatedText(string text)
    {
        if(_translations.ContainsKey(text))
        {
            return _translations[text];
        }
        else
        {
            return text;
        }
    }
}

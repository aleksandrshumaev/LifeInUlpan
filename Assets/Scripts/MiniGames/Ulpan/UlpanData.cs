using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UlpanData : MonoBehaviour
{
    [SerializeField] string _dataCsvFilePath= "/Data/UlpanData.csv"; 
    Game _game;
    Dictionary<int,List<Word>> _originals = new Dictionary<int, List<Word>>();
    Dictionary<int, List<Word>> _translations = new Dictionary<int, List<Word>>();
    List<Word> _words = new List<Word>();
    List<Word> _mistakes=new List<Word>();
    int _days;
    int _wordsPerDay;

    public int Days { get => _days; set => _days = value; }
    public int WordsPerDay { get => _wordsPerDay; set => _wordsPerDay = value; }

    // Start is called before the first frame update
    private void Awake()
    {
        _game = GetComponent<Game>();
        _game.UlpanData=this;

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ParsefromFile()
    {
        _originals=new Dictionary<int,List<Word>>();
        _translations=new Dictionary<int,List<Word>>();
        //string allText = System.IO.File.ReadAllLines(Application.dataPath + _dataCsvFilePath);
        //string[] lines = allText.Split('\n');
        string[] lines = System.IO.File.ReadAllLines(Application.dataPath + _dataCsvFilePath);
        string[] config = lines[0].Split('_');

        Int32.TryParse(config[0], out _days);
        Int32.TryParse(config[1], out _wordsPerDay);
        for(int day = 1; day < _days+1; day++)
        {
            List<Word> originals = new List<Word>();
            List<Word> translations = new List<Word>();
            for (int j = 1; j < _wordsPerDay+1; j++)
            {
                string[] data = lines[j+(day-1)*_wordsPerDay].Split('_');
                int dayFromData;
                Int32.TryParse(data[0], out dayFromData);
                if(day==dayFromData)
                {
                    Word original = new Word(j + (day - 1) * _wordsPerDay-1, "original", data[1]);
                    Word translation = new Word(j + (day - 1) * _wordsPerDay-1, "translation", data[2]);
                    original.Allias = translation;
                    translation.Allias = original;
                    originals.Add(original);
                    translations.Add(translation);
                    _words.Add(original);
                    _words.Add(translation);
                }

            }
            _originals.Add(day, originals);
            _translations.Add(day, translations);
        }

    }
    public List<Word> GetOriginalsForDay(int day)
    {
        return FisherYatesShuffle(_originals[day]);
    }
    public List<Word> GetTranslationsForDay(int day)
    {
        return FisherYatesShuffle(_translations[day]);
    }
    List<Word> FisherYatesShuffle(List<Word> listToShuffle)
    {
        //List<Word> shuffeledList = listToShuffle;
        for (int i = listToShuffle.Count - 1; i >= 1; i--)
        {
            int j = UnityEngine.Random.Range(0,i);

            Word tmp = listToShuffle[j];
            listToShuffle[j] = listToShuffle[i];
            listToShuffle[i] = tmp;
        }
        return listToShuffle;

    }
    public void AddToMistakes(Word mistake)
    {
        if(!IsMistakeInMistakes(mistake))
        {
            _mistakes.Add(mistake);
            Debug.Log("AddToMistakes "+mistake.Name);
        }
        Word madedMistake = GetMistakeFromMadedMistakes(mistake);
        if (madedMistake != null)
        {
            madedMistake.MistakesCount += 1;
        }
        /*else
        {
            Word madedMistake = GetMistakeFromMadedMistakes(mistake);
            if (madedMistake != null)
            {
                madedMistake.MistakesCount += 1;
            }
            else
            {
                _mistakes.Add(mistake);
            }
        }*/
    }
    public void RemoveFromMistakes(Word mistake)
    {
        Word madedMistake = GetMistakeFromMadedMistakes(mistake);
        if(madedMistake != null)
        {
            if(madedMistake.MistakesCount > 1)
            {
                madedMistake.MistakesCount -= 1;
            }
            else
            {
                Debug.Log("RemoveFromMistakes " + mistake.Name);
                _mistakes.Remove(madedMistake);
            }
        }
    }
    bool IsMistakeInMistakes(Word newMistake)
    {
        foreach(Word mistake in _mistakes)
        {
            if(mistake.Name == newMistake.Name)
                return true;
        }
        return false;
    }
    Word GetMistakeFromMadedMistakes(Word newMistake)
    {
        foreach (Word mistake in _mistakes)
        {
            if (mistake.Name == newMistake.Name)
                return mistake;
        }
        return null;
    }
    public List<Word> GetMistakes()
    {
        List<Word> mistakes = new List<Word>();
        Debug.Log(_mistakes.Count + " _ " + _wordsPerDay);
        if(_mistakes.Count>=_wordsPerDay)
        {
            for (int i = 0; i < _wordsPerDay; i++)
            {
                mistakes.Add(GetRandomMistake());
            }
        }
        return mistakes;
    }
    Word GetRandomMistake()
    {
        int mistakeId= UnityEngine.Random.Range(0,_mistakes.Count);
        return _mistakes[mistakeId];
    }
    public List<Word> GetRandomMistakes()
    {
        List<Word> randomMistakes= new List<Word>();
        for(int i = 0; i < _wordsPerDay; i++)
        {
            int mistakeId = UnityEngine.Random.Range(0, _mistakes.Count-i);
            Word tempMistake= _mistakes[mistakeId];
            _mistakes[mistakeId] = _mistakes[_mistakes.Count - i - 1];
            _mistakes[_mistakes.Count - i - 1] = tempMistake;
            randomMistakes.Add(tempMistake);
        }
        //int mistakeId = UnityEngine.Random.Range(0, _mistakes.Count);
        return randomMistakes;
    }
    public void SaveMistakes()
    {
        int[] mistakes=new int[_days*_wordsPerDay];
        for(int i=0; i < mistakes.Length; i++)
        {
            mistakes[i]= 0;
        }
        foreach(Word mistake in _mistakes)
        {
            Debug.Log("SAVING_MISTAKE: "+mistake.Id+" "+ mistake.Name+" "+mistake.MistakesCount);
            mistakes[mistake.Id] = mistake.MistakesCount;
        }
        _game.GetPlayer().Mistakes=mistakes;
    }
    public void LoadMistakes()
    {
        _mistakes.Clear();
        int[] mistakes = _game.GetPlayer().Mistakes;
        for (int i=0; i < mistakes.Length; i++)
        {
            if(mistakes[i] != 0)
            {
                Debug.Log(GetWordFromId(i).Name);
                Word mistake = GetWordFromId(i).Clone();
                mistake.MistakesCount = mistakes[i];
                _mistakes.Add(mistake);
            }
        }
    }
    public List<Word> GetWordsAliases(List<Word> wordsToFindAliases)
    {
        List<Word> aliases=new List<Word>();
        foreach(Word word in wordsToFindAliases)
        {
            aliases.Add(word.Allias);
        }
        return aliases;
    }
    public List<Word> GetShuffledWordsAliases(List<Word> wordsToFindAliases)
    {
        List<Word> aliases = new List<Word>();
        foreach (Word word in wordsToFindAliases)
        {
            aliases.Add(word.Allias);
        }

        return FisherYatesShuffle(aliases);
    }
    Word GetWordFromName(string name)
    {
        foreach(Word word in _words)
        {
            if(word.Name.Equals(name))
            {
                return word;
            }
        }
        return null;
    }
    Word GetWordFromId(int id)
    {
        foreach (Word word in _words)
        {
            if (word.Id==id)
            {
                return word;
            }
        }
        return null;
    }
}

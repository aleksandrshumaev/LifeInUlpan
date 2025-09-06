using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Word
{
    int _id;
    string _type;
    string _name;
    Word _allias;
    Ulpan _ulpan;
    WordSlot _slot;
    bool _chosed;
    int _mistakesCount;

    public Word(int id, string type, string name)
    {
        _id = id;   
        _type = type;
        _name = name;
        _chosed = false;
        _mistakesCount = 0;
    }

    public Ulpan Ulpan { get => _ulpan; set => _ulpan = value; }
    public WordSlot Slot { get => _slot; set => _slot = value; }
    public string Type { get => _type; set => _type = value; }
    public Word Allias { get => _allias; set => _allias = value; }
    public string Name { get => _name; set => _name = value; }
    public int MistakesCount { get => _mistakesCount; set => _mistakesCount = value; }
    public int Id { get => _id; set => _id = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {

        if (!_chosed)
        {
            Debug.Log(Name + " " + Type + " Chose");
            Chose();
        }
        else
        {
            Debug.Log(Name + " " + Type + " UnChose");
            UnChose();
        }
    }
    void Chose()
    {
        if(Ulpan.AddToAnswer(this))
        {
            Debug.Log(Name + " " + Type + " Chosed");
            _chosed = true;
        }
        //return false;
    }
    public void UnChose()
    {
        if (Ulpan.RemoveFromAnswer(this))
        {
            Debug.Log(Name + " " + Type + " Unchosed");
            _chosed = false;
        }
        //return false;
    }
    public Word Clone()
    {
        Word wordCopy=new Word(this.Id,this.Type, this.Name);
        wordCopy.Allias = this.Allias;
        wordCopy.Ulpan = this.Ulpan;
        return wordCopy;
    }
}

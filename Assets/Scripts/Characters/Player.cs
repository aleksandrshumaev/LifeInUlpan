using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    enum AtributesNames
    {
        UlpanScore,
        Money,
        StressLevel,
        EnergyLevel,
        HairAmount
    }
    AtributesNames _atribute;
    //Game _game;
    static Player _instance;
    bool _isUlpanPassedToday=false;
    bool _isHomeworkPassedToday=false;
    List<Atribute> _atributes;
    List<int> _seenDialogues=new List<int>();
    int[] _mistakes;

    //public int UlpanScore { get => _ulpanScore;}
    public bool IsUlpanPassedToday { get => _isUlpanPassedToday; set => _isUlpanPassedToday = value; }

    public bool IsHomeworkPassedToday { get => _isHomeworkPassedToday; set => _isHomeworkPassedToday = value; }
    public List<Atribute> Atributes { get => _atributes; set => _atributes = value; }
    private AtributesNames Atribute { get => _atribute; set => _atribute = value; }
    public List<int> SeenDialogues { get => _seenDialogues; set => _seenDialogues = value; }
    public static Player Instance { get => _instance; set => _instance = value; }
    public int[] Mistakes { get => _mistakes; set => _mistakes = value; }

    protected override void Awake()
    {
        base.Awake();
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
        Game.Player = this;
        
    }
    // Start is called before the first frame update
    public override void Start()
    {
        //Game.Ui.UpdateUi();
        
    }

    public Atribute GetAtribute(string name)
    {
        foreach(Atribute atribute in _atributes)
        {
            if(atribute.Name == name)
            {
                return atribute;
            }
        }
        Debug.Log("No atribute in list");
        return null;
    }
    public void ChangeUlpanScoreBy(int value)
    {
        GetAtribute(AtributesNames.UlpanScore.ToString()).ChangeValueBy(value);

        Debug.Log(value);
    }
    public void ChangeStressLevelBy(int value)
    {
        GetAtribute(AtributesNames.StressLevel.ToString()).ChangeValueBy(value);
    }
    public void ChangeEnergyLevelBy(int value)
    {
        GetAtribute(AtributesNames.EnergyLevel.ToString()).ChangeValueBy(value);
        if(GetAtribute(AtributesNames.EnergyLevel.ToString()).Value==0)
        {
            PassedOut();
        }
    }
    public void PassedOut()
    {
        Game.ApplyEffect("PassedOut");
        Game.Ui.PassedoutNoteUi.ShowDescription(this);
        Game.Fading();
    }
    public bool SpentMoney(int value)
    {
        Atribute money = GetAtribute(AtributesNames.Money.ToString());
        if (money!=null && money.Value>=value)
        {
            money.ChangeValueBy(-value);
            
            return true;
        }
        return false;
    }
    public void ChangeHairAmountBy(int value)
    {
        GetAtribute(AtributesNames.HairAmount.ToString()).ChangeValueBy(value);
        Game.Ui.UpdateUi();
        Debug.Log("HAIR_AMOUNT_CHANGED" + GetAtribute(AtributesNames.HairAmount.ToString()).Value);
        if (GetAtribute(AtributesNames.HairAmount.ToString()).Value <= 0)
        {
            Game.LostAllHairs();
        }
    }
    public void OnDayStarted()
    {
        Atribute currentStressLevel = GetAtribute(AtributesNames.StressLevel.ToString());
        //Atribute hairAmount = GetAtribute("HairAmount");
        ChangeHairAmountBy(-(currentStressLevel.Value / 10));
        _isUlpanPassedToday = false;
        _isHomeworkPassedToday = false;
    }
    public void ChangeAtributeByValue(string atributeName, int value)
    {
        if(atributeName== AtributesNames.StressLevel.ToString())
        {
            ChangeStressLevelBy(value);
        }
        else if(atributeName== AtributesNames.HairAmount.ToString())
        {
            ChangeHairAmountBy(value);
        }
        else if(atributeName == AtributesNames.EnergyLevel.ToString())
        {
            ChangeEnergyLevelBy(value);
        }
    }
    public bool HasSeenDialogue(int id)
    {
        return _seenDialogues.Contains(id);
    }

    public void AddMoney(int allowenceAmount)
    {
        if(allowenceAmount>=0)
        {
            GetAtribute(AtributesNames.Money.ToString()).ChangeValueBy(allowenceAmount);
            
        }
    }
    public int GetEnrgyLevel()
    {
        return GetAtribute(AtributesNames.EnergyLevel.ToString()).Value;
    }

    public int GetHairAmount()
    {
        return GetAtribute(AtributesNames.HairAmount.ToString()).Value;
    }

    public int GetUlpanScore()
    {
        return GetAtribute(AtributesNames.UlpanScore.ToString()).Value;
    }

    public int GetStressLevel()
    {
        return GetAtribute(AtributesNames.StressLevel.ToString()).Value;
    }
    public int GetMoney()
    {
        return GetAtribute(AtributesNames.Money.ToString()).Value;
    }
    public void LoadAtributes(int ulpanScore, int hairAmount, int energyLevel, int stressLevel, int money, bool isHomeWorkPasedToday, bool isUlpanPasedToday, int[] mistakes, int[] seenDialogues)
    {
        _isHomeworkPassedToday = isHomeWorkPasedToday;
        _isUlpanPassedToday=isUlpanPasedToday;
        GetAtribute(AtributesNames.Money.ToString()).SetValue(money);
        GetAtribute(AtributesNames.EnergyLevel.ToString()).SetValue(energyLevel);
        GetAtribute(AtributesNames.StressLevel.ToString()).SetValue(stressLevel);
        GetAtribute(AtributesNames.UlpanScore.ToString()).SetValue(ulpanScore);
        GetAtribute(AtributesNames.HairAmount.ToString()).SetValue(hairAmount);
        _mistakes = mistakes;
        foreach(int dialogueId in seenDialogues)
        {
            _seenDialogues.Add(dialogueId);
        }
        //Debug.Log(_mistakes.Length);
    }
}

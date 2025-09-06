using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : Furniture
{
    //[SerializeField] string
    // Start is called before the first frame update
    TimeStruct _nextTimeToSleep;
    string _usingTypeChoosingDescriprion;
    string _sleptWellDescriprion;
    string _napedWellDescriprion;
    string _cantSleepDescriprion;
    string _sleepEffect;
    string _napEffect;
    int _sleepingDelay = 12;
    int _nappingDelay = 6;
    public override void Start()
    {
        base.Start();
        UsingDescription = "Ui_" + this.GetType().Name + "UsingDescription";
        _usingTypeChoosingDescriprion= "Ui_" + this.GetType().Name + "UsingTypeChoosingDescription";
        _sleptWellDescriprion = "Ui_" + this.GetType().Name+"SleptWell";
        _napedWellDescriprion = "Ui_" + this.GetType().Name + "NapedWell";
        _cantSleepDescriprion = "Ui_" + this.GetType().Name + "CantSleep";
        _sleepEffect = this.GetType().Name + "SleepEffect";
        _napEffect = this.GetType().Name + "NapEffect";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnMouseDown()
    {
        if (!Game.GetPlayer().IsChoosingObject && !Game.GetPlayer().IsUsingObject)
        {
            ChosedByCharacter(Game.GetPlayer());
            Game.Ui.BedDescriptionUi.ShowDescription(this, _usingTypeChoosingDescriprion);
        }

    }
    public void Sleep(Player player)
    {
        if(Game.Time.GetCurrentTime().CompareTo(_nextTimeToSleep)>=0)
        {
            UseAction();
            _nextTimeToSleep = Game.Time.GetCurrentTime().AddHours(_sleepingDelay);
            Game.ApplyEffect(_sleepEffect);
            Game.Ui.BedDescriptionUi.ShowSleptWellPanel(_sleptWellDescriprion);
            Game.SaveGame();
            Game.Fading();

        }
        else
        {
            Game.Ui.BedDescriptionUi.ShowCantUseDescription(_cantSleepDescriprion);
        }
    }
    public void Nap(Player player)
    {
        if (Game.Time.GetCurrentTime().CompareTo(_nextTimeToSleep) >= 0)
        {
            UseAction();
            _nextTimeToSleep = Game.Time.GetCurrentTime().AddHours(_nappingDelay);
            Game.ApplyEffect(_napEffect);
            Game.Ui.BedDescriptionUi.ShowSleptWellPanel(_napedWellDescriprion);
            Game.SaveGame();
            Game.Fading();
        }
        else
        {
            Game.Ui.BedDescriptionUi.ShowCantUseDescription(_cantSleepDescriprion);
        }
    }
    public void WakedUp(Player player)
    {
        StopUsing(player);
    }
}

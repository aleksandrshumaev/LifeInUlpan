using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeWorkNotes : Furniture
{
    string _notEnoughMistakesDesrciption;
    string _alreadyUsedDescription;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        UsingDescription = "Ui_" + this.GetType().Name + "UsingDescription";
        _alreadyUsedDescription="Ui_"+this.GetType().Name+"AlreadyUsedDescription";
        _notEnoughMistakesDesrciption = "Ui_" + this.GetType().Name + "NotEnoughMistakes";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void UseAction(bool IsUsingBlockingMouse = true)
    {
        
        if(Game.StartHomeWorkMinigame(this))
        {
            Game.GetPlayer().IsUsingObject = true;
            StopUsing(Game.GetPlayer());
        }
        else
        {
            base.UseAction();
        }
    }
    public void SetNotEnoughMistakesState()
    {
        Game.Ui.HomeWorkDescriptionUi.ShowNoMistakesPanel(this,_notEnoughMistakesDesrciption);
        Debug.Log("Not enough mistakes: ");
    }
    public void SetAlreadyPassedState()
    {
        Game.Ui.HomeWorkDescriptionUi.ShowAlreadyUsedPanel(this,_alreadyUsedDescription);
        Debug.Log("Already Passed");
    }
    public void HomeWorkDone()
    {

        StopUsing(Game.GetPlayer());
    }
}

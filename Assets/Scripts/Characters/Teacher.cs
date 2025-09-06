using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teacher : NPC
{
    string _alreadyUsedDescription;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        UsingDescription = "Ui_" + this.GetType().Name + "UsingDescription";
        _alreadyUsedDescription = "Ui_" + this.GetType().Name + "AlreadyUsedDescription";
    }
    public override void UseAction(bool IsUsingBlockingMouse = true)
    {
        base.UseAction();
        if (Game.StartUlpanMinigame(this))
        {
            StopUsing(Game.GetPlayer());
            Game.GetPlayer().IsUsingObject = true;
        }
    }
    public void SetAlreadyPassedState()
    {
        Game.Ui.TeacherDescriptionUi.ShowAlreadyUsedPanel(this, _alreadyUsedDescription);
        Debug.Log("Already Passed");
    }
    public void UlpanDone()
    {
        StopUsing(Game.GetPlayer());
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Friend : NPC
{
    string _friendTalkDescription;
    string _friendEffect;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        UsingDescription = "Ui_" + this.GetType().Name + "UsingDescription";
        //_usingTypeChoosingDescriprion = "Ui_" + this.GetType().Name + "UsingTypeChoosingDescription";
        _friendTalkDescription = "Ui_" + this.GetType().Name +"TalkedDescription";
        _friendEffect = this.GetType().Name + "TalkEffect";
    }
    public override void UseAction(bool IsUsingBlockingMouse = true)
    {
        base.UseAction();
        Game.ApplyEffect(_friendEffect);
        Game.Ui.FriendTalkingUi.ShowTalkDescriptionPanel(this,_friendTalkDescription);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTalkFinished(Player player)
    {
        StopUsing(player);
    }
}

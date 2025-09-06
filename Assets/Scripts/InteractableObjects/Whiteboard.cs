using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Whiteboard : Furniture
{
    //string _wiskyEffect;
    string _whiteboardLearningDescription;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        UsingDescription = "Ui_" + this.GetType().Name + "UsingDescription";
        _whiteboardLearningDescription = "Ui_" + this.GetType().Name + "WhiskyConsumedDescription";
        //_wiskyEffect = this.GetType().Name + "ConsumtionEffect";
    }

    // Update is called once per frame
    void Update()
    {

    }
    public override void UseAction(bool IsUsingBlockingMouse = true)
    {

        base.UseAction();
        //Game.ApplyEffect(_wiskyEffect);
        Game.Ui.WhiteboardDescriptionUi.ShowWhiteboardPanel(this, _whiteboardLearningDescription);
    }
    public void OnWiskyConsumed(Player player)
    {
        StopUsing(player);
    }
}

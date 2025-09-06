using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : Furniture
{
    
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        UsingDescription = "Ui_" + this.GetType().Name + "UsingDescription";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void UseAction(bool IsUsingBlockingMouse = true)
    {
        base.UseAction();
        int randomComputerEffect = Random.Range(0, 5);
        string appliedEffect = this.GetType().Name;
        if(randomComputerEffect < 2)
        {
            appliedEffect += "BadEffect";
        }
        else if(randomComputerEffect < 4)
        {
            appliedEffect += "NormalEffect";
        }
        else
        {
            appliedEffect += "GoodEffect";
        }
        Game.ApplyEffect(appliedEffect);
        string computerUsedDescriprion = "Ui_" + appliedEffect;
        Game.Ui.ComputerDescriptionUi.ShowDescription(this, computerUsedDescriprion);
    }
    public override void StopUsing(Character character)
    {
        base.StopUsing(character);
    }
}

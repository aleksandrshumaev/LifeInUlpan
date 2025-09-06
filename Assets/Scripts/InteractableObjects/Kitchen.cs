using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kitchen : Furniture
{
    string _usingTypeChoosingDescriprion;
    string _goodFoodEffectDescriprion;
    string _badFoodEffectDescriprion;
    string _notEnoughMoneyDescription;
    string _goodFoodEffect;
    string _badFoodEffect;
    int _goodFoodPrice;
    int _badFoodPrice;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        UsingDescription = "Ui_" + this.GetType().Name + "UsingDescription";
        _usingTypeChoosingDescriprion = "Ui_" + this.GetType().Name + "UsingTypeChoosingDescription";
        _goodFoodEffectDescriprion = "Ui_" + this.GetType().Name + "GoodFoodDescription";
        _badFoodEffectDescriprion = "Ui_" + this.GetType().Name + "BadFoodDescription";
        _notEnoughMoneyDescription = "Ui_"+this.GetType().Name+"NotEnoghtMoney";
        _goodFoodEffect = this.GetType().Name + "GoodEffect";
        _badFoodEffect = this.GetType().Name + "BadEffect";
        _goodFoodPrice = Game.GetCostForEffect(_goodFoodEffect);
        _badFoodPrice = Game.GetCostForEffect(_badFoodEffect);
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
            Game.Ui.KitchenDescriptionUi.ShowDescription(this, _usingTypeChoosingDescriprion);
        }
    }
    public void BuyGoodFood()
    {
        if(Game.Player.SpentMoney(_goodFoodPrice))
        {
            UseAction();
            Game.ApplyEffect(_goodFoodEffect);
            Game.Ui.KitchenDescriptionUi.ShowFoodEatenlPanel(_goodFoodEffectDescriprion);
        }
        else
        {
            Game.Ui.KitchenDescriptionUi.ShowNotEnoughMoneyPanel(_notEnoughMoneyDescription);
        }
    }
    public void BuyBadFood()
    {
        if (Game.Player.SpentMoney(_badFoodPrice))
        {
            UseAction();
            Game.ApplyEffect(_badFoodEffect);
            Game.Ui.KitchenDescriptionUi.ShowFoodEatenlPanel(_badFoodEffectDescriprion);
        }
        else
        {
            Game.Ui.KitchenDescriptionUi.ShowNotEnoughMoneyPanel(_notEnoughMoneyDescription);
        }
    }
    public void FoodEaten(Player player)
    {
        StopUsing(player);
    }
}

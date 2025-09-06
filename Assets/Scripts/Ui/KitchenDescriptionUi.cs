using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KitchenDescriptionUi : UiTextLines
{
    [SerializeField] GameObject _takeFoodDescriptionPanel;
    [SerializeField] GameObject _notEnoughMoneyDescriptionPanel;
    [SerializeField] GameObject _foodEatenlPanel;
    [SerializeField] Text _takingFoodDescription;
    [SerializeField] Text _notEnoughMoneyDescription;
    [SerializeField] Text _foodEatenDescription;
    [SerializeField] Text _goodFoodButtonText;
    [SerializeField] Text _badFoodButtonText;
    Kitchen _kitchen;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        _badFoodButtonText.text = GetTranslation("Ui_BadFoodButton");
        _goodFoodButtonText.text = GetTranslation("Ui_GoodFoodButton");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ShowDescription(Kitchen kitchen, string usingTypeChoosingDescriprion)
    {
        _takeFoodDescriptionPanel.SetActive(true);
        _kitchen = kitchen;
        _takingFoodDescription.text = GetTranslation(usingTypeChoosingDescriprion);
    }

    public void ShowFoodEatenlPanel(string foodEffectDescriprion)
    {
        _foodEatenlPanel.SetActive(true);
        _foodEatenDescription.text = GetTranslation(foodEffectDescriprion);
    }
    public void ShowNotEnoughMoneyPanel(string notEnoughDescription)
    {
        _notEnoughMoneyDescriptionPanel.SetActive(true) ;
        _notEnoughMoneyDescription.text = GetTranslation(notEnoughDescription);
    }
    public void OnBadFoodButton()
    {
        _kitchen.BuyBadFood();
        _takeFoodDescriptionPanel.SetActive(false);
    }
    public void OnGoodFoodButton()
    {
        _kitchen.BuyGoodFood();
        _takeFoodDescriptionPanel.SetActive(false);
    }
    public void OnCancleButton()
    {
        _kitchen.FoodEaten(_kitchen.Game.GetPlayer());
        _kitchen = null;
        _takeFoodDescriptionPanel.SetActive(false);
    }
    public void OnConfirmFoodEatenButton()
    {
        _kitchen.FoodEaten(_kitchen.Game.GetPlayer());
        _kitchen = null;
        _foodEatenlPanel.SetActive(false);
    }
    public void OnConfirmNotEnoughMoneyButton()
    {
        _kitchen.FoodEaten(_kitchen.Game.GetPlayer());
        _kitchen = null;
        _notEnoughMoneyDescriptionPanel.SetActive(false);
    }
}

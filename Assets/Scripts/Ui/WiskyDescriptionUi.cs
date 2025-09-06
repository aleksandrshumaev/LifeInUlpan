using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WiskyDescriptionUi :   UiTextLines
{
    //[SerializeField] GameObject _wiskyDescriptionPanel;
    //[SerializeField] GameObject _bedCantUseDescriptionPanel;
    [SerializeField] GameObject _wiskyConsumedlPanel;
    //[SerializeField] Text _takingFoodDescription;
    //[SerializeField] Text _bedCantUseDescription;
    [SerializeField] Text _wiskyConsumedDescription;
    Whisky _wisky;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void ShowWiskyConsumedPanel(Whisky wisky,string wiskyConsumedDescription)
    {
        _wiskyConsumedlPanel.SetActive(true);
        _wisky = wisky;
        _wiskyConsumedDescription.text = GetTranslation(wiskyConsumedDescription);
    }
    public void OnWiskyConsumedConfirmButton()
    {
        _wiskyConsumedlPanel.SetActive(false);
        _wisky.OnWiskyConsumed(_wisky.Game.GetPlayer());
        _wisky = null;
    }


}

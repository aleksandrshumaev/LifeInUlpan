using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BedDescriptionUi : UiTextLines
{
    [SerializeField] GameObject _bedUsingDescriptionPanel;
    [SerializeField] GameObject _bedCantUseDescriptionPanel;
    [SerializeField] GameObject _sleptWellPanel;
    [SerializeField] Text _bedUsingDescription;
    [SerializeField] Text _bedCantUseDescription;
    [SerializeField] Text _sleptWellDescription;
    [SerializeField] Text _sleepButtonText;
    [SerializeField] Text _napButtonText;
    Bed _bed;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        _sleepButtonText.text = GetTranslation("Ui_SleepButton");
        _napButtonText.text = GetTranslation("Ui_NapButton");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowCantUseDescription(string description)
    {
        _bedCantUseDescriptionPanel.SetActive(true);
        //_bed = bed;
        _bedCantUseDescription.text = GetTranslation(description);
    }
    public void ShowDescription(Bed bed, string description)
    {
        _bedUsingDescriptionPanel.SetActive(true);
        _bed = bed;
        _bedUsingDescription.text = GetTranslation(description);
    }
    public void ShowSleptWellPanel( string sleptWellDescription)
    {
        _sleptWellPanel.SetActive(true);
        //_bed = bed;
        _sleptWellDescription.text = GetTranslation(sleptWellDescription);
    }
    public void OnSleepButton()
    {
        _bed.Sleep(_bed.Game.GetPlayer());
        //_bed = null;
        _bedUsingDescriptionPanel.SetActive(false);
    }

    public void OnNapButton()
    {
        _bed.Nap(_bed.Game.GetPlayer());
        //_bed = null;
        _bedUsingDescriptionPanel.SetActive(false);
    }
    public void OnCancleButton()
    {
        _bed.StopUsing(_bed.Game.GetPlayer());
        //_bed.StopUsing(_bed.Game.GetPlayer());
        _bed = null;
        _bedUsingDescriptionPanel.SetActive(false);
    }
    public void OnConfirmCantSleepButton()
    {
        _bed.StopUsing(_bed.Game.GetPlayer());
        //_bed.StopUsing(_bed.Game.GetPlayer());
        _bed = null;
        _bedCantUseDescriptionPanel.SetActive(false);
    }
    public void OnWakeUpButton()
    {
        _bed.StopUsing(_bed.Game.GetPlayer());
        _bed = null;
        _sleptWellPanel.SetActive(false);
    }

}

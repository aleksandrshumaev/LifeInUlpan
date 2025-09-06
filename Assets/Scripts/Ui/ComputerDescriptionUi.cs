using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerDescriptionUi : UiTextLines
{
    [SerializeField] Text _description;
    [SerializeField] GameObject _computerUsingDescription;
    Computer _computer;
    // Start is called before the first frame update

    public override void Start()
    {
        base.Start();
        _computerUsingDescription.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDescription(Computer computer, string description)
    {
        _computerUsingDescription.SetActive(true);
        _computer =computer;
        _description.text = GetTranslation(description);
    }
    public void OnConfirmButton()
    {
        _computer.StopUsing(_computer.Game.GetPlayer());
        _computer = null;
        _computerUsingDescription.SetActive(false);
    }
}

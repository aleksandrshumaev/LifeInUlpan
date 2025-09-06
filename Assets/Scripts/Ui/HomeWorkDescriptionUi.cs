using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeWorkDescriptionUi : UiTextLines
{
    [SerializeField] GameObject _noMistakesDescriptionPanel;
    [SerializeField] GameObject _alreadyUsedDescriptionPanel;
    [SerializeField] Text _noMistakesDescription;
    [SerializeField] Text _alreadyUsedDescription;
    HomeWorkNotes _notes;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowAlreadyUsedPanel(HomeWorkNotes notes, string description)
    {
        _alreadyUsedDescriptionPanel.SetActive(true);
        _notes = notes;
        _alreadyUsedDescription.text = GetTranslation(description);
    }
    public void ShowNoMistakesPanel(HomeWorkNotes notes, string descriprion)
    {
        _noMistakesDescriptionPanel.SetActive(true);
        _notes= notes;
        _noMistakesDescription.text = GetTranslation(descriprion);
    }
    public void HomeWorkDone()
    {
        _notes.HomeWorkDone();
        _notes= null;
    }
    public void OnNoMistakesConfirmButton()
    {
        HomeWorkDone();
        _noMistakesDescriptionPanel?.SetActive(false);
    }
    public void OnAlreadyUsedConfirButton()
    {
        HomeWorkDone();
        _alreadyUsedDescriptionPanel.SetActive(false);
    }
}

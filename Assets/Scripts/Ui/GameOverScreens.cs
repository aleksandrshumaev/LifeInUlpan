using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreens : UiTextLines
{
    [SerializeField] GameObject _lowScoreGameOverPanel;
    [SerializeField] GameObject _lostHairGameOverPanel;
    [SerializeField] GameObject _winGameOverPanel;
    [SerializeField] Text _lowScoreGameOverDescription;
    [SerializeField] Text _lostHairGameOverDescription;
    [SerializeField] Text _winGameOverPanelDescription;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        _lowScoreGameOverDescription.text = GetTranslation("Ui_LowScoreGameOver");
        _lostHairGameOverDescription.text = GetTranslation("Ui_LostHairGameOver");
        _winGameOverPanelDescription.text = GetTranslation("Ui_WinGameOver");
    }
    public void ShowLowScoreGameOver()
    {
        _lowScoreGameOverPanel.SetActive(true);
    }
    public void ShowWinGameOver()
    {
        _winGameOverPanel.SetActive(true);
    }
    public void ShowLostHairGameOver()
    {
        _lostHairGameOverPanel.SetActive(true);
    }
    public void OnConfirmGameOverButton()
    {
        Game.DeleteSaveFile();
        Game.ToTitle();
    }
}

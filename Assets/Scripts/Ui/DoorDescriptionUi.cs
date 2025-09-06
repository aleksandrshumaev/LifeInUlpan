using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorDescriptionUi : UiTextLines
{
    [SerializeField] GameObject _fromRoomDoorDescriptionPanel;
    [SerializeField] GameObject _toRoomDoorDescriptionPanel;
    [SerializeField] GameObject _hairCureUsedDescriptionPanel;
    [SerializeField] GameObject _notenoughMoneyDescriptionPanel;
    [SerializeField] Text _hairCureUsedDescription;
    [SerializeField] Text _notenoughMoneyDescription;
    [SerializeField] Text _fromRoomDoorDescription;
    [SerializeField] Text _toRoomDoorUsedDescription;
    [SerializeField] Text _toUlapnButton;
    [SerializeField] Text _buyCureButton;
    Door _door;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        _toUlapnButton.text = GetTranslation("Ui_ToUlpanButton");
        _buyCureButton.text = GetTranslation("Ui_BuyCureButton");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowFromRoomDesriprionPanel(Door door,string description)
    {
        _fromRoomDoorDescriptionPanel.SetActive(true);
        _door = door;
        _fromRoomDoorDescription.text = GetTranslation(description); 
    }
    public void ShowToRoomDesriprionPanel(Door door, string description)
    {
        _toRoomDoorDescriptionPanel.SetActive (true);
        _door=door;
        _toRoomDoorUsedDescription.text = GetTranslation(description);
    }
    public void ShowCureUsedPanel(string description)
    {
        _hairCureUsedDescriptionPanel.SetActive(true);
        _hairCureUsedDescription.text= GetTranslation(description);
    }
    public void ShowNotEnoughMoney(string description)
    {
        _notenoughMoneyDescriptionPanel.SetActive(true);
        _notenoughMoneyDescription.text= GetTranslation(description);
    }
    public void OnGoToUlpanButton()
    {
        _fromRoomDoorDescriptionPanel.SetActive(false);
        _door.FromRoomDoorUse();
        _door = null;
    }
    public void OnBuyCureButton()
    {
        _fromRoomDoorDescriptionPanel.SetActive(false);
        _door.BuyCure();
    }
    public void OnCancleFromRoomButton()
    {
        _fromRoomDoorDescriptionPanel.SetActive(false);
        _door.StopUsing(_door.Game.GetPlayer());
        _door = null;
    }
    public void OnCancleToRoomButton()
    {
        _toRoomDoorDescriptionPanel.SetActive(false);
        _door.StopUsing(_door.Game.GetPlayer());
        _door = null;
    }
    public void OnConfirmNotEnoughMoneyButton()
    {
        _door.StopUsing(_door.Game.GetPlayer());
        _notenoughMoneyDescriptionPanel.SetActive(false);
        _door = null;
    }
    public void OnConfirmCureUsedButton()
    {
        _door.CureUsed(_door.Game.GetPlayer());
        _hairCureUsedDescriptionPanel.SetActive(false);
        _door = null;
    }
    public void OnConfirmToRoomButton()
    {
        _toRoomDoorDescriptionPanel.SetActive(false);
        _door.ToRoomDoorUse();
        _door=null;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Furniture
{
    enum DoorType
    {
        ToRoom,
        FromRoom,
        InRoom
    }
    [SerializeField] DoorType _type;
    [SerializeField] GameObject _cameraPosition;
    [SerializeField] GameObject _playerPosition;
    int _hairCurePrice;
    string _hairCureEffect;
    string _cureUsedDescription;
    string _notEnoughMoneyDescription;
    string _fromRoomDoorDescription;
    string _toRoomDoorDescription;
    public override void Start()
    {
        base.Start();
        UsingDescription = "Ui_" + this.GetType().Name + "UsingDescription";
        _cureUsedDescription = "Ui_" + this.GetType().Name + "CureDescription";
        _fromRoomDoorDescription = "Ui_" + this.GetType().Name + "FromRoomDescription";
        _toRoomDoorDescription = "Ui_" + this.GetType().Name + "ToRoomDescription";
        _notEnoughMoneyDescription = "Ui_" + this.GetType().Name + "CureNoMoneyDescription";
        _hairCureEffect = "HairCureEffect";
        _hairCurePrice=Game.GetCostForEffect(_hairCureEffect);
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void OnMouseDown()
    {
        if (!Game.GetPlayer().IsChoosingObject && !Game.GetPlayer().IsUsingObject)
        {
            ChosedByCharacter(Game.GetPlayer());
            if (_type == DoorType.FromRoom)
            {
                Game.Ui.DoorDescriptionUi.ShowFromRoomDesriprionPanel(this, _fromRoomDoorDescription);
            }
            else if (_type == DoorType.ToRoom)
            {
                Game.Ui.DoorDescriptionUi.ShowToRoomDesriprionPanel(this, _toRoomDoorDescription);
            }
            else if(_type == DoorType.InRoom)
            {
                DoorUse();
            }
        }
    }
    public void BuyCure()
    {
        if (Game.Player.SpentMoney(_hairCurePrice))
        {
            //UseAction();
            Game.ApplyEffect(_hairCureEffect);
            Game.Ui.DoorDescriptionUi.ShowCureUsedPanel(_cureUsedDescription);
        }
        else
        {
            Game.Ui.DoorDescriptionUi.ShowNotEnoughMoney(_notEnoughMoneyDescription);
        }
    }
    public void FromRoomDoorUse()
    {
        DoorUse();
        //Game.GetPlayer().SetState("Sitting", "Idle", 2, _playerPosition.transform.position);
        Game.CurrentLocation.GetFurniture("GrishaKitaChair").UsedByCharacter(Game.GetPlayer());
        Game.GetPlayer().IsUsingObject = false;
        if (DialogueTrigger != null)
        {
            DialogueTrigger.StartDialogue();
        }
    }
    public void ToRoomDoorUse()
    {
        Debug.Log("ToRoomDoorUse");
        Game.CurrentLocation.GetFurniture("GrishaKitaChair").StopUsing(Game.GetPlayer());
        DoorUse();
        if (DialogueTrigger != null)
        {
            DialogueTrigger.StartDialogue();
        }

    }
    public void DoorUse()
    {
        Game.GetCamera().MoveTo(_cameraPosition.transform.position);
        StopUsing(Game.GetPlayer());
        Game.GetPlayer().SetPosition(_playerPosition.transform.position);
        Sound.Source.Play();
    }
    public void CureUsed(Player player)
    {
        StopUsing(player);
    }
}

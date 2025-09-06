using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PassedoutNoteUi : UiTextLines
{
    [SerializeField] GameObject _notePanel;
    [SerializeField] Text _description;

    Player _player;
    string _descriptionText;
    bool _shouldFreePlayer=false;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        _notePanel.SetActive(false);
        _descriptionText = GetTranslation("Ui_PassedOutDescription");
        
    }
    public void ShowDescription(Player player)
    {
        _player = player;
        if(!_player.IsUsingObject)
        {
            _player.IsUsingObject = true;
            _shouldFreePlayer = true;
        }
        _notePanel.SetActive(true);
        _description.text = _descriptionText;
    }
    public void OnConfirmButton()
    {
        if(_shouldFreePlayer)
        {
            _player.IsUsingObject = false;
            _shouldFreePlayer = false;
        }

        _player=null;
        _notePanel.SetActive(false);
    }
}

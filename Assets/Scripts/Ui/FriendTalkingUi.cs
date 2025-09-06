using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendTalkingUi : UiTextLines
{
    [SerializeField] GameObject _talkDescriptionPanel;
    [SerializeField]Text _talkDescription;
    Friend _friend;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }
    public void ShowTalkDescriptionPanel(Friend friend,string description)
    {
        _talkDescriptionPanel.SetActive(true);
        _friend = friend;   
        _talkDescription.text = GetTranslation(description);
    }
    public void OnTalkConfirmButton()
    {
        _talkDescriptionPanel.SetActive(false);
        _friend.OnTalkFinished(_friend.Game.GetPlayer());
        _friend = null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

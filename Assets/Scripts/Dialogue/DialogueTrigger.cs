using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] string _dialogueId; 
    Dialogue _dialogue;
    Game _game;

    public string DialogueId { get => _dialogueId; set => _dialogueId = value; }
    public Dialogue Dialogue { get => _dialogue; set => _dialogue = value; }

    public void Start()
    {
        _game = GameObject.FindGameObjectWithTag("Game").GetComponent<Game>();
        _game.DialogueTriggers.Add(this);
        _dialogue=_game.DialogueData.GetDialogueWithId(_dialogueId);
        //Dialogue triggers in Game
    }

    public void StartDialogue()
    {
        if (!_game.GetPlayer().HasSeenDialogue(_dialogue.Id))
        {
            _game.Ui.DialogueUi.ShowDialogue(_dialogue, _game.GetPlayer());
        }
    }
}

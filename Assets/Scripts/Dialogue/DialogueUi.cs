using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUi : UiTextLines
{
    [SerializeField] GameObject _dialoguePanel;
    [SerializeField] Text _dialogueSentense;
    [SerializeField] Text _buttonDescription;
    Queue<string> _sentences;
    string _nextSentenceButtonDescription;
    string _endDialogueButtonDescription;
    Player _player;
    // Start is called before the first frame update
    public override void Start()
    {
        _sentences = new Queue<string>();
        _nextSentenceButtonDescription = "Ui_NextSentenceButton";
        _endDialogueButtonDescription = "Ui_EndDialogueButton";
    }
    public void ShowDialogue(Dialogue dialogue,Player player)
    {
        _player = player;
        _player.IsUsingObject = true;
        _player.SeenDialogues.Add(dialogue.Id);
        _dialoguePanel.SetActive(true);
        _buttonDescription.text = GetTranslation(_nextSentenceButtonDescription);
        _sentences.Clear();
        foreach(string line in dialogue.Lines)
        {
            _sentences.Enqueue(line);
        }
        DisplayNextLine();
    }

    public void DisplayNextLine()
    {
        if (_sentences.Count == 0)
        {
            EndDialogue();
        }
        else
        {
            if (_sentences.Count == 1)
            {
                _buttonDescription.text = GetTranslation(_endDialogueButtonDescription);
            }
            _dialogueSentense.text = GetTranslation(_sentences.Dequeue());
        }

    }
    public void EndDialogue()
    {
        _player.IsUsingObject=false;
        _player = null;
        _dialoguePanel.SetActive(false);
    }
}

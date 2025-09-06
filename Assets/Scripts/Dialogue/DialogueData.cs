using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueData : MonoBehaviour
{
    string _dataCsvFilePath = "/Data/DialogueData.csv";
    Dictionary<string,Dialogue> _dialogues;

    public Dictionary<string, Dialogue> Dialogues { get => _dialogues; set => _dialogues = value; }

    //public List<Dialogue> Dialogues { get => _dialogues; set => _dialogues = value; }

    // Start is called before the first frame update
    void Start()
    {

    }
    public void ParseFromFile()
    {
        string[] lines = System.IO.File.ReadAllLines(Application.dataPath + _dataCsvFilePath);
        _dialogues = new Dictionary<string,Dialogue>();
        foreach (string line in lines)
        {
            string[] dialogueData = line.Split(' ');
            string[] dialogueLines = new string[dialogueData.Length - 1];
            for (int i = 1; i < dialogueData.Length; i++)
            {
                dialogueLines[i - 1] = dialogueData[i];
            }
            int dialogueId;
            if(System.Int32.TryParse(dialogueData[0], out dialogueId))
            {
                Dialogue dialogue = new Dialogue(dialogueId, dialogueLines);
                _dialogues.Add(dialogueData[0], dialogue);
            }
        }
    }
    public Dialogue GetDialogueWithId(string Id)
    {
        return _dialogues[Id];
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

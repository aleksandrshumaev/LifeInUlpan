using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    int _id;
    string _npcName;
    string[] _lines;

    public Dialogue(int id, string[] lines)
    {
        Id = id;
        Lines = lines;
    }

    public int Id { get => _id; set => _id = value; }
    public string NpcName { get => _npcName; set => _npcName = value; }
    public string[] Lines { get => _lines; set => _lines = value; }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsData : MonoBehaviour
{
    string _dataCsvFilePath = "/Data/EffectData.csv";
    Dictionary<string,Dictionary<string,int>> _effects;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ParsefromFile()
    {
        _effects = new Dictionary<string, Dictionary<string, int>>();
        string[] lines = System.IO.File.ReadAllLines(Application.dataPath + _dataCsvFilePath);
        foreach(string line in lines)
        {
            Dictionary<string, int> effect = new Dictionary<string, int>();
            string[] data = line.Split('_');
            for(int i = 1; i < data.Length; i++)
            {
                string atributeName = data[i].Split(' ')[0];
                int atributeChangeValue = Int32.Parse(data[i].Split(' ')[1]);
                effect.Add(atributeName, atributeChangeValue);
            }
            _effects.Add(data[0], effect);
        }
        
    }
    public Dictionary<string, int> GetEffect(string effectName)
    {
        if(_effects.ContainsKey(effectName))
        {
            return _effects[effectName];
        }
        return null;
    }
}

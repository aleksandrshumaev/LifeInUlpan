using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtributeData : MonoBehaviour
{
    string _atributesDataCsvFilePath = "/Data/AtributeData.csv";
    Player _player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public List<Atribute> InitializeAtributes()
    {
        string[] lines = System.IO.File.ReadAllLines(Application.dataPath + _atributesDataCsvFilePath);
        List<Atribute> atributes = new List<Atribute>();
        foreach (string line in lines)
        {
            string[] data = line.Split('_');
            string name=data[0];
            string description=data[1];
            int minValue=int.Parse(data[2]);
            int maxValue=int.Parse(data[3]);
            int initialValue=int.Parse(data[4]);
            Debug.Log(name + " MinValue: " + minValue + " MaxValue: " + maxValue);
            Atribute atribute = new Atribute(name, description, maxValue, minValue, initialValue);
            atributes.Add(atribute);
        }
        return atributes;
    }
}

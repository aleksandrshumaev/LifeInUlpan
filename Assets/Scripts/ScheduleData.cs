using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScheduleData : MonoBehaviour
{
    string _dataCsvFilePath = "/Data/ScheduleData.csv";
    Dictionary<string, Dictionary<string, Dictionary<string, string>>> _schedule = new Dictionary<string, Dictionary<string, Dictionary<string, string>>>();
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ParseScheduleFromFile()
    {
        //_effects = new Dictionary<string, List<Dictionary<string, int>>>();
        string[] lines = System.IO.File.ReadAllLines(Application.dataPath + _dataCsvFilePath);
        foreach (string line in lines)
        {
            string[] schedule = line.Split(':');
            //List<Dictionary<string, int>> effects = new List<Dictionary<string, int>>();
            string[] characterSchedule = schedule[1].Split(' ');
            
            Dictionary<string, Dictionary<string, string>> characterScheduleLocationTime = new Dictionary<string, Dictionary<string, string>>();
            //List<Dictionary<string, Dictionary<string, string>>> characterScheduleLocationActions = new List<Dictionary<string, Dictionary<string, string>>> ();
            foreach (string characterAction in characterSchedule)
            {
                string[] characterActionData = characterAction.Split('_');
                Dictionary<string, string> characterScheduleLocationPlace = new Dictionary<string, string>();
                characterScheduleLocationPlace.Add(characterActionData[1], characterActionData[2]);
                characterScheduleLocationTime.Add(characterActionData[0], characterScheduleLocationPlace);
                //characterScheduleLocationActions.Add(characterScheduleLocationTime);  
            }
            _schedule.Add(schedule[0], characterScheduleLocationTime);
        }
    }
    public Dictionary<string, Dictionary<string, string>> GetCharcterSchedule(string charcaterName)
    {
        foreach(string name in _schedule.Keys)
        {
            if(name==charcaterName)
            {
                return _schedule[name];
            }
        }
        return null;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

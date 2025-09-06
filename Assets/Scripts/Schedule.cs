using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Schedule : MonoBehaviour
{
    Character _character;
    // Start is called before the first frame update
    void Start()
    {
        _character = GetComponent<Character>();//????
        _character.Game.Time.OnChangingTimeCallBack+=SetCurrentActionForCharacter;
        SetCurrentActionForCharacter();
    }
    public void SetCurrentActionForCharacter()
    {
        Debug.Log(_character.Name + "_SCHEDULE");
        Dictionary<string,Dictionary<string,string>> characterSchedule = _character.Game.ScheduleData.GetCharcterSchedule(_character.Name);
        if(characterSchedule != null)
        {
            string time = GetNearestScheduleTimeToCurrentTime(characterSchedule);
            if (characterSchedule.ContainsKey(time))
            {
                Dictionary<string,string> locationPosition=characterSchedule[time];
                Location currentLocation = _character.Game.CurrentLocation;
                if (locationPosition.ContainsKey(currentLocation.Name))
                {
                    //Debug.Log(_character.Name + " in " + currentLocation.Name + "Schedule");
                    _character.StopUsingCurrentFurniture();
                    currentLocation.GetFurniture(locationPosition[currentLocation.Name]).UsedByCharacter(_character);
                    _character.UseFurniture(currentLocation.GetFurniture(locationPosition[currentLocation.Name]));
                }
            }
        }
        
    }
    string GetNearestScheduleTimeToCurrentTime(Dictionary<string, Dictionary<string, string>> characterSchedule)
    {
        string nearesScheduleTime = "0000";
        foreach(string scheduleTime in characterSchedule.Keys)
        {
            TimeStruct time=_character.Game.Time.GetHoursAndMinutesFromString(scheduleTime);
            Debug.Log("SCHEDULE_Time " + time.Hour+" "+time.Minute);
            if (_character.Game.Time.IsTimeLaterCurrentTime(time))
            {
                Debug.Log("SCHEDULE_Time_Later " + nearesScheduleTime);
                return nearesScheduleTime;
            }
            else
            {
                Debug.Log("SCHEDULE_TimeCorrect" + nearesScheduleTime);
                nearesScheduleTime = scheduleTime;
            }
        }
        return nearesScheduleTime;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

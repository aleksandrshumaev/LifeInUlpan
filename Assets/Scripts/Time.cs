using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct TimeStruct
{
    int _day;
    int _hour;
    int _minute;
    public TimeStruct(int day,int hour,int minute)
    {
        _day=day;
        _hour=hour;
        _minute=minute;
    }

    public int Day { get => _day;}
    public int Hour { get => _hour;}
    public int Minute { get => _minute;}

    public int CompareTo(TimeStruct time)
    {
        if(_day < time._day)
        {
            return -1;
        }
        else if(_day > time._day)
        {
            return 1;
        }
        else
        {
            if(_hour < time._hour)
            {
                return -1;
            }
            else if(_hour > time._hour)
            {
                return 1;
            }
            else
            {
                if(_minute < time._minute)
                {
                    return -1;
                }
                else if(_minute>time._minute)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

    }
    public TimeStruct AddDays(int days)
    {
        _day += days;
        return this;
    }
    public TimeStruct AddHours(int hours)
    {
        _hour += hours;
        int daysToAdd = _hour / 24;
        int hoursToAdd = _hour % 24;
        _hour = hoursToAdd;
        AddDays(daysToAdd);
        Debug.Log("TIME BED CHECK " + this.Day + " " + this.Hour + " " + this.Minute);
        return this;
    }

    public TimeStruct AddMinutes(int minutes)
    {
        _minute += minutes;
        int hoursToAdd = _minute / 60;
        int minutesToAdd = _minute % 60;
        AddHours(hoursToAdd);
        _minute = minutesToAdd;
        return this;
    }
}
public class Time : MonoBehaviour
{

    int _day=1;
    Game _game;
    int _hours;
    int _minutes;
    TimeStruct _currentTime;
    public delegate void OnTimeChanged();
    OnTimeChanged _onChangingTimeCallBack;
    OnTimeChanged _onChangingDayCallBack;
    public int Day { get => _day; set => _day = value; }
    public OnTimeChanged OnChangingTimeCallBack { get => _onChangingTimeCallBack; set => _onChangingTimeCallBack = value; }
    public OnTimeChanged OnChangingDayCallBack { get => _onChangingDayCallBack; set => _onChangingDayCallBack = value; }

    private void Awake()
    {
        InitializeGame();
    }
    void InitializeGame()
    {
        _game = GameObject.FindGameObjectWithTag("Game").GetComponent<Game>();
        _game.Time = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public TimeStruct GetCurrentTime()
    {
        return new TimeStruct(_day, _hours, _minutes);
    }
    public void NextDay()
    {
        _day++;
        if (_onChangingDayCallBack != null)
        {
            OnChangingDayCallBack.Invoke();
        }
        if (Day % 30 == 0)
        {
            _game.GetAllowance();
        }
        if (Day == _game.UlpanData.Days)
        {
            _game.GameOver();
        }

    }
    public void ChangeMinutesBy(int minutes)
    {
        _minutes += minutes;
        int hoursToAdd = _minutes / 60;
        int minutesToAdd = _minutes % 60;
        ChangeHoursBy(hoursToAdd);
        _minutes=minutesToAdd;
        if(_onChangingTimeCallBack != null)
        {
            OnChangingTimeCallBack.Invoke();
        }
    }
    public void ChangeHoursBy(int hours)
    {
        _hours+=hours;
        int daysToAdd = _hours / 24;
        int hoursToAdd = _hours % 24;
        _hours=hoursToAdd;
        for(int i = 0; i < daysToAdd; i++)
        {
            NextDay();
        }

    }
    public TimeStruct GetHoursAndMinutesFromString(string time)
    {
        int hours; 
        int minutes;
        Int32.TryParse(time.Substring(0, 2),out hours);
        Int32.TryParse(time.Substring(2),out minutes);
        return new TimeStruct(GetCurrentTime().Day, hours, minutes);
    }
    public bool IsTimeLaterCurrentTime(TimeStruct time)
    {
        Debug.Log("TIME_SCHEDULE: "+time.Hour + " " + time.Minute);
        Debug.Log("CURRENT_TIME: " + GetCurrentTime().Hour + " " + GetCurrentTime().Minute);
        if (time.Hour> GetCurrentTime().Hour)
        {
            return true;
        }
        else if(time.Hour< GetCurrentTime().Hour)
        {
            return false;
        }
        else
        {
            if(time.Minute>= GetCurrentTime().Minute)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    internal void SetInitialTime()
    {
        _day=1;
        _hours=9;
        _minutes=0;
    }

    internal void LoadTime(int day, int hour, int minute)
    {
        _day = day;
        _hours = hour;
        _minutes = minute;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimePanel : UiTextLines
{
    [SerializeField]Text _day;
    [SerializeField] Text _time;
    [SerializeField]Text _dayDiscription;
    //Game Game;
    //Time _time;
    // Start is called before the first frame update
    public override void Start()
    {    
        Game=GameObject.FindGameObjectWithTag("Game").GetComponent<Game>();
        _dayDiscription.text = GetTranslation("Ui_Day");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateUi()
    {
        Time time = Game.Time;
        TimeStruct gameTime = time.GetCurrentTime();
        _day.text = time.Day.ToString();
        _time.text = gameTime.Hour.ToString("D2")+" : "+gameTime.Minute.ToString("D2");
    }
}

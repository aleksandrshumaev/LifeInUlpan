using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    int[] _mistakes;
    int[] _seenDiaogues;
    int _stressLevel;
    int _energyLevel;
    int _money;
    int _hairAmount;
    int _ulpanScore;
    int _day;
    int _hour;
    int _minute;
    bool _isUlpanPasedToday;
    bool _isHomeWorkPasedToday;

    public SaveData (Game game)
    {
        Player player = game.Player;
        TimeStruct time=game.Time.GetCurrentTime();
        _stressLevel = player.GetStressLevel();
        _energyLevel = player.GetEnrgyLevel();
        _money = player.GetMoney();
        _hairAmount = player.GetHairAmount();
        _ulpanScore = player.GetUlpanScore();
        _day = time.Day;
        _hour = time.Hour;
        _minute = time.Minute;
        _mistakes = player.Mistakes;
        _seenDiaogues = player.SeenDialogues.ToArray();
        _isUlpanPasedToday = player.IsUlpanPassedToday;
        _isHomeWorkPasedToday = player.IsHomeworkPassedToday;

    }

    public int[] Mistakes { get => _mistakes; set => _mistakes = value; }
    public int StressLevel { get => _stressLevel; set => _stressLevel = value; }
    public int EnergyLevel { get => _energyLevel; set => _energyLevel = value; }
    public int Money { get => _money; set => _money = value; }
    public int HairAmount { get => _hairAmount; set => _hairAmount = value; }
    public int UlpanScore { get => _ulpanScore; set => _ulpanScore = value; }
    public int Day { get => _day; set => _day = value; }
    public int Hour { get => _hour; set => _hour = value; }
    public int Minute { get => _minute; set => _minute = value; }
    public bool IsUlpanPasedToday { get => _isUlpanPasedToday; set => _isUlpanPasedToday = value; }
    public bool IsHomeWorkPasedToday { get => _isHomeWorkPasedToday; set => _isHomeWorkPasedToday = value; }
    public int[] SeenDiaogues { get => _seenDiaogues; set => _seenDiaogues = value; }
}

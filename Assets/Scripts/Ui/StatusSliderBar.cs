using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusSliderBar : MonoBehaviour
{
    [SerializeField] string _atributeName;
    Game _game;
    [SerializeField]Slider _slider;
    [SerializeField]Text _valueText;

    // Start is called before the first frame update
    void Start()
    {
        _game=GameObject.FindGameObjectWithTag("Game").GetComponent<Game>();
        _slider.maxValue= (float)_game.GetPlayer().GetAtribute(_atributeName).MaxValue;
        _slider.minValue = (float)_game.GetPlayer().GetAtribute(_atributeName).MinValue;
        //Debug.Log(_atributeName+" SetMinValue: "+_slider.minValue+" SetMaxValue: "+_slider.maxValue+" But "+_atributeName + " MinValue: " + _game.GetPlayer().GetAtribute(_atributeName).MinValue + " MaxValue: " + _game.GetPlayer().GetAtribute(_atributeName).MaxValue);
    }

    // Update is called once per frame
    public void UpdateUi()
    {
        int newValue = _game.GetPlayer().GetAtribute(_atributeName).Value;
        _slider.value = newValue;
        _valueText.text = newValue.ToString();
    }
}

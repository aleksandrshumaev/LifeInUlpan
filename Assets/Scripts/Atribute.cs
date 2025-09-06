using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atribute
{
    string _name;
    string _description;
    int _value;
    int _maxValue;
    int _minValue;

    public Atribute(string name, string description, int maxValue, int minValue,int value)
    {
        _name = name;
        _description = description;
        _value = value;
        _maxValue = maxValue;
        _minValue = minValue;
    }

    public string Name { get => _name;}
    public int Value { get => _value;}
    public int MaxValue { get => _maxValue;}
    public int MinValue { get => _minValue;}

    public void SetValue(int value)
    {
        if(value<_minValue)
        {
            _value = _minValue;
        }
        else if(value>_maxValue)
        {
            value = _maxValue; 
        }
        else
        {
            _value = value;
        }

    }
    public void ChangeValueBy(int value)
    {
        if(_value+value<_minValue)
        {
            _value = _minValue;
        }
        else if(_value+value>_maxValue)
        {
            _value = _maxValue;
        }
        else
        {
            _value+=value;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Furniture : InteractableObject
{
    string _name;

    public string Name { get => _name; set => _name = value; }

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        _name=gameObject.name;
        Debug.Log("FURNITURE: " + _name);
        Game.CurrentLocation.AddFurniture(this);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Location : MonoBehaviour
{
    [SerializeField]string _name;
    [SerializeField]Furniture _playerStartPosition;
    [SerializeField]Furniture _playerLoadPosition;
    [SerializeField] GameObject _startCameraPosition;
    [SerializeField] GameObject _loadCameraPosition;
    Dictionary<string,Furniture> _furnitures=new Dictionary<string, Furniture>();
    Game _game;
    public string Name { get => _name; set => _name = value; }

    // Start is called before the first frame update
    private void Awake()
    {
        _game = GameObject.FindGameObjectWithTag("Game").GetComponent<Game>();
        _game.CurrentLocation = this;
    }
    void Start()
    {
        if(_game.HasSaveFile())
        {
            _playerLoadPosition.UsedByCharacter(_game.GetPlayer(),false);
            _game.GetCamera().MoveTo(_loadCameraPosition);
        }
        else
        {
            _playerStartPosition.UsedByCharacter(_game.GetPlayer(),false);
            _game.GetCamera().MoveTo(_startCameraPosition);
        }
    }
    public void AddFurniture(Furniture furniture)
    {
        if(!_furnitures.ContainsKey(furniture.Name))
        {
            _furnitures.Add(furniture.Name, furniture);
        }
    }
    public Furniture GetFurniture(string name)
    {
        foreach(string furnitureName in _furnitures.Keys)
        {
            if(furnitureName == name)
            {
                return _furnitures[furnitureName];
            }
        }
        return null;    
    }    

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGame : MonoBehaviour
{
    Game _game;
    [SerializeField]string _name;

    public Game Game { get => _game; set => _game = value; }
    public string Name { get => _name; set => _name = value; }

    // Start is called before the first frame update

    protected void OnEnable()
    {
        InitializeGame();
    }
    public virtual void StartGame(string name="")
    {
        _game.GetPlayer().IsUsingObject = true;
    }
    protected virtual void InitializeGame()
    {
        Game = GameObject.FindGameObjectWithTag("Game").GetComponent<Game>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected void OnDestroy()
    {
        Game.MiniGames.Remove(this);
    }
    protected void OnDisable()
    {
        Game.MiniGames.Remove(this);
    }
}

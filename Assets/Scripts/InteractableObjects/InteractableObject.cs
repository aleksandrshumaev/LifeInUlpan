using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    enum InteractionFaceDirection
    {
        BottomLeft,
        TopLeft,
        TopRight,
        BottomRight,
    }
    enum InteractionStanding
    {
        Standing,
        Sitting,
        Laying
    }
    enum InteractionActivity
    {
        Idle,
        Eating,
        Writing,
        Playing,
    }
    [SerializeField] InteractionFaceDirection _usingFaceDirection;
    [SerializeField] InteractionFaceDirection _choosingFaceDirection;
    [SerializeField] InteractionStanding _usingStanding;
    [SerializeField] InteractionStanding _choosingStanding;


    string _usingDescription="";
    [SerializeField] InteractionActivity _usingActivity;
    [SerializeField] InteractionActivity _choosingActivity;
    [SerializeField] GameObject _characterUsingPosition;
    [SerializeField] GameObject _characterChoosingPosition;
    [SerializeField] GameObject _idleState;
    [SerializeField] GameObject _choosingState;
    [SerializeField] GameObject _usingState;
    [SerializeField] List<InteractableObject> _childObjects;
    [SerializeField] Sound _sound;
    [SerializeField] DialogueTrigger _dialogueTrigger;

    //[SerializeField] AudioSource
    Game _game;

    public Game Game { get => _game; set => _game = value; }
    public string UsingDescription { get => _usingDescription; set => _usingDescription = value; }
    public Sound Sound { get => _sound; set => _sound = value; }
    public DialogueTrigger DialogueTrigger { get => _dialogueTrigger; set => _dialogueTrigger = value; }

    protected virtual void Awake()
    {
        _game= GameObject.FindGameObjectWithTag("Game").GetComponent<Game>();
        _sound.Source = gameObject.AddComponent<AudioSource>();
        if( _sound.Clip != null )
        {
            _sound.Source.clip = _sound.Clip;
            
        }
    }
    // Start is called before the first frame update
    public virtual void Start()
    {
        SetIdleState();
        if(_sound!=null)
        {
            ChangeSoundVolume();
            _game.Settings.OnChangingSoundVolumeCallBack += ChangeSoundVolume;
        }
    }
    void ChangeSoundVolume()
    {
        _sound.Volume = _game.Settings.SoundVolume;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseEnter()
    {
        
        if(!_game.GetPlayer().IsChoosingObject && !_game.GetPlayer().IsUsingObject)
        {
            Debug.Log("entered");
            SetMouseHoveredState();
        }
    }
    public void OnMouseExit()
    {

        if (!_game.GetPlayer().IsChoosingObject && !_game.GetPlayer().IsUsingObject)
        {
            Debug.Log("exit");
            SetIdleState();
        }
    }
    public virtual void OnMouseDown()
    {
        if(!_game.GetPlayer().IsChoosingObject && !_game.GetPlayer().IsUsingObject)
        {
            Debug.Log("mosueDown");
            if (_game.Ui.DescriptionPanelUi.ShowInteractableObjectDescriptionPanel(this))
            {
                ChosedByCharacter(_game.GetPlayer());
            }
            else
            {
                UseAction();
            }
        }
    }
    void DisableAllStates()
    {
        _idleState.SetActive(false);
        _choosingState.SetActive(false);
        _usingState.SetActive(false);
    }
    public virtual void SetMouseHoveredState()
    {
        SetChosedState();
    }
    public virtual void SetChosedState()
    {
        foreach (InteractableObject child in _childObjects)
        {
            child.SetChosedState();
        }
        DisableAllStates();
        _choosingState.SetActive(true);
    }
    public virtual void SetUsedState()
    {
        foreach (InteractableObject child in _childObjects)
        {
            child.SetUsedState();
        }
        DisableAllStates();
        _usingState.SetActive(true);
    }
    public virtual void SetIdleState()
    {
        foreach (InteractableObject child in _childObjects)
        {
            child.SetIdleState();
        }
        DisableAllStates();
        _idleState.SetActive(true);
    }
    protected void ChosedByCharacter(Character character)
    {
        character.SetState(_choosingStanding.ToString(), _choosingActivity.ToString(), (int)_choosingFaceDirection, _characterChoosingPosition.transform.position,false,true);
        SetChosedState();
    }
    public void UsedByCharacter(Character character,bool isUsingBlockingMouse=true)
    {
        character.SetState(_usingStanding.ToString(), _usingActivity.ToString(), (int)_usingFaceDirection, _characterUsingPosition.transform.position, isUsingBlockingMouse);
        SetUsedState();
        if (DialogueTrigger != null)
        {
            Debug.Log(DialogueTrigger.Dialogue.Id);
            DialogueTrigger.StartDialogue();
        }
        Debug.Log(character.name + " use " + this.name);
        //character.UseFurniture(this);
    }
    public virtual void UseAction(bool IsUsingBlockingMouse=true)
    {
        _sound.Source.Play();
        UsedByCharacter(_game.GetPlayer());


    }
    public virtual void StopUsing(Character character)
    {
        _sound.Source.Stop();
        Debug.Log(gameObject.name+" StopUsing");
        character.SetState(_choosingStanding.ToString(), _choosingActivity.ToString(), (int)_choosingFaceDirection, _characterChoosingPosition.transform.position,false);
        SetIdleState();
        //character.StopUsingCurrentFurniture();
    }
    public string GetDescription()
    {
        throw new NotImplementedException();
    }
    public void OnDestroy()
    {
        if (_sound != null)
        {
            _game.Settings.OnChangingSoundVolumeCallBack -= ChangeSoundVolume;
        }
    }
}

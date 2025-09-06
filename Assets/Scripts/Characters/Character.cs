using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : InteractableObject
{
    [SerializeField]string _name;
    InteractableObject _usingFurniture;
    string _currentActivity;
    string _continuingActivity;
    string _standing;
    int _faceDirection;
    bool _isUsingObject;
    bool _isChoosingObject;
    CharacterAnimation _characterAnimation;

    public bool IsUsingObject { get => _isUsingObject; set => _isUsingObject = value; }
    public bool IsChoosingObject { get => _isChoosingObject; set => _isChoosingObject = value; }
    public CharacterAnimation CharacterAnimation { get => _characterAnimation; set => _characterAnimation = value; }
    public string Name { get => _name; set => _name = value; }

    protected override void Awake()
    {
        base.Awake();
        _characterAnimation = GetComponent<CharacterAnimation>();
        if(_name!="Player")
        {
            Game.Characters.Add(this);
        }
    }
    // Start is called before the first frame update
    public override void Start()
    {
        SetState("Standing","Idle",3,this.transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetPosition(Vector3 position)
    {
        this.gameObject.transform.position = position;
    }
    void SetStanding(string standing)
    {
        _standing = standing;
    }
    void SetFaceDirection(int faceDirection)
    {
        _faceDirection = faceDirection;
    }
    void SetCurrentActivity(string currentActivity)
    {
        _currentActivity = currentActivity;
    }
    void SetContinuingActivity(string continuingActivity)
    {
        _continuingActivity=continuingActivity;
    }
    public void SetMouseHoveredAnimation()
    {
        SetCurrentActivity("Chosed");
        RefreshAnimation();

    }
    public void SetMouseExitAnimation()
    {
        SetCurrentActivity(_continuingActivity);
        RefreshAnimation();
    }
    public void SetTalkAnimation()
    {
        SetCurrentActivity("Talk");
        RefreshAnimation();
    }
    public void SetTalkEndsAnimation()
    {
        SetCurrentActivity(_continuingActivity);
        RefreshAnimation();
    }
    public void SetState(string standing, string activity, int faceDirection, Vector3 position,bool isUsingObject=false,bool isChoosingObject=false)
    {
        SetStanding(standing);
        SetFaceDirection(faceDirection);
        SetCurrentActivity(activity);
        SetContinuingActivity(activity);
        SetPosition(position);
        RefreshAnimation();
        _isUsingObject = isUsingObject;
        _isChoosingObject = isChoosingObject;
    }
    public void StopUsingCurrentFurniture()
    {
        if(_usingFurniture!=null)
            _usingFurniture.StopUsing(this);
    }
    public void UseFurniture(InteractableObject furniture)
    {
        _usingFurniture=furniture;
    }
    void RefreshAnimation()
    {
        _characterAnimation.RefreshAnimation(_faceDirection,_standing,_currentActivity);
    }
}

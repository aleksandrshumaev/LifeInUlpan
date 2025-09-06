using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] GameObject _ulpanMinigamePanel;
    [SerializeField] GameObject _buttonPanel;
    //
    //
    //
    [SerializeField] DescriptionPanelUi _descriptionPanelUi;
    [SerializeField] ComputerDescriptionUi _computerDescriptionUi;
    [SerializeField] BedDescriptionUi _bedDescriptionUi;
    [SerializeField] KitchenDescriptionUi _kitchenDescriptionUi;
    [SerializeField] WiskyDescriptionUi _wiskyDescriptionUi;
    [SerializeField] HomeWorkDescriptionUi _homeWorkDescriptionUi;
    [SerializeField] TeacherDescriptionUi _teacherDescriptionUi;
    [SerializeField] DoorDescriptionUi _doorDescriptionUi;
    [SerializeField] FriendTalkingUi _friendTalkingUi;
    [SerializeField] StatusSliderBar _energyLevelBar;
    [SerializeField] StatusSliderBar _stressLevelBar;
    [SerializeField] TimePanel _timePanel;
    [SerializeField] MoneyPanel _moneyPanel;
    [SerializeField] FacePanel _facePanel;
    [SerializeField] WhiteboardDescriptionUi _whiteboardDescriptionUi;
    [SerializeField] PassedoutNoteUi _passedoutNoteUi;
    [SerializeField] DialogueUi _dialogueUi;
    [SerializeField] GameOverScreens _gameOverScreens;
    Game _game;
    Animator _animator;
    //public GameObject InteractableObjectDesriptionPanel { get => _interactableObjectDesriptionPanel; set => _interactableObjectDesriptionPanel = value; }
    public BedDescriptionUi BedDescriptionUi { get => _bedDescriptionUi; set => _bedDescriptionUi = value; }
    public ComputerDescriptionUi ComputerDescriptionUi { get => _computerDescriptionUi; set => _computerDescriptionUi = value; }
    public DescriptionPanelUi DescriptionPanelUi { get => _descriptionPanelUi; set => _descriptionPanelUi = value; }
    public KitchenDescriptionUi KitchenDescriptionUi { get => _kitchenDescriptionUi; set => _kitchenDescriptionUi = value; }
    public WiskyDescriptionUi WiskyDescriptionUi { get => _wiskyDescriptionUi; set => _wiskyDescriptionUi = value; }
    public HomeWorkDescriptionUi HomeWorkDescriptionUi { get => _homeWorkDescriptionUi; set => _homeWorkDescriptionUi = value; }
    public DoorDescriptionUi DoorDescriptionUi { get => _doorDescriptionUi; set => _doorDescriptionUi = value; }
    public FriendTalkingUi FriendTalkingUi { get => _friendTalkingUi; set => _friendTalkingUi = value; }
    public WhiteboardDescriptionUi WhiteboardDescriptionUi { get => _whiteboardDescriptionUi; set => _whiteboardDescriptionUi = value; }
    public TeacherDescriptionUi TeacherDescriptionUi { get => _teacherDescriptionUi; set => _teacherDescriptionUi = value; }
    public PassedoutNoteUi PassedoutNoteUi { get => _passedoutNoteUi; set => _passedoutNoteUi = value; }
    public DialogueUi DialogueUi { get => _dialogueUi; set => _dialogueUi = value; }
    public GameOverScreens GameOverScreens { get => _gameOverScreens; set => _gameOverScreens = value; }

    // Start is called before the first frame update
    private void Awake()
    {
        InitializeGame();
        _animator = GetComponent<Animator>();
    }
    void InitializeGame()
    {
        _game=GameObject.FindGameObjectWithTag("Game").GetComponent<Game>();
        _game.Ui = this;
    }
    void Start()
    {
        UpdateUi();
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void Fade()
    {
        _animator.Play("FadeIn", 0);
    }
    public void ShowUlpanMinigame()
    {
        _ulpanMinigamePanel.SetActive(true);
        //_buttonPanel.SetActive(false);
    }

    public void UpdateUi()
    {
        _energyLevelBar.UpdateUi();
        _stressLevelBar.UpdateUi();
        _timePanel.UpdateUi();
        _moneyPanel.UpdateUi();
        _facePanel.UpdateUi();
    }
    /*public bool ShowInteractableObjectDescriptionPanel(InteractableObject interactableObject)
{
   string interactableObjectDescription = interactableObject.UsingDescription;
   if (interactableObjectDescription != "")
   {
       _interactableObjectDesriptionPanel.SetActive(true);
       _interactableObjectDesriptionPanel.GetComponent<InteractableObjectChoosingUi>().ShowDescription(interactableObject);
       return true;
   }
   return false;
}*/
    /*public void ShowComputerUsedDescription(Computer computer,string description)
    {
        if (computer != null)
        {
            _computerDescriptionUi.ShowDescription(computer, _game.GetTranslation(description));
        }
    }
    public void ShowBedUsedDescription(Bed bed, string description)
    {
        if (bed != null)
        {
            _bedDescriptionUi.ShowDescription(bed, _game.GetTranslation(description));
        }
    }*/
}

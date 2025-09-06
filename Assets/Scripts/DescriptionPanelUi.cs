using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DescriptionPanelUi : UiTextLines
{
    [SerializeField] GameObject _desriptionPanel;
    [SerializeField] Text _description;
    InteractableObject _interactableObject;

    public GameObject DesriptionPanel { get => _desriptionPanel;}
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        _desriptionPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool IsPanelActive()
    {
        return DesriptionPanel.activeSelf;
    }
    public bool ShowInteractableObjectDescriptionPanel(InteractableObject interactableObject)
    {
        string interactableChoosingObjectDescription = interactableObject.UsingDescription;
        if (interactableChoosingObjectDescription != "")
        {
            _desriptionPanel.SetActive(true);
            ShowDescription(interactableObject,GetTranslation(interactableChoosingObjectDescription));
            return true;
        }
        return false;
    }
    public void ShowDescription(InteractableObject interactableObject,string chosigDescriprion)
    {
        _interactableObject = interactableObject;
        _description.text= chosigDescriprion;
    }
    public void OnConfirmButton()
    {
        _interactableObject.UseAction();
        _interactableObject = null;
        _desriptionPanel.SetActive(false);
    }
    public void OnCancleButton()
    {
        _interactableObject.StopUsing(_interactableObject.Game.GetPlayer());
        _interactableObject = null;
        _desriptionPanel.SetActive(false);
    }
}

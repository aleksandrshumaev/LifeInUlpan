using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeacherDescriptionUi : UiTextLines
{
    // Start is called before the first frame update
    [SerializeField] GameObject _alreadyUsedDescriptionPanel;
    [SerializeField] Text _alreadyUsedDescription;
    Teacher _teacher;
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ShowAlreadyUsedPanel(Teacher teacher, string description)
    {
        _alreadyUsedDescriptionPanel.SetActive(true);
        _teacher = teacher;
        _alreadyUsedDescription.text = GetTranslation(description);
    }
    public void OnAlreadyUsedConfirButton()
    {
        HomeWorkDone();
        _alreadyUsedDescriptionPanel.SetActive(false);
    }
    public void HomeWorkDone()
    {
        _teacher.UlpanDone();
        _teacher = null;
    }
}

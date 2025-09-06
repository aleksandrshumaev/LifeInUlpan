using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordSlot : MonoBehaviour
{
    [SerializeField] Text _text;
    GameObject _slotPanel;
    [SerializeField] Word _word;
    [SerializeField]Button _button;
    Image _panelImage;

    public Word Word { get => _word; set => _word = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnSlotButton()
    {
        Debug.Log(_word.Name + " " + _word.Type + " clicked");
        _word.OnClick();
    }
    public void SetUp(Word word)
    {
        _word = word;
        _button.enabled = true;
        _text.text = word.Name;
        _slotPanel = this.gameObject;
        _panelImage = _slotPanel.GetComponent<Image>();
        _button=_slotPanel.GetComponent<Button>();
        SetAsUnSelected();
        _word.Slot = this;
    }
    public void SetAsSelected()
    {
        Debug.Log("selected_"+Word.Name);
        //_panelImage.color = new Color(100f,100f,100f,255f);
        //_panelImage.color = new Color(160f, 230f, 255f);
        _panelImage.color = Color.yellow;
    }
    public void SetAsUnSelected()
    {
        if(_button.enabled)
        {
            _panelImage.color = new Color(255, 255, 255, 255);
        }
        else
        {
            _panelImage.color= Color.grey;
        }
    }
    public void SetAsCorrect()
    {
        _panelImage.color = Color.green;
        _button.enabled = false;
        StartCoroutine(ColoredTimer());
    }
    public void SetAsWrong()
    {
        _panelImage.color =Color.red;
        StartCoroutine(ColoredTimer());
    }
    IEnumerator ColoredTimer()
    {
        yield return new WaitForSeconds(1);
        SetAsUnSelected();
    }


}

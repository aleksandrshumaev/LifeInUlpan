using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyPanel : UiTextLines
{
    [SerializeField] Text _money;
    [SerializeField] Text _moneyPanel;
    // Start is called before the first frame update
    public override void Start()
    {
        _moneyPanel.text = GetTranslation("Ui_MoneyPanel");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateUi()
    {
        _money.text = Game.GetPlayer().GetMoney().ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FacePanel : UiTextLines
{
    [SerializeField] Image _hairState;
    [SerializeField] List<Sprite> _hairTextures;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
    }
    int GetHairTextureIndex()
    {
        int hairAmountValue = Game.GetPlayer().GetAtribute("HairAmount").Value;
        int index;
        if (hairAmountValue > 0)
        {
            index = (hairAmountValue / 10) + 1;
        }
        else
        {
            index = 0;
        }
        return index;
    }
    public void UpdateUi()
    {
        _hairState.sprite = _hairTextures[GetHairTextureIndex()];
    }
}

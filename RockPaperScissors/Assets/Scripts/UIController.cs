using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [Header("Type Images")]
    [SerializeField] Image rockImg = null;
    [SerializeField] Image rockImg2 = null;
    [SerializeField] Image paperImg = null;
    [SerializeField] Image paperImg2 = null;
    [SerializeField] Image scissorsImg = null;
    [SerializeField] Image scissorsImg2 = null;

    public void UpdateTypeText(Player.activeType typing)
    {
        switch (typing)
        {
            case Player.activeType.rock:
                rockImg.rectTransform.sizeDelta = new Vector2(80, 80);
                rockImg2.rectTransform.sizeDelta = new Vector2(70, 70);

                paperImg.rectTransform.sizeDelta = new Vector2(50, 50);
                paperImg2.rectTransform.sizeDelta = new Vector2(40, 40);

                scissorsImg.rectTransform.sizeDelta = new Vector2(50, 50);
                scissorsImg2.rectTransform.sizeDelta = new Vector2(40, 40);
                break;
            case Player.activeType.paper:
                rockImg.rectTransform.sizeDelta = new Vector2(50, 50);
                rockImg2.rectTransform.sizeDelta = new Vector2(40, 40);

                paperImg.rectTransform.sizeDelta = new Vector2(80, 80);
                paperImg2.rectTransform.sizeDelta = new Vector2(70, 70);

                scissorsImg.rectTransform.sizeDelta = new Vector2(50, 50);
                scissorsImg2.rectTransform.sizeDelta = new Vector2(40, 40);
                break;
            case Player.activeType.scissors:
                rockImg.rectTransform.sizeDelta = new Vector2(50, 50);
                rockImg2.rectTransform.sizeDelta = new Vector2(40, 40);

                paperImg.rectTransform.sizeDelta = new Vector2(50, 50);
                paperImg2.rectTransform.sizeDelta = new Vector2(40, 40);

                scissorsImg.rectTransform.sizeDelta = new Vector2(80, 80);
                scissorsImg2.rectTransform.sizeDelta = new Vector2(70, 70);
                break;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [Header("New Sizes")]
    public int boardMin;
    public int boardMax;
    public int imgMin;
    public int imgMax;

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
                rockImg.rectTransform.sizeDelta = new Vector2(boardMax, boardMax);
                rockImg2.rectTransform.sizeDelta = new Vector2(imgMax, imgMax);

                paperImg.rectTransform.sizeDelta = new Vector2(boardMin, boardMin);
                paperImg2.rectTransform.sizeDelta = new Vector2(imgMin, imgMin);

                scissorsImg.rectTransform.sizeDelta = new Vector2(boardMin, boardMin);
                scissorsImg2.rectTransform.sizeDelta = new Vector2(imgMin, imgMin);
                break;
            case Player.activeType.paper:
                rockImg.rectTransform.sizeDelta = new Vector2(boardMin, boardMin);
                rockImg2.rectTransform.sizeDelta = new Vector2(imgMin, imgMin);

                paperImg.rectTransform.sizeDelta = new Vector2(boardMax, boardMax);
                paperImg2.rectTransform.sizeDelta = new Vector2(imgMax, imgMax);

                scissorsImg.rectTransform.sizeDelta = new Vector2(boardMin, boardMin);
                scissorsImg2.rectTransform.sizeDelta = new Vector2(imgMin, imgMin);
                break;
            case Player.activeType.scissors:
                rockImg.rectTransform.sizeDelta = new Vector2(boardMin, boardMin);
                rockImg2.rectTransform.sizeDelta = new Vector2(imgMin, imgMin);

                paperImg.rectTransform.sizeDelta = new Vector2(boardMin, boardMin);
                paperImg2.rectTransform.sizeDelta = new Vector2(imgMin, imgMin);

                scissorsImg.rectTransform.sizeDelta = new Vector2(boardMax, boardMax);
                scissorsImg2.rectTransform.sizeDelta = new Vector2(imgMax, imgMax);
                break;
        }
    }
}

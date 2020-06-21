using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [Header("Text")]
    [SerializeField] TextMeshProUGUI curText = null;

    [Header("Type Images")]
    [SerializeField] Image rockImg = null;
    [SerializeField] Image paperImg = null;
    [SerializeField] Image scissorsImg = null;

    public void UpdateTypeText(Player.activeType typing)
    {
        switch (typing)
        {
            case Player.activeType.rock:
                curText.text = "ROCK";
                rockImg.rectTransform.sizeDelta = new Vector2(80, 80);
                paperImg.rectTransform.sizeDelta = new Vector2(50, 50);
                scissorsImg.rectTransform.sizeDelta = new Vector2(50, 50);
                break;
            case Player.activeType.paper:
                curText.text = "PAPER";
                rockImg.rectTransform.sizeDelta = new Vector2(50, 50);
                paperImg.rectTransform.sizeDelta = new Vector2(80, 80);
                scissorsImg.rectTransform.sizeDelta = new Vector2(50, 50);
                break;
            case Player.activeType.scissors:
                curText.text = "SCISSORS";
                rockImg.rectTransform.sizeDelta = new Vector2(50, 50);
                paperImg.rectTransform.sizeDelta = new Vector2(50, 50);
                scissorsImg.rectTransform.sizeDelta = new Vector2(80, 80);
                break;
        }
    }
}

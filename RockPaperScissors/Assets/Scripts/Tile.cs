using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tile : MonoBehaviour
{
    public enum type
    {
        normal,
        stairs,
        rock,
        paper,
        scissors
    }

    [Header("Tile information")]
    public bool walkableTile;
    [Space]
    public type tileType;
    public bool endNode;
    public string endName;
    [Space]
    [SerializeField] Sprite baseSprite = null;
    [SerializeField] GameObject child = null;

    SpriteRenderer sr;

    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void ClearTile()
    {
        walkableTile = true;
        sr.sprite = baseSprite;
        child.SetActive(false);

        if (endNode)
            SceneManager.LoadScene(endName);
    }
}

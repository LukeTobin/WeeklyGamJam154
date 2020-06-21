using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    [Space]
    [SerializeField] Sprite baseSprite;

    SpriteRenderer sr;

    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void ClearTile()
    {
        walkableTile = true;
        sr.sprite = baseSprite;
    }

}

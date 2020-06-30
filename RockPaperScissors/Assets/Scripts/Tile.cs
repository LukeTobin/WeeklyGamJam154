using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tile : MonoBehaviour
{
    public enum type
    {
        normal,
        purple,
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
    int health = 2;

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

    public void DestroyTile()
    {
        if (tileType == type.purple)
        {
            health--;
            if (health < 1)
            {
                Destroy(this.gameObject);
            }
            else
            {
                sr.sprite = baseSprite;
            }
        }
        else
        {
            sr.sprite = baseSprite;
            Destroy(this.gameObject);
        }
    }
}

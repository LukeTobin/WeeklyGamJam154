using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum activeType
    {
        rock,
        paper,
        scissors
    }

    public enum direction
    {
        up,
        down,
        left,
        right
    }

    [Header("Enumerated")]
    public activeType currentType;
    public direction facingDirection;

    [Header("Sprites")]
    [SerializeField] Sprite sprUp;
    [SerializeField] Sprite sprDown;
    [SerializeField] Sprite sprLeft;
    [SerializeField] Sprite sprRight;

    [Header("Checks")]
    public LayerMask obstacleLayer;

    SpriteRenderer sr;
    UIController ui;


    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        ui = FindObjectOfType<UIController>();

        ui.UpdateTypeText(currentType);
    }

    private void Update()
    {
        // movement
        if (Input.GetKeyDown(KeyCode.W))
        {
            facingDirection = direction.up;
            sr.sprite = sprUp;

            CheckMove(facingDirection);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            facingDirection = direction.down;
            sr.sprite = sprDown;

            CheckMove(facingDirection);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            facingDirection = direction.right;
            sr.sprite = sprRight;

            CheckMove(facingDirection);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            facingDirection = direction.left;
            sr.sprite = sprLeft;

            CheckMove(facingDirection);
        }

        // use type
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack(facingDirection);
        }
    }

    void CheckMove(direction dir)
    {
        if (dir == direction.up)
        {
            Collider2D obstacle = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y + 1f), 0.1f, obstacleLayer);
            if (obstacle != null && obstacle.GetComponent<Tile>())
            {
                if (obstacle.GetComponent<Tile>().walkableTile)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + 1.1f);
                    NextType();
                }
            }
        }
        else if (dir == direction.down)
        {
            Collider2D obstacle = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y - 1.3f), 0.2f, obstacleLayer);
            if (obstacle != null && obstacle.GetComponent<Tile>())
            {
                if (obstacle.GetComponent<Tile>().walkableTile)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y - 1.1f);
                    NextType();
                }
            }
        }
        else if (dir == direction.right)
        {
            Collider2D obstacle = Physics2D.OverlapCircle(new Vector2(transform.position.x + .9f, transform.position.y), 0.1f, obstacleLayer);
            if (obstacle != null && obstacle.GetComponent<Tile>())
            {
                if (obstacle.GetComponent<Tile>().walkableTile)
                {
                    transform.position = new Vector2(transform.position.x + 1.1f, transform.position.y);
                    NextType();
                }
            }
        }
        else if (dir == direction.left)
        {
            Collider2D obstacle = Physics2D.OverlapCircle(new Vector2(transform.position.x - .9f, transform.position.y), 0.1f, obstacleLayer);
            if (obstacle != null && obstacle.GetComponent<Tile>())
            {
                if (obstacle.GetComponent<Tile>().walkableTile)
                {
                    transform.position = new Vector2(transform.position.x - 1.1f, transform.position.y);
                    NextType();
                }
            }
        }

    }

    void Attack(direction dir)
    {
        if (dir == direction.up)
        {
            Collider2D obstacle = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y + 1f), 0.1f, obstacleLayer);
            if (obstacle != null && obstacle.GetComponent<Tile>())
            {
                if (!obstacle.GetComponent<Tile>().walkableTile)
                {
                    switch (obstacle.GetComponent<Tile>().tileType)
                    {
                        case Tile.type.paper:
                            if (currentType == activeType.paper)
                            {
                                // BOUNCE ANIMATION
                            }
                            else if (currentType == activeType.rock)
                            {
                                // DETH
                            }
                            else if (currentType == activeType.scissors)
                            {
                                obstacle.GetComponent<Tile>().ClearTile();
                            }
                            break;
                        case Tile.type.rock:
                            if (currentType == activeType.paper)
                            {
                                obstacle.GetComponent<Tile>().ClearTile();
                            }
                            else if (currentType == activeType.rock)
                            {
                                
                            }
                            else if (currentType == activeType.scissors)
                            {

                            }
                            break;
                        case Tile.type.scissors:
                            if (currentType == activeType.paper)
                            {
                                // BOUNCE ANIMATION
                            }
                            else if (currentType == activeType.rock)
                            {
                                obstacle.GetComponent<Tile>().ClearTile();
                            }
                            else if (currentType == activeType.scissors)
                            {

                            }
                            break;
                    }
                }
            }
        }
    }

    void NextType()
    {
        if (currentType == activeType.rock)
            currentType = activeType.paper;
        else if (currentType == activeType.paper)
            currentType = activeType.scissors;
        else if (currentType == activeType.scissors)
            currentType = activeType.rock;

        ui.UpdateTypeText(currentType);
    }
}

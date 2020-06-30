using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField] Sprite sprUp = null;
    [SerializeField] Sprite sprDown = null;
    [SerializeField] Sprite sprLeft = null;
    [SerializeField] Sprite sprRight = null;

    [Header("Checks")]
    [SerializeField] GameObject checkerCenter = null;
    [SerializeField] GameObject checkerUp = null;
    [SerializeField] GameObject checkerDown = null;
    [SerializeField] GameObject checkerRight = null;
    [SerializeField] GameObject checkerLeft = null;

    [Header("Checks")]
    public LayerMask obstacleLayer;
    [SerializeField] GameObject currentTile = null;

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
            if (currentTile != null)
                currentTile.GetComponent<Tile>().DestroyTile();
            CheckMove(direction.up);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentTile != null)
                currentTile.GetComponent<Tile>().DestroyTile();
            CheckMove(direction.down);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (currentTile != null)
                currentTile.GetComponent<Tile>().DestroyTile();
            CheckMove(direction.right);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (currentTile != null)
                currentTile.GetComponent<Tile>().DestroyTile();
            CheckMove(direction.left);
        }
    }

    void CheckMove(direction dir)
    {
        if (dir == direction.up)
        {
            Collider2D obstacle = Physics2D.OverlapCircle(checkerUp.transform.position, 0.1f, obstacleLayer);
            if (obstacle != null && obstacle.GetComponent<Tile>())
            {
                if (obstacle.GetComponent<Tile>().walkableTile)
                {
                    currentTile = obstacle.gameObject;

                    transform.position = new Vector2(transform.position.x, transform.position.y + 1.1f);

                    facingDirection = direction.up;
                    sr.sprite = sprUp;

                    NextType();

                    CheckNewPos();
                }
                else
                {
                    facingDirection = direction.up;
                    sr.sprite = sprUp;

                    Attack(facingDirection);
                }
            }
            else
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + 1.1f);
                facingDirection = direction.up;
                sr.sprite = sprUp;
                KillPlayer();
            }
        }
        else if (dir == direction.down)
        {
            Collider2D obstacle = Physics2D.OverlapCircle(checkerDown.transform.position, 0.1f, obstacleLayer);
            if (obstacle != null && obstacle.GetComponent<Tile>())
            {
                if (obstacle.GetComponent<Tile>().walkableTile)
                {
                    currentTile = obstacle.gameObject;

                    transform.position = new Vector2(transform.position.x, transform.position.y - 1.1f);

                    facingDirection = direction.down;
                    sr.sprite = sprDown;

                    NextType();

                    CheckNewPos();
                }
                else
                {
                    facingDirection = direction.down;
                    sr.sprite = sprDown;

                    Attack(facingDirection);
                }
            }
            else
            {
                transform.position = new Vector2(transform.position.x, transform.position.y - 1.1f);
                facingDirection = direction.down;
                sr.sprite = sprDown;
                KillPlayer();
            }
        }
        else if (dir == direction.right)
        {
            Collider2D obstacle = Physics2D.OverlapCircle(checkerRight.transform.position, 0.01f, obstacleLayer);
            if (obstacle != null && obstacle.GetComponent<Tile>())
            {
                if (obstacle.GetComponent<Tile>().walkableTile)
                {
                    currentTile = obstacle.gameObject;

                    transform.position = new Vector2(transform.position.x + 1.1f, transform.position.y);

                    facingDirection = direction.right;
                    sr.sprite = sprRight;

                    NextType();

                    CheckNewPos();
                }
                else
                {
                    facingDirection = direction.right;
                    sr.sprite = sprRight;

                    Attack(facingDirection);
                }
            }
            else
            {
                transform.position = new Vector2(transform.position.x + 1.1f, transform.position.y);
                facingDirection = direction.right;
                sr.sprite = sprRight;
                KillPlayer();
            }
        }
        else if (dir == direction.left)
        {
            Collider2D obstacle = Physics2D.OverlapCircle(checkerLeft.transform.position, 0.01f, obstacleLayer);
            if (obstacle != null && obstacle.GetComponent<Tile>())
            {
                if (obstacle.GetComponent<Tile>().walkableTile)
                {
                    currentTile = obstacle.gameObject;

                    transform.position = new Vector2(transform.position.x - 1.1f, transform.position.y);

                    facingDirection = direction.left;
                    sr.sprite = sprLeft;

                    NextType();

                    CheckNewPos();
                }
                else
                {
                    facingDirection = direction.left;
                    sr.sprite = sprLeft;

                    Attack(facingDirection);
                }
            }
            else
            {
                transform.position = new Vector2(transform.position.x - 1.1f, transform.position.y);
                facingDirection = direction.left;
                sr.sprite = sprLeft;
                KillPlayer();
            }
        }

    }

    void Attack(direction dir)
    {
        if (dir == direction.up)
        {
            Collider2D obstacle = Physics2D.OverlapCircle(checkerUp.transform.position, 0.1f, obstacleLayer);
            if (obstacle != null && obstacle.GetComponent<Tile>())
            {
                if (!obstacle.GetComponent<Tile>().walkableTile)
                {
                    CheckAttackPos(new Vector2(transform.position.x, transform.position.y + 1.1f), obstacle.GetComponent<Tile>().tileType, obstacle.GetComponent<Tile>());
                }
            }
        }
        else if (dir == direction.down)
        {
            Collider2D obstacle = Physics2D.OverlapCircle(checkerDown.transform.position, 0.1f, obstacleLayer);
            if (obstacle != null && obstacle.GetComponent<Tile>())
            {
                if (!obstacle.GetComponent<Tile>().walkableTile)
                {
                    CheckAttackPos(new Vector2(transform.position.x, transform.position.y - 1.1f), obstacle.GetComponent<Tile>().tileType, obstacle.GetComponent<Tile>());
                }
            }
        }
        else if (dir == direction.right)
        {
            Collider2D obstacle = Physics2D.OverlapCircle(checkerRight.transform.position, 0.1f, obstacleLayer);
            if (obstacle != null && obstacle.GetComponent<Tile>())
            {
                if (!obstacle.GetComponent<Tile>().walkableTile)
                {
                    CheckAttackPos(new Vector2(transform.position.x + 1.1f, transform.position.y), obstacle.GetComponent<Tile>().tileType, obstacle.GetComponent<Tile>());
                }
            }
        }
        else if (dir == direction.left)
        {
            Collider2D obstacle = Physics2D.OverlapCircle(checkerLeft.transform.position, 0.1f, obstacleLayer);
            if (obstacle != null && obstacle.GetComponent<Tile>())
            {
                if (!obstacle.GetComponent<Tile>().walkableTile)
                {
                    CheckAttackPos(new Vector2(transform.position.x - 1.1f, transform.position.y), obstacle.GetComponent<Tile>().tileType, obstacle.GetComponent<Tile>());
                }
            }
        }
    }

    void CheckAttackPos(Vector2 checkVector, Tile.type tileType, Tile tile)
    {
        switch (tileType)
        {
            case Tile.type.paper:
                if (currentType == activeType.paper)
                {
                    KillPlayer();
                }
                else if (currentType == activeType.rock)
                {
                    KillPlayer();
                }
                else if (currentType == activeType.scissors)
                {
                    tile.ClearTile();
                    transform.position = checkVector;
                    currentTile = tile.gameObject;
                    NextType();
                    //CheckNewPos();
                }
                break;
            case Tile.type.rock:
                if (currentType == activeType.paper)
                {
                    tile.ClearTile();
                    transform.position = checkVector;
                    currentTile = tile.gameObject;
                    NextType();
                    //CheckNewPos();
                }
                else if (currentType == activeType.rock)
                {
                    KillPlayer();
                }
                else if (currentType == activeType.scissors)
                {
                    KillPlayer();
                }
                break;
            case Tile.type.scissors:
                if (currentType == activeType.paper)
                {
                    KillPlayer();
                }
                else if (currentType == activeType.rock)
                {
                    tile.ClearTile();
                    transform.position = checkVector;
                    currentTile = tile.gameObject;
                    NextType();
                    //CheckNewPos();
                }
                else if (currentType == activeType.scissors)
                {
                    KillPlayer();
                }
                break;
        }
    }

    void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void CheckNewPos()
    {
        Collider2D obstacle = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y), 0.1f, obstacleLayer);
        if(obstacle == null)
        {
            KillPlayer();
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

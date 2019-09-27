using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{



    private Vector2 gridMoveDirection;
    [System.NonSerialized] public Vector2 gridPosition;
    private Vector2 oldSnakeHeadPos;
    [SerializeField] private float gridMoveTimer = 0.1f;

    public float timer = 0f;
    float MaxTime = 0.1f;
    public float timerOffset = 0f;

    [SerializeField] private float gridMoveTimerMax;
    //SerializedField can expose private variable to inspector so it can be edited. 
    //Good to keep variables private for security reasons I.E. other scripts can't access them at will.
    [SerializeField] private float moveSpace = 0f;
    [SerializeField] private int maxBodyCount = 0;
    [SerializeField] GameObject snakeBody = null;

    [SerializeField] private List<GameObject> bodyObjects = new List<GameObject>();
    //[SerializeField] private float rayDistance; //It was used in my original script
    [SerializeField] bool isAlive;

    public LinkedListTest linkedList;
    public GameObject objMainHead;
    public GameObject bodiesRoot; //all my clones are collected in bodiesRoot

    private enum directions { North, South, East, West, none }
    private directions currentDir = directions.West;

    Vector3 desiredDirection;

    private void Awake()
    {
        desiredDirection = Vector2.left * moveSpace;

        isAlive = true;

        gridPosition = new Vector2(10, 10);
        gridMoveTimer = gridMoveTimerMax;

        linkedList = new LinkedListTest();
        objMainHead = Instantiate(snakeBody, gridPosition, Quaternion.identity);
        objMainHead.gameObject.tag = "Player";

        objMainHead.transform.parent = gameObject.transform;

        linkedList.PushBack(objMainHead);
        maxBodyCount--;

        timer = Time.time + timerOffset;
    }



    private GameObject SnakeInstantiate()
    {
        GameObject obj = Instantiate(snakeBody, linkedList.GetLastNode().lastPosition, Quaternion.identity, bodiesRoot.transform);


        if (obj.GetComponent<BoxCollider2D>() != null)
        {
            bodyObjects.Add(obj);
            print(bodyObjects.Count);
        }
        else
        {
            obj.AddComponent<BoxCollider2D>();
            bodyObjects.Add(obj);
            print(bodyObjects.Count);
        }

        return obj;
    }
    private void GrowSnake()
    {
        linkedList.PushBack(SnakeInstantiate());
        maxBodyCount--;
    }



    private void Update()
    {
        // gridPosition.y += 0.5f;
        if (isAlive)
        {
            timer += Time.deltaTime;

            if (Input.anyKey) { checkInput(); }
            if (timer > MaxTime)
            {
                timer = 0;



                gridMoveDirection = desiredDirection;
                gridPosition += gridMoveDirection;

                MoveSnake();
            }
        }
    }

    private void checkInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && gridMoveDirection.y != -moveSpace)
        {
            desiredDirection = Vector2.up * moveSpace;

            return;
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow) && gridMoveDirection.y != moveSpace)
        {
            desiredDirection = Vector2.down * moveSpace;

            return;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) && gridMoveDirection.x != -moveSpace)
        {
            desiredDirection = Vector2.right * moveSpace;

            return;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && gridMoveDirection.x != moveSpace)
        {
            desiredDirection = Vector2.left * moveSpace;

            return;
        }


    }

    private void MoveSnake()
    {
        linkedList.MoveSnakeManager(gridPosition);
        if (maxBodyCount != 0 && gridMoveDirection != Vector2.zero)
        {
            GrowSnake();
            return;
        }

    }

    public void IncreaseBodyCount()
    {
        maxBodyCount++;
    }


}

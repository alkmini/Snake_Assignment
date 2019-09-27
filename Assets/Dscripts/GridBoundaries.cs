using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GridBoundaries : MonoBehaviour
{
    [SerializeField] private UnityEvent KS;
    public float xLeft, xRight, yDown, yUp;
    Snake snake;

    private void Awake()
    {
        snake = GetComponent<Snake>();
    }

    // Start is called before the first frame update
    void Update()
    {

       
        if (snake.objMainHead.transform.position.x <= xLeft)
        {
            snake.objMainHead.transform.position = new Vector2(xRight, snake.objMainHead.transform.position.y);
            KS.Invoke();
        }
        if (snake.objMainHead.transform.position.x >= xRight)
        {
            snake.objMainHead.transform.position = new Vector2(xLeft, snake.objMainHead.transform.position.y);
            KS.Invoke();
        }
        if (snake.objMainHead.transform.position.y <= yDown)
        {
            snake.objMainHead.transform.position = new Vector2(yDown, snake.objMainHead.transform.position.x);
            KS.Invoke();
        }
        if (snake.objMainHead.transform.position.y >= yUp)
        {
            snake.objMainHead.transform.position = new Vector2(yUp, snake.objMainHead.transform.position.x);
            KS.Invoke();
        }
    }



    
}

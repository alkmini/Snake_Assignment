using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Events;

public class Mouse : MonoBehaviour
{
    [SerializeField] private UnityEvent EatApple;

    private int mouseX, mouseY;
    private Snake snakescr;

    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        snakescr = GameObject.Find("SnakeParent").GetComponent<Snake>();
        Assert.IsNotNull(snakescr, "could not find the snake");

        spriteRenderer = GetComponent<SpriteRenderer>();
        Assert.IsNotNull(spriteRenderer, "could not find the sprite Renderer Component");

        boxCollider = GetComponent<BoxCollider2D>();
        Assert.IsNotNull(boxCollider, "could not find the Box Collider2D");
     
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //collision.gameObject.SetActive(false);
            //we have collided with mouse
            //Snake.maxBodyCount++;
            //gameObject.SetActive(false);

            EatApple.Invoke();

            spriteRenderer.enabled = false;
            boxCollider.enabled = false;
            print(collision.name);
            //collision.gameObject.transform.parent.GetComponent<Snake>().IncreaseBodyCount();
            snakescr.IncreaseBodyCount();


            Debug.Log("player found");

            RandomMousePosition();
            spriteRenderer.enabled = true;
            boxCollider.enabled = true;
        }
        
        
        
    }

    private void RandomMousePosition()
    {
        Vector3 tempPos;
        do
        {
            mouseY = Random.Range(0, 10);
            mouseX = Random.Range(-15, 35);
            tempPos = new Vector3(mouseX, mouseY, 0);
        } while (snakescr.linkedList.AppleOverlapping(tempPos));

        Debug.Log("REACTIVATE");
        transform.position = tempPos;
        spriteRenderer.enabled = true;
        boxCollider.enabled = true;

    }
}

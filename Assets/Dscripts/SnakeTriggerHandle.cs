using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTriggerHandle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (gameObject.transform.parent)
            {
                gameObject.transform.parent.GetComponent<Bodies>().TriggerBodies();
            }
        }
    }

}

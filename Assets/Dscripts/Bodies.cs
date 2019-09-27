using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bodies : MonoBehaviour
{
    [SerializeField] private UnityEvent KS;
    private BoxCollider2D boxCollider;

   public void TriggerBodies()
    {
        KS.Invoke();
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LinkedListTest
{
    public Node first = null;

    Snake snake = GameObject.FindGameObjectWithTag("SnakeParent").GetComponent<Snake>();

   

    public class Node
    {
        public GameObject snakeBody;
        public Node next;
        internal Vector3 lastPosition = Vector3.zero;


      

        public Node(GameObject obj) // public Node(int d)
        {
          
            next = null;
            snakeBody = obj; //data = d;



        }
    
    }

    internal void PushFront(GameObject new_snake)
    {
        Node node = new Node(new_snake);
        node.next = first;
        first = node;
        Debug.Log("You found it");
    }

    internal void PushBack(Node node, GameObject new_snake)
    {
        Node new_node = new Node(new_snake);
        if (first == null)
        {
            first = new_node;
            return;
        }
        
        
        Node lastNode = GetLastNode();
        lastNode.next = new_node;
    }

    internal void PushBack(GameObject obj)
    {
        if (first == null)
        {
            first = new Node(obj);
        }
        else 
        {
            Node temp = GetLastNode();
            temp.next = new Node(obj);
        }
    }

    internal Node GetLastNode()
    {
        Node temp = first;
        while (temp.next != null)
        {
            temp = temp.next;
        }
        return temp;
    }

    internal void InsertAfter(Node prev_node, GameObject new_snake)
    {
        if (prev_node == null)
        {
            Console.WriteLine("The given previous node cannot be null");
            return;
        }
        Node new_node = new Node(new_snake);
        new_node.next = prev_node.next;
        prev_node.next = new_node;
    }

    public void Remove(Node node)
    {
        Node previous = null;
        Node current = first;
        while (current != node)
        {
            previous = current;
            current = current.next;
        }
        previous.next = current.next;
    }

    public int Count()
    {
        int count = 0;
        Node node = first;
        while(node != null && node.next != null)
        {
            node = node.next;
            count++;
        }
        return count;
    }

    public void MoveSnakeManager(Vector3 dire)
    { 
        Node current = first;
        Node previous = null;

        current.lastPosition = current.snakeBody.transform.position;

        current.snakeBody.transform.position = dire;

        while (current.next != null)
        {
            previous = current;
            current = current.next;
            current.lastPosition = current.snakeBody.transform.position;
            current.snakeBody.transform.position = previous.lastPosition;

        }
    }

    public bool AppleOverlapping(Vector3 mousePos)
    {
        Node temp = first;
        while(temp != null)
        {
            if (mousePos == temp.snakeBody.transform.position)
            {
                return true;
            }
                temp = temp.next;
        }
        return false;
    }

}

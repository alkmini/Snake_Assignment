using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Assertions;


public class GameHandler : MonoBehaviour
{

    [SerializeField] private int score = 0;

    [SerializeField] private Text scoreBoard = null;

    public void KS()
    {
        SceneManager.LoadScene(1);
    }

    public void IncrementScore()
    {
        score++;
        scoreBoard.text = "Score: " + score;
    }

    private void Awake()
    {
        Assert.IsNotNull(scoreBoard);
    }

}

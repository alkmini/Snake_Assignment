using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitScene()
    {
#if UNITY_EDITOR 
        UnityEditor.EditorApplication.isPlaying = false;

#else
        Application.Quit();

#endif
    }
}

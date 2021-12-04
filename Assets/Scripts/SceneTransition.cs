using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string Scene;

public void playGame()
    {
        Cursor.visible = false;
        SceneManager.LoadScene(Scene);
    }

    public void playTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
}


﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string Scene;

public void playGame()
    {
        SceneManager.LoadScene(Scene);
    }
}


﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string SceneName;
    // Start is called before the first frame update
    public void LoadSceneWithName ()
    {
        SceneManager.LoadScene (SceneName);
    }
}
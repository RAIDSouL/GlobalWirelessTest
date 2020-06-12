using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxStatus : MonoBehaviour
{
    public GameController GameController;
    public bool isTrue;

    void Start()
    {
        GameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
    public void Setfalse()
    {
        isTrue = false;
    }

    public void Settrue()
    {
        isTrue = true;
    }

    public void SendAns()
    {
        if (isTrue)
        {
            GameController.Correct();
        }
        else
        {
            GameController.Wrong();
        }
    }
}
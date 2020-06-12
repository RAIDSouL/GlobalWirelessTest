using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LoadScore : MonoBehaviour
{
    int score;
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start ()
    {
        score = PlayerPrefs.GetInt ("score");
        scoreText.text = score.ToString ();
    }

    // Update is called once per frame

}
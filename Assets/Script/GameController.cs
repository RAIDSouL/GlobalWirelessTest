using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public TextMeshProUGUI first_number;
    public TextMeshProUGUI second_number;
    public TextMeshProUGUI ShowTimer;
    public TextMeshProUGUI operatorText;
    public TextMeshProUGUI scoreText;
    public BoxStatus[] btn;
    public TextMeshProUGUI[] btntext;
    public AudioSource sound;
    public AudioClip correct;
    public AudioClip wrong;
    public int[] boxValue;
    int score;

    int firstnum;
    int secondnum;
    int operatorNumber;
    int ans;
    int fakeans;

    float Timer;
    int question = 1;
    int randombtn;

    // Start is called before the first frame update

    void Start()
    {
        ResetQuestion();
    }

    void Update()
    {
        Timer -= Time.deltaTime;
        ShowTimer.text = Timer.ToString("00");
        if (Timer < 0)
        {
            ResetQuestion();
        }
    }

    void ResetQuestion()
    {
        if (question > 10)
        {
            PlayerPrefs.SetInt("score", score);
            SceneManager.LoadScene("End");
        }
        else
        {
            foreach (var item in btntext)
            {
                item.text = "";
            }
            boxValue = new int[4];
            question += 1;
            Timer = 20f;
            operatorNumber = Random.Range(0, 4);
            if (operatorNumber == 3)
            {
                do
                {
                    firstnum = Random.Range(10, 100);
                    secondnum = Random.Range(2, 20);
                    // print ("MOD : " + firstnum / secondnum);
                }
                while (firstnum % secondnum != 0);
            }
            else
            {
                firstnum = Random.Range(10, 100);
                secondnum = Random.Range(10, 100);
            }
            Showoperator();
            first_number.text = firstnum.ToString();
            second_number.text = secondnum.ToString();
            SetAnsBox();
            SetFakeBox();
        }
    }

    void Showoperator()
    {
        if (operatorNumber == 0)
        {
            operatorText.text = "+";
        }
        else if (operatorNumber == 1)
        {
            operatorText.text = "-";
        }
        else if (operatorNumber == 2)
        {
            operatorText.text = "x";
        }
        else
            operatorText.text = "÷";
    }

    void SetAnsBox()
    {
        foreach (var item in btn)
        {
            item.Setfalse();
        }
        randombtn = Random.Range(0, 4);
        btn[randombtn].Settrue();
        FindAns();
    }

    public void Correct()
    {
        sound.PlayOneShot(correct);
        score += 1;
        scoreText.text = score.ToString();
        ResetQuestion();
    }

    public void Wrong()
    {
        sound.PlayOneShot(wrong);
        score -= 1;
        scoreText.text = score.ToString();
        ResetQuestion();
    }

    void FindAns()
    {
        //Set Correct Ans to box
        if (operatorNumber == 0)
        {
            // operatorText.text = "+";
            ans = firstnum + secondnum;
            boxValue[randombtn] = ans;
        }
        else if (operatorNumber == 1)
        {
            // operatorText.text = "-";
            ans = firstnum - secondnum;
            boxValue[randombtn] = ans;
        }
        else if (operatorNumber == 2)
        {
            // operatorText.text = "x";
            ans = firstnum * secondnum;
            boxValue[randombtn] = ans;
        }
        else
        {
            // operatorText.text = "÷";
            ans = firstnum / secondnum;
            boxValue[randombtn] = ans;
        }
    }

    void SetFakeBox()
    {
        for (int i = 0; i < boxValue.Length; i++)
        {
            if (i == randombtn)
            {
                continue;
            }
            else
            {
                boxValue[i] = boxValue[randombtn] + Random.Range(-10, 10);
                foreach (var box in boxValue)
                {
                    do
                    {
                        boxValue[i] = boxValue[i] + Random.Range(-20, 20);
                    } while (boxValue[i] == box);
                }
            }
        }
        Setbtntext(boxValue);
    }

    void Setbtntext(int[] boxValue)
    {
        for (int i = 0; i < boxValue.Length; i++)
        {
            btntext[i].text = boxValue[i].ToString();
        }
    }
}
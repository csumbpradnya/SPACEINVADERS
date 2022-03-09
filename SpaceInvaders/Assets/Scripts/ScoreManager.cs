using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class ScoreManager : MonoBehaviour
{
    private int highScore;
    private string Key = "key";
    private int scores;
    public TMP_Text score;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt(Key,0); 
        score.SetText("Score: " + "000" + scores + "\n" +  "  HighScore: " + highScore);
    }

    public void scoreEnemy1()
    {
        scores += 100;
    }
    public void scoreEnemy2()
    {
        scores += 150;
    }
    public void scoreEnemy3()
    {
        scores += 200;
    }

    public void scoreEnemy4()
    {
        scores += 500;
    }
    public void HighScore()
    {
        if(scores>highScore){
            PlayerPrefs.SetInt(Key, scores);
            PlayerPrefs.Save();
        }
        if (scores < 1000)
        {
            score.SetText("Score: " + "0" + scores + "\n" +  "  HighScore: " + highScore);
        }
        else if (scores > 1000)
        {
            score.SetText("Score: " + scores + "\n" +  "  HighScore: " + highScore);
        }
    }
}

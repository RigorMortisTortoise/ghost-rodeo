using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI timeText;

    private void Awake()
    {
        instance = this;
        //UpdateTime(1, 0);
        //The timer setting that appears when the game starts, in this case, 30 seconds.
        UpdateTime(0,30);
    }

    public void UpdateTime(int mins, int secs)
    {
        timeText.text = mins.ToString("D2") + ":" + secs.ToString("D2");
    }

    public void UpdateUI(int score, int scoreToReach)
    {
        scoreText.text = "Score: " + score + "/" + scoreToReach;

    }



}

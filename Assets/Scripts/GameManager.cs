using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    //TIMER
    int playtime = 30;
    int seconds, minutes;

    //LEVEL AND SCORE
    public static int currentLevel = 1;
    int baseScore = 100;
    int scoreToReach;

    bool hasLost;

    [HideInInspector]public bool countDownDone;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(hasLost == true)
        {
            hasLost = false;
            ScoreManager.ResetScore();
            currentLevel = 1;
        }

        scoreToReach = currentLevel * (baseScore * currentLevel);
        ScoreManager.scoreToReach = scoreToReach;
        UIManager.instance.UpdateUI(ScoreManager.ReadScore(), scoreToReach);
        //countDownDone = false;
        StartCoroutine("PlayTimer");
        
    }


    IEnumerator PlayTimer()
    {
        while(playtime > 0)
        {
            yield return new WaitForSeconds(1);
            playtime--;
            seconds = playtime % 60;
            minutes = playtime / 60 % 60;
            //update UI
            UIManager.instance.UpdateTime(minutes, seconds);

        }

        Debug.Log("Time has ended");
        CheckForWin();
       

    }

        void CheckForWin()
    {
            if(ScoreManager.ReadScore() >= scoreToReach)
        {
            Debug.Log("You won the level");
            currentLevel++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
            else
        {
            hasLost = true;
            ScoreHolder.score = ScoreManager.ReadScore();
            ScoreHolder.level = currentLevel;
            SceneManager.LoadScene("GameOver");
            //Debug.Log("Game Over");
        }
    }
}

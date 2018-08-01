using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIMANAGER : MonoBehaviour {
    public Text text;
    public int ScoreNum;

    public Text score;
    public Text BestT;

    public static int BestScore=0;
    public void AddScore()
    {
        ScoreNum += 100;
        text.text = ScoreNum.ToString();
        if (BestScore <= ScoreNum)
            BestScore = ScoreNum;
    }

    public void ShowResult()
    {
        score.text = "Score : " + text.text;
        BestT.text = "BestScore : " + BestScore.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene("ingame");
    }
}

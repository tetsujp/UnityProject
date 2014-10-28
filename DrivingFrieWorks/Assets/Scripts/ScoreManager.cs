using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

    double[] score{get;set;}
    double maxScore;
    double nowScore;
    public double percentScore{get;set;}
    readonly int[] SCORE_POINT={ 3, 2, 1,0 };//スコア基礎点
	// Use this for initialization
	void Start () {
	}
    public void Initalize(int countNum)
    {
        score = new double[(int)JudgeKind.NUM];
        maxScore = 0;
        nowScore = 0;
        percentScore = 0;
        SetMaxScore(countNum);
    }
	// Update is called once per frame
	void Update () {
	
	}

    public void AddScore(JudgeKind e)
    {
        score[(int)e]++;
        nowScore += SCORE_POINT[(int)e];
        percentScore = nowScore * 100 / maxScore;
    }

    void SetMaxScore(int countNum)
    {
        maxScore = countNum * (int)SCORE_POINT[0];
    }
    public double GetJudgeScore(JudgeKind k)
    {
        return score[(int)k];
    }


}

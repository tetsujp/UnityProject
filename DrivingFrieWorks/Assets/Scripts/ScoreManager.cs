using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

    double[] score{get;set;}
    double maxScore;
    double nowScore;
    public double percentScore{get;set;}
    public int comboCount { get; set; }
    readonly int[] SCORE_POINT={ 3, 2, 1,0 };//スコア基礎点
    Transform judge;
    Transform combo;
    GameObject canvas;
    Transform scoreCanv;
	// Use this for initialization
	void Start () {
        canvas = GameObject.FindGameObjectWithTag("ComboCanvas");
        judge = canvas.transform.FindChild("Judge");
        combo = canvas.transform.FindChild("Combo");
        judge.gameObject.SetActive(false);
        combo.gameObject.SetActive(false);
	}
    public void Initalize(int countNum)
    {
        Finalizer();
        scoreCanv = GameObject.FindGameObjectWithTag("ScoreCanvas").transform.FindChild("Score");
        SetMaxScore(countNum);
    }
    public void Finalizer()
    {
        score = new double[(int)JudgeKind.NUM];
        maxScore = 0;
        nowScore = 0;
        percentScore = 0;
        comboCount = 0;
    }
	// Update is called once per frame
	void Update () {
	
	}

    public void AddScore(JudgeKind e)
    {
        score[(int)e]++;

        judge.gameObject.SetActive(true);
        judge.GetComponent<Text>().text = e.ToString();
        judge.GetComponent<Animation>().Play();
        if (e != JudgeKind.Miss)
        {
            comboCount++;
            combo.gameObject.SetActive(true);
            combo.GetComponent<Text>().text = comboCount.ToString();
            combo.GetComponent<Animation>().Play();
            scoreCanv.gameObject.GetComponent<Animation>().Play();
        }
        else
        {
            comboCount = 0;
        }
        nowScore += SCORE_POINT[(int)e];
        percentScore = nowScore * 100 / maxScore;
        scoreCanv.gameObject.GetComponent<Text>().text = percentScore >= 100 ? "100" : percentScore.ToString("F1");
        //SetScore();
    }

    void SetMaxScore(int countNum)
    {
        maxScore = countNum * (int)SCORE_POINT[0];
    }
    public double GetJudgeScore(JudgeKind k)
    {
        return score[(int)k];
    }
    void SetScore()
    {
        scoreCanv.gameObject.GetComponent<Text>().text = percentScore >= 100 ? "100" : percentScore.ToString("F1");
        scoreCanv.gameObject.GetComponent<Animation>().Play();
    }
}

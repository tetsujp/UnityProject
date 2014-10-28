using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//ライン毎のノートのリスト
public class LineNote : MonoBehaviour
{
    //Noteのリスト
    List<Note> noteList=new List<Note>();
    int displayNoteNumber=0;//何番目のノートまで出たか
    int hitNoteNumber = 0;//何番目のノートの判定が終了したか
    public LineName lineName{get;set;}

    ScoreManager scoreManager;

    public readonly float[] JUDGE_TIME = { 0.07f, 0.12f, 0.2f };//判定時間
	// Use this for initialization
	void Start ()
	{
        scoreManager = GameObject.FindGameObjectWithTag("ScoreManager").GetComponent<ScoreManager>();
        //noteList = new List<Note>();
        
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
    public void Add(Note n)
    {
        noteList.Add(n);
    }

    //画面に出す判定
    public void UpdateDisplay(float startTime)
    {
        float nowTime = Time.time-startTime;
        bool endLoopFlag = false;

        //画面に出す
        while (endLoopFlag == false)
        {
                //画面に出す
                if (noteList.Count > displayNoteNumber)
                {
                    if (noteList[displayNoteNumber].apperTime < nowTime)
                    {
                        //ノートのアクティブ化
                        noteList[displayNoteNumber].gameObject.SetActive(true);
                        displayNoteNumber++;
                        continue;
                    }
                }
                endLoopFlag = true;
            }
        }
    public void CheckHit(float startTime)
    {
        float nowTime = Time.time - startTime;
        if (hitNoteNumber >= noteList.Count) return ;
        float absTime=Mathf.Abs((float)noteList[hitNoteNumber].judgeTime - nowTime);
        //入力時
        if (Input.GetButtonDown(lineName.ToString()))
        {
            //just
            if (absTime < JUDGE_TIME[(int)JudgeKind.Just])
            {
                noteList[hitNoteNumber].Hit(JudgeKind.Just);
                scoreManager.AddScore(JudgeKind.Just);
                hitNoteNumber++;
            }
                //great
            else if (absTime < JUDGE_TIME[(int)JudgeKind.Great])
            {
                noteList[hitNoteNumber].Hit(JudgeKind.Great);
                scoreManager.AddScore(JudgeKind.Great);
                hitNoteNumber++;

            }
                //good
            else if (absTime < JUDGE_TIME[(int)JudgeKind.Good])
            {
                noteList[hitNoteNumber].Hit(JudgeKind.Good);
                scoreManager.AddScore(JudgeKind.Good);
                hitNoteNumber++;
            }
        }
        //miss
        else if (nowTime - noteList[hitNoteNumber].judgeTime > JUDGE_TIME[(int)JudgeKind.Good])
        {
            noteList[hitNoteNumber].Hit(JudgeKind.Miss);
            hitNoteNumber++;
            scoreManager.AddScore(JudgeKind.Miss);
        }
        
    }
}
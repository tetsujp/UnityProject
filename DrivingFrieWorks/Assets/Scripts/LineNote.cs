using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//ライン毎のノートのリスト
public enum e_lineName { left, leftCenter, center, rightCenter, right }
public enum e_judgeKind{just,great,good,miss}
public class LineNote : MonoBehaviour
{
    //Noteのリスト
    List<Note> noteList=new List<Note>();
    int displayNoteNumber=0;//何番目のノートまで出たか
    int hitNoteNumber = 0;//何番目のノートの判定が終了したか
    public e_lineName lineName{get;set;}
    

    readonly float[] JUDGE_TIME = { 0.2f, 0.3f, 0.4f };//判定時間
	// Use this for initialization
	void Start ()
	{

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
            if (absTime < JUDGE_TIME[(int)e_judgeKind.just])
            {
                noteList[hitNoteNumber].Hit(e_judgeKind.just);
                hitNoteNumber++;
            }
                //great
            else if (absTime < JUDGE_TIME[(int)e_judgeKind.great])
            {
                noteList[hitNoteNumber].Hit(e_judgeKind.great);
                hitNoteNumber++;

            }
                //good
            else if (absTime < JUDGE_TIME[(int)e_judgeKind.good])
            {
                noteList[hitNoteNumber].Hit(e_judgeKind.good);
                hitNoteNumber++;
            }
        }
        //miss
        else if (nowTime - noteList[hitNoteNumber].judgeTime > JUDGE_TIME[(int)e_judgeKind.good])
        {
            hitNoteNumber++;
        }
        
    }
}
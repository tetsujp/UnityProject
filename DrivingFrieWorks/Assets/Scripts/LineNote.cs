using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
//ライン毎のノートのリスト
public class LineNote : MonoBehaviour
{
    //Noteのリスト
    List<Note> noteList=new List<Note>();
    int displayNoteNumber=0;//何番目のノートまで出たか
    int hitNoteNumber = 0;//何番目のノートの判定が終了したか
    public LineName lineName{get;set;}
    public Transform[] pushPosition;
    public GameObject prefabPushNote;//地面に出すエフェクト
    ScoreManager scoreManager;

    public readonly float[] JUDGE_TIME = { 0.06f, 0.10f, 0.2f };//判定時間
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
    public void DestroyNote()
    {
        foreach (var note in noteList)
        {
            if (note != null)
            {
                if (note.gameObject.activeSelf == false)
                {
                    Destroy(note.gameObject);
                }
            }
        }
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
        float judge_now_time=((float)noteList[hitNoteNumber].judgeTime - nowTime);
        //judgeTimeを過ぎていた場合、止める
        if (judge_now_time < 0)
        {
            noteList[hitNoteNumber].StopMove();
        }
        //Justに入ったらエフェクト
        if (judge_now_time < JUDGE_TIME[(int)JudgeKind.Just])
        {
            noteList[hitNoteNumber].StartJustAnimation();
        }
        float absTime=Mathf.Abs(judge_now_time);
        //入力時

        if (Input.GetButtonDown(lineName.ToString()))
        {
            //下の花火を出す
            Instantiate(prefabPushNote, pushPosition[(int)lineName].position, Quaternion.identity);

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
    public void SortList()
    {
        noteList.Sort((a, b) => (int)(a.apperTime - b.apperTime));
    }
}
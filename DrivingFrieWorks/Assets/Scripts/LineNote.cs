using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//ライン毎のノートのリスト
public class LineNote : MonoBehaviour
{

    List<Note> noteList;
    int displayNoteNumber=0;//何番目のノートまで出たか
	// Use this for initialization
	void Start ()
	{
        noteList = new List<Note>();
        
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
    public void UpdateDistplay(float startTime){
        float nowTime = Time.time-startTime;
        bool endLoopFlag=false;
        while (endLoopFlag == false)
        {
            //画面に出す
            if (noteList.Count < displayNoteNumber)
            {
                if (noteList[displayNoteNumber].apperTime > nowTime)
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
}
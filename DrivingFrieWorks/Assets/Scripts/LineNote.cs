using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//ライン毎のノートのリスト
public class LineNote : MonoBehaviour
{
    //Noteのリスト
    List<Note> noteList=new List<Note>();
    int displayNoteNumber=0;//何番目のノートまで出たか
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
    public void Distplay(float startTime){
        float nowTime = Time.time-startTime;
        //画面に出す
        if (noteList[displayNoteNumber].GetApperTime() > nowTime)
        {
<<<<<<< HEAD
            //画面に出す
            if (noteList.Count < displayNoteNumber)
            {

                if (noteList[displayNoteNumber].apperTime> nowTime)
                {
                    //ノートのアクティブ化
                    noteList[displayNoteNumber].gameObject.SetActive(true);
                    displayNoteNumber++;
                    continue;
                }
            }
            endLoopFlag = true;
=======
            //noteList[displayNoteNumber].SetActive(true);
>>>>>>> parent of 8734fd1... GameObjectに変更前
        }


    }
}
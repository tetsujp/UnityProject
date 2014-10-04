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
    public void Distplay(float startTime){
        float nowTime = Time.time-startTime;
        //画面に出す
        if (noteList[displayNoteNumber].GetApperTime() > nowTime)
        {
            //noteList[displayNoteNumber].SetActive(true);
        }


    }
}
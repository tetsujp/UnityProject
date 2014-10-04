using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class NoteOwner : MonoBehaviour
{

    List<Note>[] noteList;
    int[] displayNoteNumber;//何番目のノートまで出たか

	// Use this for initialization
	void Start ()
	{
        //ノートデータの取得
        noteList = GameObject.FindWithTag("LoadMusic").GetComponent<LoadPlayMusic>().GetList();
        //初期化
        displayNoteNumber=new int[Global.MAX_LINE];
        Array.Clear(displayNoteNumber,0,displayNoteNumber.Length);


	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

    //画面に内に出す判定
void noteDisplay(){

	float nowTime=Time.time;

	for(var i=0;i<Global.MAX_LINE;i++){

	//画面内に表示するかの判定

        Note n = noteList[i][displayNoteNumber[i]];

		//Note pop=*(list_note[i]).begin();

		//スタートする時間と現在時間を比較
		//もし出るならfield_timeに残り表示時間

//        int Note::Judge_Start_Time(int time){
//    field_time=start_time-time;
//    return field_time;

//}
		if(pop.Judge_Start_Time(HIT_LINE/(bpm*highspeed)+delay)<=(now_time-start_time)){
			//入れる作業
			//list_field_note[i].push_back(pop);

			//元リストの先頭削除
			//list_note[i].pop_front();
			//再びリストを見る
			//1フレーム内で高密度縦連用
			i--;
		}
	}
}
}